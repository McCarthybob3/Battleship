using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameFlow Game = new GameFlow();
            GameFlow.Flow();
        }
    }
}
