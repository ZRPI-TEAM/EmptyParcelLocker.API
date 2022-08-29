using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmptyParcelLocker.API.Data.Models;

public class ParcelLocker
{
    public ParcelLocker()
    {
        Lockers = new Collection<Locker>();
    }
    
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Address { get; set; }

    public ICollection<Locker> Lockers { get; set; }
}