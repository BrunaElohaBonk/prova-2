namespace Prova2.Models;

public class Tour
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Point> Points { get; set; }
}