using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorldCupScoreBoard.Abstractions
{
    public interface IGameFinisher<TInput>
    {
        void FinishGame(TInput game);
    }
}
