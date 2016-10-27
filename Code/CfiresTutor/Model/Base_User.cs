using NPoco;
using System;

namespace CfiresTutor.Model
{
    [TableName("Base_User")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class Base_User
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        [Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        [Column("UserType")]
        public UserType UserType { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        [Column("LoginName")]
        public string LoginName { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [Column("UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column("Password")]
        public string Password { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Column("Sex")]
        public int Sex { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Column("Email")]
        public string Email { get; set; }

        /// <summary>
        /// 邮箱是否激活(默认：0未激活)
        /// </summary>
        [Column("EmailConfirmed")]
        public bool EmailConfirmed { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Column("Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Column("Address")]
        public string Address { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        [Column("Enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("IsDelete")]
        public bool IsDelete { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        [Column("LastLoginDate")]
        public DateTime LastLoginDate { get; set; }
    }
}
