using FootballWorldCupScoreBoard.Abstractions;
using FootballWorldCupScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballWorldCupScoreBoard
{
    public class ScoreUpdater
        : IScoreUpdater<Game, int?, int?>
    {
        ScoreBoard ScoreBoard { get; set; }

        public ScoreUpdater(ScoreBoard scoreBoard)
        {
            ScoreBoard = scoreBoard ?? throw new ArgumentNullException(nameof(scoreBoard));
        }

        public void UpdateScore(Game game, int? scoreHomeTeam, int? scoreAwayTeam)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));

            var existingGame = ScoreBoard.Games.Where(x => x.Id == game.Id).FirstOrDefault();

            if (existingGame != null)
            {

                if (scoreHomeTeam.HasValue && scoreAwayTeam.HasValue)
                {
                    existingGame.Score = new Score()
                    {
                        HomeScore = scoreHomeTeam.Value,
                        AwayScore = scoreAwayTeam.Value,
                        TotalScore = scoreHomeTeam.Value + scoreAwayTeam.Value
                    };
                }
                else if (scoreHomeTeam.HasValue && !scoreAwayTeam.HasValue)
                {
                    existingGame.Score.HomeScore = scoreHomeTeam.Value;
                    existingGame.Score.TotalScore = scoreHomeTeam.Value + existingGame.Score.AwayScore;
                }
                else if (!scoreHomeTeam.HasValue && scoreAwayTeam.HasValue)
                {
                    existingGame.Score.AwayScore = scoreAwayTeam.Value;
                    existingGame.Score.TotalScore = scoreAwayTeam.Value + existingGame.Score.HomeScore;
                }
            }

        }
    }
}
