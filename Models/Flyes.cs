namespace proyectoef.Models;

public class Flyes
{
    public Guid FlyesId { get; set; }
    public Guid DesignId { get; set; }
    public string Name { get; set; }
    public string Descripcion { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreationDate { get; set; }
    public Status StatusFlyes { get; set; } = Status.Active;
    public virtual Design Design { get; set; }
}