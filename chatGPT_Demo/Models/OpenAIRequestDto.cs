using System.Text.Json.Serialization;

namespace chatGPT_Demo.Models
{
    //public class OpenAIRequestDto
    //{
    //    [JsonPropertyName("model")]
    //    public string Model { get; set; }

    //    [JsonPropertyName("messages")]
    //    public List<OpenAIMessageRequestDto> Messages { get; set; }

    //    [JsonPropertyName("temperature")]
    //    public float Temperature { get; set; }

    //    [JsonPropertyName("max_tokens")]
    //    public int MaxTokens { get; set; }

    //    [JsonPropertyName("numoutputs")]
    //    public int NumOutputs { get; set; }
    //}

    //public class OpenAIMessageRequestDto
    //{
    //    [JsonPropertyName("role")]
    //    public string Role { get; set; }

    //    [JsonPropertyName("content")]
    //    public string Content { get; set; }
    //}

    public class OpenAIResponseDto
    {
        public List<OpenAIChoiceDto> Choices { get; set; }
    }

    public class OpenAIChoiceDto
    {
        public string Text { get; set; }
    }

    public class OpenAIRequestDto
    {
        public string Model { get; set; }
        public string Prompt { get; set; }
        public int MaxTokens { get; set; }
        public double Temperature { get; set; }
        public double TopP { get; set; }
        public int NumOutputs { get; set; }
    }

}