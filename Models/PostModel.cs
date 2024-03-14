using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StickaTillsammans.Models;

public class Post
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Ange titel.")]
    [Display(Name = "Titel")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "Skriv en text till inlägget.")]
    [Display(Name = "Text")]
    [DataType(DataType.Text)]
    public string? Text { get; set; }
    [Display(Name = "Bild")]
    public string? ImageName { get; set; }
    [NotMapped]
    [Display(Name = "Bild")]
    public IFormFile? ImageFile { get; set; }
    [Display(Name = "Kategori")]
    public int? CategoryId { get; set; }
    [Display(Name = "Kategori")]
    public Category? Category { get; set; }
}