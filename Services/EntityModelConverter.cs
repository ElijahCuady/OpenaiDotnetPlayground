using OpenAI;
using Newtonsoft.Json;
using src.OpenaiDotnetPlayground.DTOs;
using src.OpenaiDotnetPlayground.Models;
using System.Diagnostics;
using System.Text;
using OpenAI.Chat;

namespace src.OpenaiDotnetPlayground.Services;

public class EntityModelConverter
{
    
    public static CustomChatRequest ConvertToCustomChatRequest(ChatRequest chatRequest)
    {
        CustomChatRequest customChatRequest = new CustomChatRequest
        {
            Messages = parseMessagesForStoring(chatRequest.Messages),
            Model = chatRequest.Model,
            FrequencyPenalty = chatRequest.FrequencyPenalty,
            MaxTokens = chatRequest.MaxTokens,
            PresencePenalty = chatRequest.PresencePenalty,
            ResponseFormat = chatRequest.ResponseFormat.ToString(),
            Seed = chatRequest.Seed,
            Temperature = chatRequest.Temperature,
            TopP = chatRequest.TopP,
            User = chatRequest.User,
            Timestamp = DateTime.Now
        };

        return customChatRequest;
    }

    public static string parseMessagesForStoring(IReadOnlyList<Message> messages){
        StringBuilder sb = new();

        foreach (var message in messages){
            sb.AppendLine($"Role: {message.Role}");
            sb.AppendLine($"Name: {message.Name}");
            sb.AppendLine($"Message:\n{message.Content}");
        }

        return sb.ToString();
    }
    
    public static CustomChatResponse ConvertToCustomChatResponse(ChatResponse response, Stopwatch sw)
    {
        CustomChatResponse chatResponse = new()
        {
            Created = response.CreatedAtUnixTimeSeconds,
            Model = response.Model,
            SystemFingerprint = response.SystemFingerprint,
            Message = response.Choices[0].Message.Content.ToString(),
            PromptTokens = response.Usage.PromptTokens,
            CompletionTokens = response.Usage.CompletionTokens,
            TotalTokens = response.Usage.TotalTokens,
            Latency = sw.Elapsed.TotalSeconds,
            Timestamp = DateTime.Now,
        };

        return chatResponse;
    }
    
    public static Feedback ConvertToFeedback(FlashcardWithUserInputDTO flashcardWithUserInputDTO, FeedbackDTO feedbackDTO)
    {
        Feedback feedback = new Feedback();

        feedback.FlashcardId = flashcardWithUserInputDTO.FlashcardId;
        feedback.Front = flashcardWithUserInputDTO.Front;
        feedback.Back = flashcardWithUserInputDTO.Back;
        feedback.UserAnswer = flashcardWithUserInputDTO.UserAnswer;
        feedback.Correct = feedbackDTO.Correct;
        feedback.Score = feedbackDTO.Score;
        feedback.Explanation = feedbackDTO.Explanation;

        return feedback;
    }


    /*
    public static AiDistractorsSet ConvertToAiDistractorsSet(Deck deck, ChatRequest chatRequest, ChatResponse chatResponse)
    {
        AiDistractorsSet aiDistractorsSet = new AiDistractorsSet();
        aiDistractorsSet.ChatRequestId = chatRequest.Id;
        aiDistractorsSet.ChatResponseId = chatResponse.Id;
        aiDistractorsSet.DeckId = deck.DeckId;
        if(deck.Flashcards == null)
        {
            aiDistractorsSet.CountFlashcards = 0;
        }
        else
        {
            aiDistractorsSet.CountFlashcards = deck.Flashcards.Count;
        }

        aiDistractorsSet.RawOutput = chatResponse.MessageContent;

        int countDistractorsGenerated = DistractorsAreParseable(chatResponse.MessageContent, deck);

        if(countDistractorsGenerated >= 0)
        {
            aiDistractorsSet.OutputParseable = true;
        }
        else
        {
            aiDistractorsSet.OutputParseable = false;
        }
        aiDistractorsSet.DistractorsGeneratedCount = countDistractorsGenerated;

        return aiDistractorsSet;
    }

    public static int DistractorsAreParseable(string rawOutput, Deck deck)
    {
        try
        {
            var questionDistractors = JsonConvert.DeserializeObject<Dictionary<string, QuestionDistractors>>(rawOutput);

            if (questionDistractors == null)
            {
                return -1;
            }

            // an enumerator for the dictionary
            using (var enumerator = questionDistractors.GetEnumerator())
            {
                for (int i = 0; i < deck.Flashcards!.Count && i < questionDistractors.Count; i++)
                {
                    // moving to the next element in the dictionary
                    if (!enumerator.MoveNext())
                    {
                        break; // This shouldn't happen given the loop condition, but just to be safe
                    }

                    // Update the flashcard with the current Distractor1
                    var currentPair = enumerator.Current; // Current is a KeyValuePair<TKey, TValue>
                    deck.Flashcards[i].Distractor1 = currentPair.Value.Distractor1;
                    deck.Flashcards[i].Distractor2 = currentPair.Value.Distractor2;

                }
            }

            return questionDistractors.Count;
        }
        catch (Exception)
        {
            return -1;
        }
    }

    public static AiDeckDetail ConvertToAiDeckDetail(int ChatRequestId, ChatResponse chatResponse, int deckId)
    {
        AiDeckDetail aiDeckDetail = new AiDeckDetail();
        aiDeckDetail.ChatRequestId = ChatRequestId;
        aiDeckDetail.ChatResponseId = chatResponse.Id;
        aiDeckDetail.DeckId = deckId;
        aiDeckDetail.RawOutput = chatResponse.MessageContent;

        return aiDeckDetail;
    }
    */
}