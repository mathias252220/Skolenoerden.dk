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
        services.AddTransient<ILogic, LogicOneTwo>();
        services.AddSingleton<Func<IEnumerable<ILogic>>>(x => () => x.GetService<IEnumerable<ILogic>>());
        services.AddSingleton<ILogicFactory, LogicFactory>();
    }
}