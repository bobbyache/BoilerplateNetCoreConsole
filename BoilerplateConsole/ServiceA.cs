using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BoilerplateConsole
{
    public class ServiceA : IServiceA
    {
        public void Log(string message)
        {
            Debug.Write(message);
        }
    }
}
