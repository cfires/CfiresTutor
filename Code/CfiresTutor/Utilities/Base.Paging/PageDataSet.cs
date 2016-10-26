using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfiresTutor.Utilities
{
    /// <summary>
    /// 分页数据封装
    /// </summary>
    /// <typeparam name="T">分页数据的实体类型</typeparam>
    [Serializable]
    public class PageDataSet<T> : ReadOnlyCollection<T>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="entities">用于分页的实体集合</param>
        public PageDataSet(IEnumerable<T> entities)
            : base(entities.ToList())
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="entities">用于分页的实体集合</param>
        public PageDataSet(IList<T> entities)
            : base(entities)
        {
        }

        private int _pageSize = 20;
        private int _pageIndex = 1;
        private long _totalRecords = 0;

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int PageSize
        {
            get { return this._pageSize; }
            set { this._pageSize = value; }
        }

        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex
        {
            get { return this._pageIndex; }
            set { this._pageIndex = value; }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public long TotalRecords
        {
            get { return this._totalRecords; }
            set { this._totalRecords = value; }
        }

        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount
        {
            get
            {
                long result = TotalRecords / PageSize;
                if (TotalRecords % PageSize != 0)
                    result++;

                return Convert.ToInt32(result);
            }
        }

        private double queryDuration = 0;
        /// <summary>
        /// 搜索执行时间(秒)
        /// </summary>
        public double QueryDuration
        {
            get { return queryDuration; }
            set { queryDuration = value; }
        }

    }
}
