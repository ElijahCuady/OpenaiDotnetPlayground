using System.Text;
using Microsoft.VisualBasic;
using src.OpenaiDotnetPlayground.Models;

namespace src.OpenaiDotnetPlayground.Services;

public class CustomPrinter
{
    public static void Print(string objToString, string objName){
        StringBuilder sb = new StringBuilder();

        sb.Append($"\n\n----------{objName}----------");
        sb.Append($"\n{objToString}\n");
        sb.Append($"----------{objName}----------\n\n");

        Console.WriteLine(sb.ToString());
    }

    public static void FormatCustomChatRequest(CustomChatRequest request)
    {
        var sb = new StringBuilder();

        sb.AppendLine("\n\n******** C U S T O M  C H A T  R E Q U E S T ********");
        sb.AppendLine($"Id: {request.Id}");
        sb.AppendLine($"UserId: {request.UserId}");
        sb.AppendLine($"Messages: {request.Messages}");
        sb.AppendLine($"Model: {request.Model}");
        sb.AppendLine($"FrequencyPenalty: {request.FrequencyPenalty}");
        sb.AppendLine($"MaxTokens: {request.MaxTokens}");
        sb.AppendLine($"PresencePenalty: {request.PresencePenalty}");
        sb.AppendLine($"ResponseFormat: {request.ResponseFormat}");
        sb.AppendLine($"Seed: {request.Seed}");
        sb.AppendLine($"Temperature: {request.Temperature}");
        sb.AppendLine($"TopP: {request.TopP}");
        sb.AppendLine($"User: {request.User}");
        sb.AppendLine($"Timestamp: {request.Timestamp}");
        sb.AppendLine("******** C U S T O M  C H A T  R E Q U E S T ********\n\n");

        Console.WriteLine(sb.ToString());
    }

}