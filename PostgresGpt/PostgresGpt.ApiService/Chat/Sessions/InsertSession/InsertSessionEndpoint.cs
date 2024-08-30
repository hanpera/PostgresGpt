using Carter;
using Mapster;
using MediatR;
using PostgresGpt.ApiService.Models;

namespace PostgresGpt.ApiService.Chat.Sessions.InsertSession
{

    public record InsertSessionRequest();

    public record InsertSessionResponse(Session Session);

    public class InsertSessionEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/sessions",
                    async (InsertSessionRequest request, ISender sender) =>
                    {
                        var command = new InsertSessionCommand();
                        var result = await sender.Send(command);
                        var response = result.Adapt<InsertSessionResponse>();
                        return Results.Created($"/sessions/{response.Session.Id}", response);
                    })
                .WithName("InsertSession")
                .Produces<InsertSessionResponse>()
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Insert Session")
                .WithDescription("Insert Session");
        }
    }
}
