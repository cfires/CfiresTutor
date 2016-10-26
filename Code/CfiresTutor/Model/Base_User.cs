using NPoco;
using System;

namespace CfiresTutor.Model
{
    [TableName("Base_User")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class Base_User
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("UserType")]
        public UserType UserType { get; set; }

        [Column("LoginName")]
        public string LoginName { get; set; }

        [Column("UserName")]
        public string UserName { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("Sex")]
        public int Sex { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("EmailConfirmed")]
        public bool EmailConfirmed { get; set; }

        [Column("Phone")]
        public string Phone { get; set; }

        [Column("Enabled")]
        public bool Enabled { get; set; }

        [Column("IsDelete")]
        public bool IsDelete { get; set; }

        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }

        [Column("LastLoginDate")]
        public DateTime LastLoginDate { get; set; }
    }
}
