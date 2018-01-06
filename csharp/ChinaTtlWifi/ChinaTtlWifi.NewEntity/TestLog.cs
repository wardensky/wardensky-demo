using MongoDB.Bson.Serialization.Attributes;
using System;
using Wims.Common.Entity;
namespace ChinaTtlWifi.NewEntity
{
    /// <summary>
    /// 这个概念要参考wifi联盟的测试软件
    /// </summary>
    [Serializable]
    public class TestLog : BaseEntity
    {
        public string ProjectId { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CaseId { get; set; }

        public string Author { get; set; }
        /// <summary>
        /// info error
        /// </summary>
        public string Level { get; set; }
        public string _class { get; set; }
    }
}
