using CfiresTutor.Model;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfiresTutor.DAL
{
    public class Base_TeacherDal : Repository<Base_Teacher>
    {
        IDatabase db = new Database("connStr");

    }
}
