using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSystem.Api.Model;
using FSystem.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FSystem.Api.Controllers
{
    [Route("api/[controller]")]
    public class RecordsController : Controller
    {
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
            var records = inputService.GetCommaDelimitedRecords(dataStore.Data);
            return outputService.Save(records);
        }

        [HttpGet("{sortBy}")]
        public ActionResult<string> Sorted(string sortBy)
        {
            var records = inputService.GetCommaDelimitedRecords(dataStore.Data);
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
        // POST api/values
        [HttpPost]
        public void Post(string value)
        {
            dataStore.Add(value);
        }
    }
}
