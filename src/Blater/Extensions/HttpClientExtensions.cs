using System.Text;

namespace Blater.Extensions;

public static class HttpClientExtensions
{
    public static async Task<Stream> PostStreamAsync(this HttpClient httpClient, string url, object body)
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
        request.Headers.ConnectionClose = false;
        request.Headers.Connection.Add("keep-alive");

        var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
    }
}