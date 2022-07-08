using File = ECommercenet6.Domain.Entities.File;

namespace ECommercenet6.Domain;

public class InVoiceFile:File
{
    public decimal Price { get; set; }
    
}