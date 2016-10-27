using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CfiresTutor.Model;
using NPoco;

namespace CfiresTutor.DAL
{
    public class Base_StudentDal : Repository<Base_Student>
    {
        IDatabase db = new Database("db");
    }
}
