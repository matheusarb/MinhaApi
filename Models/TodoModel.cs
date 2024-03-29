namespace MinhaApi.Models;

public class TodoModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Username { get; set; }
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; }
}