using EAD_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAD_BAL
{
    public class UserBO
    {
        public static int Save(UserDTO dto)
        {
            return EAD_DAL.UserDAO.Save(dto);
        }
        public static bool IsValidUser(String login, String pass)
        {
            return EAD_DAL.UserDAO.IsValidUser(login, pass);
        }
        public static bool IsExistingUser(String login)
        {
            return EAD_DAL.UserDAO.IsExistingUser(login);
        }
        public static object showData()
        {
            return EAD_DAL.UserDAO.dataInGrid();
        }
        public static UserDTO GetUserData(int id)
        {
            return EAD_DAL.UserDAO.GetUserData(id);
        }
        public static UserDTO GetUserDataByLogin(string login)
        {
            return EAD_DAL.UserDAO.GetUserDataByLogin(login);

        }
        public static int resetPassword(String pass, String login)
        {
            return EAD_DAL.UserDAO.resetPassword(pass, login);

        }

    }
}
