
using System;
using Wims.Common.Entity;
namespace ChinaTtlWifi.NewEntity
{
    [Serializable]
    public class TestParam : BaseEntity
    {

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
