using BuildingBlocks.CQRS;
using MediatR;
using PostgresGpt.ApiService.Services;

namespace PostgresGpt.ApiService.Chat.ClearCache
{

    public record ClearCacheCommand : ICommand;
    public class ClearCacheHandler (ChatService service)
        : ICommandHandler<ClearCacheCommand>
    {
        public async Task<Unit> Handle(ClearCacheCommand request, CancellationToken cancellationToken)
        {
            await service.ClearCacheAsync();
            return new Unit();
        }
    }
}
