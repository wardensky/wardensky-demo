namespace MongoBll
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.GridFS;
    using MongoDB.Driver.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;

    public class MongoDbBaseDao<T> 
        where T : ChinaTtlWifi.NewEntity.BaseEntity
    {
        #region Constants

        private const string MongoDbServer = "mongodb://192.168.163.197/tests_mongodb";

        #endregion
    
        #region Fields

        private readonly string collectioname = typeof(T).Name;

        private MongoDatabase repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MongoDbBaseDao{T}" /> class.
        /// </summary>
        /// <param name="pConnectionstring">The connection string.</param>
        /// <example>mongodb://localhost/database_name</example>
        public MongoDbBaseDao(string pConnectionstring)
        {
            this.ConnectionDatabasestring(pConnectionstring);
        }


        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Counts the specified condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        public virtual long Count(Expression<Func<T, bool>> condition)
        {
            return this.repository.GetCollection<T>(this.collectioname).AsQueryable().Where(condition).LongCount();
        }

        /// <summary>
        ///     Count all elements
        /// </summary>
        /// <returns></returns>
        public virtual long Count()
        {
            return this.repository.GetCollection<T>(this.collectioname).Count();
        }

        /// <summary>
        ///     Deletes the specified object.
        /// </summary>
        /// <param name="pobject">The object.</param>
        public virtual void Delete(T pobject)
        {
            this.repository.GetCollection<T>(this.collectioname).Remove(Query.EQ("_id", pobject.Id));
        }

        public virtual void DeleteBy(string name, string value)
        {
            this.repository.GetCollection<T>(this.collectioname).Remove(Query.EQ(name, value));
        }

        /// <summary>
        ///     Deletes the specified object.
        /// </summary>
        /// <param name="condition"></param>
        public virtual void Delete(Expression<Func<T, bool>> condition)
        {
            var todelete = this.GetAll(condition) as List<T>;
            if (todelete == null || todelete.Count <= 0)
            {
                return;
            }
            foreach (T t in todelete)
            {
                Delete(t);
            }
        }

        public virtual void DeleteAll()
        {
            IEnumerable<T> todelete = this.GetAll();
            foreach (T t in todelete)
            {
                Delete(t);
            }
        }

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return this.repository.GetCollection<T>(this.collectioname).FindAll();
        }

        /// <summary>
        ///     Gets all using a condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> condition)
        {
            return this.repository.GetCollection<T>(this.collectioname).AsQueryable().Where(condition).ToList();
        }

        /// <summary>
        ///     Gets all using a condition, a TOP clause and an optional orderBy clause.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="maxresult">The max result.</param>
        /// <param name="orderByDescending">if set to <c>true</c> [order by descending].</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll(
            Expression<Func<T, bool>> condition,
            int maxresult,
            bool orderByDescending)
        {
            IQueryable<T> query = this.repository.GetCollection<T>(this.collectioname).AsQueryable().Where(condition);

            return orderByDescending
                       ? query.OrderByDescending(x => x.Id).Take(maxresult)
                       : query.OrderBy(x => x.Id).Take(maxresult);
        }

        /// <summary>
        ///     Gets the by condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        public virtual T GetByCondition(Expression<Func<T, bool>> condition)
        {
            return this.repository.GetCollection<T>(this.collectioname).AsQueryable().Where(condition).FirstOrDefault();
        }


        public virtual T SelectFirstBy(string name, BsonValue value)
        {
            return this.repository.GetCollection<T>(this.collectioname).FindOne(Query.EQ(name, value));
        }

        public virtual T SelectById(BsonValue value)
        {
            return this.repository.GetCollection<T>(this.collectioname).FindOne(Query.EQ("_id", value));
        }

        public virtual IEnumerable<T> SelectBy(string name, BsonValue value)
        {
            return this.repository.GetCollection<T>(this.collectioname).Find(Query.EQ(name, value));
        }

        public virtual IEnumerable<T> SelectGT(string name, BsonValue value)
        {
            return this.repository.GetCollection<T>(this.collectioname).Find(Query.GT(name, value));
        }
        /// <summary>
        ///     Gets the by MongoId.
        /// </summary>
        /// <param name="MongoId">The _id.</param>
        /// <returns></returns>
        public virtual T GetById(string MongoId)
        {
            return this.repository.GetCollection<T>(this.collectioname).FindOne(Query.EQ("_id", new ObjectId(MongoId)));
        }

        public T GetFirst(string field, string search)
        {
            long selectCount;
            IEnumerable<T> selectList = this.Search(field, search, 1, 1, out selectCount);
            return selectList.FirstOrDefault();
        }


        /// <summary>
        ///     Paginates by an specified condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="pagesize">The page size.</param>
        /// <param name="page">The page.</param>
        /// <param name="pOrderByClause">The OrderBy Clause.</param>
        /// <param name="pOrderByDescending">if set to <c>true</c> [order by descending].</param>
        /// <returns></returns>
        public virtual IEnumerable<T> Paginate<TKey>(
            Expression<Func<T, bool>> condition,
            int pagesize,
            int page,
            out long allRecordCount,
            Func<T, TKey> pOrderByClause,
            bool pOrderByDescending)
        {
            IEnumerable<T> query = this.repository.GetCollection<T>(this.collectioname).AsQueryable().Where(condition);
            allRecordCount = query.Count();
            return this.PaginateQuery(pagesize, page, pOrderByClause, pOrderByDescending, query);
        }

        /// <summary>
        ///     Paginates by an specified condition.
        /// </summary>
        /// <param name="pagesize">The page size.</param>
        /// <param name="page">The page.</param>
        /// <param name="pOrderByClause">The OrderBy Clause.</param>
        /// <param name="pOrderByDescending">if set to <c>true</c> [order by descending].</param>
        /// <returns></returns>
        public virtual IEnumerable<T> Paginate<TKey>(
            int pagesize,
            int page,
            Func<T, TKey> pOrderByClause,
            bool pOrderByDescending)
        {
            IQueryable<T> query = this.repository.GetCollection<T>(this.collectioname).AsQueryable();
            return this.PaginateQuery(pagesize, page, pOrderByClause, pOrderByDescending, query);
        }

        /// <summary>
        ///     Saves the specified object.
        /// </summary>
        /// <param name="pobject">The object.</param>
        /// <returns></returns>
        public virtual T Save(T pobject)
        {
            if (string.IsNullOrEmpty(pobject.Id))
            {
                pobject.Id = Guid.NewGuid().ToString();
            }
            this.repository.GetCollection<T>(this.collectioname).Save(pobject);
            return pobject;
        }

        public virtual void UpLoadByGridFS(Stream stream, string fileName)
        {
            this.repository.GetGridFS(MongoGridFSSettings.Defaults).Upload(stream, fileName);
        }

        public virtual byte[] DownLoadByGridFS(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return null;
            }
            var fileInfo = this.repository.GetGridFS(MongoGridFSSettings.Defaults).FindOne(fileName);
            byte[] buffer;
            using (var stream = fileInfo.OpenRead())
            {
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
            }
            return buffer;
        }

        public virtual void DeleteByGridFS(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                this.repository.GetGridFS(MongoGridFSSettings.Defaults).Delete(fileName);
            }
        }

        /// <summary>
        ///     Search indexes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="search">The search value</param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="foundedRecords">total number of founded records in index</param>
        /// <returns></returns>
        public IEnumerable<T> Search(string field, string search, int page, int pagesize, out long foundedRecords)
        {
            IMongoQuery query = Query.Matches(field, new BsonRegularExpression(search, "i"));
            List<T> totallist = this.repository.GetCollection<T>(this.collectioname).Find(query).ToList();
            foundedRecords = totallist.Count;
            return totallist.Skip(pagesize * (page - 1)).Take(pagesize).ToList();
        }

        public IEnumerable<T> Search_And(
            IDictionary<string, string> keysAndValues,
            int page,
            int pagesize,
            out long foundedRecords)
        {
            List<IMongoQuery> queries =
                keysAndValues.Keys.Select(key => Query.Matches(key, new BsonRegularExpression(keysAndValues[key], "i")))
                    .ToList();
            IMongoQuery query = Query.And(queries);
            List<T> totallist = this.repository.GetCollection<T>(this.collectioname).Find(query).ToList();
            foundedRecords = totallist.Count;
            return totallist.Skip(pagesize * (page - 1)).Take(pagesize).ToList();
        }

        public IEnumerable<T> Search_And(IList<IMongoQuery> search, int page, int pagesize, out long foundedRecords)
        {
            IMongoQuery query = Query.And(search);
            List<T> totallist = this.repository.GetCollection<T>(this.collectioname).Find(query).ToList();
            foundedRecords = totallist.Count;
            return totallist.Skip(pagesize * (page - 1)).Take(pagesize).ToList();
        }

        public IEnumerable<T> Search_Or(
            IDictionary<string, string> keysAndValues,
            int page,
            int pagesize,
            out long foundedRecords)
        {
            List<IMongoQuery> queries =
                keysAndValues.Keys.Select(key => Query.Matches(key, new BsonRegularExpression(keysAndValues[key], "i")))
                    .ToList();
            IMongoQuery query = Query.Or(queries);
            List<T> totallist = this.repository.GetCollection<T>(this.collectioname).Find(query).ToList();
            foundedRecords = totallist.Count;
            return totallist.Skip(pagesize * (page - 1)).Take(pagesize).ToList();
        }

        public IEnumerable<T> Search_Or(IList<IMongoQuery> search, int page, int pagesize, out long foundedRecords)
        {
            IMongoQuery query = Query.Or(search);
            List<T> totallist = this.repository.GetCollection<T>(this.collectioname).Find(query).ToList();
            foundedRecords = totallist.Count;
            return totallist.Skip(pagesize * (page - 1)).Take(pagesize).ToList();
        }

        #endregion

        #region Methods

        protected IEnumerable<T> PaginateQuery<TKey>(
            int pagesize,
            int page,
            Func<T, TKey> pOrderByClause,
            bool pOrderByDescending,
            IEnumerable<T> query)
        {
            if (pOrderByClause == null)
            {
                query = pOrderByDescending ? query.OrderByDescending(x => x.Id) : query.OrderBy(x => x.Id);
                //default order by MongoId
            }
            else
            {
                query = pOrderByDescending ? query.OrderByDescending(pOrderByClause) : query.OrderBy(pOrderByClause);
            }
            return query.Skip(pagesize * (page - 1)).Take(pagesize);
        }

        private void ConnectionDatabasestring(string pConnectionstring)
        {
            MongoUrl mongourl = MongoUrl.Create(pConnectionstring);
            var client = new MongoClient(mongourl);
            MongoServer server = client.GetServer();
            this.repository = server.GetDatabase(mongourl.DatabaseName);
        }

        #endregion
    }
}