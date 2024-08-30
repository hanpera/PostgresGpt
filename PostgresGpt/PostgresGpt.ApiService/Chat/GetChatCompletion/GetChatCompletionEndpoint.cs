using Carter;
using Mapster;
using MediatR;
using PostgresGpt.ApiService.Chat.Messages.GetChatSessionMessages;
using PostgresGpt.ApiService.Models;

namespace PostgresGpt.ApiService.Chat.GetChatCompletion
{
    public record GetChatCompletionRequest(string SessionId, string PromptText);

    public record GetChatCompletionResponse(Message? Message);

    public class GetChatCompletionEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/chat", async (GetChatCompletionRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetChatCompletionCommand>();
                var result = await sender.Send(query);
                var response = result.Adapt<GetChatCompletionResponse>();
                return Results.Ok(result);
            })
            .WithName("GetChatCompletion")
            .Produces<GetChatCompletionResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get chat completion")
            .WithDescription("Get chat completion");
        }
    }
}
