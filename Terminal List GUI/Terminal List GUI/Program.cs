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
    class OptionPrinter
    {
        public static void printOptions(int selected = 0)
        {
            List<Option> Options = OptionCreator.CreateOptions();

            for (int i = 0; i < Options.Count; i++)
            {
                Console.Clear();

                string _name = Options[i].Name;
                string _desc = Options[i].Desc;

                if (i == selected)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Name: {0}".PadRight(Console.WindowWidth - (1 + _name.Length)), _name);
                    Console.WriteLine("Desc: {0}".PadRight(Console.WindowWidth - (1 + _desc.Length)), _desc);
                }
            }
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
