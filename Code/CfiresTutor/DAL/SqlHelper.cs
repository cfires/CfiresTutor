using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CfiresTutor.DAL
{
    public class SqlHelper
    {
        //获取配置文件中的连接字符串
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">sql参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns>首行首列</returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 多行查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    try
                    {
                        con.Open();
                        return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        con.Dispose();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 封装一个返回DataTable的方法。(用来执行查询结果比较少的sql，params长度可变参数)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, conStr))
            {
                if (parameters != null)
                {
                    sda.SelectCommand.Parameters.AddRange(parameters);
                }
                sda.Fill(dt);
            }

            return dt;
        }
    }
}
