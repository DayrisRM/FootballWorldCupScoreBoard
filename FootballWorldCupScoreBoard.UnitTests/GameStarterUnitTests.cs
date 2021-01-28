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
    public class GameStarterUnitTests
    {
        [Fact]
        public void Constructor_ScoreBoard_Null_Throws()
        {
            Action action = () => new GameStarter(null);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void StartGame_Action_IsCalled()
        {
            var starterGameMock = new Mock<IGameStarter<HomeTeam, AwayTeam>>();
            var starterGame = starterGameMock.Object;
            starterGame.StartGame(It.IsAny<HomeTeam>(), It.IsAny<AwayTeam>());
            starterGameMock.Verify(m => m.StartGame(It.IsAny<HomeTeam>(), It.IsAny<AwayTeam>()), Times.Once);
        }

        [Fact]
        public void StartGame_HomeTeam_Null_Throws()
        {
            var scoreBoard = Mock.Of<ScoreBoard>();
            var GameStarter = new GameStarter(scoreBoard);
            Action action = () => GameStarter.StartGame(null, It.IsAny<AwayTeam>());
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void StartGame_AwayTeam_Null_Throws()
        {
            var scoreBoard = Mock.Of<ScoreBoard>();
            var GameStarter = new GameStarter(scoreBoard);
            Action action = () => GameStarter.StartGame(It.IsAny<HomeTeam>(), null);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void StartGame_Add_ContainsGame()
        {
            var scoreBoard = new ScoreBoard();
            var GameStarter = new GameStarter(scoreBoard);

            var homeTeam = new HomeTeam() { Name = "Barcelona" };
            var awayTeam = new AwayTeam() { Name = "Madrid" };

            GameStarter.StartGame(homeTeam, awayTeam);

            Assert.Single(scoreBoard.Games);
        }

        [Fact]
        public void StartGame_Add_NotEmpty()
        {
            var scoreBoard = new ScoreBoard();
            var GameStarter = new GameStarter(scoreBoard);

            var homeTeam = new HomeTeam() { Name = "Barcelona" };
            var awayTeam = new AwayTeam() { Name = "Madrid" };

            GameStarter.StartGame(homeTeam, awayTeam);

            Assert.NotEmpty(scoreBoard.Games);

        }

    }
}
