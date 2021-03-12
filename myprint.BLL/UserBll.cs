using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.Entity;
namespace myprint.BLL
{
    public interface UserBll
    {
        User getUserOne(long id);

        User getUser(string phone, string passowrd);

        void updateProfile(User user);

        void updatePassword(long id, string password);
    }
}
