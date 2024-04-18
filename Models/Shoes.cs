using System.ComponentModel.DataAnnotations;

namespace ShoesStoreWebsite.Models;

public class Shoes
{
    public int Id { get; set; }
    public string? Brand { get; set; }
    public string? Category { get; set; }
    public string? Name { get; set; }
    public string? Gender { get; set; }
    public string? Material { get; set; }
    public string? Sole { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    public string? Storagen_Instructions {  get; set; }
    public decimal Price { get; set; }
    public string? URLImage { get; set; }
    public ICollection<Comment> Comments { get; set; }


}