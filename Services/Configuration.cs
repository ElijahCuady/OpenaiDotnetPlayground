namespace src.OpenaiDotnetPlayground.Services;

public class Configuration
{
    private readonly IConfiguration _configuration;

    public Configuration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string OpenaiApiKey => _configuration["Openai:ApiKey"]!;
    public string Testing => _configuration["Openai:Testing"]!;
}