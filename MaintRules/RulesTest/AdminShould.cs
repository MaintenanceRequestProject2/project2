﻿using MaintRules.Domain;
using Newtonsoft.Json;
using System;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace MaintRules.RulesTest
{
    public class AdminShould
    {
        private readonly ITestOutputHelper _output;
        private Repair rep;
        private Admin adm;


        public AdminShould(ITestOutputHelper Output)
        {
            adm = new Admin(1, "this", "guy", "thisguy@this.guy", 0000000000, "yes", "Worker");
            Output = _output;
        }

        [Fact]
        public void TestCR()
        {
            var testw1 = new Worker(1, "this", "guy", "thisguy@this.guy", 0000000000, "yes", "Worker");
            var testenant = new Tenant(1, "another", "guy", "em@il.com", 555010101, "no", "Tenant", true);

            var testrep = testw1.CreateRepair(testenant, "I got issue", "many issue");

            Assert.Equal(testrep.Tenant_ID, 1);
            Assert.Equal(testrep.Issue, "I got issue");
            Assert.Equal(testrep.IssueDetails, "many issue");

            testenant.ActiveFlag = false;

            Assert.Equal(testw1.CreateRepair(testenant, "dummy", "dummy"), null);
        }

        [Fact]
        public void TestAssign()
        {

            var adm1 = new Admin(1, "this", "guy", "thisguy@this.guy", 0000000, "yes", "Worker");
            var testw1 = new Worker(1, "that", "guy", "thatguy@that.guy", 555010101, "no", "Worker");
            var testenant = new Tenant(1, "another", "guy", "em@il.com", 555010101, "no", "Tenant", true);

            var testrep = testenant.CreateRepair("I got issue", "many issue");
            adm1.AssignToOther(testrep, testw1);

            Assert.Equal(testrep.Worker_ID, 1);

            Assert.Equal(testrep.Worker_ID, 2);

        }

        [Fact]
        public void testOpenClose()
        {
            var adm1 = new Admin(1, "this", "guy", "thisguy@this.guy", 0000000, "yes", "Worker");
            var testw1 = new Worker(1, "this", "guy", "thisguy@this.guy", 0000000, "yes", "Worker");
            var testenant = new Tenant(1, "another", "guy", "em@il.com", 555010101, "no", "Tenant", true);

            var testrep = testw1.CreateRepair(testenant, "I got issue", "many issue");

            adm1.CloseRepair(testrep);

            Assert.Equal(testrep.Status, "Closed");
            Assert.False(testrep.ActiveFlag);

            adm1.ReopenRepair(testrep);

            Assert.Equal(testrep.Status, "Reopened");
            Assert.True(testrep.ActiveFlag);
        }
    }
}
