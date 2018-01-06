namespace Wims.Common.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    //======================================================================
    //
    //        All rights reserved
    //
    //        filename :IBaseDao
    //        description :IBaseDao通用接口
    //
    //        created by lizhao@wisdombud.com at  2014-08-05 9:06:27
    //
    //======================================================================
    public interface IBaseDao<T, TId>
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Counts the specified condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        long Count(Expression<Func<T, bool>> condition);

        /// <summary>
        ///     Count all elements
        /// </summary>
        /// <returns></returns>
        long Count();

        /// <summary>
        ///     Deletes the Entity.
        /// </summary>
        /// <param name="pobject">The pobject.</param>
        void Delete(T pobject);

        /// <summary>
        ///     Deletes the Entities.
        /// </summary>
        /// <param name="condition">The condition.</param>
        void Delete(Expression<Func<T, bool>> condition);

        /// <summary>
        ///     Deletes All.
        /// </summary>
        void DeleteAll();

        /// <summary>
        ///     Gets all Entities.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        ///     Gets all Entities by condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Expression<Func<T, bool>> condition);

        /// <summary>
        ///     GetAll by query
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="top">TOP Clause, if is [0] will be ignored</param>
        /// <param name="orderByDescending">If is [true] order by desc - If is [false] order by asc</param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Expression<Func<T, bool>> condition, int top, bool orderByDescending);

        /// <summary>
        ///     Gets the first Entity by condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        T GetByCondition(Expression<Func<T, bool>> condition);

        /// <summary>
        ///     Gets the Entity by ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        T GetById(TId id);

        /// <summary>
        ///     查找第一个满足条件的T
        /// </summary>
        /// <param name="field">字段名称</param>
        /// <param name="search">字段值</param>
        /// <returns>查找到的T 如果不存在为null</returns>
        T GetFirst(string field, string search);

        /// <summary>
        ///     Paginates the specified func.
        /// </summary>
        /// <param name="condition">The func.</param>
        /// <param name="pagesize">The pagesize.</param>
        /// <param name="page">The page.</param>
        /// <param name="pOrderByClause"></param>
        /// <param name="pOrderByDescending">if set to <c>true</c> [p order by descending].</param>
        /// <returns></returns>
        IEnumerable<T> Paginate<TKey>(
            Expression<Func<T, bool>> condition,
            int pagesize,
            int page,
            out long allRecordCount,
            Func<T, TKey> pOrderByClause,
            bool pOrderByDescending);

        /// <summary>
        ///     Paginates the specified func.
        /// </summary>
        /// <param name="pagesize">The pagesize.</param>
        /// <param name="page">The page.</param>
        /// <param name="pOrderByClause"></param>
        /// <param name="pOrderByDescending">if set to <c>true</c> [p order by descending].</param>
        /// <returns></returns>
        IEnumerable<T> Paginate<TKey>(
            int pagesize,
            int page,
            Func<T, TKey> pOrderByClause,
            bool pOrderByDescending);

        /// <summary>
        ///     Saves the Entity.
        /// </summary>
        /// <param name="pobject">The p object.</param>
        /// <returns></returns>
        T Save(T pobject);

        /// <summary>
        ///     Seach using 'text' command
        /// </summary>
        /// <param name="field"></param>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="foundedRecords"></param>
        /// <returns></returns>
        IEnumerable<T> Search(string field, string search, int page, int pagesize, out long foundedRecords);

        /// <summary>
        ///     Seach using 'text' command based in key value pairs And Clause
        /// </summary>
        /// <param name="keysAndValues"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="foundedRecords"></param>
        /// <returns></returns>
        IEnumerable<T> Search_And(
            IDictionary<string, string> keysAndValues,
            int page,
            int pagesize,
            out long foundedRecords);

        /// <summary>
        ///     Seach using 'text' command based in key value pairs Or Clause
        /// </summary>
        /// <param name="keysAndValues"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="foundedRecords"></param>
        /// <returns></returns>
        IEnumerable<T> Search_Or(
            IDictionary<string, string> keysAndValues,
            int page,
            int pagesize,
            out long foundedRecords);

        #endregion
    }
}