using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5Chp_332pg_OOP
{
    public partial class Form1 : Form
    {
        // OBJECT'S CREATION

        Room DiningRoom;
        Room Stairs;

        RoomWithDoor LivingRoom;
        RoomWithDoor Kitchen;

        OutsideWithDoor FrontYard;
        OutsideWithDoor BackYard;

        RoomWithHidingPlace UpstairsHallway;
        RoomWithHidingPlace MasterBedroom;
        RoomWithHidingPlace SecondBedroom;
        RoomWithHidingPlace Bathroom;

        OutsideWithHidingPlace Driveway;
        OutsideWithHidingPlace Garden;

        Location CurrentLocation;

        Opponent Computer;

        void CreateObjects()
        {
            //OBJECT'S DECLARATION

            DiningRoom = new Room("Dining Room", "A beautiful oak table");
            Garden = new OutsideWithHidingPlace("Garden", true, "shed");
            LivingRoom = new RoomWithDoor("Living Room", "a huge TV", "a really old looking doors");
            Kitchen = new RoomWithDoor("Kitchen", "nice looking oven", "white with yellow strokes doors");
            FrontYard = new OutsideWithDoor("Front Yard", false, "a really old looking doors");
            BackYard = new OutsideWithDoor("Back Yard", false, "white with yellow strokes doors");
            Stairs = new Room("Stairs", "a wooden bannister that connect the living room");
            UpstairsHallway = new RoomWithHidingPlace("Upstairs hallway", "picture of a dog", "closet");
            MasterBedroom = new RoomWithHidingPlace("Master Bedroom", "large bed", "under the bed");
            SecondBedroom = new RoomWithHidingPlace("Second Bedroom", "small bed", "under the bed");
            Bathroom = new RoomWithHidingPlace("Bathroom", "sink and toilet", "shower");
            Driveway = new OutsideWithHidingPlace("Driveway", true, "garage");  

            LivingRoom.DoorLocation = FrontYard;
            Kitchen.DoorLocation = BackYard;

            FrontYard.DoorLocation = LivingRoom;
            BackYard.DoorLocation = Kitchen;

            DiningRoom.Exits = new Location[] { LivingRoom, Kitchen };
            Garden.Exits = new Location[] { FrontYard, BackYard };
            LivingRoom.Exits = new Location[] { DiningRoom , Stairs};
            Kitchen.Exits = new Location[] { DiningRoom };
            FrontYard.Exits = new Location[] { Garden, Driveway };
            BackYard.Exits = new Location[] { Garden, Driveway };
            Stairs.Exits = new Location[] { LivingRoom, UpstairsHallway };
            UpstairsHallway.Exits = new Location[] { MasterBedroom, SecondBedroom, Bathroom };
            MasterBedroom.Exits = new Location[] { UpstairsHallway };
            SecondBedroom.Exits = new Location[] { UpstairsHallway };
            Bathroom.Exits = new Location[] { UpstairsHallway };
            Driveway.Exits = new Location[] { FrontYard, BackYard };
        }

        void GoTo(Location location)
        {
            // SWITCH OF LOCATION
            CurrentLocation = location;

            comboBox1.Items.Clear();

            // BUTTON2 - GO THROUGH THE DOORS; BUTCHECK - CHECK IF SOMEONE'S HIDING
            button2.Enabled = false;
            butCheck.Enabled = false;

            // ADD NEW ITEMS TO DISPLAY (NEW EXITS)
            for (int i = 0; i < location.Exits.Length; i++) comboBox1.Items.Add(location.Exits[i].Name);

            comboBox1.SelectedIndex = 0;

            // CHECKS IF OBJECTS HAVE THE RIGHT METHODS (INTERFACES)
            if (location is IHasExteriorDoor)
            {
                button2.Enabled = true;
            }

            if (location is IHidingPlace)
            {
                butCheck.Enabled = true;
            }
            textBox1.Text = location.Description;
        }

        public Form1()
        {
            InitializeComponent();
            CreateObjects();

            Computer = new Opponent(FrontYard);

            button1.Visible = false;
            comboBox1.Visible = false;
            button2.Visible = false;
            butCheck.Visible = false;
            textBox1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GoTo(CurrentLocation.Exits[comboBox1.SelectedIndex]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CurrentLocation is IHasExteriorDoor)
            {
                IHasExteriorDoor NewLocation = CurrentLocation as IHasExteriorDoor;
                GoTo(NewLocation.DoorLocation);
            }     
        }

        private void butCheck_Click(object sender, EventArgs e)
        {
            if (Computer.Check(CurrentLocation))
            {
                button1.Visible = false;
                comboBox1.Visible = false;
                button2.Visible = false;
                butCheck.Visible = false;
                butHide.Visible = true;
                textBox1.Text = "";
                MessageBox.Show("You won!");
            }
            else MessageBox.Show("Nobody's here!");
        }

        private void butHide_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++) Computer.Move();

            button1.Visible = true;
            comboBox1.Visible = true;
            button2.Visible = true;
            butCheck.Visible = true;
            butHide.Visible = false;
            GoTo(DiningRoom);
        }
    }
}
