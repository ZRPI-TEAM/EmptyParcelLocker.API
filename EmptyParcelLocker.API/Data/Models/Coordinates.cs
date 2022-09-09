using System.ComponentModel.DataAnnotations;

namespace EmptyParcelLocker.API.Data.Models;

public class Coordinates
{
    [Key]
    public Guid Id { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
}