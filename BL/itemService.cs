using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BL
{
   public class itemService
    {
        public itemDTO SetItem(itemDTO item)
        {
            using(lostFoundDBEntities db =new lostFoundDBEntities())
            {
                item newItem = MapperGlobal.mapper.Map<item>(item);
                newItem = db.item.Add(newItem);
                newItem.colorId = setColor(item.color);
                db.SaveChanges();
                return MapperGlobal.mapper.Map<itemDTO>(newItem);
            }
        }

        public int setColor(string color)
        {
            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
                //  color newcolor = MapperGlobal.mapper.Map<color>(color);

                if (!db.color.Any(x => x.colorDescription == color.Trim()))
                {
                    color newcolor = db.color.Add(new DAL.color { colorDescription = color });
                    db.SaveChanges();
                    return newcolor.colorId;
                    // return MapperGlobal.mapper.Map<colorDTO>(newcolor);

                }
                else
                {

                    color Iscolor = db.color.FirstOrDefault(x => x.colorDescription == color.Trim());
                    return Iscolor.colorId;
                }

            }
        }

        public List<itemDTO> getAllItems(int type, bool isBargain, int limit, int page, ref int sum)
        {
            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
                int[] baginT = new int[8];
                int from = (page) * limit;
                List<item> p = db.item.Where(x => x.categoryCode == type && x.isBargain == isBargain && x.isActive == true).ToList();
                sum = p.Count();
                if (sum < from)
                    return null;
                if (sum < from + limit)
                {
                    limit = sum - from;
                }
                p = p.GetRange(from, limit).ToList();
                List<itemDTO> f = MapperGlobal.mapper.Map<List<itemDTO>>(p);

                return f;


            }
        }
        public int AllItem()
        {
            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
                List<item> d = db.item.ToList();
                //MapperGlobal.mapper.Map<List<UserDTO>>(d)
                return d.Count();
          


            }
        }
        public int[] countItem()
        {
            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
                int[] count = new int[8];
                int sum = db.item.Count();
                for (int i = 0; i < 8; i++)
                {
                    List<item> p = db.item.Where(x => x.categoryCode == i+1).ToList();
                    // List<itemDTO> f = MapperGlobal.mapper.Map<List<itemDTO>>(p);
                    
                    count[i]=((p.Count()*100)/sum);
                }
                
                return count;


            }
        }

        public itemDTO UpdateItem(int itemId)
        {
        using (lostFoundDBEntities db=new lostFoundDBEntities())
            {
                item newItem = db.item.FirstOrDefault(x => x.itemId == itemId);
                if (newItem != null)
                {
                    newItem.isActive = false;
                }
                db.SaveChanges();
                return MapperGlobal.mapper.Map<itemDTO>(newItem);
            }
        
        }
        public bool Is(int id, int colorId)
        {

            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
                return db.item.Any(x => x.colorId == colorId && x.itemId == id);

            }

        }
        public List<itemDTO> getAllItemUser(int userId)
        {
            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
                List<item> p = db.item.Where(x => x.userId == userId&&x.isActive==true).ToList();
                List<itemDTO> f = MapperGlobal.mapper.Map<List<itemDTO>>(p);
                return f;
            }
        }
        public itemDTO EditItem(itemDTO item)
        {
            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
                item newItem = db.item.FirstOrDefault(x => x.itemId == item.itemId);
                if (newItem != null)
                {
                    newItem.categoryCode = item.categoryCode;
                    newItem.itemPlace = item.itemPlace;
                    newItem.itemDescription = item.itemDescription;
                    newItem.nameFinder = item.nameFinder;
                    newItem.phoneFinder = item.phoneFinder;
                    newItem.isBargain = item.isBargain;
                    newItem.colorId = setColor(item.color);
                    // newItem.Image =item.Image;


                }
                db.SaveChanges();
                return MapperGlobal.mapper.Map<itemDTO>(newItem);
            }
        }


    }

}
