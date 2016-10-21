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
        Tutor = 1,

        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        Admin = 2,
    }
}
