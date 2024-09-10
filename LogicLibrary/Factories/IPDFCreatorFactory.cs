using LogicLibrary.QuestPDF;
namespace LogicLibrary.Factories;

public interface IPDFCreatorFactory
{
    IPDFCreator Create(string input);
}