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
    public class ItemController : ApiController
    {
        itemService service = new itemService();
        [HttpPost]
        public IHttpActionResult SetItem(itemDTO item)
        {
            if (item == null)
                return NotFound();
            return Ok(service.SetItem(item));
        }
        [HttpGet]
        public IHttpActionResult GetAllItems(int type, bool isBargin, int limit, int page)
        {
            int sum = 0;
            var arr = service.getAllItems(type, isBargin, limit, page, ref sum);
            return Ok(new { arr, sum });
        }


        
        [HttpDelete]
        public IHttpActionResult DeleteItem(int itemId)
        {
            if (itemId == 0)
                return NotFound();
                return Ok(service.UpdateItem(itemId));
            
        }
        [HttpGet]
        [Route("~/api/item/Is")]

        public bool Is(int id, int colorId)
        {
            return service.Is(id, colorId);
        }
        [HttpGet]
        [Route("~/api/item/getAllItemUser")]
        public List<itemDTO> getAllItemUser(int userId)
        {
            return service.getAllItemUser(userId);
        }
        [HttpGet]
        [Route("~/api/item/countItem")]
        public int[] countItem()
        {
            return service.countItem();
        }
        [HttpPost]
        [Route("~/api/item/EditItem")]
        public IHttpActionResult EditItem(itemDTO item)
        {
            if (item == null)
                return NotFound();
            return Ok(service.EditItem(item));
        }
        [HttpGet]
        public int AllItem()
        {
            return service.AllItem();
        }

    }
}
