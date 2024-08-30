using BuildingBlocks.CQRS;
using PostgresGpt.ApiService.Models;
using PostgresGpt.ApiService.Services;

namespace PostgresGpt.ApiService.Chat.GetChatCompletion
{
    public record GetChatCompletionCommand(string SessionId, string PromptText) : ICommand<GetChatCompletionResult>;

    public record GetChatCompletionResult(Message? Message);


    public class GetChatCompletionHandler (ChatService service)
        : ICommandHandler<GetChatCompletionCommand, GetChatCompletionResult>
    {
        public async Task<GetChatCompletionResult> Handle(GetChatCompletionCommand request, CancellationToken cancellationToken)
        {
            var result = await service.GetChatCompletionAsync(request.SessionId, request.PromptText);
            return new GetChatCompletionResult(result);
        }
    }
}
