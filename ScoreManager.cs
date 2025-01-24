using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Interface;

namespace Tennis
{
    public class ScoreManager : IScoreManger
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private int _numeberOfTimes;
        private readonly Random _random;
        public ScoreManager(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
            _numeberOfTimes = 0;
            _random = new Random();
        }
        public string GetScore()
        {
            var pari = "";
            if (_player1.Points >= 4 && _player1.Points >= _player2.Points + 2)
            {
                return $"{GetPointDesccription(_player1.Points)} - {_player1.Name} vince";
            }

            if (_player2.Points >= 4 && _player2.Points >= _player1.Points + 2)
            {
                return $"{GetPointDesccription(_player2.Points)} - {_player2.Name} vince";
            }

            if (_player1.Points >= 2 && _player2.Points >= 2 && (_player1.Points == _player2.Points))
            {

                pari = "Deuce";
                _numeberOfTimes++;
                if (_numeberOfTimes >= 3)
                {
                    if (_random.NextDouble() >= 0.5)
                        _player1.ScorePoint();
                    else
                        _player2.ScorePoint();

                }
            }

            string score1 = GetPointDesccription(_player1.Points);
            string score2 = GetPointDesccription(_player2.Points);
            return $" {pari} {score1} -  {score2} ";


        }
        public bool HasWinner()
        {



            return (_player1.Points >= 4 && _player1.Points >= _player2.Points + 2) || (_player2.Points >= 4 && _player2.Points >= _player1.Points + 2);
        }
        private string GetPointDesccription(int points)
        {
            return points switch { 0 => "Love", 1 => "Fifteen", 2 => "Thirty", 3 => "Forty", _ => "Game" };
        }
    }
}
