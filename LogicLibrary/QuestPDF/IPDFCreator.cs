using LogicLibrary.Models;
using QuestPDF.Infrastructure;

namespace LogicLibrary.QuestPDF;
public interface IPDFCreator
{
    public string taskTypes {  get; set; }
    IDocument CreateKeyPagePDF(KeyPageModel keyPage, List<GroupModel> groups);
    IDocument CreateOutpostPagesPDF(List<OutpostModel> outposts, List<GroupModel> groups);
    IDocument PrintFullPDF(KeyPageModel keyPage, List<OutpostModel> outposts, List<GroupModel> groups);
}