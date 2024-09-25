using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using PostgresGpt.Web.Models;

namespace PostgresGpt.Web
{
    public class ChatApiClient(HttpClient httpClient)
    {
        public async Task<List<SessionDto>?> GetAllSessions()
        {
            var response = await httpClient.GetFromJsonAsync<GetAllSessionsResponse>("/sessions");
            return response!.Sessions.ToList();
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
            var response = await httpClient.PostAsJsonAsync("/sessions", new StringContent(string.Empty, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<InsertSessionResponse>();
            return result!.Session;
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
            var response = await httpClient.GetFromJsonAsync<GetChatSessionMessagesResponse>($"/sessions/{sessionId}/messages");
            return response!.Messages;
        }

        // Get the Chat Completion endpoint
        public async Task<MessageDto?> GetChatCompletion(string sessionId, string promptText)
        {
            var responseMessage = await httpClient.PostAsJsonAsync($"/chat", new { SessionId = sessionId, PromptText = promptText });
            responseMessage.EnsureSuccessStatusCode();
            var result = await responseMessage.Content.ReadFromJsonAsync<GetChatCompletionResponse>();
            return result!.Message;
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
