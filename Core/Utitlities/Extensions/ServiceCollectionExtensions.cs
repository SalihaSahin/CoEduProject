using Core.Utitlities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utitlities.Extensions
{ 
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection servicecollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(servicecollection);
            }
            return ServiceTool.Create(servicecollection);
        }
    }
}
