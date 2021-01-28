using FootballWorldCupScoreBoard.Abstractions;
using FootballWorldCupScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorldCupScoreBoard
{
    public class GameStarter
        : IGameStarter<HomeTeam, AwayTeam>
    {
        public void StartGame(HomeTeam homeTeam, AwayTeam awayTeam)
        {
            throw new NotImplementedException();
        }
    }
}
