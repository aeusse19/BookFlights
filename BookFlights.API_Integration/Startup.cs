using BookFlights.Business.Data;
using Owin;

namespace BookFlights.API_Integration
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //Configure the db context to use a single instance for request
            app.CreatePerOwinContext(BookFlightsContext.Create);
        }
    }
}
