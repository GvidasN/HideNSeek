using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Chp_332pg_OOP
{
    class Opponent
    {
        private Location MyLocation;
        private Random random;

        public Opponent(Location StartingLocation)
        {
            random = new Random();
            MyLocation = StartingLocation;
        }

       public bool Check(Location LocationToCheck)
        {
            if (LocationToCheck == MyLocation) return true;
            else return false;
        }

        public void Move()
        {
            bool WhereToHide = false;

            while (WhereToHide == false)
            {
                if (MyLocation is IHasExteriorDoor)
                {
                    IHasExteriorDoor NewLocation = MyLocation as IHasExteriorDoor;

                    if (random.Next(2) == 1)
                    {
                        MyLocation = NewLocation.DoorLocation;      
                    }
                }

                int RandomNumber = random.Next(MyLocation.Exits.Length);
                MyLocation = MyLocation.Exits[RandomNumber];

                if (MyLocation is IHidingPlace)
                {
                    WhereToHide = true;
                   
                }
            }

            
        }
    }
}
