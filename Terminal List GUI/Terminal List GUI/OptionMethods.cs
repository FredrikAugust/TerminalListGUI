using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalListGUI;

namespace OptionFunctionManipulator
{
    interface IFunction
    {
        int FunctionID { get; set; }
        void Function();
    }
    class CreateOptionFunction
    {
        public static List<IFunction> CreateFunctions()
        {
            List<IFunction> OptionFunctions = new List<IFunction>();

            Exit Exit = new Exit();
            Exit.FunctionID = 0;
            OptionFunctions.Add(Exit);

            return OptionFunctions;
        }
    }
    class ReturnToMenu
    {
        public static void FunctionControls() 
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

    class Exit : IFunction
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
}
