using Microsoft.AspNetCore.Mvc;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using src.OpenaiDotnetPlayground.Services;

namespace src.OpenaiDotnetPlayground.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OpenaiController : ControllerBase
{
    private readonly Configuration _configuration;
    private readonly OpenAIClient _client;

    public OpenaiController(Configuration configuration, OpenAIClient client)
    {
        _configuration = configuration;
        _client = client;
    }

        [HttpPost("sendRequestGptMini")]
    public async Task<IActionResult> SendRequestGptMini(){
        try{

            var messages = new List<Message>
            {
                new Message(Role.User, "Who won the world series in 2020?"),
            };
            var model = new Model("gpt-4o-mini");

            var chatRequest = new ChatRequest(messages, model);
            CustomPrinter.Print(chatRequest.ToString()!, "chatRequest");

            var response = await _client.ChatEndpoint.GetCompletionAsync(chatRequest);
            CustomPrinter.Print(response.ToString() ?? "Empty", "chatResponse");

            var choice = response.FirstChoice;
            Console.WriteLine($"[{choice.Index}] {choice.Message.Role}: {choice.Message} | Finish Reason: {choice.FinishReason}");

            return Ok(response);
        } catch(Exception ex){
            return BadRequest(ex);
        }
    }

    [HttpPost("sendRequest")]
    public async Task<IActionResult> SendRequest(){
        try{

            var messages = new List<Message>
            {
                new Message(Role.User, "Who won the world series in 2020?"),
            };
            var chatRequest = new ChatRequest(messages, Model.GPT4o);
            CustomPrinter.Print(chatRequest.ToString()!, "chatRequest");

            var response = await _client.ChatEndpoint.GetCompletionAsync(chatRequest);
            CustomPrinter.Print(response.ToString() ?? "Empty", "chatResponse");

            var choice = response.FirstChoice;
            Console.WriteLine($"[{choice.Index}] {choice.Message.Role}: {choice.Message} | Finish Reason: {choice.FinishReason}");

            return Ok(response);
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

    /*
    Official openai lib
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
    */
    