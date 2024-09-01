using BuildingBlocks.CQRS;
using PostgresGpt.ApiService.Services;

namespace PostgresGpt.ApiService.Chat.SummarizeChatSession
{
    public record SummarizeChatSessionNameCommand (string SessionId) : ICommand<SummarizeChatSessionNameResult>;

    public record SummarizeChatSessionNameResult(string CompletionText);

    public class SummarizeChatSessionNameHandler (ChatService service)
        : ICommandHandler<SummarizeChatSessionNameCommand, SummarizeChatSessionNameResult>
    {
        public async Task<SummarizeChatSessionNameResult> Handle(SummarizeChatSessionNameCommand request, CancellationToken cancellationToken)
        {
            var result = await service.SummarizeChatSessionNameAsync(request.SessionId);
            return new SummarizeChatSessionNameResult(result);
        }
    }
}
