using Entities_assign3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_assign3
{
    public class FolderBO
    {
        public static List<FolderDTO> GetFolderNames(int id,int pid)
        {
            return DAL_assign3.FolderDAO.GetFolderNames(id, pid);
        }
        public static int Save(String fName, int pid, int uid)
        {
            return DAL_assign3.FolderDAO.Save(fName, pid, uid);
        }
        public static bool IsExistingFolder(String fName, int pid)
        {
            return DAL_assign3.FolderDAO.IsExistingFolder(fName, pid);

        }


    }
}
