using CfiresTutor.DAL;
using CfiresTutor.Model;
using CfiresTutor.Utilities;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfiresTutor.BLL
{
    public class Base_UserBll
    {
        BaseUserDal _userDal = new BaseUserDal();

        public Base_User Get(int id)
        {
            return _userDal.Get(id);
        }

        public void AddUser(Base_User user)
        {
            user.CreateDate = DateTime.Now;
            user.LastLoginDate = DateTime.Now;
            user.Password = SecurityHelper.EncryptAES(user.Password);
            user.Enabled = true;

            _userDal.Insert(user);

        }

        public Base_User GetByEmail(string email)
        {
            return _userDal.GetByEmail(email);
        }

        public Base_User GetByLoginName(string loginName)
        {
            return _userDal.GetByLoginName(loginName);
        }

        public PageDataSet<Base_User> GetPageList(int pageIndex, int pageSize, string keyword, UserType userType = UserType.Student)
        {
            return _userDal.GetPageList(pageIndex, pageSize, keyword, userType);
        }
    }
}
