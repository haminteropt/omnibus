using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;

namespace OmniRigBus.Controller
{
    public class RigController : ApiController
    {
        private RigState rigState = RigState.Instance;
        public RigController()
        {

        }
        // GET api/rig 
        public RigState Get()
        {
            return rigState;
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "Hello", "World" };
        //}

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
