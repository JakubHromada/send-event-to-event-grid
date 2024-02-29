namespace AddEventToEventGrid;

public class TeamsNotification
{
    public string? Subject { get; set; }
    public DateTime? Timestamp { get; set; }
    public string? Importance { get; set; }
    public string? Message { get; set; }
    public string? Details { get; set; }
    public string? Source { get; set; }
    public string? Country { get; set; }
    public string? Url { get; set; }
    public string? ExecutingUser { get; set; }
    public string? Action { get; set; }
}