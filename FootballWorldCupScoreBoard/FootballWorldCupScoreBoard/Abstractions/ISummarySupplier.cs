using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorldCupScoreBoard.Abstractions
{
    public interface ISummarySupplier<TOutput>
    {
        TOutput GetSummary();
    }
}
