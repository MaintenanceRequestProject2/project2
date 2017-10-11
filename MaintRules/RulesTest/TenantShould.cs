using MaintRules.Domain;
using Newtonsoft.Json;
using System;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace MaintRules.RulesTest
{
    public class TenantShould
    {
        private readonly ITestOutputHelper _output;
        private Repair rep;
        private Tenant ten;

        public TenantShould(ITestOutputHelper Output)
        {
            ten = new Tenant(1, "this", "guy", "em@il.com", 555010101, "no", "Tenant", true);
            Output = _output;
        }


        [Fact]
        public void TestCR() 
        {

            var testenant = new Tenant(1, "guy@guy.guy");

            var testrep = testenant.CreateRepair("I got issue", "many issue");

            Assert.Equal(testrep.Tenant_ID, 1);
            Assert.Equal(testrep.Issue, "I got issue");
            Assert.Equal(testrep.IssueDetails, "many issue");

            testenant.ActiveFlag = false;

            Assert.Equal(testenant.CreateRepair("dummy", "dummy"), null);
        }


    }
}
