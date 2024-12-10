using chatGPT_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace chatGPT_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public OpenAIController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpPost]
        [Route("api/chat")]
        public async Task<IActionResult> UseChatGPT([FromBody] string userQuestion)
        {
            var apiKey = "";
            var baseUrl = "";

            var client = _clientFactory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var prompt = $"Q: {userQuestion} A:";
            var requestDto = new OpenAIRequestDto
            {
                Model = "text-davinci", // Use the latest available model
                Prompt = prompt,
                MaxTokens = 150,
                Temperature = 0.7,
                TopP = 1,
                NumOutputs = 5
            };

            var json = JsonSerializer.Serialize(requestDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(baseUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Failed to get responses from OpenAI API");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<OpenAIResponseDto>(responseContent);

            if (responseData?.Choices == null || responseData.Choices.Count == 0)
            {
                return StatusCode(500, "No response choices found from OpenAI API");
            }

            var responseTexts = responseData.Choices.Select(choice => choice.Text).ToList();

            return Ok(responseTexts);
        }
    }
}