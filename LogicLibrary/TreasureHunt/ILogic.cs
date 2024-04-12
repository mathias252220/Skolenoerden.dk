using LogicLibrary.Models;

namespace LogicLibrary.Logic
{
    public interface ILogic
    {
        List<char> CreateAlphabet();
        KeyPageModel CreateKeyPage();
    }
}