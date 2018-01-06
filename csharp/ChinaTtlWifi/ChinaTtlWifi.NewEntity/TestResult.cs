using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using Wims.Common.Entity;
namespace ChinaTtlWifi.NewEntity
{
    [Serializable]
    public class TestResult : BaseEntity
    {
        public string ProjectId { get; set; }

        public string CaseId { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }
    
        public bool IsPass { get; set; }
        public List<double> Result { get; set; }
    }
}
