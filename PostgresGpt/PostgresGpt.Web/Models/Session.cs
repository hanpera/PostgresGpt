namespace PostgresGpt.Web.Models;

public record SessionDto
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public string Id { get; set; }

    public string Type { get; set; }

    public string SessionId { get; set; }

    public int? Tokens { get; set; }

    public string Name { get; set; }




}