


using System.Text.Json.Serialization;

namespace WebApiClient
{
	record class IconHub( [property: JsonPropertyName("unicode")] string  Icon);
}
