using Blater.Utilities;

namespace Blater.Models;

public class BaseId
{
    public BaseId()
    {
        Id = SequentialGuidGenerator.NewShortGuid();
    }
    public ShortGuid Id { get; set; }
}