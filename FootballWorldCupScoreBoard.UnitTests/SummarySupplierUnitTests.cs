using FluentAssertions;
using FootballWorldCupScoreBoard.Abstractions;
using FootballWorldCupScoreBoard.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballWorldCupScoreBoard.UnitTests
{
    [Trait("Type", "Unit")]
    public class SummarySupplierUnitTests
    {
        [Fact]
        public void Constructor_ScoreBoard_Null_Throws()
        {
            Action action = () => new SummarySupplier(null);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void UpdaterScore_Action_IsCalled()
        {
            var summarySupplierMock = new Mock<ISummarySupplier<List<Game>>>();
            var summarySupplier = summarySupplierMock.Object;
            summarySupplier.GetSummary();
            summarySupplierMock.Verify(m => m.GetSummary(), Times.Once);
        }


        [Fact]
        public void GetSummary_Result_IsList()
        {
            var scoreBoard = new ScoreBoard();
            var SummarySupplier = new SummarySupplier(scoreBoard);
            var summary = SummarySupplier.GetSummary();
            Assert.IsAssignableFrom<List<Game>>(summary);
        }

        [Fact]
        public void GetSummary_NotGame_ListEmpty()
        {
            var scoreBoard = new ScoreBoard();
            var SummarySupplier = new SummarySupplier(scoreBoard);
            var summary = SummarySupplier.GetSummary();
            Assert.Empty(summary);
        }



        [Fact]
        public void GetSummary_Succesful_CorrectOrder() 
        {
            var scoreBoard = ScoreBoardInitializer();
            var SummarySupplier = new SummarySupplier(scoreBoard);
            var summary = SummarySupplier.GetSummary();
          

            var correctOrder = new List<int>(new int[] { 4, 2, 1, 5, 3 });
            var summaryOrder = summary.Select(x => x.Id).ToList();


            summaryOrder.Should().BeEquivalentTo(correctOrder);

        }


        [Fact]
        public void GetSummary_ZeroTotalScore_CorrectOrder()
        {
            var scoreBoard = ScoreBoardInitializerZeroScore();
            var SummarySupplier = new SummarySupplier(scoreBoard);
            var summary = SummarySupplier.GetSummary();


            var correctOrder = new List<int>(new int[] { 2, 1 });
            var summaryOrder = summary.Select(x => x.Id).ToList();


            summaryOrder.Should().BeEquivalentTo(correctOrder);

        }
        


        private ScoreBoard ScoreBoardInitializer()
        {
            var scoreBoard = new ScoreBoard();

            var game1 = new Game()
            {
                Id = 1,
                HomeTeam = new HomeTeam() { Name = "Mexico" },
                AwayTeam = new AwayTeam() { Name = "Canada" },
                Score = new Score() { AwayScore = 0, HomeScore = 5, TotalScore = 5 }
            };

            var game2 = new Game()
            {
                Id = 2,
                HomeTeam = new HomeTeam() { Name = "Spain" },
                AwayTeam = new AwayTeam() { Name = "Brazil" },
                Score = new Score() { AwayScore = 10, HomeScore = 2, TotalScore = 12 }
            };

            var game3 = new Game()
            {
                Id = 3,
                HomeTeam = new HomeTeam() { Name = "Germany" },
                AwayTeam = new AwayTeam() { Name = "France" },
                Score = new Score() { AwayScore = 2, HomeScore = 2, TotalScore = 4 }
            };

            var game4 = new Game()
            {
                Id = 4,
                HomeTeam = new HomeTeam() { Name = "Uruguay" },
                AwayTeam = new AwayTeam() { Name = "Italy" },
                Score = new Score() { AwayScore = 6, HomeScore = 6, TotalScore = 12 }
            };

            var game5 = new Game()
            {
                Id = 5,
                HomeTeam = new HomeTeam() { Name = "Argentina" },
                AwayTeam = new AwayTeam() { Name = "Australia" },
                Score = new Score() { AwayScore = 3, HomeScore = 1, TotalScore = 4 }
            };

            scoreBoard.Games.Add(game1);
            scoreBoard.Games.Add(game2);
            scoreBoard.Games.Add(game3);
            scoreBoard.Games.Add(game4);
            scoreBoard.Games.Add(game5);

            return scoreBoard;
        }

        private ScoreBoard ScoreBoardInitializerZeroScore() 
        {
            var scoreBoard = new ScoreBoard();

            var game1 = new Game()
            {
                Id = 1,
                HomeTeam = new HomeTeam() { Name = "Mexico" },
                AwayTeam = new AwayTeam() { Name = "Canada" },
                Score = new Score() { AwayScore = 0, HomeScore = 0, TotalScore = 0 }
            };

           
            var game2 = new Game()
            {
                Id = 2,
                HomeTeam = new HomeTeam() { Name = "Argentina" },
                AwayTeam = new AwayTeam() { Name = "Australia" },
                Score = new Score() { AwayScore = 0, HomeScore = 0, TotalScore = 0 }
            };

            scoreBoard.Games.Add(game1);
            scoreBoard.Games.Add(game2);
          

            return scoreBoard;
        }


    }
}
