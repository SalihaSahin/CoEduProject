using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> //classın attributeları okunur
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name, method.GetParameters().Select(x =>x.ParameterType).ToArray()) //methodun attributeları okunur
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);


            return classAttributes.OrderBy(x => x.Priority).ToArray();//öncelik sırasına gre sırala
        }
    }
}



