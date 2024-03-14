using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StickaTillsammans.Models;

public class Course {
    public int Id { get; set; }
    [Required(ErrorMessage = "Ange en titel.")]
    [Display(Name = "Titel")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "Ange ett datum.")]
    [DataType(DataType.Date)]
    [Display(Name = "Datum")]
    public string? Date { get; set; }
    [Required(ErrorMessage = "Ange en tid.")]
    [DataType(DataType.Time)]
    [Display(Name = "Tid")]
    public string? Time { get; set; }
    [Required(ErrorMessage = "Ange ett pris.")]
    [Display(Name = "Pris")]
    public int? Price { get; set; }
    [Required(ErrorMessage = "Ange antal kursplatser")]
    [Display(Name = "Kursplatser")]
    public int? Spots { get; set; }
    [DataType(DataType.Text)]
    [Display(Name = "Beskrivning")]
    public string? Description { get; set; }
    [Display(Name = "Bild")]
    public string? ImageName { get; set; }
    [NotMapped]
    [Display(Name = "Bild")]
    public IFormFile? ImageFile { get; set; }
    [Display(Name = "Kursdeltagare")]
    public List<Participant>? Participants { get; set; }
}