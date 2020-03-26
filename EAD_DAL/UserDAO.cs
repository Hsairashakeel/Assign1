using EAD_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAD_DAL
{
    public class UserDAO
    {
        public static int Save(UserDTO dto)
        {

            String sqlQuery = "";
            if (dto.UserID > 0)
            {
                sqlQuery = String.Format(@"UPDATE [dbo].[UsersData] Set Name='{0}' ,Login='{1}',Password='{2}',Gender='{3}',Address='{4}',Age='{5}',NIC='{6}',DOB='{7}',IsCricket='{8}',Hockey='{9}',Chess='{10}',ImageName='{11}',CreateOn='{12}' WHERE UserID='{13}' ",
                   dto.Name, dto.Login, dto.password, dto.gender, dto.adress, dto.age, dto.nic, dto.DOB, dto.cricket, dto.hockey, dto.chess, dto.imageNmae, dto.createOn, dto.UserID);
            }
            else
            {
                sqlQuery = String.Format("INSERT INTO [dbo].[UsersData](Name,Login,Password,Gender,Address,Age,NIC,DOB,IsCricket,Hockey,Chess,ImageName,CreateOn)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
                dto.Name, dto.Login, dto.password, dto.gender, dto.adress, dto.age, dto.nic, dto.DOB, dto.cricket, dto.hockey, dto.chess, dto.imageNmae, dto.createOn);
            }
            using (DBhelper helper = new DBhelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }


        }
        public static bool IsValidUser(String login, string password)
        {
            String sqlQuery = "";
            sqlQuery = String.Format("select * from UsersData WHERE Login = '{0}' AND Password = '{1}' ", login, password);
            using (DBhelper helper = new DBhelper())
            {
                return helper.Adapter(sqlQuery);
            }
        }
        public static bool IsExistingUser(String login)
        {
            String sqlQuery = "";
            sqlQuery = String.Format("select * from UsersData WHERE Login = '{0}' ", login);
            using (DBhelper helper = new DBhelper())
            {
                return helper.Adapter(sqlQuery);
            }
        }
        public static UserDTO fillDTO(SqlDataReader reader)
        {
            var dto = new UserDTO();
            dto.UserID = reader.GetInt32(0);
            dto.Name = reader.GetString(1);
            dto.Login = reader.GetString(2);
            dto.password = reader.GetString(3);
            dto.gender = Convert.ToChar(reader.GetString(4));
            dto.adress = reader.GetString(5);
            dto.age = reader.GetInt32(6);
            dto.nic = reader.GetString(7);
            dto.DOB = reader.GetDateTime(8);
            dto.cricket = reader.GetBoolean(9);
            dto.hockey = reader.GetBoolean(10);
            dto.chess = reader.GetBoolean(11);
            dto.imageNmae = reader.GetString(12);
            dto.createOn = reader.GetDateTime(13);
            //string applicationBsePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            //String pathToSaveImage = applicationBsePath + @"\images\";

            return dto;
        }

        public static UserDTO GetUserData(int id)
        {
            var query = String.Format("select * from UsersData where UserID={0}", id);
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
        public static UserDTO GetUserDataByLogin(string login)
        {
            var query = String.Format("select * from UsersData where Login='{0}'", login);
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
        public static int resetPassword(String pass, String login)
        {

            String sqlQuery = "";
            String q = string.Format(@"update UsersData SET Password='{0}' WHERE Login='{1}'", pass, login);

            using (DBhelper helper = new DBhelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }
        }



        public static object dataInGrid()
        {
            String sqlQuery = "";
            sqlQuery = String.Format("select * from UsersData");

            using (DBhelper helper = new DBhelper())
            {
                return helper.dataInGrid(sqlQuery);
            }

        }
    }
}
