using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace proyectoef.Models;

public class Products
{
    public Guid ProductId { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Descripcion { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreationDate { get; set; }
    public Status StatusProduct{get;set;}
    public virtual Category Category {get;set;}
    [JsonIgnore]
    public virtual ICollection<Design> Designs { get; set; }
}
