namespace Wims.Common.Mongo
{
    using System.Collections.Generic;


    using MongoDB.Driver;

    //======================================================================
    //
    //        All rights reserved
    //
    //        filename :IMongoDbDao
    //        description :IMongoDbDao MongoDbDao接口
    //
    //        created by lizhao@wisdombud.com at  2014-08-01 9:06:27
    //        modify by lizhao@wisdombud.com at 2014-08-05 10:48
    //        refactor a basedao interface for more database and create a subInterface of mondodbdao
    //
    //======================================================================
    public interface IMongoDbDao<T, TId> : IBaseDao<T, TId>
        where T : MongoDbEntity
    {
        #region Public Methods and Operators

        IEnumerable<T> Search_And(IList<IMongoQuery> search, int page, int pagesize, out long foundedRecords);

        IEnumerable<T> Search_Or(IList<IMongoQuery> search, int page, int pagesize, out long foundedRecords);

        #endregion
    }
}