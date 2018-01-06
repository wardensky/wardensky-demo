using System;
using System.Collections.Generic;

namespace ChinaTtlWifi.NewEntity
{
    /// <summary>
    /// 测试床，这个概念要去掉
    /// chzhao
    /// </summary>
    [Serializable]
    public class TestBed
    {
        public string Desc { get; set; }

        public string Remark { get; set; }

        public string Name { get; set; }

        public List<TestDevice> TestDeviceList { get; set; }
    }
}
