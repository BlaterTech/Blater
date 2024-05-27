using Blater.Utilities;

namespace Blater.Models;

public class BaseId
{
    public BaseId()
    {
        Id = SequentialGuidGenerator.NewGuid();
    }
    public Guid Id { get; set; }
}