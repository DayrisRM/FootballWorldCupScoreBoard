using FootballWorldCupScoreBoard.Abstractions;
using FootballWorldCupScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballWorldCupScoreBoard
{
    public class GameFinisher
        : IGameFinisher<Game>
    {

        ScoreBoard ScoreBoard { get; set; }

        public GameFinisher(ScoreBoard scoreBoard)
        {
            ScoreBoard = scoreBoard ?? throw new ArgumentNullException(nameof(scoreBoard));
        }


        public void FinishGame(Game game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));

            var existingGame = ScoreBoard.Games.Where(x => x.Id == game.Id).FirstOrDefault();

            if (existingGame != null)
            {
                ScoreBoard.Games.Remove(existingGame);
            }
        }
    }
}
