using ChinaTtlWifi.NewEntity;
using Wims.Common;
using Wims.Common.MongoDBUtil;

namespace ChinaTtlWifi.NewBll
{
    public sealed class DbFactory
    {
   
        public static MongoUtil<Dut> DutBll = new MongoUtil<Dut>(GlobalValues.MONGO_URL);
        public static MongoUtil<Command> CommandBll = new MongoUtil<Command>(GlobalValues.MONGO_URL);
        public static MongoUtil<Step> StepBll = new MongoUtil<Step>(GlobalValues.MONGO_URL);
        public static MongoUtil<Project> ProjectBll = new MongoUtil<Project>(GlobalValues.MONGO_URL);
        public static MongoUtil<TestLog> TestLogBll = new MongoUtil<TestLog>(GlobalValues.MONGO_URL);
        public static MongoUtil<TestDevice> TestDeviceBll = new MongoUtil<TestDevice>(GlobalValues.MONGO_URL);
        public static MongoUtil<TestParams> TestParamsBll = new MongoUtil<TestParams>(GlobalValues.MONGO_URL);
        public static MongoUtil<TestParam> TestParamBll = new MongoUtil<TestParam>(GlobalValues.MONGO_URL);
        public static MongoUtil<TestCase> TestCaseBll = new MongoUtil<TestCase>(GlobalValues.MONGO_URL);
    }
}
