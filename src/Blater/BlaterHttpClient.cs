using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Blater.Results;

namespace Blater;

[SuppressMessage("Design", "CA1054:URI-like parameters should not be strings")]
[SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings")]
[SuppressMessage("Design", "CA1031:Não capturar exceptions de tipos genéricos")]
public class BlaterHttpClient(ILogger<BlaterHttpClient> logger, HttpClient httpClient)
{
    #if DEBUG
    private const bool LogRequests = true;
    private const bool LogResponse = true;
    #endif

    public JsonSerializerOptions DefaultJsonSerializerOptions { get; set; } = JsonExtensions.DefaultJsonSerializerOptions;
    public string BaseAddress { get; } = httpClient.BaseAddress?.ToString() ?? string.Empty;

    public void SetToken(string token)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    #region SpecialCases

    public async Task<BlaterResult<string>> GetString(string url)
    {
        try
        {
            var response = await httpClient.GetAsync(url).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                logger.LogError("BlaterHttpClient === ERROR [{Method}] to {Url}, StatusCode: {StatusCode}\n Headers:{@@Headers}\n ResponseContent:\n{Content}",
                                response.RequestMessage?.Method,
                                response.RequestMessage?.RequestUri,
                                response.StatusCode,
                                response.RequestMessage?.Headers,
                                stringContent);
                return BlaterErrors.HttpRequestError($"BlaterHttpClient Error: {response.StatusCode} - {stringContent}");
            }

            var valueString = await response.Content.ReadAsStringAsync();

            logger.LogDebug("BlaterHttpClient === RESPONSE [{Method}] to {Url}, StatusCode: {StatusCode} Response:\n {@JsonObject}",
                            response.RequestMessage?.Method, response.RequestMessage?.RequestUri, response.StatusCode, valueString);

            return valueString;
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making GET request to {Url}", url);
            throw;
        }
    }

    public async Task<BlaterResult> Delete(string url)
    {
        try
        {
            var response = await httpClient.DeleteAsync(url).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                logger.LogError("BlaterHttpClient === ERROR [{Method}] to {Url}, StatusCode: {StatusCode}\n ResponseContent:\n{Content} \nHeaders:{@Headers}",
                                response.RequestMessage?.Method,
                                response.RequestMessage?.RequestUri, response.StatusCode, stringContent, response.RequestMessage?.Headers);

                return BlaterErrors.HttpRequestError($"BlaterHttpClient Error: {response.StatusCode} - {stringContent}");
            }

            return new BlaterResult { Success = true };
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making DELETE request to {Url}", url);
            throw;
        }
    }

    public async Task<BlaterResult> Post(string url, object body, JsonSerializerOptions? options = null)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync(url, body, JsonExtensions.DefaultJsonSerializerOptions).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                logger.LogError("BlaterHttpClient === ERROR [{Method}] to {Url}, StatusCode: {StatusCode}\n ResponseContent:\n{Content} \nHeaders:{@Headers}",
                                response.RequestMessage?.Method,
                                response.RequestMessage?.RequestUri, response.StatusCode, stringContent, response.RequestMessage?.Headers);

                return BlaterErrors.HttpRequestError($"BlaterHttpClient Error: {response.StatusCode} - {stringContent}");
            }

            return new BlaterResult { Success = true };
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making POST request to {Url}", url);
            throw;
        }
    }

    public async Task<BlaterResult> Post(string url)
    {
        try
        {
            using var stringEmpty = new StringContent(string.Empty);
            var response = await httpClient.PostAsync(url, stringEmpty).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync()!;
                logger.LogError("BlaterHttpClient === ERROR [{Method}] to {Url}, StatusCode: {StatusCode}\n ResponseContent:\n{Content} \nHeaders:{@Headers}",
                                response.RequestMessage?.Method,
                                response.RequestMessage?.RequestUri, response.StatusCode, stringContent, response.RequestMessage?.Headers);

                return BlaterErrors.HttpRequestError($"BlaterHttpClient Error: {response.StatusCode} - {stringContent}");
            }

            return new BlaterResult { Success = true };
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making POST request to {Url}", url);
            throw;
        }
    }

    #endregion

    public async Task<BlaterResult<T>> Get<T>(string url)
    {
        try
        {
            var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            return await HandleResponse<T>(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making GET request to {Url}", url);
            throw;
        }
    }

    public async Task<BlaterResult<T>> Post<T>(string url, object body, JsonSerializerOptions? options = null)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync(url, body, options ?? DefaultJsonSerializerOptions).ConfigureAwait(false);
            return await HandleResponse<T>(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making POST request to {Url}", url);
            throw;
        }
    }

    public async Task<BlaterResult<T>> Post<T>(string url, HttpContent content)
    {
        try
        {
            var response = await httpClient.PostAsync(url, content).ConfigureAwait(false);
            return await HandleResponse<T>(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making POST request to {Url}", url);
            throw;
        }
    }

    public async Task<BlaterResult<T>> Put<T>(string url, object? body = null, JsonSerializerOptions? options = null)
    {
        try
        {
            var response = await httpClient.PutAsJsonAsync(url, body, options ?? DefaultJsonSerializerOptions).ConfigureAwait(false);
            return await HandleResponse<T>(response, options ?? DefaultJsonSerializerOptions);
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making PUT request to {Url}", url);
            throw;
        }
    }

    public async Task<BlaterResult<T>> Put<T>(string url, HttpContent content)
    {
        try
        {
            var response = await httpClient.PutAsync(url, content).ConfigureAwait(false);
            return await HandleResponse<T>(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making PUT request to {Url}", url);
            throw;
        }
    }

    public async Task<BlaterResult<T>> Delete<T>(string url)
    {
        try
        {
            var response = await httpClient.DeleteAsync(url).ConfigureAwait(false);
            return await HandleResponse<T>(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making DELETE request to {Url}", url);
            throw;
        }
    }

    public async Task<BlaterResult<T>> Patch<T>(string url, HttpContent content)
    {
        try
        {
            var response = await httpClient.PatchAsync(url, content).ConfigureAwait(false);
            return await HandleResponse<T>(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making PATCH request to {Url}", url);
            throw;
        }
    }

    public async Task<BlaterResult<T>> Patch<T>(string url, object? body = null)
    {
        try
        {
            var response = await httpClient.PatchAsJsonAsync(url, body, DefaultJsonSerializerOptions).ConfigureAwait(false);
            return await HandleResponse<T>(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making PATCH request to {Url}", url);
            throw;
        }
    }

    #region Stream

    public async IAsyncEnumerable<T> GetStream<T>(string url)
    {
        var response = await httpClient.GetStreamAsync(url).ConfigureAwait(false);
        using var streamReader = new StreamReader(response);

        while (!streamReader.EndOfStream)
        {
            var line = await streamReader.ReadLineAsync();

            if (string.IsNullOrWhiteSpace(line))
            {
                yield break;
            }

            #if DEBUG
            logger.LogDebug("BlaterHttpClient === STREAM RESPONSE: {@JsonObject}", line);
            #endif

            var json = line.FromJson<T>();

            if (json != null)
            {
                yield return json;
            }
        }
    }

    public async IAsyncEnumerable<T> PostStream<T>(string url, object body)
    {
        var response = await httpClient.PostStreamAsync(url, body).ConfigureAwait(false);
        using var streamReader = new StreamReader(response);

        while (!streamReader.EndOfStream)
        {
            var line = await streamReader.ReadLineAsync();

            if (string.IsNullOrWhiteSpace(line))
            {
                yield break;
            }

            #if DEBUG
            logger.LogDebug("BlaterHttpClient === STREAM RESPONSE: {@JsonObject}", line);
            #endif

            var json = line.FromJson<T>();

            if (json != null)
            {
                yield return json;
            }
        }
    }

    #endregion

    private async Task<BlaterResult<T>> HandleResponse<T>(HttpResponseMessage message, JsonSerializerOptions? options = null)
    {
        try
        {
            #if DEBUG

            if (LogRequests)
            {
                var stringContent = string.Empty;
                if (message.RequestMessage?.Content != null)
                {
                    stringContent = await message.RequestMessage?.Content?.ReadAsStringAsync()!;
                }

                logger.LogDebug("BlaterHttpClient === REQUEST [{Method}] to {Url}, StatusCode: {StatusCode}\n Content:\n{Content} \nHeaders:{@Headers}",
                                message.RequestMessage?.Method,
                                message.RequestMessage?.RequestUri, message.StatusCode, stringContent, message.RequestMessage?.Headers);
            }

            #endif

            if (!message.IsSuccessStatusCode)
            {
                var stringContent = await message.Content.ReadAsStringAsync();
                logger.LogError("BlaterHttpClient === ERROR [{Method}] to {Url}, StatusCode: {StatusCode}\n ResponseContent:\n{Content} \nHeaders:{@Headers}",
                                message.RequestMessage?.Method,
                                message.RequestMessage?.RequestUri, message.StatusCode, stringContent, message.RequestMessage?.Headers);
                return new BlaterError(stringContent);
            }

            #if DEBUG

            if (LogResponse)
            {
                var debugString = await message.Content.ReadAsStringAsync();

                logger.LogDebug("BlaterHttpClient === RESPONSE [{Method}] to {Url}, StatusCode: {StatusCode} Response:\n {@JsonObject}",
                                message.RequestMessage?.Method, message.RequestMessage?.RequestUri, message.StatusCode, debugString);

                try
                {
                    var debugObject = debugString.FromJson<T>(options ?? DefaultJsonSerializerOptions);

                    if (debugObject == null)
                    {
                        logger.LogDebug("BlaterHttpClient === Response Null:\n {@JsonObject}", debugString);
                        throw new Exception("Error while deserializing response");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            #endif

            var stream = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
            var json = stream.FromJson<T>();

            if (json != null)
            {
                return json;
            }

            logger.LogError("BlaterHttpClient === Error while deserializing response");
            return BlaterErrors.JsonSerializationError("Error while deserializing response");
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while handling response");
            return BlaterErrors.GenericInternalError;
        }
    }
}