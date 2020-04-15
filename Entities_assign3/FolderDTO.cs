using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_assign3
{
    public class FolderDTO
    {
        public int UserID { get; set; }
        public int folderId { get; set; }
        public int parentFolderId { get; set; }
        public String FolderName { get; set; }
    }
}
