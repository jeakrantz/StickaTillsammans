using System.ComponentModel.DataAnnotations.Schema;

namespace StickaTillsammans.Models;

public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }

    public string? Text { get; set; }
    public string? ImageName { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}