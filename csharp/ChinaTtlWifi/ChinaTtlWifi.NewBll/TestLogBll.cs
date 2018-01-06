using ChinaTtlWifi.NewEntity;
using System;
using Wims.Common.MongoDBUtil;

namespace ChinaTtlWifi.NewBll
{
    public class TestLogBll : MongoUtil<TestLog>
    {
        private static TestLogBll inst;


        public static TestLogBll GetInst()
        {
            if (inst == null)
                inst = new TestLogBll();
            return inst;
        }
        private TestLogBll() { }

        public void Write(string projectId, string content,string caseId)
        {
            TestLog log = new TestLog();
            log.ProjectId = projectId;
            log.Content = content;
            log.CaseId = caseId;
            log.CreateTime = DateTime.Now;
            log.Level = "INFO";
            this.Insert(log);
        }
    }
}
