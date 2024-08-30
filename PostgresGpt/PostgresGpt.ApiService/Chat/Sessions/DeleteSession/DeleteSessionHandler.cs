using BuildingBlocks.CQRS;
using MediatR;
using PostgresGpt.ApiService.Services;

namespace PostgresGpt.ApiService.Chat.Sessions.DeleteSession
{
    public record DeleteSessionCommand(string id) : ICommand; 

    //public record DeleteSessionResult();

    public class DeleteSessionHandler (ChatService service)
        : ICommandHandler<DeleteSessionCommand>
    {
        public async Task<Unit> Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
        {
            await service.DeleteChatSessionAsync(request.id);
            return new Unit();
        }
    }

}
