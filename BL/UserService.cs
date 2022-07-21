using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BL;
using DAL;
namespace BL
{
    public class UserService
    {//Register Function
        
        public UserDTO AddUser(UserDTO user)
        {
            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
                users newUser = MapperGlobal.mapper.Map<users>(user);
                newUser = db.users.Add(newUser);
                db.SaveChanges();
                return MapperGlobal.mapper.Map<UserDTO>(newUser);
            }
        }

        public int getAllUsers()
        {
            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
                List<users> d = db.users.ToList();
                //MapperGlobal.mapper.Map<List<UserDTO>>(d)
                return d.Count();
            }
        }

        public UserDTO UpdateUser(int userId)
        {
            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
                users newUser = db.users.FirstOrDefault(x => x.userId == userId);
                if (newUser != null)
                {
                    newUser.isActive = false;
                }
                db.users.Add(newUser);

                db.SaveChanges();
                return MapperGlobal.mapper.Map<UserDTO>(newUser);
            }
        }
        public UserDTO IsUser(users u)
        {

            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
               users theUser=db.users.FirstOrDefault(x => x.userName == u.userName  && x.password == u.password&&x.mail==u.mail);
                return MapperGlobal.mapper.Map<UserDTO>(theUser);
                
            }

        }
        public UserDTO UserEmailService(int userId,int c)
        {
            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
                
                users newUser = db.users.FirstOrDefault(x => x.userId == userId);
                if (c == 0)
                {
                    newUser.isPriemum = false;
                }

                else if (newUser != null)
                {
                    newUser.isPriemum = true;
                }
                db.SaveChanges();
                return MapperGlobal.mapper.Map<UserDTO>(newUser);
            }
        }
    }
    }