using Spectre.Console;

namespace DrinksInfo.BBualdo;

public class ConsoleEngine
{
  public static string GetSelection(string title, List<string> choices)
  {
    string choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                       .Title(title)
                                       .AddChoices(choices));

    return choice;
  }

  public static void ShowTitle()
  {
    Rule rule = new Rule("Drinks Info").DoubleBorder().Centered();
    rule.Style = new Style(Color.Aqua);
    AnsiConsole.Write(rule);
  }
}
