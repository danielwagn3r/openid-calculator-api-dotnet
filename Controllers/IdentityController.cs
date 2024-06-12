using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace CalcApi.Controllers;

[Route("[controller]")]
[Authorize]
public class IdentityController : ControllerBase
{
    private readonly ILogger _logger;
    
    public IdentityController(ILogger<IdentityController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        HttpContext.GetTokenAsync("access_token").ContinueWith(task =>
        {
            if (task.IsCompletedSuccessfully)
            {
                _logger.LogInformation("Access token: {token}", task.Result);
            }
        });

        return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }
}