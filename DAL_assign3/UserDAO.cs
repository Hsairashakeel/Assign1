using Entities_assign3;
using MySql.Data.MySqlClient;
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

            String MysqlQuery = "";


                MysqlQuery = String.Format("INSERT INTO users(username,password,email)VALUES('{0}','{1}','{2}')",
                 dto.Login, dto.password,dto.email);
            
            using (DBhelper helper = new DBhelper())
            {
                return helper.ExecuteQuery(MysqlQuery);
            }


        }
        public static bool IsValidUser(String login, string password)
        {
            String MysqlQuery = "";
            MysqlQuery = String.Format("select * from users WHERE username = '{0}' AND password = '{1}' ", login, password);
            using (DBhelper helper = new DBhelper())
            {
                return helper.Adapter(MysqlQuery);
            }
        }
        public static UserDTO fillDTO(MySqlDataReader reader)
        {
            var dto = new UserDTO();
            dto.UserID = reader.GetInt32(0);
            dto.Login = reader.GetString(1);
            dto.email = reader.GetString(2);
            dto.password = reader.GetString(3);
            return dto;
        }
        public static UserDTO GetUserDataByLogin(string login)
        {
            var query = String.Format("select * from users where username='{0}'", login);
            using (DBhelper helper = new DBhelper())
            {
                try
                {
                    var reader = helper.ExecuteReader(query);
                    UserDTO dto = null;
                    if (reader.Read())
                    {
                        dto = fillDTO(reader);
                    }
                    return dto;
                }
                catch(Exception e)
                {
                    throw;
                }
                
            }
        }
        public static bool IsExistingLogin(String login)
        {
            String MysqlQuery = "";
            MysqlQuery = String.Format("select * from users WHERE username = '{0}' ", login);
            using (DBhelper helper = new DBhelper())
            {
                return helper.Adapter(MysqlQuery);
            }
        }
        public static bool IsExistingEmail(String email)
        {
            String MysqlQuery = "";
            MysqlQuery = String.Format("select * from users WHERE email = '{0}' ", email);
            using (DBhelper helper = new DBhelper())
            {
                return helper.Adapter(MysqlQuery);
            }
        }
    }
}
