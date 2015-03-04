using System;

namespace Option
{
    interface IOption
    {
        string Name { get; set; }
        string Desc { get; set; }
    }
    public class Option
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
                if (value.Length > 1)
                {
                    this.name = value;
                }
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
                if (value.Length > 1)
                {
                    this.desc = value;
                }
            }
        }
    }

}