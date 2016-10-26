using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfiresTutor.Model
{
    [TableName("Base_Teacher")]
    [PrimaryKey("UserId", AutoIncrement = false)]
    public class Base_Teacher : Base_User
    {
        [Column("UserId")]
        public int UserId { get; set; }
    }
}
