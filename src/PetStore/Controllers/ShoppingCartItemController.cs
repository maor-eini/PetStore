using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PetStore.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCartItemController : Controller
    {
        // GET: api/ShoppingCartItem
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/ShoppingCartItem/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/ShoppingCartItem
        [HttpPost]
        [Route("api/ShoppingCartItem/{id}")]
        public void Post(string value)
        {
        }

        // PUT api/ShoppingCartItem/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/ShoppingCartItem/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
