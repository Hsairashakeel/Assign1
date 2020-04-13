using Entities_assign3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_assign3
{
    public class UserBO
    {
        public static int Save(UserDTO dto)
        {
            return DAL_assign3.UserDAO.Save(dto);
        }
        public static bool IsValidUser(String login, String pass)
        {
            return DAL_assign3.UserDAO.IsValidUser(login, pass);
        }
        public static bool IsExistingLogin(String login)
        {
            return DAL_assign3.UserDAO.IsExistingLogin(login);
        }
        public static bool IsExistingEmail(String email)
        {
            return DAL_assign3.UserDAO.IsExistingEmail(email);
        }
        public static UserDTO GetUserDataByLogin(string login)
        {
            return DAL_assign3.UserDAO.GetUserDataByLogin(login);

        }


    }
}
