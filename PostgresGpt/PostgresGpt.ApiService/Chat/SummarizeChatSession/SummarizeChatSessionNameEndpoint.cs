using Carter;
using Mapster;
using MediatR;
using PostgresGpt.ApiService.Chat.Sessions.InsertSession;

namespace PostgresGpt.ApiService.Chat.SummarizeChatSession
{
    public record SummarizeChatSessionNameRequest(string SessionId);

    public record SummarizeChatSessionNameResponse(string CompletionText);

    public class SummarizeChatSessionNameEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/chat/summarize",
                    async (SummarizeChatSessionNameRequest request, ISender sender) =>
                    {
                        var command = request.Adapt<SummarizeChatSessionNameCommand>();
                        var result = await sender.Send(command);
                        var response = result.Adapt<SummarizeChatSessionNameResponse>();
                        return Results.Ok(response);
                    })
                .WithName("SummarizeChatSessionName")
                .Produces<SummarizeChatSessionNameResponse>()
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Summarize chat session name")
                .WithDescription("Summarize chat session name");
        }
    }
}
