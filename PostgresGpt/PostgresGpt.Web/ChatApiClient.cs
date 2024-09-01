using PostgresGpt.Web.Models;

namespace PostgresGpt.Web
{
    public class ChatApiClient(HttpClient httpClient)
    {
        public async Task<IEnumerable<SessionDto>?> GetAllSessions()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SessionDto>>("/sessions");
        }


    }
}
