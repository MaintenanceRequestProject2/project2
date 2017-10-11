using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MaintAPI.Models
{

	public class DBHelper
	{
        private HttpClient _client = new HttpClient();
        private const string _api = "http://ec2-18-221-118-195.us-east-2.compute.amazonaws.com/pet-e/userui/api/";
        private const string AdminDir = "Admin/";
        private const string WorkerDir = "Workers/";
        private const string TenantDir = "Tenants/";
        private const string RepairDir = "Repairs/";

        public TenantModel DBGetTenant(int id)
        {
            var res = _client.GetAsync(_api + TenantDir + id).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<TenantModel>(ResObject);
            result.Transfer();
            return result;
        }

        public TenantModel DBGetTenant(string email)
        {
            var res = _client.GetAsync(_api + TenantDir + "GetTenant/" + email).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<TenantModel>(ResObject);
            result.Transfer();
            return result;
        }

        public List<TenantModel> DBGetAllTenant()
        {
            var res = _client.GetAsync(_api + TenantDir).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<List<TenantModel>>(ResObject);
            foreach (TenantModel u in result)
            {
                u.Transfer();
            }
            return result;
        }

        public bool CheckEmail(string email)
        {
            var cd = _client.GetAsync(_api + "Accounts/email/" + email).GetAwaiter().GetResult();
            var cds = cd.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<bool>(cds);
            return result;
        }

        public TenantModel DBCreateTenant(TenantModel t)
        {
            if (CheckEmail(t.Email))
            {
                var body = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
                var cd = _client.PostAsync(_api + TenantDir, body).GetAwaiter().GetResult();
                var result = DBGetTenant(t.Email);
                return result;
            }
            else
            {
                throw new Exception("Username is taken.");
            }
        }

        public void DBSaveTenantChanges(TenantModel t)
        {
            var body = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
            var cd = _client.PutAsync(_api + TenantDir, body);

        }

        public void DBDeleteTenant(int id)
        {
            _client.DeleteAsync(_api + TenantDir + id).GetAwaiter().GetResult();
        }

		public RepairModel DBGetRepair(int id)
		{
            var res = _client.GetAsync(_api + RepairDir + id).GetAwaiter().GetResult();
			var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			var result = JsonConvert.DeserializeObject<RepairModel>(ResObject);
			return result;
		}

        public List<RepairModel> DBGetAllRepairs()
		{
            var res = _client.GetAsync(_api + RepairDir).GetAwaiter().GetResult();
			var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<List<RepairModel>>(ResObject);
			return result;
		}

        public RepairModel DBCreateRepair(RepairModel rm)
		{
			var text = JsonConvert.SerializeObject(rm);
			var body = new StringContent(text, Encoding.UTF8, "application/json");
            var cd = _client.PostAsync(_api + RepairDir, body);
			string cds = cd.GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<RepairModel>(cds);
			return result;
		}

        public void DBSaveRepairChanges(RepairModel rm)
		{
			var body = new StringContent(JsonConvert.SerializeObject(rm), Encoding.UTF8, "application/json");
            var cd = _client.PutAsync(_api + RepairDir + rm.R.ID, body).GetAwaiter().GetResult();
		}


		public void DBDeleteOrder(int id)
		{
			_client.DeleteAsync(_api + "Repairs/" + id).GetAwaiter().GetResult();
		}
	}
}