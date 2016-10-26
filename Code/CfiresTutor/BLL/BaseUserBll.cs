﻿using CfiresTutor.DAL;
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
    public class BaseUserBll
    {
        BaseUserDal _userDal = new BaseUserDal();

        public Base_Teacher Get(int id)
        {
            return _userDal.Get(id);
        }

        public Base_Teacher GetByEmail(string email)
        {
            return _userDal.GetByEmail(email);
        }

        public void Create(Base_Teacher user)
        {
            user.CreateDate = DateTime.Now;
            user.Password = SecurityHelper.EncryptAES(user.Password);
            user.Enabled = true;
            _userDal.Insert(user);
        }

        public PageDataSet<Base_Teacher> GetPageList(int pageIndex, int pageSize, string keyword, UserType userType = UserType.Student)
        {
            return _userDal.GetPageList(pageIndex, pageSize, keyword, userType);
        }
    }
}
