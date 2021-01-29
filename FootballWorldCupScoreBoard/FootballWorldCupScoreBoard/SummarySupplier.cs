using FootballWorldCupScoreBoard.Abstractions;
using FootballWorldCupScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballWorldCupScoreBoard
{
    public class SummarySupplier
         : ISummarySupplier<List<Game>>
    {
        ScoreBoard ScoreBoard { get; set; }

        public SummarySupplier(ScoreBoard scoreBoard)
        {
            ScoreBoard = scoreBoard ?? throw new ArgumentNullException(nameof(scoreBoard));
        }

        public List<Game> GetSummary()
        {
            var summary = new List<Game>();

            if (ScoreBoard.Games.Any())
            {
                summary = ScoreBoard.Games.OrderByDescending(x => x.Score.TotalScore).ThenByDescending(t => t.Id).ToList();
            }
           
            return summary;
        }
    }
}
