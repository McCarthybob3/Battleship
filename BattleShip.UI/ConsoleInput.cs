using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    class ConsoleInput
    {
      

        public static Coordinate InputtoCoordinate()
        {
            
            Console.WriteLine("Enter A Coordinate (A-J for row, 1-10 for column  EX: A1, B2, C3)");
            int First_int = 0;
            string Input =ConsoleInput.ReadLine();

            if (Input.Length <= 1)
            {
                Console.WriteLine("Invalid input, Try again");
                return InputtoCoordinate();


            }
            string First_String = Input.Substring(0, 1);
           
            
            switch (First_String)
            {
                   case "A":
                    First_int = 1;
                    break;
                case "a":
                    First_int = 1;
                    break;
                case "B":
                    First_int = 2;
                    break;
                case "b":
                    First_int = 2;
                    break;
                case "C":
                    First_int = 3;
                    break;
                case "c":
                    First_int = 3;
                    break;
                case "D":
                    First_int = 4;
                    break;
                case "d":
                    First_int = 4;
                    break;
                case "E":
                    First_int = 5;
                    break;
                case "e":
                    First_int = 5;
                    break;
                case "F":
                    First_int = 6;
                    break;
                case "f":
                    First_int = 6;
                    break;
                case "G":
                    First_int = 7;
                    break;
                case "g":
                    First_int = 7;
                    break;
                case "H":
                    First_int = 8;
                    break;
                case "h":
                    First_int = 8;
                    break;
                case "I":
                    First_int = 9;
                    break;
                case "i":
                    First_int = 9;
                    break;
                case "J":
                    First_int = 10;
                    break;
                case "j":
                    First_int = 10;
                    break;
                default :
                    Console.WriteLine("Sorry, try again");
                    return InputtoCoordinate();
                    break;
            }
           
            string Second_String = Input.Substring(Input.Length-1, 1);
            string Third_String = Input.Substring(Input.Length - 2, 2);
            int Second_int=0;

            if ((Second_String == "1" || Second_String == "2" || Second_String == "3" || Second_String == "4" || Second_String == "5" || Second_String == "6" || Second_String == "7" || Second_String == "8" || Second_String == "9"))
            {
                Second_int = Convert.ToInt32(Second_String);

            }
            else if (Third_String == "10")
            {
                Second_int = 10;
            }
            else
            {
                Console.WriteLine("Invalid coordinates, try again");
                return InputtoCoordinate();

            }

            Coordinate Answer = new Coordinate(First_int, Second_int);
            return Answer;

        }

        public static string ReadLine()
        {
          string name =  Console.ReadLine();
            return name;
        }

       
    }
}
