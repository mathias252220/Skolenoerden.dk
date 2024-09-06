using LogicLibrary.QuestPDF;
using LogicLibrary.TreasureHunt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Factories;

public class PDFCreatorFactory : IPDFCreatorFactory
{
    private readonly Func<IEnumerable<IPDFCreator>> factory;
    public PDFCreatorFactory(Func<IEnumerable<IPDFCreator>> factory)
    {
        this.factory = factory;
    }

    public IPDFCreator Create(string input)
    {
        var set = this.factory();
        IPDFCreator output = set.Where(x => x.taskTypes == input).First();
        return output;
    }
}
