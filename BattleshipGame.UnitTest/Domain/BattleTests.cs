using System.Linq;
using BattleshipGame.Domain.Domain;
using BattleshipGame.Domain.Domain.Core;
using BattleshipGame.Domain.Domain.Ship;
using BattleshipGame.Domain.Factories;
using NUnit.Framework;

namespace BattleshipGame.UnitTest.Domain
{
    public class BattleTests
    {
        [Test]
        public void GameResetTest()
        {
            //Arrange
            var factory = new MatrixFactory();
            var tileFactory = new TileFactory();
            var playerMatrix = factory.Create(10, 10, OwnerTypeEnum.Player, tileFactory);
            var enemyMatrix = factory.Create(10, 10, OwnerTypeEnum.Enemy, tileFactory);
            //TODO: Replace Random provider with deterministic random provider, sometimes test may fail
            var battle = new Battle(playerMatrix, enemyMatrix, new ShipRandomFiller(new RandomProvider()));
            
            //Act
            battle.Reset();
            
            //Assert

            Assert.AreEqual(battle.PlayerShips.Count(), 5);
        }
        
        
    }
}