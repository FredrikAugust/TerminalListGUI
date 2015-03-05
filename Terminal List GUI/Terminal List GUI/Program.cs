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
        private static void AddToList(Option _optionToAdd, List<Option> _optionsList)
        {
            _optionsList.Add(_optionToAdd);
        }
        public static void CreateOption(Option _option, List<Option> _list,  string _name, string _desc)
        {
            _option.Name = _name;
            _option.Desc = _desc;

            AddToList(_option, _list);
        }
    }
    class MenuHandler
    {
        public static void ReadKey(int position = 0)
        {
            bool validInput = false;

            Console.WriteLine("Use the arrow keys to navigate, and enter to select option");

            while (validInput != true)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);

                switch (Convert.ToString(keyPressed.Key))
                {
                    case "UpArrow":
                        MenuUI.CreateMenu(position - 1);
                        break;
                    case "DownArrow":
                        MenuUI.CreateMenu(position + 1);
                        break;
                    case "Enter":
                        Console.WriteLine("This feature has not yet been implemented.");
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again.");
                        continue;
                }
            }
        }
    }
    class MenuUI
    {
        private static void PrintMenuOptions(Option option)
        {
            Console.WriteLine("Name: {0}".PadRight(Console.WindowWidth - (1 + option.Name.Length)), option.Name);
            Console.WriteLine("Desc: {0}".PadRight(Console.WindowWidth - (1 + option.Desc.Length)), option.Desc);
            Console.WriteLine();
        }
        public static void CreateMenu(int selected = 0)
        {
            List<Option> Options = new List<Option>();

            Option NewFile = new Option();
            Option RemoveFile = new Option();

            OptionCreator.CreateOption(NewFile, Options, "New File", "Creates a new file");
            OptionCreator.CreateOption(RemoveFile, Options, "Delete File", "Deletes a file");

            Console.Clear();

            for (int i = 0; i < Options.Count; i++)
            {
                if (i == selected)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                    PrintMenuOptions(Options[i]);
                    
                    Console.ResetColor();

                    continue;
                }

                PrintMenuOptions(Options[i]);
            }

            MenuHandler.ReadKey(selected);
        }
    }
    class Program
    {
        static void Main()
        {
            Console.Clear();

            MenuUI.CreateMenu();

            Console.ReadKey();  // Stops the program from exiting when it reaches the last line
        }
    }
}
