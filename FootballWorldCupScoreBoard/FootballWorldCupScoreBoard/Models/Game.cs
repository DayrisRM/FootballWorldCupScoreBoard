using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorldCupScoreBoard.Models
{
    public class Game
    {
        public int Id { get; set; }
        public HomeTeam HomeTeam { get; set; }
        public AwayTeam AwayTeam { get; set; }
        public Score Score { get; set; } = new Score();

    }
}
