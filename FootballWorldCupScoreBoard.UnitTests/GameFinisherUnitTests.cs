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
    public class GameFinisherUnitTests
    {
        [Fact]
        public void Constructor_ScoreBoard_Null_Throws()
        {
            Action action = () => new GameFinisher(null);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FinishGame_Action_IsCalled()
        {
            var gameFinisherMock = new Mock<IGameFinisher<Game>>();
            var gameFinisher = gameFinisherMock.Object;
            gameFinisher.FinishGame(It.IsAny<Game>());
            gameFinisherMock.Verify(m => m.FinishGame(It.IsAny<Game>()), Times.Once);
        }


        [Fact]
        public void FinishGame_Game_Null_Throws()
        {
            var scoreBoard = Mock.Of<ScoreBoard>();
            var gameFinisher = new GameFinisher(scoreBoard);
            Action action = () => gameFinisher.FinishGame(null);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FinishGame_Remove_DecreaseCount()
        {
            var scoreBoard = ScoreBoardInitializer();

            var countBeforeFinishGame = scoreBoard.Games.Count();

            var game = new Game()
            {
                Id = 3,
                HomeTeam = new HomeTeam() { Name = "Tarragona" },
                AwayTeam = new AwayTeam() { Name = "Murcia" }
            };

            var GameFinisher = new GameFinisher(scoreBoard);

            GameFinisher.FinishGame(game);


            Assert.Equal(countBeforeFinishGame - 1, scoreBoard.Games.Count);
        }

        [Fact]
        public void FinishGame_NotFoundGame_SameCount()
        {
            var scoreBoard = ScoreBoardInitializer();

            var countBeforeFinishGame = scoreBoard.Games.Count();

            var game = new Game()
            {
                Id = 5,
                HomeTeam = new HomeTeam() { Name = "Alicante" },
                AwayTeam = new AwayTeam() { Name = "Valencia" }
            };

            var GameFinisher = new GameFinisher(scoreBoard);

            GameFinisher.FinishGame(game);


            Assert.Equal(countBeforeFinishGame, scoreBoard.Games.Count);
        }


        private ScoreBoard ScoreBoardInitializer()
        {
            var scoreBoard = new ScoreBoard();

            var game1 = new Game()
            {
                Id = 1,
                HomeTeam = new HomeTeam() { Name = "Barcelona" },
                AwayTeam = new AwayTeam() { Name = "Sevilla" }
            };

            var game2 = new Game()
            {
                Id = 2,
                HomeTeam = new HomeTeam() { Name = "Madrid" },
                AwayTeam = new AwayTeam() { Name = "Bilbao" }
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
