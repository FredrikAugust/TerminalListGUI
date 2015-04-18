using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalListGUI;

namespace OptionFunctionManipulator
{
    interface IMethod
    {
        /// <summary>
        /// This is the interface for the functions which will be associated with the options.
        /// </summary>

        int FunctionID { get; set; }
        void Function();
    }
    static class CreateOptionFunction
    {
        /// <summary>
        /// Instanciates the objects which contains the functions. I am aware this is a klunky way to solve this, but it's the only way for now.
        /// </summary>
        /// <returns>List of all the functions which are associated with the options</returns>

        public static List<IMethod> CreateFunctions()
        {
            List<IMethod> OptionFunctions = new List<IMethod>();

            // To create a new function:
            // * Start by adding the class, int and method down below (at the bottom of this file)
            // * Then copy, paste and edit the following commented fields

            Exit Exit = new Exit();
            Exit.FunctionID = 0;

            PrintSomething PrintSomething = new PrintSomething();
            PrintSomething.FunctionID = 1;

            // Class ClassObject = new Class(),
            // Class.FunctionID = x; Where x is +1 of the highest number over

            OptionFunctions.Add(Exit);
            OptionFunctions.Add(PrintSomething);

            // OptionFunctions.Add(ClassObject);

            return OptionFunctions;
        }
    }
    static class ReturnToMenu
    {
        /// <summary>
        /// Simple 'controls' that are used when the user has 'entered' a method.
        /// The only thing you can really do is go back to the "choose method" menu, or exit the application
        /// </summary>

        public static void MethodControls() 
        {
            string exitInfo = "Press any key to return to the option menu, or Escape to exit the program";
            Console.WriteLine("\n");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("{0}".PadRight(Console.WindowWidth - (1 + exitInfo.Length)), exitInfo);

            Console.ResetColor();

            ConsoleKeyInfo keyPressed = Console.ReadKey(true);

            switch (Convert.ToString(keyPressed.Key))
            {
                case "Escape":
                    Environment.Exit(0);
                    break;
                default:
                    MenuUI.CreateMenu();
                    break;
            }   
        }
    }

    // Place all of your custom methods under here

    class Exit : IMethod
    {
        private int functionID;

        public int FunctionID
        {
            get
            {
                return this.functionID;
            }
            set
            {
                this.functionID = value;
            }
        }

        public void Function()
        {
            Environment.Exit(0);
        }
    }

    class PrintSomething : IMethod
    {
        private int functionID;

        public int FunctionID
        {
            get
            {
                return this.functionID;
            }
            set
            {
                this.functionID = value;
            }
        }

        public void Function()
        {
            Console.WriteLine("Welcome to paradise!");
        }
    }
}
