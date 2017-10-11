using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaintAPI.Models;
using MaintRules.Domain;
using System.Net.Http;

namespace MaintAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]

    public class RepairsController : Controller
    {
        private DBHelper _dbh = new DBHelper();

        public string Error(Exception e)
        {
            return e.Message;
        }

        [HttpGet("{id}")]
        public RepairModel GetRepair(int id)
        {
            return _dbh.DBGetRepair(id);
        }

        [HttpPost]
        public RepairModel CreateRepair([FromBody]DataModels.CreateRepairModel crm)
        {
            var t = _dbh.DBGetTenant(crm.Tenant_ID);
            t.Transfer();
            var tl = t.TenantLogic;
            var rm = _dbh.DBGetRepair(crm.ID).R;

            try
            {
                var update = tl.CreateRepair(crm.Issue, crm.IssueDetails);
                var result = new RepairModel(update);
                _dbh.DBSaveRepairChanges(result);
                return result;
            }
            catch (Exception e)
            {
                Error(e);
                return new RepairModel(rm);
            }
        }


        [HttpGet]
        public List<RepairModel> GetAllRepairs()
        {
            return _dbh.DBGetAllRepairs();
        }

    }
}
