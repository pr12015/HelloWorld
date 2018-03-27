using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.Reflection;

namespace HelloWorld
{
    public class Container : IContainer
    {
        public string Load(string assemblyName)
        {
            bool success = false;

            try
            {
                Console.WriteLine(@"C:\users\stefan\Desktop\containers\Container" + assemblyName);
               // Console.ReadKey(true);
                Assembly dll = Assembly.LoadFile(@"C:\users\stefan\Desktop\containers\Container" + assemblyName);
                
                if (dll != null)
                {
                    object obj = dll.CreateInstance("DLL1.DllHello");
                    if (obj != null)
                    {
                        MethodInfo mi = obj.GetType().GetMethod("Greet");
                        mi.Invoke(obj, new object[] { "From dll hell" });
                        success = true;
                    }
                    // success = true;
                }               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            return "Loading assebmly " + (success ? "was " : "was NOT ") + "successfull.";
        }

        public string Load_c()
        {
            bool success = false;
            try
            {
                DLLHelper.dllGreeting();
                success = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return "Loading C assebmly " + (success ? "was " : "was NOT ") + "successfull.";
        }
    }
}
