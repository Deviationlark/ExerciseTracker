﻿using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExerciseTracker;
public class Program
{
    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var menu = serviceProvider.GetRequiredService<IExerciseService>();
        bool appRunning = true;
        while (appRunning) menu.MainMenu();
    }
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ExerciseController>();
        services.AddTransient<ExerciseDatabase>();
        // Have both of these here because of a challenge to create a branch with Dapper
        services.AddTransient<IExerciseRepository, ExerciseRepository>();
        services.AddTransient<IExerciseRepositoryDapper, ExerciseRepositoryDapper>();
        services.AddTransient<IUserInput, UserInput>();
        services.AddScoped<IExerciseService, ExerciseService>();
    }
}