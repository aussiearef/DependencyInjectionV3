﻿using System;
using Microsoft.Extensions.DependencyInjection;

namespace ConditionalResolve;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();

        var collection = new ServiceCollection();

        collection.AddScoped<EuropeTaxCalculator>();
        collection.AddScoped<AustraliaTaxCalculator>();

        collection.AddScoped<Func<UserLocations, ITaxCalculator>>(
            serviceProvider => key =>
            {
                switch (key)
                {
                    case UserLocations.Australia: return serviceProvider.GetService<AustraliaTaxCalculator>();
                    case UserLocations.Europe: return serviceProvider.GetService<EuropeTaxCalculator>();
                    default: return null;
                }
            }
        );

        collection.AddSingleton<Purchase>();

        var provider = collection.BuildServiceProvider();

        var purchase = provider.GetService<Purchase>();
        var totalCharge = purchase.CheckOut(UserLocations.Europe);

        Console.WriteLine(totalCharge);
        Console.WriteLine("Press a key");
        Console.ReadKey();
    }
}