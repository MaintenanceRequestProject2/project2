using MaintRules.Domain;
using MaintAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace MaintRules.RulesTest
{
    public class DbHelperShould
    {
        private readonly ITestOutputHelper _output;
        private RepairModel rmut;
        private Tenant tut;
        private Repair rut;
        private DBHelper dbh;
        private TenantModel tmut;

        public DbHelperShould(ITestOutputHelper Output)
        {
            _output = Output;
            tut = new Tenant(58, "this@guy.guy");
            tmut = new TenantModel()
            {
                TenantId = 1,
                Password = "whatpwd"
            };
            rut = new Repair(tut.TenantID, "spider", "many spider");
            rmut = new RepairModel(rut);
            dbh = new DBHelper();
        }

        [Fact]
        public void BeAbleToRetrieveATenantModelByID()
        {
            var tst = dbh.DBGetTenant(1);
            tst.Transfer();
            Assert.True(tst.TenantId == 1);
            Assert.True(tst.TenantLogic.First == "will");
        }

        [Fact]
        public void BeAbleToRetrieveARepairModelByID()
        {
            var id = dbh.DBCreateRepair(rmut).R.ID;
            var tst = dbh.DBGetRepair(id);
            Assert.NotNull(tst.R.Issue);
            Assert.IsType<Repair>(tst.R);
        }


        [Fact]
        public void CreateATenant()
        {
            var id = dbh.DBGetTenant("this@guy.guy").TenantId;
            dbh.DBDeleteTenant(id);
            dbh.DBCreateTenant(tmut);
            var actual = dbh.DBGetTenant("this@guy.guy");
            _output.WriteLine(actual.ToString());
            Assert.IsType<TenantModel>(actual);
            Assert.Equal("this@guy.guy", actual.Email);

        }

        [Fact]
        public void GetATenantByEmail()
        {
            var actual = dbh.DBGetTenant("this@guy.guy");
            Assert.Equal(actual.Email, "this@guy.guy");
        }


        [Fact]
        public void CheckIfEmailIsUnique()
        {
            var actual = dbh.CheckEmail("this@guy.guy");
            var actual2 = dbh.CheckEmail("HNNNNNG");
            Assert.False(actual);
            Assert.True(actual2);
        }


        [Fact]
private void SaveAnUpdatedRepair()
        {
            var get = dbh.DBGetRepair(1);
            get.R.Issue = "DBAPI needs to save issue changes";
            dbh.DBSaveRepairChanges(get);

            var result = dbh.DBGetRepair(1);
            Assert.Equal("DBAPI needs to save issue changes", result.R.Issue);
            result.R.Issue = "Ceiling Fan";
            dbh.DBSaveRepairChanges(result);
        }


    }
}