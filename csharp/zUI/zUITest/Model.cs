using System;
using System.ComponentModel;

namespace zUITest
{
    [Serializable]
    public class Model
    {
        public string Id { get; set; }
        [Description("名字")]
        public string Name { get; set; }
        [Description("城市")]
        public string City { get; set; }

        [Description("地址1")]
        public string Address1 { get; set; }
        [Description("地址2")]
        public string Address2 { get; set; }
        [Description("地址3")]
        public string Address3 { get; set; }
    }
}
