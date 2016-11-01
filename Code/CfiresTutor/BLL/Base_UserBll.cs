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
        Base_StudentDal _studentDal = new Base_StudentDal();
        Base_TeacherDal _teacherDal = new Base_TeacherDal();

        /// <summary>
        /// 获取用户实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Base_User Get(int id)
        {
            return _userDal.Get(id);
        }

        /// <summary>
        /// 获取用户实体
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Base_User GetByEmail(string email)
        {
            return _userDal.GetByEmail(email);
        }

        /// <summary>
        /// 获取用户实体
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public Base_User GetByLoginName(string loginName)
        {
            return _userDal.GetByLoginName(loginName);
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(Base_User user)
        {
            user.CreateDate = DateTime.Now;
            user.LastLoginDate = DateTime.Now;
            user.Password = SecurityHelper.EncryptAES(user.Password);
            user.Enabled = true;

            _userDal.Insert(user);

        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(Base_User user)
        {
            user.LastLoginDate = DateTime.Now;
            _userDal.Update(user);
        }

        /// <summary>
        /// 删除用户（逻辑删除）
        /// </summary>
        /// <param name="user"></param>
        public void Delete(Base_User user)
        {
            user.IsDelete = true;
            _userDal.Update(user);
        }

        /// <summary>
        /// 物理删除（同时删除学员表或教员表中关联数据）
        /// </summary>
        /// <param name="user"></param>
        public void DeletePhysical(Base_User user)
        {
            if (user.UserType == UserType.Teacher)
            {
                var teacher = _teacherDal.Get(user.Id);
                _teacherDal.Delete(teacher);
            }
            else
            {
                var student = _studentDal.Get(user.Id);
                _studentDal.Delete(student);
            }

            _userDal.Delete(user);
        }

        /// <summary>
        /// 获取用户列表（分页显示）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        public PageDataSet<Base_User> GetPageList(int pageIndex, int pageSize, string keyword, UserType userType = UserType.Student)
        {
            return _userDal.GetPageList(pageIndex, pageSize, keyword, userType);
        }
    }
}
