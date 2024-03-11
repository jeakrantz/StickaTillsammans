using System.ComponentModel.DataAnnotations.Schema;

namespace StickaTillsammans.Models;

public class Course {
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Date { get; set; }
    public string? Time { get; set; }
    public int? Price { get; set; }
    public int? Spots { get; set; }
    public string? Description { get; set; }
    public string? ImageName { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }
    public List<Participant>? Participants { get; set; }
}