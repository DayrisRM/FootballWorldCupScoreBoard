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
        ScoreBoard ScoreBoard { get; set; }

        public GameStarter(ScoreBoard scoreBoard)
        {
            ScoreBoard = scoreBoard ?? throw new ArgumentNullException(nameof(scoreBoard));
        }

        public void StartGame(HomeTeam homeTeam, AwayTeam awayTeam)
        {
            if (homeTeam == null) throw new ArgumentNullException(nameof(homeTeam));
            if (awayTeam == null) throw new ArgumentNullException(nameof(awayTeam));

            var gameId = ScoreBoard.Games.Count + 1; //TODO: MUST be entity id from DB

            var game = new Game()
            {
                Id = gameId,
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                Score = new Score()
            };

            ScoreBoard.Games.Add(game);
        }
    }
}
