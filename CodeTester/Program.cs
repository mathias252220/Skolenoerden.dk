using LogicLibrary.QuestPDF;
using LogicLibrary.TreasureHunt;
using LogicLibrary.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

LogicThree logic = new();

KeyPageModel keyPage = logic.CreateKeyPage();

List<OutpostModel> outposts = new List<OutpostModel>
{
    new OutpostModel{Name = "Klassen"},
    new OutpostModel{Name = "Fodboldbanen"},
    new OutpostModel{Name = "Hallen"},
    new OutpostModel{Name = "Græsset"},
    new OutpostModel{Name = "Busstoppet"}
};

foreach (OutpostModel outpost in outposts)
{
    logic.PopulateOutpost(outpost, keyPage);
}

List<GroupModel> groups = new List<GroupModel>
{
    new GroupModel(),
    new GroupModel(),
    new GroupModel()
};

foreach (GroupModel group in groups)
{
    group.groupNumber = groups.IndexOf(group) + 1;
    group.firstOutpost = group.groupNumber;
}
PDFCreator pdfCreator = new PDFCreator();

QuestPDF.Settings.License = LicenseType.Community;
var skattejagt = pdfCreator.PrintFullPDF(keyPage, outposts, groups);
skattejagt.ShowInPreviewer();
skattejagt.GeneratePdf("Skattejagt.pdf");
Console.WriteLine("pdf has been generated");

