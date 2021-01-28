using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorldCupScoreBoard.Abstractions
{
    public interface IScoreUpdater<TInput, TInput2, TInput3>
    {
        void UpdateScore(TInput game, TInput2 scoreHomeTeam, TInput3 scoreAwayTeam);
    }
}
