using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmptyParcelLocker.API.Data.Models;

public class LockerType
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; }
    public int MaxHeight { get; set; }
    public int MaxWidth { get; set; }
    public int MaxLength { get; set; }
    public int MaxWeight { get; set; }
}