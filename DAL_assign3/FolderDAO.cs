using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_assign3;
using MySql.Data.MySqlClient;

namespace DAL_assign3
{
    public static class FolderDAO
    {
        public static int Save(String fName, int pid, int uid)
        {
            try
            {
                String MysqlQuery = "";
                MysqlQuery = String.Format("INSERT INTO folders (folderName,parentFolderId,userId)VALUES('{0}','{1}','{2}')",
                 fName, pid, uid);

                using (FolderHelper helper = new FolderHelper())
                {
                    return helper.ExecuteQuery(MysqlQuery);
                }
                 
            }
            catch(Exception e)
            {
                throw;
            }
           
        }
        public static bool IsExistingFolder(String fName, int pid)
        {
            String MysqlQuery = "";
            MysqlQuery = String.Format("select * from folders WHERE folderName = '{0}' AND parentFolderId = '{1}'", fName, pid);
            using (FolderHelper helper = new FolderHelper())
            {
                return helper.Adapter(MysqlQuery);
            }
        }

        public static List<FolderDTO> GetFolderNames(int id, int pid)
        {
            string MysqlQuery = String.Format("select * from folders WHERE userId = '{0}' AND parentFolderId='{1}'", id, pid);
            using (FolderHelper helper = new FolderHelper())
            {
                var reader = helper.ExecuteReader(MysqlQuery);
                List<FolderDTO> names = new List<FolderDTO>();
                while (reader.Read())
                {
                    var dto = fillDTO(reader);
                    if (dto != null)
                    {
                        names.Add(dto);
                    }
                }
                return names;
            }
        }
        public static FolderDTO fillDTO(MySqlDataReader reader)
        {
            var dto = new FolderDTO();
            dto.FolderName = reader.GetString(0);
            dto.parentFolderId = reader.GetInt32(1);
            dto.UserID = reader.GetInt32(2);
            dto.folderId = reader.GetInt32(3);

            return dto;
        }
    }
}
