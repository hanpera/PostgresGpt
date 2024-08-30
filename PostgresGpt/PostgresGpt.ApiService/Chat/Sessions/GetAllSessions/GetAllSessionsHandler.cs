using BuildingBlocks.CQRS;
using PostgresGpt.ApiService.Models;
using PostgresGpt.ApiService.Services;

namespace PostgresGpt.ApiService.Chat.Sessions.GetAllSessions
{
    public record GetSessionsQuery() : IQuery<GetSessionsResult>;
    public record GetSessionsResult(IEnumerable<Session> Sessions);

    public class GetAllSessionsHandler (ChatService service)
        : IQueryHandler<GetSessionsQuery, GetSessionsResult>
    {
        public async Task<GetSessionsResult> Handle(GetSessionsQuery request, CancellationToken cancellationToken)
        {
            var result = await service.GetAllChatSessionsAsync();
            return new GetSessionsResult(result);
        }
    }
}
