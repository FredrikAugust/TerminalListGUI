using System;
using System.Collections.Generic;
using System.Text;
using OptionFunctionManipulator;

namespace TerminalListGUI
{
    class Option
    {
        /// <summary>
        /// Creating necessary variables for the options to work.
        /// The option ID will be a unique ID that will be used to 
        /// determine which of the options to show.
        /// 
        /// Instances of this class will be used to represent the options.
        /// </summary>

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
    static class OptionCreator
    {
        /// <summary>
        /// This features all the methods necessary to create an option and it's components.
        /// </summary>
        /// <param name="_option">The option which the method should edit/create</param>
        /// <param name="_list">The list which the option will be added to</param>
        /// <param name="_name">The name of the option</param>
        /// <param name="_desc">A short one-liner description of the option and what it will do</param>

        public static void CreateOption(Option _option, List<Option> _list,  string _name, string _desc)
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

            _list.Add(_option);
        }
    }
    static class MenuHandler
    {
        /// <summary>
        /// This simply handles the navitgation of the options. 
        /// Regarding of the user input this method will see if you are able to move up/down
        /// if so; you will move up or down.
        /// </summary>
        /// <param name="_position">This is the parameter that determines where in the option "list" you are</param>
        /// <param name="_direction">Which direction the user is trying to move in</param>
        /// <param name="_options">This is a list of all the options, I might incorporate this into some other method later</param>
        
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

        /// <summary>
        /// Depending on the cursors position in the option list, it will call the respective function
        /// </summary>
        /// <param name="_pos">The position of the cursor. This is retrieved from another method</param>
        /// <param name="_options">A list of all the OPTIONS, it is very important that this is paralell with the METHOD list</param>

        private static void CallMethod(int _pos, List<Option> _options)
        {
            List<IMethod> OptionMethods = CreateOptionFunction.CreateFunctions();  // This is where all the functions belonging to the options are stored for now

            for (int i = 0; i < OptionMethods.Count; i++)
            {
                if (OptionMethods[i].FunctionID == _pos)
                {
                    OptionMethods[i].Function();
                    ReturnToMenu.MethodControls();
                }
            }
        }

        /// <summary>
        /// This gets the key the user pressed, and passes that value along to the correct method.
        /// I have not done any error handling etc. 
        /// </summary>
        /// <param name="options">Once again; the list of options</param>
        /// <param name="position">The position in the list of options</param>

        public static void ReadKey(List<Option> options, int position)
        {
            Console.WriteLine("Use the arrow keys to navigate, and enter to select option");

            Console.CursorVisible = false;

            while (true)  // This runs an infinite loop, which means that this could really just be in the main loop of the Program class.
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
                        CallMethod(position, options);
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again.");
                        continue;
                }
            }
        }
    }
    static class MenuUI
    {
        /// <summary>
        /// This will print out a single option to the screen
        /// This is put in a separate method simply for syntactic sugar, meaning that it doesn't affect the program either way, 
        /// but I think this approach looks better.
        /// </summary>
        /// <param name="option">A single option that this will print out</param>

        private static void PrintMenuOption(Option option)
        {
            Console.WriteLine("Name: {0}".PadRight(Console.WindowWidth - (1 + option.Name.Length)), option.Name);
            Console.WriteLine("Desc: {0}".PadRight(Console.WindowWidth - (1 + option.Desc.Length)), option.Desc);
            Console.WriteLine();
        }

        /// <summary>
        /// Creates the options menu, this is done by simply printing the name and the desription followed by an empty line.
        /// The only logic in this method is the fact that it will print a 'formatted' line when printing the currently selected option.
        /// This is done using the Console object, I might go over to a more homemade design later using
        /// Windows Forms as this is a bit more flexible and easier maintainable.
        /// </summary>
        /// <param name="selected">The currently selected option, this is used for displaying what option is currently selected</param>
        
        public static void CreateMenu(int selected = 0)
        {
            List<Option> Options = new List<Option>();

            Option Exit = new Option();
            OptionCreator.CreateOption(Exit, Options, "Exit", "Terminates the program");

            Option PrintSomething = new Option();
            OptionCreator.CreateOption(PrintSomething, Options, "Print Something", "Prints a magnificent piece of art");

            Console.Clear();

            for (int i = 0; i < Options.Count; i++)
            {
                if (i == selected)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                    PrintMenuOption(Options[i]);
                    
                    Console.ResetColor();

                    continue;
                }

                PrintMenuOption(Options[i]);
            }

            MenuHandler.ReadKey(Options, selected);
        }
    }
    class Program
    {
        /// <summary>
        /// Because of the pretty horrible structure of methods in this program, this will start the CreateMenu() method, 
        /// which will eventually result in an infinite loop checking for user input. 
        /// Once again; this is one of the reasons for why I'm considering changing to Windows Forms
        /// </summary>

        static void Main()
        {
            MenuUI.CreateMenu();
        }
    }
}
