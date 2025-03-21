using Newtonsoft.Json;
using System.Text;

namespace InsuranceClaimAI.Infrastructure
{
    public class OpenAIClient : IOpenAIClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenAIClient(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<string> GenerateTextAsync(string prompt)
        {
            var requestPayload = new
            {
                model = "gpt-4", // Or "gpt-3.5-turbo"
                messages = new[]
       {
            new { role = "system", content = "You are an assistant that helps with insurance claims." },
            new { role = "user", content = prompt } // The user’s input (e.g., insurance claim question)
        },
                max_tokens = 500,
                temperature = 0.7
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestPayload), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            try
            {
                // Make the API call to the chat completions endpoint
                var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    // Deserialize the response
                    dynamic result = JsonConvert.DeserializeObject(responseString);

                    // Extract and return the assistant's response
                    return result.choices[0].message.content.ToString();
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error from OpenAI API: {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }
    }

}
