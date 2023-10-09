using System.Text.Json;
using Utilities.Helper.IHelper;


namespace Utilities.Helper
{
    public class JsonHelper : IJsonHelper
    {
        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Convert to camelCase
            //PropertyNameCaseInsensitive = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj, options);
        }

        public T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}