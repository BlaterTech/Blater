using System.Diagnostics.CodeAnalysis;

namespace Blater.Models.Storage;

[SuppressMessage("Design", "CA1056:As propriedades do tipo URI não devem ser cadeias de caracteres")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("Design", "CA1024:Usar propriedades sempre que apropriado")]
public class StorageFileInfo
{
    /// <summary>
    ///     The folder where the file is stored.
    ///     Ex: prd-lipor-files
    /// </summary>
    public string Container { get; set; } = null!;

    /// <summary>
    ///     The name of the blob file
    ///     photo1.jpeg
    /// </summary>
    public string Name { get; } = null!;

    /// <summary>
    ///     Example exe, png, jpg, txt
    /// </summary>
    public string Extension { get; } = null!;

    /*/// <summary>
    /// An optional type of the file.
    /// </summary>
    public string? Type { get; set; }*/

    /// <summary>
    ///     The url to access the file
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    ///     In case if we ever need more data
    /// </summary>
    public Dictionary<string, string>? Metadata { get; set; }

    /// <summary>
    ///     Used to check if the file is public or not and use the correct storage account
    /// </summary>
    public bool IsPublic { get; set; }

    /// <summary>
    ///     Who uploaded the file
    /// </summary>
    public string? OwnerEmail { get; set; }

    /// <summary>
    ///     Sas uri
    /// </summary>
    public string? SasUri { get; set; }

    /// <summary>
    ///     Expiration Uri Sas
    /// </summary>
    public DateTime? SasExpiration { get; set; }

    public string GetMimeType()
    {
        switch (Extension)
        {
            case ".pdf":
                return "application/pdf";
            case ".doc":
                return "application/msword";
            case ".docx":
                return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            case ".xls":
                return "application/vnd.ms-excel";
            case ".xlsx":
                return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            case ".ppt":
                return "application/vnd.ms-powerpoint";
            case ".pptx":
                return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
            case ".txt":
                return "text/plain";
            case ".jpg":
                return "image/jpeg";
            case ".jpeg":
                return "image/jpeg";
            case ".png":
                return "image/png";
            case ".gif":
                return "image/gif";
            case ".svg":
                return "image/svg+xml";
            case ".ico":
                return "image/x-icon";
            case ".xml":
                return "text/xml";
            case ".json":
                return "application/json";
            default:
                return "text/plain";
        }
    }
}