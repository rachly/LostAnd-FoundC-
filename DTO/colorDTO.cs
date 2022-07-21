using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class colorDTO
    {
        public int colorId { get; set; }
        public Nullable<int> categoryCode { get; set; }
        public Nullable<int> itemId { get; set; }
        public string colorDescription { get; set; }
    }
}
