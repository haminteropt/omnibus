using Microsoft.Owin.Cors;
using Owin;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OmniRigBus
{
    class Startup
    {
        private ORig rig;
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            rig = ORig.Instance;
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.EnableSwagger(c => c.SingleApiVersion("v1", "OmniRigBus Control OmniRig via RigBus")).
            EnableSwaggerUi();

            config.MapHttpAttributeRoutes();


            app.UseWebApi(config);
        }
    }
}
