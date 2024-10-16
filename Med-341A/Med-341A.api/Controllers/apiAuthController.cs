using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace Med_341A.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class apiAuthController : ControllerBase
    {
        private readonly Med341aContext db;
        private VMResponse response;

        public apiAuthController()
        {
            // constructor apiAuthController
        }
    }
}
