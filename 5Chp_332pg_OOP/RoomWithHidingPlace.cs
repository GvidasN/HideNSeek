using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Chp_332pg_OOP
{
    class RoomWithHidingPlace : Room, IHidingPlace
    {
        public string HidingPlace { get; }

        public RoomWithHidingPlace(string Name, string decoration, string HidingSpot) : base(Name, decoration)
        {
            HidingPlace = HidingSpot;
        }
    }
}
