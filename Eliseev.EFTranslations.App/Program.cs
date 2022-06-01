// See https://aka.ms/new-console-template for more information
using Eliseev.EFTranslations.App;

Console.WriteLine("Hello, World!");


DataContext dataContext = new DataContext();

var a = dataContext.SomeEntities.ToList();

var b = 1;