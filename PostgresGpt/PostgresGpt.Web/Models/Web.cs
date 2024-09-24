namespace PostgresGpt.Web.Models
{
    public record GetAllSessionsResponse(List<SessionDto> Sessions);
    public record InsertSessionResponse(SessionDto Session);
    public record RenameSessionRequest(string Id, string Name);
    public record GetChatSessionMessagesRequest(string SessionId);

    public record GetChatSessionMessagesResponse(List<MessageDto> Messages);


    public record GetChatCompletionRequest(string SessionId, string PromptText);

    public record GetChatCompletionResponse(MessageDto? Message);
    public record SummarizeChatSessionNameRequest(string SessionId);

    public record SummarizeChatSessionNameResponse(string CompletionText);
}
