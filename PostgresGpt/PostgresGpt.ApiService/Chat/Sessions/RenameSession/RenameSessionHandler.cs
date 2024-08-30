using BuildingBlocks.CQRS;
using MediatR;
using PostgresGpt.ApiService.Services;

namespace PostgresGpt.ApiService.Chat.Sessions.RenameSession
{
    public record  RenameSessionCommand(string Id , string Name) : ICommand;

    //public record RenameSessionResult();

    public class RenameSessionHandler (ChatService service)
        : ICommandHandler<RenameSessionCommand>
    {
        public async Task<Unit> Handle(RenameSessionCommand request, CancellationToken cancellationToken)
        {
            await service.RenameChatSessionAsync(request.Id, request.Name);
            return new Unit();
        }
    }

}
