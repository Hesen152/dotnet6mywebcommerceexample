using System.ComponentModel.DataAnnotations.Schema;
using ECommercenet6.Domain.Entities.Common;

namespace ECommercenet6.Domain.Entities;

public class File:BaseEntity
{
    public string FileName { get; set; }
    public string  Path { get; set; }
    
    public string Storage { get; set; }
    
    
    [NotMapped]
    public override DateTime UpdatedDate { get; set; }
    
    
}