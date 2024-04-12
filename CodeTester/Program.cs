using LogicLibrary.Logic;
using LogicLibrary.Models;
using LogicLibrary.QuestPDF;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuestPDF.Infrastructure;

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
        QuestPDF.Settings.License = LicenseType.Community;
        Logic logic = new Logic();
        KeyPageModel keyPage = logic.CreateKeyPage();
        logic.CreateOutpost("Skolegaarden", keyPage);
        PDFCreator pdfCreator = new PDFCreator();
        pdfCreator.CreateKeyPagePDF(keyPage);
    }
}