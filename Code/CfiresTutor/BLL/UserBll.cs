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
    public class UserBll
    {
        BaseUserDal _userDal = new BaseUserDal();

        public Base_User Get(int id)
        {
            return _userDal.Get(id);
        }

        public Base_User GetByEmail(string email)
        {
            return _userDal.GetByEmail(email);
        }

        public void Create(Base_User user)
        {
            user.CreateDate = DateTime.Now;
            user.Password = SecurityHelper.EncryptAES(user.Password);
            user.Enabled = true;
            _userDal.Insert(user);
        }

       

        #region 用户列表

        public IEnumerable<Base_User> GetUserList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return _userDal.GetList(start, end);
        }

        public PageDataSet<Base_User> GetPageList(int pageIndex, int pageSize, string keyword)
        {
            return _userDal.GetPageList(pageIndex, pageSize, keyword);
        }
        #endregion
    }
}
