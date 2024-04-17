using DrinksInfo.BBualdo.Models;
using Spectre.Console;

namespace DrinksInfo.BBualdo;

public class AppEngine
{
  public bool IsRunning { get; set; }
  public HttpClient Client { get; set; }

  public AppEngine()
  {
    IsRunning = true;
    Client = new HttpClient();
    Client.DefaultRequestHeaders.Clear();
    Client.DefaultRequestHeaders.Add("Accept", "application/json");
  }

  public async Task CategoriesMenu()
  {
    List<Category>? categories = await CoctailsHttp.GetCategories(Client);
    if (categories == null || categories.Count == 0)
    {
      PressAnyKey();
      IsRunning = false;
      Environment.Exit(0);
    }

    List<string> choices = new List<string>();

    foreach (Category category in categories)
    {
      choices.Add(category.Name);
    }

    choices.Add("Close App");

    string choosenCategory = ConsoleEngine.GetSelection("[yellow]Select Category[/]", choices);

    if (choosenCategory == "Close App")
    {
      AnsiConsole.Markup("[blue]Have a nice drink![/]");
      IsRunning = false;
      Environment.Exit(0);
    }
  }

  private void PressAnyKey()
  {
    AnsiConsole.Markup("[blue]Press any key to continue. [/]");
    Console.ReadKey();
  }
}
