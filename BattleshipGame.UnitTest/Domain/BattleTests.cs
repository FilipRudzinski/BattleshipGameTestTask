using System.Linq;
using BattleshipGame.Domain.Domain;
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
            var playerMatrix = factory.Create(10, 10);
            var enemyMatrix = factory.Create(10, 10);
            //TODO: Replace Random provider with deterministic random provider
            var battle = new Battle(playerMatrix, enemyMatrix, new ShipRandomFiller(new RandomProvider()));
            
            //Act
            battle.Reset();
            
            //Assert

            Assert.AreEqual(battle.PlayerShips.Count(), 5);
        }
        
        
    }
}