using Entities_assign3;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public static UserDTO fillDTO(SqlDataReader reader)
        {
            var dto = new UserDTO();
            dto.UserID = reader.GetInt32(0);
            dto.Login = reader.GetString(1);
            dto.password = reader.GetString(2);           
            dto.email = reader.GetString(3);
            return dto;
        }
        public static UserDTO GetUserDataByLogin(string login)
        {
            var query = String.Format("select * from UserInfo where Login='{0}'", login);
            using (DBhelper helper = new DBhelper())
            {
                var reader = helper.ExecuteReader(query);
                UserDTO dto = null;
                if (reader.Read())
                {
                    dto = fillDTO(reader);
                }
                return dto;
            }
        }
    }
}
