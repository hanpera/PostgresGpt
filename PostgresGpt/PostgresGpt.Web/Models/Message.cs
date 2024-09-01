namespace PostgresGpt.Web.Models;

public record MessageDto
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public string Id { get; set; }

    public string Type { get; set; }

    public string SessionId { get; set; }

    public DateTime TimeStamp { get; set; }

    public string Prompt { get; set; }

    public int PromptTokens { get; set; }

    public string Completion { get; set; }

    public int CompletionTokens { get; set; }

}