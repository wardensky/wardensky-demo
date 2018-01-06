using ChinaTtlWifi.NewEntity;
using System;
using System.Collections.Generic;
using Wims.Common.MongoDBUtil;

namespace ChinaTtlWifi.NewBll
{
    public class TestResultBll : MongoUtil<TestResult>
    {
        private static TestResultBll inst;


        public static TestResultBll GetInst()
        {

            if (inst == null)
                inst = new TestResultBll();
            return inst;
        }
        private TestResultBll() { }

        public void Write(string projectId, string caseId, bool isPass, List<double> data)
        {
            TestResult result = new TestResult();
            result.ProjectId = projectId;
            result.IsPass = isPass;
            result.Result = data;
            result.CaseId = caseId;
            result.CreateTime = DateTime.Now;
            this.Insert(result);
        }
    }
}
