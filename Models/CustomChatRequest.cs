using System.Diagnostics;
using System.Text;


namespace src.OpenaiDotnetPlayground.Models{
    public class CustomChatRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Messages { get; set; } = string.Empty; 
        public string Model { get; set; } = string.Empty;
        public double? FrequencyPenalty { get; set; }
        public int? MaxTokens { get; set; }
        public double? PresencePenalty { get; set; }
        public string? ResponseFormat { get; set; }
        public double? Seed { get; set; } 
        public double? Temperature { get; set; }
        public double? TopP { get; set; }
        public string? User { get; set; }
        public DateTime Timestamp { get; set; }
    }
}