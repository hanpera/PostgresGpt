using Carter;
using Mapster;
using MediatR;
using PostgresGpt.ApiService.Models;

namespace PostgresGpt.ApiService.Chat.Sessions.GetAllSessions
{
    // GetSessions

    public record  GetAllSessionsResponse (IEnumerable<Session> Sessions);

    public class GetAllSessionsEndpoint
         : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/sessions", async ( ISender sender) =>
            {
                var query = new GetSessionsQuery();
                var result = await sender.Send(query);
                var response = result.Adapt<GetSessionsResult>();
                return Results.Ok(response);
            })
            .WithName("GetSessions")
            .Produces<GetAllSessionsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get all sessions")
            .WithDescription("Get all sessions");
        }
    }
}
