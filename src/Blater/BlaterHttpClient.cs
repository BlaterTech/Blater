using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using Blater.JsonUtilities;
using Microsoft.Extensions.Logging;

namespace Blater;

[SuppressMessage("Design", "CA1054:URI-like parameters should not be strings")]
[SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings")]
public class BlaterHttpClient(ILogger<BlaterHttpClient> logger, HttpClient httpClient)
{
    #if DEBUG
    private const bool LogRequests = true;
    private const bool LogResponse = true;
    #endif
    
    public Uri? BaseAddress => httpClient.BaseAddress;
    
    public async Task<T?> Get<T>(string url)
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
    
    public async Task<T?> Post<T>(string url, object body)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync(url, body, JsonExtensions.DefaultJsonSerializerOptions).ConfigureAwait(false);
            return await HandleResponse<T>(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making POST request to {Url}", url);
            throw;
        }
    }
    
    public async Task<T?> Post<T>(string url, HttpContent content)
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
    
    public async Task<T?> Put<T>(string url, object? body = null)
    {
        try
        {
            var response = await httpClient.PutAsJsonAsync(url, body, JsonExtensions.DefaultJsonSerializerOptions).ConfigureAwait(false);
            return await HandleResponse<T>(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making PUT request to {Url}", url);
            throw;
        }
    }
    
    public async Task<T?> Put<T>(string url, HttpContent content)
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
    
    public async Task<T?> Delete<T>(string url)
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
    
    public async Task<T?> Patch<T>(string url, HttpContent content)
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
    
    public async Task<T?> Patch<T>(string url, object? body = null)
    {
        try
        {
            var response = await httpClient.PatchAsJsonAsync(url, body, JsonExtensions.DefaultJsonSerializerOptions).ConfigureAwait(false);
            return await HandleResponse<T>(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while making PATCH request to {Url}", url);
            throw;
        }
    }
    
    private async Task<T?> HandleResponse<T>(HttpResponseMessage message)
    {
        try
        {
            #if DEBUG
            
            if (LogRequests)
            {
                string stringContent = string.Empty;
                if (message.RequestMessage?.Content != null)
                {
                    stringContent = await message.RequestMessage?.Content?.ReadAsStringAsync()!;
                }
                logger.LogDebug("BlaterHttpClient === Request [{Method}] to {Url}, StatusCode: {StatusCode}\n Content:\n{Content} \nHeaders:{Headers}",
                                message.RequestMessage?.Method,
                                message.RequestMessage?.RequestUri, message.StatusCode, stringContent, message.RequestMessage?.Headers);
            }
            
            if (LogResponse)
            {
                var debugString = await message.Content.ReadAsStringAsync();
                
                try
                {
                    var debugObject = debugString.FromJson<T>();
                    
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
                
                logger.LogDebug("BlaterHttpClient === [{Method}] to {Url}, StatusCode: {StatusCode} Response:\n {@JsonObject}",
                                message.RequestMessage?.Method, message.RequestMessage?.RequestUri, message.StatusCode, debugString);
            }
            #endif
            
            if (!message.IsSuccessStatusCode)
            {
                var stringContent = await message.Content.ReadAsStringAsync()!;
                logger.LogError("BlaterHttpClient === Response [{Method}] to {Url}, StatusCode: {StatusCode}\n ResponseContent:\n{Content} \nHeaders:{Headers}",
                                message.RequestMessage?.Method,
                                message.RequestMessage?.RequestUri, message.StatusCode, stringContent, message.RequestMessage?.Headers);
            }
            
            var stream = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
            var json = stream.FromJson<T>();
            return json;
        }
        catch (Exception e)
        {
            logger.LogError(e, "BlaterHttpClient Exception === Error while handling response");
            throw;
        }
    }
}