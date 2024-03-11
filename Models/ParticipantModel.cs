namespace StickaTillsammans.Models;

public class Participant
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Tel { get; set; }
    public int? Spots { get; set; }
    public int? CourseId { get; set; }
    public Course? Course { get; set; }
}