using DrinksInfo.BBualdo.Models;
using Spectre.Console;
using System.Text.Json;

namespace DrinksInfo.BBualdo;

public class CoctailsHttp
{
  public static async Task<List<Category>?> GetCategories(HttpClient client)
  {
    List<Category> categories;

    Stream stream = await client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
    CategoriesResponse? response = await JsonSerializer.DeserializeAsync<CategoriesResponse>(stream);
    if (response == null)
    {
      AnsiConsole.Markup("[red]Couldn't establish connection sto CoctailDB server.[/]");
      return null;
    }

    categories = response.Categories;
    return categories;
  }
}
