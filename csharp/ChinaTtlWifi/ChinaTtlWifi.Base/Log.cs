using MongoDB.Bson.Serialization.Attributes;
using System;
using Wims.Common.Entity;

namespace ChinaTtlWifi.Base
{
    public class Log : BaseEntity
    {
        public string TaskId { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }
        public string Content { get; set; }

        public string Author { get; set; }
        /// <summary>
        /// info error
        /// </summary>
        public string Level { get; set; }
        public string _class { get; set; }
    }
}
