
using AddKeyMethods;
using Microsoft.Extensions.DependencyInjection;

var collection = new ServiceCollection();

collection.AddKeyedSingleton<ITaxCalculator, AustraliaTaxCalculator>(UserLocations.Australia);
collection.AddKeyedSingleton<ITaxCalculator, EuropeTaxCalculator>(UserLocations.Europe);

var provider = collection.BuildServiceProvider();

ITaxCalculator calculator = provider.GetKeyedService<ITaxCalculator>(UserLocations.Australia);

Console.Clear();
Console.WriteLine($"Your tax rate is {calculator.Calculate()}");

Console.ReadKey();