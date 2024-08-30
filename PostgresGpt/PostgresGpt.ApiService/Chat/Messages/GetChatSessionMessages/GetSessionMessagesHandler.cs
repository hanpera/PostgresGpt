﻿using BuildingBlocks.CQRS;
using PostgresGpt.ApiService.Models;
using PostgresGpt.ApiService.Services;

namespace PostgresGpt.ApiService.Chat.Messages.GetChatSessionMessages
{
    public record GetChatSessionMessagesQuery(string sessionId) : IQuery<GetChatSessionMessagesResult>;

    public record GetChatSessionMessagesResult(IEnumerable<Message> Messages);
    public class GetSessionMessagesHandler(ChatService service)
        : IQueryHandler<GetChatSessionMessagesQuery, GetChatSessionMessagesResult>
    {
        public async Task<GetChatSessionMessagesResult> Handle(GetChatSessionMessagesQuery request, CancellationToken cancellationToken)
        {
            var result = await service.GetChatSessionMessagesAsync(request.sessionId);
            return new GetChatSessionMessagesResult(result);
        }
    }
}