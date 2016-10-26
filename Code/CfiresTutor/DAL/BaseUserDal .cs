using CfiresTutor.Model;
using CfiresTutor.Utilities;
using NPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfiresTutor.DAL
{
    public class BaseUserDal : Repository<Base_User>
    {
        IDatabase db = new Database("connStr");

        public Base_User GetByEmail(string email)
        {
            var sql = Sql.Builder.Append("SELECT * FROM Base_User WHERE Email = @0", email);
            return db.FirstOrDefault<Base_User>(sql);
        }

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public IEnumerable<Base_User> GetList(string keyWord)
        {
            Sql sql = Sql.Builder.Append("SELECT * FROM Base_User where Name LIKE @0 AND Enabled=1", "%" + keyWord + "%");

            sql.OrderBy("CreateDate DESC");

            return base.GetList(sql);
        }

        /// <summary>
        /// 获取用户分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public PageDataSet<Base_User> GetPageList(int pageIndex, int pageSize, string keyWord, UserType userType = UserType.Student)
        {
            Sql sql = Sql.Builder.Append("SELECT * FROM Base_User where Enabled=1 AND IsDelete=0 AND UserType=@0", userType);

            if (!string.IsNullOrWhiteSpace(keyWord))
            {
                sql.Append("AND Name LIKE @0", "%" + keyWord + "%");
            }

            return base.GetPageList(sql, pageIndex, pageSize);
        }

    }
}
