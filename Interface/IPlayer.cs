using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Interface
{
    public interface IPlayer
    {
        string Name { get; }
        int Points { get; set; }
        void ScorePoint();
    }
}
