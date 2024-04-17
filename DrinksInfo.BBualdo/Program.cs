using DrinksInfo.BBualdo;

AppEngine app = new();

while (app.IsRunning)
{
  ConsoleEngine.ShowTitle();
  await app.CategoriesMenu();
}