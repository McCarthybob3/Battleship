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
    public class GameFlow
    {
        public static string P1_Name { get; set; }
        public static string P2_Name { get; set; }
        public static MakeBoard Make = new MakeBoard();
       public static Board p1_Board = new Board();
       public static Board p2_Board = new Board();

        public static Ship[] PlaceShipTest2(Board x)
            
        {

            for (int k = 0; k < 5; k++)
            {
                bool repeat = true;
                PlaceShipRequest NewRequest = new PlaceShipRequest();
                do
                {
                  
                    NewRequest = GameFlow.Request(x, k);


                    x.CheckCoordinate(NewRequest.Coordinate);
               

                ShipPlacement Test = new ShipPlacement();

                Test = x.PlaceShip(NewRequest);

                    if(Test == ShipPlacement.Overlap)
                    {
                        repeat = true;
                        Console.WriteLine("Oops, there was an overlap, let's try that again");
                    }
                    else if(Test== ShipPlacement.NotEnoughSpace)
                    {
                        repeat = true;
                        Console.WriteLine("No room there, try again");
                    }
                    else if (Test == ShipPlacement.Ok)
                    {
                        repeat = false;
                        Console.WriteLine("That works!");
                    }

                }
                while (repeat==true );


            }
            return x.Ships;

        }

        private static PlaceShipRequest Prompt(Board x, int Count)
        {
            
            
            
            Coordinate cord = ConsoleInput.InputtoCoordinate();
            ShipDirection dir = Output.PickADirection();
            ShipType shipT = Output.UserTypeShip(x, Count);

            

            PlaceShipRequest Player_ShipRequest = new PlaceShipRequest();
            Player_ShipRequest.Coordinate = cord;
            Player_ShipRequest.Direction = dir;
            Player_ShipRequest.ShipType = shipT;
            return Player_ShipRequest;

         
            }



        public static PlaceShipRequest Request(Board x, int Count)
        {
            PlaceShipRequest Requests = new PlaceShipRequest();

                Requests = Prompt(x, Count);
            return Requests;
        }
     

        


        public static void Flow()
        {
           

           

            Output.WelcomeMessage();
            P1_Name = Output.P1_name();
            P2_Name = Output.P2_name();

            //p1 Build Board

            Make.Blank(p1_Board);
            Output.PlayerTurn(P1_Name);
            Console.WriteLine("");
           GameFlow.PlaceShipTest2(p1_Board);
            Make.Drawboard(p1_Board);
            Console.ReadKey();
            Console.Clear();
            
            //p2 Build Board
            Make.Blank(p2_Board);
            Output.PlayerTurn(P2_Name);
            Console.WriteLine("");
            GameFlow.PlaceShipTest2(p2_Board);
            Make.Drawboard(p2_Board);
            Console.ReadKey();
            Console.Clear();

            Random _Rnd = new Random();
            int turn = _Rnd.Next(1, 2);

            ShotStatus Victorious = new ShotStatus();
            Console.WriteLine("Let the Games begin!");
          
            do {
                if (turn % 2 == 0)
                {
                    
                    Console.Clear();
                    bool repeat = false;
                    Console.WriteLine($"It's {P2_Name}'s turn");
                    //player 2 goes first
                    Console.WriteLine($"{P2_Name}'s Board");
                    Make.Drawboard(p2_Board);
                    Console.WriteLine($"{P1_Name}'s Board");
                    Make.DrawEnemyBoard(p1_Board);

                    do {
                       
                       
                        Console.WriteLine("Pick Somewhere to Fire");
                       
                        
                        Coordinate FireCord = (ConsoleInput.InputtoCoordinate());
                        FireShotResponse p2_ResponseOfChoice = p1_Board.FireShot(FireCord);

                        if (p2_ResponseOfChoice.ShotStatus == ShotStatus.Duplicate)
                        {
                            Console.WriteLine("You already tried that silly!, try again!");
                            repeat = true;
                        }
                        else if (p2_ResponseOfChoice.ShotStatus == ShotStatus.Hit)
                        {
                            Console.WriteLine("It's a hit!");
                            Make.DrawEnemyBoardFire(p1_Board, p2_ResponseOfChoice, FireCord);
                            repeat = false;

                        }
                        else if (p2_ResponseOfChoice.ShotStatus == ShotStatus.HitAndSunk)
                        {
                            Console.WriteLine($"Massive hit!, You sunk the {p2_ResponseOfChoice.ShipImpacted}");
                            Make.DrawEnemyBoardFire(p1_Board, p2_ResponseOfChoice, FireCord);
                            repeat = false;
                        }
                        else if (p2_ResponseOfChoice.ShotStatus == ShotStatus.Invalid)
                        {
                            Console.WriteLine("Invalid input, try again");
                            repeat = true;
                        } else if (p2_ResponseOfChoice.ShotStatus == ShotStatus.Miss)
                        {
                            Console.WriteLine("Oops, looks like you missed");
                            Make.DrawEnemyBoardFire(p1_Board, p2_ResponseOfChoice, FireCord);
                            repeat = false;
                        } else if (p2_ResponseOfChoice.ShotStatus == ShotStatus.Victory)
                        {
                            Console.WriteLine($"{P2_Name} Wins!");
                            Victorious = ShotStatus.Victory;
                            repeat = false;
                        }

                    } while (repeat == true);

                    Console.ReadKey();
                    turn++;
                }
                else
                {
                    
                    Console.Clear();
                    bool repeat = false;
                    //player 1 goes first
                    Console.WriteLine($"{P1_Name}'s turn");
                    Console.WriteLine($"{P1_Name}'s Board");
                    Make.Drawboard(p1_Board);
                    Console.WriteLine($"{P2_Name}'s Board");
                    Make.DrawEnemyBoard(p2_Board);
                  
                    //player 1 goes first 
                    do
                    {
                        Console.WriteLine("Pick Somewhere to Fire");
                      
                        
                        
                        Coordinate FireCord = (ConsoleInput.InputtoCoordinate());
                        FireShotResponse p1_ResponseOfChoice = p2_Board.FireShot(FireCord);

                        if (p1_ResponseOfChoice.ShotStatus == ShotStatus.Duplicate)
                        {
                            Console.WriteLine("You already tried that silly!, try again!");
                            repeat = true;
                        }
                        else if (p1_ResponseOfChoice.ShotStatus == ShotStatus.Hit)
                        {
                            Console.WriteLine("It's a hit!");
                            Make.DrawEnemyBoardFire(p2_Board, p1_ResponseOfChoice, FireCord);
                            repeat = false;

                        }
                        else if (p1_ResponseOfChoice.ShotStatus == ShotStatus.HitAndSunk)
                        {
                            Console.WriteLine($"Massive hit!, You sunk the {p1_ResponseOfChoice.ShipImpacted}");
                            Make.DrawEnemyBoardFire(p2_Board, p1_ResponseOfChoice, FireCord);
                            repeat = false;
                        }
                        else if (p1_ResponseOfChoice.ShotStatus == ShotStatus.Invalid)
                        {
                            Console.WriteLine("Invalid input, try again");
                            repeat = true;
                        }
                        else if (p1_ResponseOfChoice.ShotStatus == ShotStatus.Miss)
                        {
                            Console.WriteLine("Oops, looks like you missed");
                            Make.DrawEnemyBoardFire(p2_Board, p1_ResponseOfChoice, FireCord);
                            repeat = false;
                        }
                        else if (p1_ResponseOfChoice.ShotStatus == ShotStatus.Victory)
                        {
                            Console.WriteLine($"{P1_Name} Wins!");
                            Victorious = ShotStatus.Victory;
                            repeat = false;
                        }
                    }
                    while (repeat == true);
                    Console.ReadKey();
                    turn++;
                }
            } while (Victorious != ShotStatus.Victory);

            Output.replay();


            Console.ReadKey();
            Console.Clear();




            


        }
        
    }
}


