using System.ComponentModel;
using Wims.Common.Entity;

namespace ChinaTtlWifi.Entity
{
    public class Eut : BaseEntity
    {
        public string Name { get; set; }

        /// <summary>
        /// 设备型号
        /// </summary>
        [Description("设备型号")]
        public string Model { get; set; }
        /// <summary>
        /// 生产厂商
        /// </summary>
        [Description("生产厂商")]
        public string Producer { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Description("地址")]
        public string Address { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [Description("联系人")]
        public string Contract { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Description("联系电话")]
        public string Mobile { get; set; }
    }
}
