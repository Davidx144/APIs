using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace proyectoef.Models;

public class Category
{
    internal string? statusCategory;

    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Descripcion { get; set; }
    public Status StatusCategory { get; set; } = Status.Active;
    [JsonIgnore]
    public virtual ICollection<Products> Products { get; set; }
}
public enum Status
{
    Active,
    Inactive
}
