using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class UserDTO
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public Nullable <bool> isPriemum { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string mail { get; set; }


    }
}
