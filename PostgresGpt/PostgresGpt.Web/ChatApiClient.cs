using Microsoft.AspNetCore.SignalR;
using PostgresGpt.Web.Models;

namespace PostgresGpt.Web
{
    public class ChatApiClient(HttpClient httpClient)
    {
        public async Task<List<SessionDto>?> GetAllSessions()
        {
            return await httpClient.GetFromJsonAsync<List<SessionDto>>("/sessions");
        }

        // Get all routes present in project PostgresGpt.ApiService and create the http calls here
        // Start with DeleteSession
        public async Task DeleteSession(string sessionId)
        {
            var response = await httpClient.DeleteAsync($"/sessions/{sessionId}");
            response.EnsureSuccessStatusCode();
        }

        // Now with InsertSession
        public async Task<SessionDto> InsertSession()
        {
            var session = new SessionDto();
            var response =  await httpClient.PostAsJsonAsync<SessionDto?>("/sessions", null );
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SessionDto>();
        }

        // Now with RenameSession
        public async Task RenameSession(string sessionId, string newName)
        {
            var response = await httpClient.PutAsJsonAsync($"/sessions", new { Id = sessionId, Name = newName });
            response.EnsureSuccessStatusCode();
        }

        // Get the Session Messages
        public async Task<List<MessageDto>?> GetSessionMessages(string sessionId)
        {
            return await httpClient.GetFromJsonAsync<List<MessageDto>>($"/sessions/{sessionId}/messages");
        }

        // Get the Chat Completion endpoint
        public async Task<MessageDto?> GetChatCompletion(string sessionId, string promptText)
        {
            var responseMessage = await httpClient.PostAsJsonAsync($"/chat", new { SessionId = sessionId, PromptText = promptText });
            responseMessage.EnsureSuccessStatusCode();
            var dto = await responseMessage.Content.ReadFromJsonAsync<MessageDto>();
            return dto;
        }

        // Get the Summarize session endpoint
        public async Task<SummarizeChatSessionNameResponse?> SummarizeSession(string sessionId)
        {
            var response = await httpClient.PostAsJsonAsync($"/chat/summarize", new { SessionId = sessionId });
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SummarizeChatSessionNameResponse>();
        }

        // Clear che cache endpoint
        public async Task ClearCache()
        {
            var response = await httpClient.DeleteAsync("/cache");
            response.EnsureSuccessStatusCode();
        }
    }
}
