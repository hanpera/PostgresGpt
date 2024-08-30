using BuildingBlocks.CQRS;
using PostgresGpt.ApiService.Models;
using PostgresGpt.ApiService.Services;
using System.Windows.Input;

namespace PostgresGpt.ApiService.Chat.Sessions.InsertSession
{
    public record InsertSessionCommand() : ICommand<InsertSessionResult>;

    public record InsertSessionResult(Session Session);

    public class InsertSessionHandler(ChatService service)
        : ICommandHandler<InsertSessionCommand, InsertSessionResult>
    {
        public async Task<InsertSessionResult> Handle(InsertSessionCommand request, CancellationToken cancellationToken)
        {
            return new InsertSessionResult(await service.CreateNewChatSessionAsync());
        }
    }
}
