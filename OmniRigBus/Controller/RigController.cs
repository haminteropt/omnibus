using Newtonsoft.Json;
using OmniRigBus.RestRig;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace OmniRigBus.Controller
{
    [RoutePrefix("v1/OmniRig")]
    public class OmniRigController : ApiController
    {
        private Rigs rigs = Rigs.Instance;
        private ORig oRig = ORig.Instance;

        public OmniRigController()
        {

        }
        // GET api/rig 

        public Rigs Get()
        {
            oRig.SetRigState(0);
            oRig.SetRigState(1);
            return rigs;
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "Hello", "World" };
        //}

        // GET api/rig/5 
        public RigState Get(int id)
        {

            
            if (id != 1 && id != 2)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            id--;
            oRig.SetRigState(id);
            return rigs.RigList[id];
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
