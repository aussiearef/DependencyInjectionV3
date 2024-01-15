using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

Console.Clear();
var collection = new ServiceCollection();
collection.AddScoped<Scoped>();
collection.AddTransient<Transient>();

var provider = collection.BuildServiceProvider();
Parallel.For(1, 10, i =>
{
    var scopedObject = provider.GetService<Scoped>();
    var transientObject = provider.GetService<Transient>();
    
    Console.WriteLine($"Scope ID:{scopedObject.GetHashCode()}");
    Console.WriteLine($"Transient ID: {transientObject.GetHashCode()}");
});

Console.Write("Press a key");
Console.ReadKey();

public class Scoped
{
    
}

public class Transient
{
    
}