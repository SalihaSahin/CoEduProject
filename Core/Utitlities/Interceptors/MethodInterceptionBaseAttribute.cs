using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    //classlara ya da methodlara kleyebilirsin bu attribute u birden fazla ekleyebilrsin(Allowmultple) ve inherited edilen noktada bu attribute çalışsın
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
    //Attribute olması sağlandı
}


