using Microsoft.AspNetCore.Mvc;
using src.OpenaiDotnetPlayground.Services;

namespace src.OpenaiDotnetPlayground.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OpenaiController : ControllerBase
{
    private readonly Configuration _configuration;
    public OpenaiController(Configuration configuration)
    {
        _configuration = configuration;
    }

    // Crud operations

    [HttpGet("test")]
    public async Task<IActionResult> Test(){
        var vals = new List<string>();
        try
        {
            var val1 = _configuration.Testing;
            var val2 = _configuration.OpenaiApiKey;
            //var val3 = _configuration.AzureOpenAiApiKey;

            vals.Add(val1); vals.Add(val2); //vals.Add(val3);
        }
        catch (Exception ex)
        {
            vals.Add($"Error for config vals: {ex}");
        }
        
        return Ok(vals);
    }
}