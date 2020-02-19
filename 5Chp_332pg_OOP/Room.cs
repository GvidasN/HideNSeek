using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Chp_332pg_OOP
{
    class Room:Location
    {
        private string Decoration;

        public override string Description
        {
            get
            {
                return base.Description + " In the room there is a " + Decoration + ".";
            }
        }

        public Room(string Name,string decoration) : base(Name)
        {
            Decoration = decoration;
        }
    }
}
