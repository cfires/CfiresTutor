using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CfiresTutor.Model;
using CfiresTutor.DAL;

namespace CfiresTutor.BLL
{
    public class Base_StudentBll
    {
        Base_StudentDal _studentDal = new Base_StudentDal();

        public Base_Student Get(int id)
        {
            return _studentDal.Get(id);
        }

        public void AddStudent(Base_Student student)
        {
            _studentDal.Insert(student);
        }

        public void UpdateStudent(Base_Student student)
        {
            _studentDal.Update(student);
        }
    }
}
