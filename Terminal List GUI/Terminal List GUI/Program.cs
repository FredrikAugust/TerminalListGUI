using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalListGUI
{
    interface IOption
    {
        string Name { get; set; }
        string Desc { get; set; }
    }
    class Option : IOption
    {
        private string name;
        private string desc;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Desc
        {
            get
            {
                return this.desc;
            }
            set
            {
                this.desc = value;
            }
        }
    }
    class OptionCreator
    {
        public static List<Option> CreateOptions()
        {
            List<Option> OptionList = new List<Option>();

            Option HelloWorld = new Option();
            HelloWorld.Name = "Print \"Hello World\"";
            HelloWorld.Desc = "Prints \"Hello World\"";

            OptionList.Add(HelloWorld);

            return OptionList;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.ReadKey();  // Stops the program from exiting when it reaches the last line
        }
    }
}
