using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string NameImage { get; set; }
        public string ImageCaption { get; set; }
        public byte[] FileValue { get; set; }
    }
}
