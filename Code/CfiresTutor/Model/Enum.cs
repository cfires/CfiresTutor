using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfiresTutor.Model
{
    public enum UserType
    {
        /// <summary>
        /// 学员
        /// </summary>
        [Description("学员")]
        Student = 0,

        /// <summary>
        /// 教员
        /// </summary>
        [Description("教员")]
        Teacher = 1,

        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        Admin = 2,
    }

    /// <summary>
    /// 教师类型
    /// </summary>
    public enum TeacherType
    {
        /// <summary>
        /// 在校大学生
        /// </summary>
        [Description("在校大学生（研究生）")]
        RdbStudent = 0,

        /// <summary>
        /// 教师
        /// </summary>
        [Description("教师（在职、进修、离职、退休）")]
        RdbTeacher = 1,

        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他 （毕业人员、工作人员、留学生、外籍教师、海外归国人员等）")]
        RdbOther = 2
    }

    public enum NewsType
    {
        /// <summary>
        /// 教员信息
        /// </summary>
        [Description("教员信息")]
        TeacherInfo = 0,

        /// <summary>
        /// 学员信息
        /// </summary>
        [Description("学员信息")]
        StudentInfo = 1,

        /// <summary>
        /// 家教新闻
        /// </summary>
        [Description("家教新闻")]
        TeacherNews = 2
    }
}
