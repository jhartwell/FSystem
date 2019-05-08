using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSystem.Api.Model;
using FSystem.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSystem.Api.Controllers
{
    [Route("[controller]")]
    public class RecordsController : Controller
    {
        private const string SystemKey = "SYSTEM";
        private IInputService inputService;
        private IOutputService outputService;
        private IDataStore dataStore;

        public RecordsController(IInputService inputService, IOutputService outputService, IDataStore dataStore)
        {
            this.inputService = inputService;
            this.outputService = outputService;
            this.dataStore = dataStore;
        }

        [HttpGet]
        public ActionResult<string> Index()
        {
            var key = GetKey(Request);
            return outputService.Save(dataStore.GetData(key));
        }

        private string GetKey(HttpRequest request)
        {
            var key = SystemKey;
            if(request.Query.ContainsKey("session"))
            {
                key = request.Query["session"];
            }
            return key;
        }
        [HttpGet("{sortBy}")]
        public ActionResult<string> Sorted(string sortBy)
        {
            var key = GetKey(Request);
            var records = dataStore.GetData(key);
            switch (sortBy.ToLower())
            {
                case "gender":
                    records = records.OrderBy(x => x.Gender);
                    break;
                case "name":
                    records = records.OrderBy(x => x.LastName);
                    break;
                case "birthdate":
                    records = records.OrderBy(x => x.DateOfBirth);
                    break;
            }
            return outputService.Save(records);
        }

        [HttpPost]
        public async Task Post()
        {
            /*
             * unfortunately ASP.NET Core Web API freaks out 
             * when passing in plain text and using [FromBody] string value
             * as a method parameter. We have to read the body manually
             */
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                var records = inputService.GetCommaDelimitedRecords(body);
                var key = GetKey(Request);
                dataStore.Add(key, records);
            }
        }
    }
}
