using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Chp_332pg_OOP
{
    class OutsideWithDoor:Outside, IHasExteriorDoor
    {
        private string doorDescription;
        public OutsideWithDoor(string Name, bool weather, string Doors) : base(Name, weather)
        {
            doorDescription = Doors;
        }

       public string DoorDescription
        {
            get { return doorDescription; }           
        }

       public Location DoorLocation
        {
            get;
            set;
        }

        public override string Description
        {
            get
            {
                return base.Description + " You also see " + DoorDescription + " that leads to " + DoorLocation.Name + ".";
            }
        }

    }
}
