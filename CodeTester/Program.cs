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
        outposts.Add(logic.CreateOutpost("Bentes Kontor", keyPage));
        outposts.Add(logic.CreateOutpost("Legepladsen", keyPage));
        outposts.Add(logic.CreateOutpost("Fodboldbanen", keyPage));
        int numberOfGroups = 1;
        List<GroupModel> groups = new();
        for (int i = 0; i < numberOfGroups; i++)
        {
            GroupModel group = new GroupModel();
            group.groupNumber = i + 1;
            group.firstOutpost = i + 1;
            groups.Add(group);
        }
        PDFCreator pdfCreator = new PDFCreator();
        pdfCreator.PrintFullPDF(keyPage, outposts, groups);
    }
}