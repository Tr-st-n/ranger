using Microsoft.AspNetCore.Mvc;

namespace RangerWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RangerController : ControllerBase
{
    private readonly ILogger<RangerController> _logger;

    public RangerController(ILogger<RangerController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetValueAtIndexInRange")]
    public int Get()
    {
        // TODO: Return value at index in range
        return 0;
    }
}
