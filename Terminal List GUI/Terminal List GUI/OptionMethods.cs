using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionFunctionManipulator
{
    class OptionFunction
    {
        private int optionFunctionID;

        public int OptionFunctionID
        {
            get
            {
                return this.optionFunctionID;
            }
            set
            {
                this.optionFunctionID = value;
            }
        }
    }
    class CreateOptionFunction
    {
        public static List<OptionFunction> CreateFunctions()
        {
            List<OptionFunction> OptionFunctions = new List<OptionFunction>();

            OptionFunction Placeholder1 = new OptionFunction();

            Placeholder1.OptionFunctionID = 1;

            return OptionFunctions;
        }
    }
}
