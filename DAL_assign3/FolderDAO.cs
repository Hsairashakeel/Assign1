using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_assign3;
namespace DAL_assign3
{
    public static class  FolderDAO
    {
        public static int Save(String fName , int pid , int uid)
        {
            String sqlQuery = "";
            sqlQuery = String.Format("INSERT INTO [dbo].[folders](folderName,parentFolderId,userId)VALUES('{0}','{1}','{2}')",
             fName, pid, uid);

            using (FolderHelper helper = new FolderHelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }
        }
        public static bool IsExistingFolder(String fName,int pid)
        {
            String sqlQuery = "";
            sqlQuery = String.Format("select * from folders WHERE folderName = '{0}' AND parentFolderId = '{1}'",fName,pid);
            using (FolderHelper helper = new FolderHelper())
            {
                return helper.Adapter(sqlQuery);
            }
        }

        public static List<FolderDTO> GetFolderNames(int id,int pid)
        {
            string sqlQuery = String.Format("select * from folders WHERE userId = '{0}' AND parentFolderId='{1}'", id,pid);
            using(FolderHelper helper=new FolderHelper())
            {
                var reader = helper.ExecuteReader(sqlQuery);
                List<FolderDTO> names = new List<FolderDTO>();
                while(reader.Read())
                {
                    var dto = fillDTO(reader);
                    if(dto!=null)
                    {
                        names.Add(dto);
                    }
                }
                return names;
            }
        }
        public static FolderDTO fillDTO(SqlDataReader reader)
        {
            var dto = new FolderDTO();
            dto.folderId = reader.GetInt32(0);
            dto.FolderName = reader.GetString(1);
            dto.parentFolderId = reader.GetInt32(2);
            dto.UserID = reader.GetInt32(3);
            return dto;
        }
    }
}
