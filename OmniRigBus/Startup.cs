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

            rig = ORig.Instance;
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API")).
            EnableSwaggerUi();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }
    }
}
