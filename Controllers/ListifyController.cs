using Microsoft.AspNetCore.Mvc;

namespace RangerWebAPI.Controllers;

using Models;
using Types;

[ApiController]
[Route("[controller]")]
public class ListifyController : ControllerBase
{
    private readonly ILogger<ListifyController> _logger;

    public ListifyController(ILogger<ListifyController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] GetValueAtIndexInRangeDto model)
    {
        try
        {
            // Define new Ranger
            // ReSharper disable once CollectionNeverUpdated.Local
            var ranger = new Ranger(model.Begin, model.End);

            // Get value at index
            var value = ranger[model.GetAtIndex];

            // Log information
            _logger.LogInformation("Value of {Name}({Begin}, {End}) at index {Index} requested. Value is {Value}).",
                nameof(Ranger),
                model.Begin,
                model.End,
                model.GetAtIndex,
                value);

            // Return 200 OK with value
            return StatusCode(200, value);
        }
        catch (Exception ex)
        {
            ObjectResult errorResult;
            switch (ex)
            {
                // Thrown when begin or end are out of acceptable range
                case ArgumentOutOfRangeException:
                // Thrown when index is out of range
                case IndexOutOfRangeException:
                    errorResult = StatusCode(400, ex.Message);
                    break;

                // Something else went wrong (internal server error)
                default:
                    errorResult = StatusCode(500, "An error has occured.");
                    break;
            }

            // Log error
            _logger.LogError("Value of {Name}({Begin}, {End}) at index {Index} requested. Status {Code} returned. Exception: \"{ExceptionMessage}\".",
                nameof(Ranger),
                model.Begin,
                model.End,
                model.GetAtIndex,
                errorResult.StatusCode,
                ex.Message);

            // Return 4**/5**
            return errorResult;
        }
    }
}
