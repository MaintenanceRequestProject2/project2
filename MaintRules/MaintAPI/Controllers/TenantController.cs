using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaintAPI.Models;
using MaintRules.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaintAPI.Controllers
{

    [Produces("application/json")]
    [Route("api/Tenants/[action]")]

    public class TenantController : Controller
    {

        private DBHelper _dbh = new DBHelper();

        // GET: api/values

        public string Error(Exception e)
        {
            return e.Message;
        }

        [HttpGet("{id}")]
        public TenantModel GetTenant(int id)
        {
            return _dbh.DBGetTenant(id);
        }

        [HttpGet("{email}")]
        public TenantModel GetUserName(string email)
        {
            return _dbh.DBGetTenant(email);
        }

        [HttpGet]
        public List<TenantModel> GetAllTenant()
        {
            return _dbh.DBGetAllTenant();
        }

        [HttpPost]
        //expects form data with 
        //Username
        //Password
        public TenantModel RegisterTenant([FromBody]TenantModel t)
        {
            try
            {
                var res = _dbh.DBCreateTenant(t);
                return res;
            }
            catch (Exception e)
            {
                Error(e);
                return null;
            }
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

    }
}