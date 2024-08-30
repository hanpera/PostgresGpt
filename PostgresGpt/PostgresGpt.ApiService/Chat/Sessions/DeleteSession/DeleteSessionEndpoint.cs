using Carter;
using MediatR;

namespace PostgresGpt.ApiService.Chat.Sessions.DeleteSession
{
    public class DeleteSessionEndpoint (ISender sender)
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/sessions/{id}",
                async (string id, ISender sender) =>
                {
                    var command = new DeleteSessionCommand(id);
                    var result = await sender.Send(command);
                    
                    return Results.NoContent();
                })
            .WithName("DeleteSession")
            //.Produces<DeleteProductResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            //.ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Session")
            .WithDescription("Delete Session");
        }
    }
}
