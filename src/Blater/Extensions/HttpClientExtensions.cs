using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Blater.Extensions;

[SuppressMessage("Design", "CA1054:URI-like parameters should not be strings")]
public static class HttpClientExtensions
{
    public static async Task<(Stream stream, HttpResponseMessage response)> PostStreamAsync(this HttpClient httpClient, string url, object body)
    {
        StringContent content;
        
        if (body is string stringBody)
        {
            content = new StringContent(stringBody, Encoding.UTF8, "application/json");
        }
        else
        {
            var json = body.ToJson();
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new Exception("Failed to serialize object to JSON");
            }

            content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        using var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Content = content;

        var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return (await response.Content.ReadAsStreamAsync().ConfigureAwait(false), response);
    }
}