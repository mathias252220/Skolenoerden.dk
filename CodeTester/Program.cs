using LogicLibrary.Logic;
using LogicLibrary.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//var builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddHostedService<Worker>();

public class Program()
{
    private static void Main(string[] args)
    {
        Run();
    }
    
    private static void Run()
    {
        Logic logic = new Logic();
        KeyPageModel keyPage = logic.CreateKeyPage();
        logic.CreateOutpost("Skolegaarden", keyPage);
    }
}