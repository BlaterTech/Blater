using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Blater.Models.Bases;

[SuppressMessage("Design", "CA1056:As propriedades do tipo URI não devem ser cadeias de caracteres")]
public abstract class BaseAvatarFrontendModel
{
    [JsonIgnore]
    public abstract string Title { get; }

    [JsonIgnore]
    public abstract string SubTitle { get; }

    public virtual string AvatarUrl { get; set; } = "";
}