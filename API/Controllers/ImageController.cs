using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DAL;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http.Cors;
using Image = DAL.Image;
using System.Reflection;

namespace API.Controllers
{
    public class ImageController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage uploadImage()
        { 
            //string imageName = null;
            var httpReqest = HttpContext.Current.Request;
            // upload image
            // var postedFile = httpReqest.Files["Image"];
            var postedFile = httpReqest.Files["Image"];
            var s = httpReqest.Params["m"];
            int m = Convert.ToInt32(s);
            //   create custom file
            string imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");

            //imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            //var filePath = HttpContext.Current.Server.MapPath("~/Images/" + imageName);
            //postedFile.SaveAs(postedFile.InputStream);
            // StreamReader sourceStream = new StreamReader(postedFile.InputStream);
            byte[] buffer = new byte[16 * 1024];
            byte[] g;
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = postedFile.InputStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                //return ms.ToArray();
                g = ms.ToArray();
            }

            // byte[] fileContents = Encoding.UTF8.GetBytes(postedFile.InputStream);
            // sourceStream.Close();
            //save to DB
            using (lostFoundDBEntities db = new lostFoundDBEntities())
            {
                var item = db.item.FirstOrDefault(x => x.itemId == m);
                Image Image = new Image()
                {
                    ImageCaption = httpReqest["ImageCaption"],
                    //ImageCaption = httpReqest["ImageCaption"],
                    NameImage = imageName,
                    FileValue = g,


                };
                Image = db.Image.Add(Image);
                db.SaveChanges();
                item.ImageId = Image.Id;
                db.SaveChanges();
                return Request.CreateResponse(Image);



            }

        
    }
            }
        }
