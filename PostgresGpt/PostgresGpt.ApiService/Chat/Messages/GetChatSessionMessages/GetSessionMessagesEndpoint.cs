using BuildingBlocks.CQRS;
using Carter;
using Mapster;
using MediatR;
using PostgresGpt.ApiService.Chat.Sessions.GetAllSessions;
using PostgresGpt.ApiService.Models;

namespace PostgresGpt.ApiService.Chat.Messages.GetChatSessionMessages
{
    public record GetChatSessionMessagesRequest(string sessionId);

    public record GetChatSessionMessagesResponse(IEnumerable<Message> Messages);

    public class GetSessionMessagesEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/sessions/{sessionId}/messages", async ([AsParameters] GetChatSessionMessagesRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetChatSessionMessagesQuery>();
                var result = await sender.Send(query);
                var response = result.Adapt<GetChatSessionMessagesResponse>();
                return Results.Ok(result);
            })
            .WithName("GetSessionMessages")
            .Produces<GetChatSessionMessagesResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get session messages")
            .WithDescription("Get sessions messages");
        }
    }
}
