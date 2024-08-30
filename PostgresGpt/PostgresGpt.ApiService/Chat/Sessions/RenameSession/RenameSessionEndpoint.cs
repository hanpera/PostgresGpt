using Carter;
using Mapster;
using MediatR;

namespace PostgresGpt.ApiService.Chat.Sessions.RenameSession
{
    public record RenameSessionRequest(string Id, string Name);

    //public record RenameSessionResponse();

    public class RenameSessionEndpoint (ISender sender)
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapPut("/sessions/",
                async (RenameSessionRequest request, ISender sender) =>
                {
                    var command = request.Adapt<RenameSessionCommand>();
                    var result = await sender.Send(command);
                    //var response = result.Adapt<UpdateProductResponse>();
                    return Results.NoContent();
                })
            .WithName("RenameSession")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            //.ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Rename session")
            .WithDescription("Rename session");
        }

    }
}
