using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Interface
{
    public interface IScoreManger
    {
        string GetScore();
        bool HasWinner();
    }
}
