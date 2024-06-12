using CalcApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalcApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SquareController : ControllerBase
    {
        private readonly ILogger _logger;

        public SquareController(ILogger<SquareController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{number}")]
        [Authorize("calc:square")]
        public JsonResult Get(int number)
        {
            _logger.LogInformation("Get dousquareble of {number}", number);

            return new JsonResult(new ResultModel { Result = number * number });
        }
    }
}
