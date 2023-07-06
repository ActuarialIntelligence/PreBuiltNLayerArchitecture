using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTTestEXE
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                // Set the request URI
                string uri = "https://api.openai.com/v1/chat/completions";

                // Create the request payload (example JSON payload)
                string jsonPayload = "{\"model\": \"text-davinci-003\", \"messages\": [{\"role\": \"system\", \"content\": \"You are a helpful assistant.\"}, {\"role\": \"user\", \"content\": \"Who won the world series in 2020?\"}]}";
                StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                

                // Set the Authorization header with your API token
                string apiKey = "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";//.ConfigurationManager.AppSettings["MyKey"]; ;
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                // Send the POST request
                HttpResponseMessage response = await client.PostAsync(uri, content);

                // Process the response

                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);

            }
        }
    }
}



//namespace ChatGPTTestEXE
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            // Code for asynchronous program execution goes here
//            await DoSomethingAsync();
//        }

//        static async Task DoSomethingAsync()
//        {
//            // Example asynchronous operation
//            var result = await ChatGPTQuery.MainQuery("What is the use of pennicilin and where can I get it and how will it harm me ");
//            Console.WriteLine("Async operation completed!");
//        }
//    }
//}