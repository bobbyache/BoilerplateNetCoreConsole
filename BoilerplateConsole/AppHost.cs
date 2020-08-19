using System;
using System.Collections.Generic;
using System.Text;

namespace BoilerplateConsole
{
    public class AppHost : IAppHost
    {
        private readonly IServiceA serviceA;

        public AppHost(IServiceA mailService)
        {
            serviceA = mailService;
        }

        public void Run()
        {
            serviceA.Log("hello world!");
        }
    }
}
