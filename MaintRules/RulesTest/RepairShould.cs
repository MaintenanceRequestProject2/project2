using MaintRules.Domain;
using Newtonsoft.Json;
using System;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace MaintRules.RulesTest
{
    public class RepairShould
    {
        private readonly ITestOutputHelper _output;
        private Repair rep;

        public RepairShould(ITestOutputHelper Output) {

            rep = new Repair(1, "Ceiling Fan", "It's dusty");
            Output = _output;
        }  

        [Fact]
        public void TestConstructor() 
        {
            Assert.True(rep.ActiveFlag);
        }

        [Fact]
        public void NewRepair() 
        {
            var RepTest = new Repair(2, 1, 1, 2330, "Ceiling Fan", "Dusty", "Open", true);

            RepTest.Complex_ID = 2331;

            Assert.Equal(RepTest.ID, 2);
            Assert.Equal(RepTest.Tenant_ID, 1);
            Assert.Equal(RepTest.Worker_ID, 1);
            Assert.Equal(RepTest.Complex_ID, 2331);
            Assert.Equal(RepTest.Issue, "Ceiling Fan");
            Assert.Equal(RepTest.IssueDetails, "Dusty");
            Assert.Equal(RepTest.Status, "Open");
            Assert.Equal(RepTest.ActiveFlag, true); 
        }

    }
}
