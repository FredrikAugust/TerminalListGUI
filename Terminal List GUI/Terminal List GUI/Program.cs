using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalListGUI
{
    class Program
    {
        static void Main()
        {
            Option option1 = new Option("test", "test123");

            Console.WriteLine(option1.name);
            Console.ReadKey();
        }
    }
}
