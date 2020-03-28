using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAD_Entities
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public char gender { get; set; }
        public string adress { get; set; }
        public Decimal age { get; set; }
        public string nic { get; set; }
        public DateTime DOB { get; set; }
        public String imageNmae { get; set; }
        public DateTime createOn { get; set; }
        public Boolean cricket { get; set; }
        public Boolean hockey { get; set; }
        public Boolean chess { get; set; }
    }
}
