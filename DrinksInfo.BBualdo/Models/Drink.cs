using System.Text.Json.Serialization;

namespace DrinksInfo.BBualdo.Models;

public record class Drink([property: JsonPropertyName("idDrink")] string Id, [property: JsonPropertyName("strDrink")] string Name);