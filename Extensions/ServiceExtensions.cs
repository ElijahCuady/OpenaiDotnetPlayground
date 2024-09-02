using Microsoft.Extensions.DependencyInjection;
using src.OpenaiDotnetPlayground.Services;
using OpenAI.Chat;
using OpenAI;

namespace src.OpenaiDotnetPlayground.Extensions
{
    public static class ServiceExtensions
    {
    
        public static void AddOpenAIServices(this IServiceCollection services)
        {
            services.AddSingleton<Configuration>();

            // Register ChatClient as a service
            services.AddSingleton<OpenAIClient>(sp =>
            {
                var configuration = sp.GetRequiredService<Configuration>();
                return new OpenAIClient(configuration.OpenaiApiKey);
            });
        }
    
    }
}
