using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAD_BAL
{
    public class AdminBO
    {
        public static bool IsValidUser(String name, String pass)
        {
            return EAD_DAL.AdminDAO.IsValidUser(name, pass);
        }
    }
}
