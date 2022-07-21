using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class colorService
    {
        public List<colorDTO> getAllColors(int type, int key)
        {

            Random r = new Random();

            color[] arr = new color[5];

            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {

                color[] c = db.color.Where(x => x.item.Any(y => y.categoryCode == type)).ToArray();
                arr[0] = c.FirstOrDefault(x => x.item.Any(y => y.itemId == key));
                c = c.Where(x => !x.item.Any(y => y.itemId == key)).ToArray();
                int i = 1;
                for (; i < 5 && c.Length > 0; i++)
                {
                    int place = r.Next(0, c.Length);

                    arr[i] = c[place];
                    c = c.Where((x, index) => index != place).ToArray();
                }
                if (i < 5)
                {
                    c = db.color.Where(x => !x.item.Any()).ToArray();
                    for (; i < 5 && c.Length > 0; i++)
                    {
                        int place = r.Next(0, c.Length);

                        arr[i] = c[place];
                        c = c.Where((x, index) => index != place).ToArray();
                    }
                }
                return MapperGlobal.mapper.Map<List<colorDTO>>(arr.ToList().OrderBy(x => x.colorDescription));
            }
        }



    } 
    }
