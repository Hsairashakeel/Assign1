using Entities_assign3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_assign3
{
    public static class UserDAO
    {
        public static int Save(UserDTO dto)
        {

            String sqlQuery = "";
          
            
                sqlQuery = String.Format("INSERT INTO [dbo].[UserInfo](Login,Password,email)VALUES('{0}','{1}','{2}')",
                 dto.Login, dto.password,dto.email);
            
            using (DBhelper helper = new DBhelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }


        }
        public static bool IsValidUser(String login, string password)
        {
            String sqlQuery = "";
            sqlQuery = String.Format("select * from UserInfo WHERE Login = '{0}' AND Password = '{1}' ", login, password);
            using (DBhelper helper = new DBhelper())
            {
                return helper.Adapter(sqlQuery);
            }
        }
        public static bool IsExistingLogin(String login)
        {
            String sqlQuery = "";
            sqlQuery = String.Format("select * from UserInfo WHERE Login = '{0}' ", login);
            using (DBhelper helper = new DBhelper())
            {
                return helper.Adapter(sqlQuery);
            }
        }
        public static bool IsExistingEmail(String email)
        {
            String sqlQuery = "";
            sqlQuery = String.Format("select * from UserInfo WHERE email = '{0}' ", email);
            using (DBhelper helper = new DBhelper())
            {
                return helper.Adapter(sqlQuery);
            }
        }
    }
}
