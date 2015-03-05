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

            Placeholder1 Placeholder1 = new Placeholder1();
            Placeholder2 Placeholder2 = new Placeholder2();
            Placeholder3 Placeholder3 = new Placeholder3();
            Exit Exit = new Exit();

            Placeholder1.FunctionID = 0;
            Placeholder2.FunctionID = 1;
            Placeholder3.FunctionID = 2;
            Exit.FunctionID = 3;

            OptionFunctions.Add(Placeholder1);
            OptionFunctions.Add(Placeholder2);
            OptionFunctions.Add(Placeholder3);
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

    class Placeholder1 : IFunction
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
            Console.Clear();
            Console.WriteLine("Sweeet");
        }
    }
    class Placeholder2 : IFunction
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
            Console.Clear();
            Console.WriteLine("Cool");
        }
    }
    class Placeholder3 : IFunction
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
            Console.Clear();
            Console.WriteLine("Nice");
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
