using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class itemDTO
    {
        public int itemId { get; set; }
        public string itemPlace { get; set; }
        public Nullable<int> categoryCode { get; set; }
        public string itemDescription { get; set; }
        public string nameFinder { get; set; }
        public string phoneFinder { get; set; }
        public Nullable<bool> isBargain { get; set; }
        public Nullable<int> imageCode { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string color { get; set; }
        public ImageDTO Image { get; set; }
        
    }
}
