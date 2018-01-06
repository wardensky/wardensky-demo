using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using Wisdombud.Mongo;

namespace Wims.Common.Entity
{
    [Serializable]
    public class BaseEntity
    {
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string MongoId { get; set; }
    }

}
