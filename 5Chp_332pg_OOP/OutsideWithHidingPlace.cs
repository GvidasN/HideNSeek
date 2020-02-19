using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Chp_332pg_OOP
{
    class OutsideWithHidingPlace:Outside, IHidingPlace
    {

        public string HidingPlace { get; }

        public OutsideWithHidingPlace(string Name, bool weather, string HidingSpot) : base( Name, weather)
        {
            HidingPlace = HidingSpot;
        }
    }
}
