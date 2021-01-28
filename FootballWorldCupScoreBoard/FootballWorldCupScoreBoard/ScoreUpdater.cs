using FootballWorldCupScoreBoard.Abstractions;
using FootballWorldCupScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorldCupScoreBoard
{
    public class ScoreUpdater
        : IScoreUpdater<Game, int?, int?>
    {
        public void UpdateScore(Game game, int? scoreHomeTeam, int? scoreAwayTeam)
        {
            throw new NotImplementedException();
        }
    }
}
