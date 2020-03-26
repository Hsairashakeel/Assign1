using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAD_DAL
{
    public class AdminDAO
    {
        public static bool IsValidUser(String name, string password)
        {
            String sqlQuery = "";
            sqlQuery = String.Format("select * from AdminData WHERE AdminName = '{0}' AND Password = '{1}' ", name, password);
            using (DBhelper AdminDBHelper = new DBhelper())
            {
                return AdminDBHelper.Adapter(sqlQuery);
            }
        }
    }
}
