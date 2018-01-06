using ChinaTtlWifi.Entity;
using Wims.Common.MongoDBUtil;
 

namespace ChinaTtlWifi.Bll
{
    public class EutBll : MongoUtil<Eut>
    {
        private EutBll() { }

        private static EutBll inst;
        public static EutBll GetInst()
        {
            if (null == inst)
                inst = new EutBll();
            return inst;
        }

    }
}
