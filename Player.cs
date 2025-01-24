using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Interface;
namespace Tennis
{
    public class Player : IPlayer
    {
        public string Name { get; set; }

        public int Points { get ; set ; }

        public Player(string name) {
            Name = name;
            Points = 0;
        }
        public void ScorePoint()
        {
            
            
                 Points++;
            
        }
    }
}
 