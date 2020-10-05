using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using NortB.Services;

namespace NortB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Services.Services.Mongo.IUserService _userMService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger,
            IUserService userService,
            Services.Services.Mongo.IUserService userMService)
        {
            _userService = userService;
            _userMService = userMService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet]
        [Route("mongo")]

        public ActionResult GetMongo()
        {
            return Ok(_userMService.GetUsers());
        }
    }
}