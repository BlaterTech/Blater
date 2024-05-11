using Blater.Utilities;

namespace Blater.Models;

public class BaseId
{
    public BaseId()
    {
        Id = SequentialGuidGenerator.NewId();
    }
    public Guid Id { get; set; }
}