using Newtonsoft.Json;
using OmniRigBus.RestRig;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace OmniRigBus.Controller
{
    //[RoutePrefix("v1/OmniRig/Rigs")]
    public class OmniRigController : ApiController
    {
        private Rigs rigs = Rigs.Instance;
        private ORig oRig = ORig.Instance;

        public OmniRigController()
        {

        }
        // GET api/rig 
        [Route("api/OmniRig/V1/RigsInfo")]
        public Rigs Get()
        {
            oRig.GetRigState(0);
            oRig.GetRigState(1);
            return rigs;
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "Hello", "World" };
        //}

        // GET api/rig/5 
        [Route("api/OmniRig/V1/{id:int}")]
        public RigState Get(int id)
        {

            
            if (id != 1 && id != 2)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            id--;
            oRig.GetRigState(id);
            return rigs.RigList[id];
        }

        // POST api/demo 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/OmniRig/5 
        public void Put(int id, [FromBody]RigState value)
        {
            oRig.SetRigState(id - 1, value);
        }

    }
}
