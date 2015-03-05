using System;
using System.Collections.Generic;
using System.Text;
using OptionFunctionManipulator;

namespace TerminalListGUI
{
    class Option
    {
        private int optionID;
        private string name;
        private string desc;

        public int OptionID
        {
            get
            {
                return this.optionID;
            }
            set
            {
                this.optionID = value;
            }
        }

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
        public static void CreateOption(Option _option, List<Option> _list,  string _name, string _desc, int _id = 1)
        {
            _option.Name = _name;
            _option.Desc = _desc;
            
            int max_id = 1;

            for (var i = 0; i < _list.Count; i++)
            {
                max_id = _list[i].OptionID;
            }

            if (max_id != 1)
            {
                _option.OptionID = max_id;
            }
            else
            {
                _option.OptionID = 1;
            }

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
        private static void CallFunction(int _pos, List<Option> _options)
        {
            List<IFunction> OptionFunctions = CreateOptionFunction.CreateFunctions();

            for (int i = 0; i < OptionFunctions.Count; i++)
            {
                if (OptionFunctions[i].FunctionID == _pos)
                {
                    OptionFunctions[i].Function();
                    ReturnToMenu.FunctionControls();
                }
            }
        }
        public static void ReadKey(List<Option> options, int position)
        {
            Console.WriteLine("Use the arrow keys to navigate, and enter to select option");

            Console.CursorVisible = false;

            while (true)
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
                    case "Enter":
                        CallFunction(position, options);
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

            Option Placeholder1 = new Option();
            Option Placeholder2 = new Option();
            Option Placeholder3 = new Option();
            Option Exit = new Option();

            // Placeholders
            OptionCreator.CreateOption(Placeholder1, Options, "Hold my place", "Place my hold");
            OptionCreator.CreateOption(Placeholder2, Options, "Hold my place", "Place my hold");
            OptionCreator.CreateOption(Placeholder3, Options, "Hold my place", "Place my hold");
            OptionCreator.CreateOption(Exit, Options, "Exit", "Closes the program");

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
