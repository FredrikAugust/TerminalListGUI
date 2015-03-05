using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
