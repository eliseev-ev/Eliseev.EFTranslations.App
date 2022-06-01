// See https://aka.ms/new-console-template for more information
using Eliseev.EFTranslations.App;
using Eliseev.EFTranslations.App.Models;
using NUnit.Framework;

Console.WriteLine("Hello, World!");


DataContext dataContext = new DataContext();

var someEntity = new SomeEntity()
{
    Property3 = "NoGen"
};

await dataContext.SomeEntities.AddAsync(someEntity);
await dataContext.SaveChangesAsync();

Assert.AreEqual("1", someEntity.Property1);
Assert.AreEqual("NoGen", someEntity.Property2);
Assert.AreEqual("NoGen", someEntity.Property2);