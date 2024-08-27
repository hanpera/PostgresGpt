using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PostgresGpt.ApiService.Models;

[Table("Sessions")]
public record Session
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public string Id { get; set; }

    public string Type { get; set; }

    public string SessionId { get; set; }

    public int? Tokens { get; set; }

    public string Name { get; set; }

    [NotMapped]
    [JsonIgnore]
    public List<Message> Messages { get; set; }

    public Session()
    {
        Id = Guid.NewGuid().ToString();
        Type = nameof(Session);
        SessionId = Id;
        Tokens = 0;
        Name = "New Chat";
        Messages = new List<Message>();
    }

    public void AddMessage(Message message)
    {
        Messages.Add(message);
    }

    public void UpdateMessage(Message message)
    {
        var match = Messages.Single(m => m.Id == message.Id);
        var index = Messages.IndexOf(match);
        Messages[index] = message;
    }
}