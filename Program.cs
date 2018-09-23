using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouse
{
    //basic menu structure
    class Menu
    {
        static void Main(string[] args)
        {
            bool running = true; //sentry variable
            int choice;

            Mousey myMouse = new Mousey();
            myMouse.name = "Lenny";

            while (running)
            {
                myMouse.Age();
                choice = showMenu();
                switch (choice)
                {
                    case 0:
                        running = false;
                        break;
                    case 1:
                        Console.WriteLine(myMouse.Speak());
                        break;
                    case 2:
                        myMouse.Eat();
                        Console.WriteLine("You have fed the mouse");
                        break;
                    case 3:
                        myMouse.Play();
                        Console.WriteLine("You played with the creature");
                        break;
                    case 4:
                        Console.WriteLine("Current name: {0}", myMouse.name);
                        Console.Write("Change name to: ");
                        myMouse.name = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("You have cleaned the Mouse");
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }//end switch

            }//end while loop
        }//end main


    static int showMenu() //get a numeric value from user, return it
        {
            int input = 1;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("0) Exit");
            Console.WriteLine("1) Talk to Mouse");
            Console.WriteLine("2) Feed Mouse");
            Console.WriteLine("3) Play with Mouse");
            Console.WriteLine("4) Rename the Mouse");
            Console.WriteLine("5) Clean Mouse");
            try
            {
                input = Convert.ToInt32(Console.ReadLine()); //this tries to convert the input to an int
            } catch (FormatException) //if a format exception is caught
            {
                Console.WriteLine("Incorrect"); //write incorrect to the console
                input = 1; //reset the input to a legal value of 1
            } //end try
            return input;
        } //end showmenu
    } //end class

    class Mousey
    {
        private string pName;
        private int pFull = 10;
        private int pClean = 10;
        private int pHappy = 10;
        private int pAge = 0;

        public string name
        {
            get //return a value for a property
            {
                return pName;
            } //end get
            set //accept a potential value for a property and assign it on the private instance var
            {
                if (value.Length > 10)
                {
                    Console.WriteLine("Your name is ten letters");
                    pName = value;
                    pName = pName.Substring(0, 10);
                    Console.WriteLine("Changing name to {0}", pName);
                }
                else
                {
                    pName = value;
                } //end if
            } // end set
        } // end string property

        public string Speak() //set this to void instead of string first and didn't understand why it didn't work. string for messages!!!
        {
            string message;
            message = "Mousey says: \n";

            if (pHappy > 5)
            {
                message += " Hello, I'm " + name + "\n";
                message += " I'm happy. \n";
            }
            else if (pHappy > 2)
            {
                message += " " + name + " is displeased.";
            }
            else if (pHappy > 0)
            {
                message += " " + name + " is angry.";
            }
            else
            {
                message += "nothing. He's dead.";
            } //end if
            return message;

        } //end speaking

        public void Age() //will be adding this to main loop to make sure they age every turn
        {
            //age Mouse and kill him eventually
            pAge++;
            pFull--;
            pHappy--;
            pClean--;

            if (pFull < 5)
            {
                //if hungry, make unhappy quicker
                pHappy--;
            } //end if
        } // end age

        public void Eat()
        {
            pFull += 3; //same as writing pFull = pFull + 3
        } //end eat

        public void Play()
        {
            pHappy += 3;
        } //end play

        public void Clean()
        {
            pClean += 3;
        } //end eat

    } //end class
} //end namespace
