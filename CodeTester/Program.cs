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
        List<OutpostModel> outposts = new List<OutpostModel>();
        outposts.Add(logic.CreateOutpost("Klassen", keyPage));
        outposts.Add(logic.CreateOutpost("Skolegården", keyPage));
        outposts.Add(logic.CreateOutpost("Børnehaven", keyPage));
        PDFCreator pdfCreator = new PDFCreator();
        pdfCreator.PrintFullPDF(keyPage, outposts);
    }
}