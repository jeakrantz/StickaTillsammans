using System.ComponentModel.DataAnnotations;

namespace StickaTillsammans.Models;

public class Participant
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Ange namn.")]
    [Display(Name = "Namn")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Ange epost.")]
    [Display(Name = "Epost")]
    public string? Email { get; set; }
    [Display(Name = "Telefonnummer")]
    public string? Tel { get; set; }
    [Required(ErrorMessage = "Ange antal kursplatser.")]
    [Display(Name = "Kursplatser")]
    public int? Spots { get; set; }
    [Required(ErrorMessage = "Ange vilken workshop")]
    [Display(Name = "Workshop")]
    public int? CourseId { get; set; }
    [Display(Name = "Workshop")]
    public Course? Course { get; set; }
}