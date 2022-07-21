using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;
using DTO;
namespace API.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class CategoryController : ApiController
    {
        CategoryService service = new CategoryService();
        [HttpGet]
        public List<categoryDTO> getAllCategory()
        {
            return service.GetAllCategory();
        }

    }
}
