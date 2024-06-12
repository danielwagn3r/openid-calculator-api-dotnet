using CalcApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalcApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoubleController : ControllerBase
    {
        private readonly ILogger _logger;

        public DoubleController(ILogger<DoubleController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{number}")]
        [Authorize("calc:double")]
        public JsonResult Get(int number)
        {
            _logger.LogInformation("Get double of {number}", number);

            return new JsonResult(new ResultModel { Result = number * 2 });
        }
    }
}
