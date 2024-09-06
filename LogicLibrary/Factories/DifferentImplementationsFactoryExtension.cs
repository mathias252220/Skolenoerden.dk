using LogicLibrary.QuestPDF;
using LogicLibrary.TreasureHunt;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Factories;

public static class DifferentImplementationsFactoryExtension
{
    public static void AddLogicFactory(this IServiceCollection services)
    {
        services.AddTransient<ILogic, LogicZero>();
        services.AddTransient<ILogic, LogicOne>();
        services.AddTransient<ILogic, LogicTwo>();
        services.AddTransient<ILogic, LogicThree>();
        services.AddTransient<ILogic, LogicFour>();
        services.AddTransient<ILogic, LogicFive>();
        services.AddTransient<ILogic, LogicSix>();
        services.AddTransient<ILogic, LogicSeven>();
        services.AddTransient<ILogic, LogicEight>();
        services.AddTransient<ILogic, LogicNine>();
        services.AddSingleton<Func<IEnumerable<ILogic>>>(x => () => x.GetService<IEnumerable<ILogic>>());
        services.AddSingleton<ILogicFactory, LogicFactory>();
    }

    public static void AddPDFCreatorFactory(this IServiceCollection services)
    {
        services.AddTransient<IPDFCreator, PDFCreatorElemental>();
        services.AddTransient<IPDFCreator, PDFCreatorFracEq>();
        services.AddSingleton<Func<IEnumerable<IPDFCreator>>>(x => () => x.GetService<IEnumerable<IPDFCreator>>());
        services.AddSingleton<IPDFCreatorFactory, PDFCreatorFactory>();
    }
}