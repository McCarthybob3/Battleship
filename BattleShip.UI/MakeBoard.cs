using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{

    public class MakeBoard
    {



        public Board Drawboard(Board x)
        {
           
            int[,] arr = new int[10, 10];

            for (int i = 1; i <= 10; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        string marking = " ";
                        Coordinate CurrentCoordinate = new Coordinate(i, j);
                       
                            
                        
                        var checkCord = x.CheckCoordinate(CurrentCoordinate); 

                     
                       
                        if (x.Ships[0].BoardPositions.Contains(CurrentCoordinate))
                        {
                        if(x.Ships[0].ShipType == ShipType.Battleship)
                        {
                            marking = "B";
                        }
                        else if (x.Ships[0].ShipType == ShipType.Carrier)
                        {
                            marking = "C";
                        }
                        else if(x.Ships[0].ShipType == ShipType.Cruiser)
                        {
                            marking = "R";
                        }
                        else if(x.Ships[0].ShipType == ShipType.Destroyer)
                        {
                            marking = "D";
                        }
                        else if(x.Ships[0].ShipType == ShipType.Submarine)
                        {
                            marking = "S";
                        }
                          
                        }
                      else if (x.Ships[1].BoardPositions.Contains(CurrentCoordinate))
                        {
                        if (x.Ships[1].ShipType == ShipType.Battleship)
                        {
                            marking = "B";
                        }
                        else if (x.Ships[1].ShipType == ShipType.Carrier)
                        {
                            marking = "C";
                        }
                        else if (x.Ships[1].ShipType == ShipType.Cruiser)
                        {
                            marking = "R";
                        }
                        else if (x.Ships[1].ShipType == ShipType.Destroyer)
                        {
                            marking = "D";
                        }
                        else if (x.Ships[1].ShipType == ShipType.Submarine)
                        {
                            marking = "S";
                        }

                    }
                    else if (x.Ships[2].BoardPositions.Contains(CurrentCoordinate))
                        {
                        if (x.Ships[2].ShipType == ShipType.Battleship)
                        {
                            marking = "B";
                        }
                        else if (x.Ships[2].ShipType == ShipType.Carrier)
                        {
                            marking = "C";
                        }
                        else if (x.Ships[2].ShipType == ShipType.Cruiser)
                        {
                            marking = "R";
                        }
                        else if (x.Ships[2].ShipType == ShipType.Destroyer)
                        {
                            marking = "D";
                        }
                        else if (x.Ships[2].ShipType == ShipType.Submarine)
                        {
                            marking = "S";
                        }

                    }
                    else if (x.Ships[3].BoardPositions.Contains(CurrentCoordinate))
                        {
                        if (x.Ships[3].ShipType == ShipType.Battleship)
                        {
                            marking = "B";
                        }
                        else if (x.Ships[3].ShipType == ShipType.Carrier)
                        {
                            marking = "C";
                        }
                        else if (x.Ships[3].ShipType == ShipType.Cruiser)
                        {
                            marking = "R";
                        }
                        else if (x.Ships[3].ShipType == ShipType.Destroyer)
                        {
                            marking = "D";
                        }
                        else if (x.Ships[3].ShipType == ShipType.Submarine)
                        {
                            marking = "S";
                        }

                    }
                    else if (x.Ships[4].BoardPositions.Contains(CurrentCoordinate))
                        {
                        if (x.Ships[4].ShipType == ShipType.Battleship)
                        {
                            marking = "B";
                        }
                        else if (x.Ships[4].ShipType == ShipType.Carrier)
                        {
                            marking = "C";
                        }
                        else if (x.Ships[4].ShipType == ShipType.Cruiser)
                        {
                            marking = "R";
                        }
                        else if (x.Ships[4].ShipType == ShipType.Destroyer)
                        {
                            marking = "D";
                        }
                        else if (x.Ships[4].ShipType == ShipType.Submarine)
                        {
                            marking = "S";
                        }

                    }
                    if (checkCord == ShotHistory.Miss)
                    {

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        marking = "M";
                       
                    }
                    if (checkCord == ShotHistory.Hit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        marking = "H";
                      
                    }



                    Console.Write($"|{marking}");
                    Console.ForegroundColor = ConsoleColor.White;

                }

                    Console.WriteLine();

                
            }
            return x;
        }


        public Board Blank(Board x)
        {

            int[,] arr = new int[11, 11];



            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    string marking = "-";


                    Console.Write($"|{marking}");

                }

                Console.WriteLine();

            }
            return x;
        }

        public Board DrawEnemyBoardFire(Board x, FireShotResponse shot, Coordinate cord)
        {
            ShotHistory History = new ShotHistory();



            for (int k = 0; k < 5; k++)
            {


                x.CheckCoordinate(cord);
                Coordinate[] p1 = new Coordinate[10];

            }

            int[,] arr = new int[11, 11];



            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    string marking = " ";
                    Coordinate CurrentCoordinate = new Coordinate(i, j);
                    for (int k = 0; k < 5; k++)
                    {
                        History = x.CheckCoordinate(cord);
                    }
                    var checkCord = History;

                    if (checkCord == ShotHistory.Miss && (j == cord.YCoordinate && i == cord.XCoordinate))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        marking = "M";
                        
                    }
                    else if (checkCord == ShotHistory.Hit && (j == cord.YCoordinate && i == cord.XCoordinate))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        marking = "H";
                        
                    }
                    else if (checkCord == ShotHistory.Unknown && (j == cord.YCoordinate && i == cord.XCoordinate))
                    {
                        marking = "-";
                    }





                    Console.Write($"|{marking}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();


            }
            return x;

        }

        public Board DrawEnemyBoard(Board x)
        {
            ShotHistory History = new ShotHistory();

          
            

            int[,] arr = new int[10, 10];



            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    string marking = " ";
                    Coordinate CurrentCoordinate = new Coordinate(i, j);
                    for (int k = 0; k < 5; k++)
                    {
                        History = x.CheckCoordinate(CurrentCoordinate);
                    }
                    var checkCord = History;

                    if (checkCord == ShotHistory.Miss)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        marking = "M";
                     
                    }
                    if (checkCord == ShotHistory.Hit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        marking = "H";
                       
                    }
                    if (checkCord == ShotHistory.Unknown)
                    {
                        marking = "-";
                    }




                    Console.Write($"|{marking}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
              

            }
            return x;

        }


    }
}
    
