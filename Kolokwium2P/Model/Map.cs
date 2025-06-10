using System.ComponentModel.DataAnnotations;

namespace Kolokwium2P.Model;

public class Map
{
    [Key]
    public int MapId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
}