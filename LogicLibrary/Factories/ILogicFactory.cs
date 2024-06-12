using LogicLibrary.TreasureHunt;

namespace LogicLibrary.Factories;

public interface ILogicFactory
{
    ILogic Create(string input);
}