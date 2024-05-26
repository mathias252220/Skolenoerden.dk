using LogicLibrary.TreasureHunt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Factories;

public class LogicFactory : ILogicFactory
{
    private readonly Func<IEnumerable<ILogic>> factory;
    public LogicFactory(Func<IEnumerable<ILogic>> factory)
    {
        this.factory = factory;
    }

    public ILogic Create(string input)
    {
        var set = this.factory();
        ILogic output = set.Where(x => x.grade == input).First();
        return output;
    }
}
