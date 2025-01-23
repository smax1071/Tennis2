using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Interface;

namespace Tennis
{
    public class Game
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private readonly IScoreManger _scoreManger;
        private readonly Random _random;
        public Game(IPlayer player1, IPlayer player2, IScoreManger scoreManger) { 
            _player1 = player1;
            _player2 = player2;
            _scoreManger = scoreManger;
            _random= new Random();
                }

        public void PlayGame()
        {
       
            while (!_scoreManger.HasWinner())
            {
                
                if (_random.NextDouble() >= 0.5)
                    _player1.ScorePoint();
                else
                    _player2.ScorePoint();
                
                Console.WriteLine(_scoreManger.GetScore());
            }
            
        }
    }
}
