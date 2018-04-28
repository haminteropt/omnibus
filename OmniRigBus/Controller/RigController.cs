using System.Collections.Generic;
using System.Web.Http;

namespace OmniRigBus.Controller
{
    public class RigController : ApiController
    {
        // GET api/rig 
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello", "World" };
        }

        // GET api/rig/5 
        public string Get(int id)
        {
            return "Hello, World!";
        }

        // POST api/demo 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/demo/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/demo/5 
        public void Delete(int id)
        {
        }

    }
}
