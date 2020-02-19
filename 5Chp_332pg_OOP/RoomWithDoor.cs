using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Chp_332pg_OOP
{
    class RoomWithDoor:Room, IHasExteriorDoor
    {
        private string doorDescription;

        public RoomWithDoor(string Name, string decoration, string doors) : base(Name, decoration)
        {
            doorDescription = doors;
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
