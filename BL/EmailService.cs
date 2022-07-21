using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.IO;

namespace BL
{
   public class EmailService
    {
       
            public string send(string body, string addres, string subject, string fromAddres)
            {
                using (MailMessage mm = new MailMessage("rr0583237016@gmail.com", addres))
                {
                    mm.To.Add(addres);
                    mm.Body = body;
                    mm.IsBodyHtml = true;
                    mm.Subject = subject;
                    mm.ReplyToList.Add(fromAddres);
                    SmtpClient client = new SmtpClient("smtp.gmail.com");
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Timeout = 30 * 1000;
                    client.Credentials = new NetworkCredential("rr0583237016@gmail.com", "322407651");
                    client.Port = 587;
                    client.EnableSsl = true;
                    try
                    {
                        client.Send(mm);
                        return "המייל נשלח בהצלחה";
                    }
                    catch
                    {
                        return mm.Body;
                    }
                }
            }
            public static string CurrentPath()
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string pat = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(pat);
            }
            public string ReadFile(string path)
            {
                string full = Path.Combine(CurrentPath(), path);
                // string fullPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);
                using (var reader = new StreamReader(full))
                {
                    return reader.ReadToEnd();
                }
            }

        public bool emailsend()
        {
            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
                db.users.Where(x => x.isPriemum == true).ToList().ForEach(x =>
                {
                    string innerbody = "";
                    bool hav = false;
                    db.item.Where(y => y.itemPlace == x.city).ToList().ForEach(item =>
                    {
                        hav = true;
                        innerbody += $"<div>{item.itemDescription}</div>";
                    });
                    if (hav)
                    {

                        try
                        {

                            string body = ReadFile(@"./html/AllDay.html");
                            body = body.Replace("{cityName}", x.city);
                            body = body.Replace("{userName}", x.userName);

                            body = body.Replace("{List}", innerbody);
                            send(body,x.mail , "סיכום מוצרים שקיימים במערכת", "rr0583237016@gmail.com");
                            //return+ MapperGlobal.mapper.Map<EmailDTO>(newUseEmail)
                        }
                        catch (Exception e)
                        {
                            //return false;
                        }
                    }
                });
            }
            return true;
        }
            }
}
