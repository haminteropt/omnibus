using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OmniRigBusServer.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OmniRigBusServer.Controllers
{
    [Route("api/[controller]")]
    public class RigController : Controller
    {
        public RigController()
        {

        }
        [HttpGet]
        public IEnumerable<RadioTuningInfo> Get()
        {
            RadioTuningInfo[] rti  = { new RadioTuningInfo()};
            return rti;
        }
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
