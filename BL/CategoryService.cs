using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BL
{
    public class CategoryService
    {
        public List<categoryDTO> GetAllCategory()
        {
            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
               
                return MapperGlobal.mapper.Map<List<categoryDTO>>(db.category.ToList());
            }
        }

        


    }
}
