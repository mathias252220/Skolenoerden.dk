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

        KeyPageModel keyPage = logic.CreateKeyPage();
    }


}