namespace Blater.Models.Storage.Request;

public class StorageFileInfoRequest : StorageFileInfo
{
    /// <summary>
    ///     The content of the file in base64
    /// </summary>
    public required string FileContentBase64 { get; set; }
}