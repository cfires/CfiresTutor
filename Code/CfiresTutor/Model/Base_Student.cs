﻿using NPoco;

namespace CfiresTutor.Model
{
    [TableName("Base_Student")]
    [PrimaryKey("UserId", AutoIncrement = false)]
    public class Base_Student : Base_User
    {
        [Column("UserId")]
        public int UserId { get; set; }

        [Column("Age")]
        public int Age { get; set; }

    }
}
