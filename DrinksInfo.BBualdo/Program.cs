using DrinksInfo.BBualdo.Models;
using System.Text.Json;

async Task<List<Category>?> GetCategories()
{
  List<Category> categories;

  using HttpClient client = new();

  Stream stream = await client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");

  CategoryResponse? response = await JsonSerializer.DeserializeAsync<CategoryResponse>(stream);

  if (response == null)
  {
    Console.WriteLine("Error");
    return null;
  }

  categories = response.drinks;

  return categories;
}

List<Category>? categories = await GetCategories();

if (categories != null && categories.Count > 0)
{
  foreach (Category category in categories)
  {
    Console.WriteLine(category.CategoryName);
  }
}

