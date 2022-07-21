using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class colorController : ApiController
    {
        colorService service = new colorService();

        [HttpGet]
        public List<colorDTO> getAllColors(int type, int key)
        {
            return service.getAllColors(type, key);
        }
    }
}
