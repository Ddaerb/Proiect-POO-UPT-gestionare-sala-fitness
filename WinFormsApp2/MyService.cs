using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class MyService : IMyService
    {
        public void DoSomething()
        {
            Console.WriteLine("MyService is doing something.");
        }
    }
}
