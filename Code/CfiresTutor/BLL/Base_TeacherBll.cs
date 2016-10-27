using CfiresTutor.DAL;
using CfiresTutor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfiresTutor.BLL
{
    public class Base_TeacherBll
    {
        Base_TeacherDal _teacherDal = new Base_TeacherDal();

        public Base_Teacher GetTeacher(int teacherId)
        {
            return _teacherDal.Get(teacherId);
        }

        public void AddTeacher(Base_Teacher teacher)
        {
            _teacherDal.Insert(teacher);
        }

        public void UpdateTeacher(Base_Teacher teacher)
        {
            _teacherDal.Update(teacher);
        }
    }
}
