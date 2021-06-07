using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    // bu attribute'u kullanabilecek şeyleri sınırlıyoruz. Bu bir class olabilir, method olabilir, birden çok kez kullanılabilir
    // ve bu attribute çalışacağı method veya classın inherit ettiği yerlerde de çalışacak.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        //öncelik
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {
            
        }
    }
}
