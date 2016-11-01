using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CfiresTutor.Model;
using NPoco;
using CfiresTutor.Utilities;

namespace CfiresTutor.DAL
{
    public class Base_SubjectDal : Repository<Base_Subject>
    {
        IDatabase db = new Database("connStr");

        /// <summary>
        /// 获取科目列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public PageDataSet<Base_Subject> GetPageList(int pageIndex, int pageSize, string keyword)
        {
            Sql sql = Sql.Builder.Append("SELECT * FROM Base_Subject WHERE Enabled=1 AND IsDelete=0");
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql.Append("AND Name LIKE @0", "%" + keyword + "%");
            }
            return base.GetPageList(sql, pageIndex, pageSize);
        }
    }
}
