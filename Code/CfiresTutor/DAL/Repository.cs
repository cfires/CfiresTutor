using CfiresTutor.Utilities;
using NPoco;
using System.Collections.Generic;

namespace CfiresTutor.DAL
{
    public class Repository<T> where T : class, new()
    {
        IDatabase db = new Database("connStr");

        /// <summary>
        /// 获取实体(by 主键)
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns>实体对象</returns>
        public T Get(object primaryKey)
        {
            return db.SingleOrDefaultById<T>(primaryKey);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {
            db.Insert(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete(T entity)
        {
            return db.Delete(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public int Delete(object primaryKey)
        {
            return db.Delete<T>(primaryKey);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            db.Update(entity);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IEnumerable<T> GetList(Sql sql)
        {
            return db.Query<T>(sql);
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageDataSet<T> GetPageList(Sql sql, int pageIndex, int pageSize)
        {
            Page<T> pages = db.Page<T>(pageIndex, pageSize, sql);

            PageDataSet<T> result = new PageDataSet<T>(pages.Items);
            result.PageIndex = pageIndex;
            result.PageSize = pageSize;
            result.TotalRecords = (int)pages.TotalItems;
            return result;
        }
    }
}
