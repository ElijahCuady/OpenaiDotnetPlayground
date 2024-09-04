using System.Diagnostics;
using System.Text;


namespace src.OpenaiDotnetPlayground.Models
{
    public class CustomChatResponse
    {
        public int Id { get; set; }  // Unique identifier for the chat completion
        public int UserId { get; set; }  // User identifier
        public int Created { get; set; }  // Unix timestamp of when the chat completion was created
        public string Model { get; set; } = string.Empty;  // Model used for the chat completion
        public string SystemFingerprint { get; set; } = string.Empty;  // Fingerprint representing the backend configuration
        public string Message { get; set; } = string.Empty;  // Represents the main message or result of the chat
        public int? PromptTokens { get; set; }  // Number of tokens in the prompt
        public int? CompletionTokens { get; set; }  // Number of tokens in the completion
        public int? TotalTokens { get; set; }  // Total number of tokens used (prompt + completion)
        public double Latency { get; set; }  // Latency of the chat completion request

        public DateTime Timestamp { get; set; }  // Timestamp of when the response was recorded
    }
}
