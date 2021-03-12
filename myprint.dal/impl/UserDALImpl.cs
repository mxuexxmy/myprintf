using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.Entity;

namespace myprint.dal.impl
{
    public class UserDALImpl : UserDAL
    {
        /// <summary>
        /// 根据手机号查询用户
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public User getUserByPhone(string phone)
        {
            using (var db = new PrintingEntities())
            {
                var user = db.tb_user.FirstOrDefault(b => b.user_phone == phone);
                return user;
            }
           
        }

        /// <summary>
        /// 用于测试
        /// </summary>
        /// <returns></returns>
        public User getUserOne(long id)
        {
            using (var db = new PrintingEntities())
            {
                var user = db.tb_user.FirstOrDefault(b => b.id == id);
                return user;
            }
        }

        public void updatePassword(long id, string password)
        {
            using (var db = new PrintingEntities())
            {
                var user = db.tb_user.FirstOrDefault(b => b.id == id);
                user.password = password;
                db.SaveChanges();
            }
        }

        public void updateProfile(User user)
        {
            using (var db = new PrintingEntities())
            {
                var _user = db.tb_user.FirstOrDefault(b => b.id == user.id);
                _user.user_name = user.user_name;
                _user.user_phone = user.user_phone;
                _user.address = user.address;
                _user.update_time = DateTime.Now;
                db.SaveChanges();
             }
        }
    }
}
