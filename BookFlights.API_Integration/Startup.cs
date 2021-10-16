using BookFlights.Business.Data;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

namespace BookFlights.API_Integration
{
    public partial class Startup
    {
        public void ConfigurationAuth(IAppBuilder app)
        {
            //Configure the db context to use a single instance for request
            app.CreatePerOwinContext(BookFlightsContext.Create);
        }
    }
}
