using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    
    public virtual ParcelLockerAddress ParcelLockerAddress { get; set; }
    
    public virtual ICollection<Locker> Lockers { get; set; }
}