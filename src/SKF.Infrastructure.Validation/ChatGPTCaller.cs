using System;
using System.CodeDom.Compiler;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class ChatGptClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _apiUrl;

    public ChatGptClient(string apiKey)
    {
        _apiKey = apiKey;
        _apiUrl = "https://api.openai.com/v1/chat/completions";
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
    }

    public async Task<string> QueryChatGpt(string[] messages, int maxTokens)
    {
        string jsonPayload = $"{{\"messages\":{SerializeMessages(messages)},\"max_tokens\":{maxTokens}}}";

        var response = await _httpClient.PostAsync(_apiUrl, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    private string SerializeMessages(string[] messages)
    {
        var serializedMessages = new StringBuilder("[");
        foreach (var message in messages)
        {
            serializedMessages.Append("{\"role\":\"user\",\"content\":\"");
            serializedMessages.Append(message);
            serializedMessages.Append("\"},");
        }
        serializedMessages.Length--; // Remove the last comma
        serializedMessages.Append("]");

        return serializedMessages.ToString();
    }
}

public static class ChatGPTQuery
{
    public static async Task<string> MainQuery(string chatGPTQuery)
    {
        // Replace "YOUR_API_KEY" with your OpenAI API key
        var apiKey = "";
        var chatGptClient = new ChatGptClient(apiKey);

        string[] messages = { chatGPTQuery }; //+" Please return results in Json format tagged by type location severity contraindications date warning and description" };
        int maxTokens = 50;


            var response = await chatGptClient.QueryChatGpt(messages, maxTokens);
            Console.WriteLine(response);
            return response;

    }
}
