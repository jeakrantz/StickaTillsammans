using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StickaTillsammans.Models;

public class Category
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Ange ett namn på kategorin.")]
    [Display(Name = "Kategori")]
    public string? Name { get; set; }
    [Display(Name = "Inlägg")]
    public List<Post>? Posts { get; set; }

}