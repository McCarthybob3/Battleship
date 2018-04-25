using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class Output
    {
       
        public static void WelcomeMessage()
        {

            Console.WriteLine(
"                                      | __\n"+
"                                      |\\/\n"+
"                                      ---\n"+
"                                     / | [\n"+
"                             !      | |||\n"+
"                          _ /|   _ /| -++'\n"+
"                        + +--|  | --| --|_ | -\n"+
"                     { /| __ |  |/\\__ |  | --- ||| __ /\n"+
"                     +---------------___[} -_ === _.'____                    /\\ \n" + 
"                     ____ -  ||___-{]_| _[}-  |      |_[___\\==--             \\/   _\n"+
"   __..._____-- ==/ ___]_ | __ | _____________________________[___\\== --____, ------' .7\n"+
  "|                                                                          | BB - 61 /\n"+
  " \\_________________________________________________________________________________ |\n"
   );
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to BattleShip, Generals!");
            Console.ReadKey();
            Console.Clear();
           

        }

        public static string P1_name() {

            Console.WriteLine("Player 1: enter your name please");
            string answer = ConsoleInput.ReadLine();
            return answer;
        }

        public static string P2_name()
        {

            Console.WriteLine("Player 2: enter your name please");
            string answer = ConsoleInput.ReadLine();
            return answer;
        }


        public static void PlayerTurn(string name)
        {
            Console.WriteLine($"Your turn {name}! ");
            Console.ReadKey();

        }

        

        public static void replay()
        {
            Console.WriteLine("Would you like to play again?  Yes or no ");
            string answer = ConsoleInput.ReadLine();

            if (answer == "Yes" || answer == "yes" || answer == "Y" || answer == "y")
            {
                GameFlow.Flow();
            }
            else
            {
                Console.WriteLine("Thanks for playing!, press any key to quit");
                Console.ReadKey();
            }


        }
        
        

       


        public static ShipDirection PickADirection()
        {
            string directionTemp = "";
            ShipDirection Direction = new ShipDirection();
            Console.WriteLine("Pick a direction");
            directionTemp = ConsoleInput.ReadLine();

            
            if (directionTemp == "Up" || directionTemp == "up")
            {
                Direction = ShipDirection.Up;
            }
            else if (directionTemp == "Down" || directionTemp == "down")
            {
                Direction = ShipDirection.Down;
            }
            else if (directionTemp == "Right" || directionTemp == "right")
            {
                Direction = ShipDirection.Right;
            }
            else if (directionTemp == "Left" || directionTemp == "left")
            {
                Direction = ShipDirection.Left;
            }
            else
            {
                Console.WriteLine("Invalid use, try again");
                Console.ReadKey();
                PickADirection();
            }
            return Direction;
        }

        public static ShipType UserTypeShip(Board x, int Count)
        {
            ShipType ship = new ShipType();

            Console.WriteLine("Enter a Ship type");
            string typeofship = ConsoleInput.ReadLine();


            if (typeofship == "Destroyer" || typeofship == "destroyer")
            {
                ship = ShipType.Destroyer;

            }
            else if (typeofship == "Submarine" || typeofship == "submarine")
            {
                ship = ShipType.Submarine;

            }
            else if (typeofship == "Cruiser" || typeofship == "cruiser")
            {
                ship = ShipType.Cruiser;

            }
            else if (typeofship == "Battleship" || typeofship == "battleship")
            {
                ship = ShipType.Battleship;

            }
            else if (typeofship == "Carrier" || typeofship == "carrier")
            {
                ship = ShipType.Carrier;
              
                
            }
            else
            {
                Console.WriteLine("Invalid Ship type, try again");
                UserTypeShip(x, Count);
              
            }

            
                for (int i = Count; i < 5; i++)
                {
                if (Count ==1)
                {
                    if (x.Ships[i - 1].ShipType == ship)
                    {
                        Console.WriteLine("You've got a duplicate ship, try again!");
                       ship = UserTypeShip(x, Count);
                    }
                }
                else if (Count == 2)
                {
                    if ((x.Ships[i - 1].ShipType == ship)||(x.Ships[i - 2].ShipType == ship))
                    {
                        Console.WriteLine("You've got a duplicate ship, try again!");
                      ship =  UserTypeShip(x, Count);
                    }
                }
                else if (Count == 3)
                {
                    if ((x.Ships[i - 1].ShipType == ship) || (x.Ships[i - 2].ShipType == ship)|| (x.Ships[i - 3].ShipType == ship))
                    {
                        Console.WriteLine("You've got a duplicate ship, try again!");
                       ship = UserTypeShip(x, Count);
                    }
                }
                else if(Count==4)
                {
                    if ((x.Ships[i - 1].ShipType == ship) || (x.Ships[i - 2].ShipType == ship) || (x.Ships[i - 3].ShipType == ship)||(x.Ships[i - 4].ShipType == ship))
                    {
                        Console.WriteLine("You've got a duplicate ship, try again!");
                       ship = UserTypeShip(x, Count);
                    }
                }
                break;
                }
               

            

                return ship;
            
        

        }

 
    }
}
