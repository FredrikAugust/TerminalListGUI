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
        private static void ChangeOption(int _position, string _direction, List<Option> _options)
        {
            if (_direction == "up" && _position != 0)
            {
                MenuUI.CreateMenu(_position - 1);
            }
            else if (_direction == "down" && _position != (_options.Count - 1)) 
            {
                MenuUI.CreateMenu(_position + 1);
            }
        }
        public static void ReadKey(List<Option> options, int position)
        {
            bool validInput = false;

            Console.WriteLine("Use the arrow keys to navigate, and enter to select option");

            while (validInput != true)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);

                switch (Convert.ToString(keyPressed.Key))
                {
                    case "UpArrow":
                        ChangeOption(position, "up", options);
                        continue;
                    case "DownArrow":
                        ChangeOption(position, "down", options);
                        continue;
                    case "Enter":  // This is going to be remade as the options actually gets methods
                        Console.WriteLine("This feature has not yet been implemented.\nPress any button to close the program..");
                        Console.ReadKey(true);
                        Environment.Exit(0);
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

            MenuHandler.ReadKey(Options, selected);
        }
    }
    class Program
    {
        static void Main()
        {
            MenuUI.CreateMenu();
            Console.ReadKey();  // Stops the program from exiting when it reaches the last line
        }
    }
}
