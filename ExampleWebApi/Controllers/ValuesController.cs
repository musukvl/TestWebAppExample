using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ExampleWebApi.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public DataController(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("environment")]
        public ActionResult<string> GetEnv()
        {
            return _hostingEnvironment.EnvironmentName;
        }


        [HttpGet]
        [Route("config-param")]
        public ActionResult<string> GetConfigParameter()
        {
            return _configuration["AppConfig"];
        }
    }
}
