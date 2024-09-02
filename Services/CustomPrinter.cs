using System.Text;
using Microsoft.VisualBasic;

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
}