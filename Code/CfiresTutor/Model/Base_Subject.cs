using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfiresTutor.Model
{
    /// <summary>
    /// 科目实体类
    /// </summary>
    [TableName("Base_Subject")]
    [PrimaryKey("Id")]
    public class Base_Subject
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Grade")]
        public string Grade { get; set; }

        [Column("Price")]
        public int Price { get; set; }

        public int? Num { get; set; }

        public int? Sex { get; set; }
    }
}
