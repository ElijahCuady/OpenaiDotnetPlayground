using Microsoft.Extensions.DependencyInjection;
using src.OpenaiDotnetPlayground.Services;
using OpenAI.Chat;

namespace src.OpenaiDotnetPlayground.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddOpenAIServices(this IServiceCollection services)
        {
            services.AddSingleton<Configuration>();

            // Register ChatClient as a service
            services.AddSingleton<ChatClient>(sp =>
            {
                var configuration = sp.GetRequiredService<Configuration>();
                return new ChatClient(model: "gpt-4o-mini", configuration.OpenaiApiKey);
            });
        }
    }
}
