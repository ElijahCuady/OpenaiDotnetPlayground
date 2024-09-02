using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;
using src.OpenaiDotnetPlayground.Services;

namespace src.OpenaiDotnetPlayground.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OpenaiController : ControllerBase
{
    private readonly Configuration _configuration;
    private readonly ChatClient _client;

    public OpenaiController(Configuration configuration, ChatClient client)
    {
        _configuration = configuration;
        _client = client;
    }


    [HttpPost("sendRequest")]
    public async Task<IActionResult> SendRequest(){
        try{
            List<UserChatMessage> messages = new List<UserChatMessage>();
            String stringPrompt = "Say good morning!";
            UserChatMessage prompt = new UserChatMessage(stringPrompt);
            messages.Add(prompt);
            CustomPrinter.Print(prompt.ToString()!, "Prompt");

            ChatCompletion chatCompletion = _client.CompleteChat(messages);
            CustomPrinter.Print(chatCompletion.ToString() ?? "Empty", "ChatCompletion");

            Console.WriteLine("\n\nHello\n\n");
            Console.WriteLine(chatCompletion);

            return Ok(chatCompletion);
        } catch(Exception ex){
            return BadRequest(ex);
        }
    }

    [HttpGet("test")]
    public async Task<IActionResult> Test(){
        var vals = new List<string>();
        try
        {
            var val1 = _configuration.OpenaiApiKey;
            var val2 = _configuration.Testing;
            //var val3 = _configuration.AzureOpenAiApiKey;

            CustomPrinter.Print(val2, "testing");

            vals.Add(val1); vals.Add(val2); //vals.Add(val3);
        }
        catch (Exception ex)
        {
            vals.Add($"Error for config vals: {ex}");
        }
        
        return Ok(vals);
    }
}