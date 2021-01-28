using FootballWorldCupScoreBoard.Abstractions;
using FootballWorldCupScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorldCupScoreBoard
{
    public class SummarySupplier
         : ISummarySupplier<List<Game>>
    {
        public List<Game> GetSummary()
        {
            throw new NotImplementedException();
        }
    }
}
