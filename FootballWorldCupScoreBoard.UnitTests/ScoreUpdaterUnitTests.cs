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
    public class ScoreUpdaterUnitTests
    {
        [Fact]
        public void Constructor_ScoreBoard_Null_Throws()
        {
            Action action = () => new ScoreUpdater(null);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void UpdateScore_Action_IsCalled()
        {
            var scoreUpdaterMock = new Mock<IScoreUpdater<Game, int?, int?>>();
            var scoreUpdater = scoreUpdaterMock.Object;
            scoreUpdater.UpdateScore(It.IsAny<Game>(), It.IsAny<int>(), It.IsAny<int>());
            scoreUpdaterMock.Verify(m => m.UpdateScore(It.IsAny<Game>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void UpdateScore_Game_Null_Throws()
        {
            var scoreBoard = Mock.Of<ScoreBoard>();
            var scoreUpdater = new ScoreUpdater(scoreBoard);
            Action action = () => scoreUpdater.UpdateScore(null, It.IsAny<int>(), It.IsAny<int>());
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(5, 1, 6)]
        [InlineData(3, 0, 3)]
        [InlineData(0, 0, 0)]
        public void UpdateScore_ScoreHomeAndScoreAway_IncrementsTotalScore(int homeScore, int awayScore, int expected)
        {
            var scoreBoard = ScoreBoardInitializer();

            var game = new Game()
            {
                Id = 1,
                HomeTeam = new HomeTeam() { Name = "Barcelona" },
                AwayTeam = new AwayTeam() { Name = "Sevilla" },
            };

            var ScoreUpdater = new ScoreUpdater(scoreBoard);
            ScoreUpdater.UpdateScore(game, homeScore, awayScore);

            Assert.Equal(expected, scoreBoard.Games[0].Score.TotalScore);

        }

        [Theory]
        [InlineData(5, 1, 5)]
        [InlineData(3, 0, 3)]
        [InlineData(0, 0, 0)]
        public void UpdateScore_ScoreHomeAndScoreAway_IncrementsScoreHome(int homeScore, int awayScore, int expected)
        {
            var scoreBoard = ScoreBoardInitializer();

            var game = new Game()
            {
                Id = 1,
                HomeTeam = new HomeTeam() { Name = "Barcelona" },
                AwayTeam = new AwayTeam() { Name = "Sevilla" },
            };

            var ScoreUpdater = new ScoreUpdater(scoreBoard);
            ScoreUpdater.UpdateScore(game, homeScore, awayScore);

            Assert.Equal(expected, scoreBoard.Games[0].Score.HomeScore);

        }

        [Theory]
        [InlineData(5, 1, 1)]
        [InlineData(3, 0, 0)]
        [InlineData(0, 0, 0)]
        public void UpdateScore_ScoreHomeAndScoreAway_IncrementsScoreAway(int homeScore, int awayScore, int expected)
        {
            var scoreBoard = ScoreBoardInitializer();

            var game = new Game()
            {
                Id = 1,
                HomeTeam = new HomeTeam() { Name = "Barcelona" },
                AwayTeam = new AwayTeam() { Name = "Sevilla" },
            };

            var ScoreUpdater = new ScoreUpdater(scoreBoard);
            ScoreUpdater.UpdateScore(game, homeScore, awayScore);

            Assert.Equal(expected, scoreBoard.Games[0].Score.AwayScore);

        }


        [Theory]
        [InlineData(5, 5)]
        [InlineData(0, 0)]
        public void UpdateScore_ScoreHomeHasValueAndScoreAwayNull_IncrementsScoreHome(int homeScore, int expected)
        {
            var scoreBoard = ScoreBoardInitializer();

            var game = new Game()
            {
                Id = 1,
                HomeTeam = new HomeTeam() { Name = "Barcelona" },
                AwayTeam = new AwayTeam() { Name = "Sevilla" },
            };

            var ScoreUpdater = new ScoreUpdater(scoreBoard);
            ScoreUpdater.UpdateScore(game, homeScore, null);

            Assert.Equal(expected, scoreBoard.Games[0].Score.HomeScore);
        }


        [Theory]
        [InlineData(5, 6)]
        [InlineData(0, 1)]
        public void UpdateScore_ScoreHomeHasValueAndScoreAwayNull_IncrementsTotalScore(int homeScore, int expected)
        {
            var scoreBoard = ScoreBoardInitializer();

            var game = new Game()
            {
                Id = 1,
                HomeTeam = new HomeTeam() { Name = "Barcelona" },
                AwayTeam = new AwayTeam() { Name = "Sevilla" }
            };

            var ScoreUpdater = new ScoreUpdater(scoreBoard);
            ScoreUpdater.UpdateScore(game, homeScore, null);

            Assert.Equal(expected, scoreBoard.Games[0].Score.TotalScore);
        }

        //
        [Theory]
        [InlineData(3, 3)]
        [InlineData(1, 1)]
        public void UpdateScore_ScoreAwayHasValueAndScoreHomeNull_IncrementsScoreAway(int awayScore, int expected)
        {
            var scoreBoard = ScoreBoardInitializer();

            var game = new Game()
            {
                Id = 2,
                HomeTeam = new HomeTeam() { Name = "Madrid" },
                AwayTeam = new AwayTeam() { Name = "Bilbao" },
            };

            var ScoreUpdater = new ScoreUpdater(scoreBoard);
            ScoreUpdater.UpdateScore(game, null, awayScore);

            Assert.Equal(expected, scoreBoard.Games[1].Score.AwayScore);
        }

        [Theory]
        [InlineData(3, 4)]
        [InlineData(1, 2)]
        public void UpdateScore_ScoreAwayHasValueAndScoreHomeNull_IncrementsTotalScore(int awayScore, int expected)
        {
            var scoreBoard = ScoreBoardInitializer();

            var game = new Game()
            {
                Id = 2,
                HomeTeam = new HomeTeam() { Name = "Madrid" },
                AwayTeam = new AwayTeam() { Name = "Bilbao" },
            };

            var ScoreUpdater = new ScoreUpdater(scoreBoard);
            ScoreUpdater.UpdateScore(game, null, awayScore);

            Assert.Equal(expected, scoreBoard.Games[1].Score.TotalScore);
        }



        private ScoreBoard ScoreBoardInitializer()
        {
            var scoreBoard = new ScoreBoard();

            var game1 = new Game()
            {
                Id = 1,
                HomeTeam = new HomeTeam() { Name = "Barcelona" },
                AwayTeam = new AwayTeam() { Name = "Sevilla" },
                Score = new Score() { AwayScore = 1, HomeScore = 3, TotalScore = 4 }
            };

            var game2 = new Game()
            {
                Id = 2,
                HomeTeam = new HomeTeam() { Name = "Madrid" },
                AwayTeam = new AwayTeam() { Name = "Bilbao" },
                Score = new Score() { AwayScore = 0, HomeScore = 1, TotalScore = 1 }
            };

            var game3 = new Game()
            {
                Id = 3,
                HomeTeam = new HomeTeam() { Name = "Tarragona" },
                AwayTeam = new AwayTeam() { Name = "Murcia" }
            };


            scoreBoard.Games.Add(game1);
            scoreBoard.Games.Add(game2);
            scoreBoard.Games.Add(game3);

            return scoreBoard;
        }

    }
}
