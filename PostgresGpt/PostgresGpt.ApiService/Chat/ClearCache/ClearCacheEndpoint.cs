using Carter;
using MediatR;

namespace PostgresGpt.ApiService.Chat.ClearCache
{
    public class ClearCacheEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/cache",
                async (string id, ISender sender) =>
                {
                    var command = new ClearCacheCommand();
                    var result = await sender.Send(command);
                    return Results.NoContent();
                })
            .WithName("ClearCache")
            //.Produces<DeleteProductResponse>()
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            //.ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Clear cache")
            .WithDescription("Clear cache");
        }
    }
}
