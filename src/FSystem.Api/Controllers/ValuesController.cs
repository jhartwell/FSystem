using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSystem.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace FSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromServices] IOutputService outputService, 
            [FromServices] IInputService inputService, [FromServices] IDataStore dataStore)
        {

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromServices] IDataStore dataStore, [FromBody] string value)
        {
            dataStore.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
