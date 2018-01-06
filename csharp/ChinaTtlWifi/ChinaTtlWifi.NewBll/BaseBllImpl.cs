namespace ChinaTtlWifi.NewBll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Wims.Common;
    using Wims.Common.Entity;
    using Wims.Common.MongoDBUtil;
    using Wims.Mili.AOP;
    using Wisdombud.Mongo;
    using Wisdombud.MongoDb;


    public class BaseBllImpl<T> : IBaseBll<T>
        where T : BaseEntity
    {
        #region Static Fields


        private static MongoUtil<T> mongoDbDao = new MongoUtil<T>(GlobalValues.MONGO_URL);


        #endregion

        #region Public Methods and Operators
        [LogAttribute(LogType.Operate, "增加")]
        public virtual int Add(T entity)
        {
            try
            {

                mongoDbDao.Dao.Save(entity);
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
        [LogAttribute(LogType.Operate, "增加")]
        public virtual int Add(List<T> entityList)
        {
            try
            {
                foreach (var entity in entityList)
                {
                    mongoDbDao.Dao.Save(entity);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
        [LogAttribute(LogType.Operate, "删除")]
        public virtual int Delete(T entity)
        {
            try
            {
                mongoDbDao.Dao.Delete(entity);
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
        [LogAttribute(LogType.Operate, "删除")]
        public virtual int Delete(Expression<Func<T, bool>> condition)
        {
            try
            {
                mongoDbDao.Dao.Delete(condition);
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
        [LogAttribute(LogType.Operate, "删除")]
        public virtual int Delete(List<T> entityList)
        {
            try
            {
                foreach (var entity in entityList)
                {
                    mongoDbDao.Dao.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
        [LogAttribute(LogType.Operate, "删除")]
        public virtual int DeleteAll()
        {
            try
            {
                mongoDbDao.DeleteAll();
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }

        public virtual T Select(string id)
        {
            try
            {
                return mongoDbDao.Dao.GetById(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual List<T> SelectAll()
        {
            try
            {
                return mongoDbDao.Dao.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual List<T> SelectBy(Expression<Func<T, bool>> condition)
        {
            try
            {
                return mongoDbDao.Dao.GetAll(condition).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual T SelectFirst()
        {
            try
            {
                List<T> listEntity = mongoDbDao.Dao.GetAll().ToList();
                if (listEntity.Count > 0)
                {
                    return listEntity.FirstOrDefault();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual T SelectFirst(Expression<Func<T, bool>> condition)
        {
            try
            {
                List<T> listEntity = mongoDbDao.Dao.GetAll(condition).ToList();
                if (listEntity.Count > 0)
                {
                    return listEntity.FirstOrDefault();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public virtual T SelectLast()
        {
            try
            {
                List<T> listEntity = mongoDbDao.Dao.GetAll().ToList();
                if (listEntity.Count > 0)
                {
                    return listEntity.LastOrDefault();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual T SelectLast(Expression<Func<T, bool>> condition)
        {
            try
            {
                List<T> listEntity = mongoDbDao.Dao.GetAll(condition).ToList();
                if (listEntity.Count > 0)
                {
                    return listEntity.LastOrDefault();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        ///if entity.id is null,add new record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [LogAttribute(LogType.Operate, "更新")]
        public virtual int Update(T entity)
        {
            try
            {
                mongoDbDao.Dao.Save(entity);
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }
        [LogAttribute(LogType.Operate, "更新")]
        public virtual int Update(List<T> entityList)
        {
            try
            {
                foreach (var entity in entityList)
                {
                    Update(entity);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }

        #endregion
    }
}