using ChinaTtlWifi.Entity;
using Wims.Common.MongoDBUtil;

namespace ChinaTtlWifi.Bll
{
    public class TaskBll : MongoUtil<Task>
    {
        private TaskBll() { }

        private static TaskBll inst;
        public static TaskBll GetInst()
        {
            if (null == inst)
                inst = new TaskBll();
            return inst;
        }

    }
}
