namespace Wims.Common.Mongo
{
    using System.Xml.Serialization;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    //======================================================================
    //
    //        All rights reserved
    //
    //        filename :MongoDbEntity
    //        description :
    //
    //        created by lizhao@wisdombud.com at  2014-08-01 9:02:38
    //
    //======================================================================
    [Serializable]
    public abstract class MongoDbEntity
    {
        #region Public Properties

        [BsonRepresentation(BsonType.ObjectId)]
        public string MongoId { get; set; }


        public string Id
        {
            get;
            set;
            //get { return _id; }
            //set { value = _id; }
        }

        //private string _id = Guid.NewGuid().ToString();
        #endregion
    }
}