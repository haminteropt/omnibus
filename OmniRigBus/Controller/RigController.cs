using Newtonsoft.Json;
using OmniRigBus.RestRig;
using RigBus;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace OmniRigBus.Controller
{
    public class Freq
    {
        public int rigId { get; set; }
        public int freq { get; set; }
    }
    public class Mode
    {
        public int rigId { get; set; }
        public string mode { get; set; }
    }
    //[RoutePrefix("v1/RigBus/Rigs")]
    public class OmniRigController : ApiController
    {
        private Rigs rigs = Rigs.Instance;
        private OmniRigInterface oRig = OmniRigInterface.Instance;

        public OmniRigController()
        {

        }
        // GET api/rig 
        [Route("api/RigBus/V1/RigsInfo")]
        public Rigs Get()
        {
            oRig.GetRigState(0);
            oRig.GetRigState(1);
            return rigs;
        }

        // GET api/rig/5 
        [Route("api/RigBus/V1/RigsInfo/{id:int}")]
        public RigState Get(int id)
        {

            
            if (id != 1 && id != 2)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            id--;
            oRig.GetRigState(id);
            return rigs.RigList[id];
        }


        [Route("api/RigBus/V1/freq")]
        public void PutFreq([FromBody]Freq value)
        {
            if (value.rigId != 1 && value.rigId != 2)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Console.WriteLine("rig {0} freq value: {1}",value.rigId, value.freq);
            oRig.setFreq(value.rigId - 1, value.freq);
        }

        [Route("api/RigBus/V1/mode")]
        public void PutMode([FromBody]Mode value)
        {
            if (value.rigId != 1 && value.rigId != 2)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Console.WriteLine("rig {0} freq value: {1}", value.rigId, value.mode);
            oRig.setMode(value.rigId - 1, value.mode);
        }
        [Route("api/RigBus/V1/setRig/{id:int}")]
        public void Put(int id, [FromBody]RigState value)
        {
            oRig.SetRigState(id - 1, value);
        }

    }
}
