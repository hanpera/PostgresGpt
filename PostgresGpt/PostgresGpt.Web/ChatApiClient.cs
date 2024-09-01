using PostgresGpt.Web.Models;

namespace PostgresGpt.Web
{
    public class ChatApiClient(HttpClient httpClient)
    {
        public async Task<IEnumerable<SessionDto>?> GetAllSessions()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SessionDto>>("/sessions");
        }

        // Get all routes present in project PostgresGpt.ApiService and create the hpp calls here
        // Start with DeleteSession
        public async Task DeleteSession(Guid sessionId)
        {
            await httpClient.DeleteAsync($"/sessions/{sessionId}");
        }

        // Now with InsertSession
        public async Task InsertSession(SessionDto session)
        {
            await httpClient.PostAsJsonAsync("/sessions", session);
        }

        // Now with RenameSession
        public async Task RenameSession(Guid sessionId, string newName)
        {
            await httpClient.PutAsJsonAsync($"/sessions", new{Id = sessionId, Name = newName});
        }
    }
}
