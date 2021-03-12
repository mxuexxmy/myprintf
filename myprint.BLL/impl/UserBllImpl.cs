using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.dal.impl;
using myprint.Entity;

namespace myprint.BLL.impl
{
    public class UserBllImpl : UserBll
    {
        private UserDALImpl userDALImpl = new UserDALImpl();

        public User getUser(string phone, string passowrd)
        {
            User user = userDALImpl.getUserByPhone(phone);
            if (user == null)
            {
                return null;
            }
            if (user.password.Equals(passowrd))
            {
                return user;
            }
            
            return null;
        }

        public User getUserOne(long id)
        {
            return userDALImpl.getUserOne(id);
        }


        public void updatePassword(long id, string password)
        {
            userDALImpl.updatePassword(id, password);
        }

        public void updateProfile(User user)
        {
            userDALImpl.updateProfile(user);
        }
    }
}
