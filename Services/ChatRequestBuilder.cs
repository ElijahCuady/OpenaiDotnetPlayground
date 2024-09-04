using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using src.OpenaiDotnetPlayground.DTOs;
using src.OpenaiDotnetPlayground.Services;


public class ChatRequestBuilder{
    public static ChatRequest? BuildFeedbackPrompt(string modelName, FlashcardWithUserInputDTO flashcardWithUserInputDTO){
        if (flashcardWithUserInputDTO == null)
        {
            return null;
        }

        var prompt = $$"""
            CONSTRAINTS
            - Evaluate how well the student's response aligns with the correct answer
            - Format the output as JSON
           
            EXAMPLE
            Flashcard Question: "Who won the 2016 NBA Finals?"
            Correct Answer: "The Cleveland Cavaliers"
            Student's Response: "The Golden State Warriors"

            JSON Output:
            {
                "score": 2,
                "correct": false,
                "explanation": "Your answer is incorrect. The Golden State Warriors won the 2016 NBA Finals."
            }

            ASK
            Evaluate the student's response to the given flashcard question, providing a numerical score, boolean value, and a detailed feedback in JSON format.
            Flashcard Question: "{{flashcardWithUserInputDTO.Front}}"
            Correct Answer: "{{flashcardWithUserInputDTO.Back}}"
            Student's Response: "{{flashcardWithUserInputDTO.UserAnswer}}"
            """;

        //Console.WriteLine($"Entire Prompt:\n{prompt}");
        var messages = new List<Message>
        {
            new Message(Role.User, prompt),
        };
        var model = new Model(modelName);

        var chatRequest = new ChatRequest(messages, model, maxTokens: 150, seed: 905, responseFormat: ChatResponseFormat.Json);
        //CustomPrinter.Print(chatRequest.ToString()!, "chatRequest");


        return chatRequest;
    }
}

