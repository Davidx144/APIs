using System.Text.Json.Serialization;

namespace proyectoef.Models;

public class Design
{
    public Guid DesignId { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Descripcion { get; set; }
    public string ImageUrl { get; set; }

    public DateTime CreationDate { get; set; }
    public Status StatusDesign{get;set;}
    public virtual Products Product {get;set;}
    
    [JsonIgnore]
    public virtual ICollection<Flyes> Flyes { get; set; }
}