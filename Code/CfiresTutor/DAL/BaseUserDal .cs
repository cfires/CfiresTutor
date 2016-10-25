using CfiresTutor.Model;
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
        /// 获取用户集合（分页显示）
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<Base_User> GetList(int start, int end)
        {
            string sql = "SELECT * FROM (SELECT row_number() over(order by Id) as num,* from Base_User) as t where t.num >=@start and t.num <=@end";

            SqlParameter[] pars = {
                new SqlParameter("@start",start),
                new SqlParameter("@end",end)
            };
            List<Base_User> list = new List<Base_User>();
            DataTable dt = SqlHelper.ExecuteDataTable(sql, pars);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Base_User()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Password = row["Password"].ToString(),
                    Email = row["Email"].ToString(),
                    Type = (UserType)row["Type"],
                    CreateDate = (DateTime)row["CreateDate"]
                });
            }
            return list;

        }

        /// <summary>
        /// 获取用户分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public Page<Base_User> GetPageList(int pageIndex, int pageSize, string keyWord)
        {
            Sql sql = Sql.Builder.Append("SELECT * FROM Base_User where Enabled=1");

            if (!string.IsNullOrWhiteSpace(keyWord))
            {
                sql.Append("AND Name LIKE @0", "%" + keyWord + "%");
            }

            return base.GetPageList(sql, pageIndex, pageSize);
        }

    }
}
