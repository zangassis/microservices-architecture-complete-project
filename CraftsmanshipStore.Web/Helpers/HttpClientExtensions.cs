namespace CraftsmanshipStore.Web.Helpers;

public static class HttpClientExtensions
{
    private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");

    public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode == false)
            throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        var result = JsonSerializer.Deserialize<T>(
            dataAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        return result;
    }

    public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient client, string url, T data)
    {
        var dataAsString = JsonSerializer.Serialize(data);

        var content = new StringContent(dataAsString);

        content.Headers.ContentType = contentType;

        return client.PostAsync(url, content);
    }

    public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient client, string url, T data)
    {
        var dataAsString = JsonSerializer.Serialize(data);

        var content = new StringContent(dataAsString);

        content.Headers.ContentType = contentType;

        return client.PutAsync(url, content);
    }
}
