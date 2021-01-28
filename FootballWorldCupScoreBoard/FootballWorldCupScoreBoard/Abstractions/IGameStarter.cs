using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorldCupScoreBoard.Abstractions
{
    public interface IGameStarter<TInput, TInput2>
    {
        void StartGame(TInput homeTeam, TInput2 awayTeam);
    }
}
