using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Chp_332pg_OOP
{
    class Outside:Location
    {
        private bool hot;

        public override string Description
        {
            get
            {
                if (hot) return base.Description + " It is warm.";
                else return base.Description + " It is cold.";
            }
        }

        public Outside(string Name, bool weather) : base(Name)
        {
            hot = weather;
        }
    }
}
