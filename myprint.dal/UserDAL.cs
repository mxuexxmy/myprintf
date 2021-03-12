using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.Entity;

namespace myprint.dal
{
    public interface UserDAL
    {
        User getUserOne(long id);

        // 根据用户手机号获取用户
        User getUserByPhone(string phone);

        void updateProfile(User user);

        void updatePassword(long id, string password);

    }
}
