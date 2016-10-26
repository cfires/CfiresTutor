using NPoco;

namespace CfiresTutor.Model
{
    /// <summary>
    /// 课程实体类
    /// </summary>
    [TableName("Base_Subject")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class Base_Subject
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        [Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 课程年级
        /// </summary>
        [Column("Grade")]
        public string Grade { get; set; }

        /// <summary>
        /// 官方价格
        /// </summary>
        [Column("Price")]
        public int? OfficialPrice { get; set; }
    }
}
