using BattleshipGame.Domain.Domain;
using NUnit.Framework;

namespace BattleshipGame.UnitTest.Domain
{
    
    public class GameTileTests
    {
        [Test]
        public void CreationTest()
        {
            //arrange
            var gameTile = new GameTile(new Coordinate(0,0));
            //act
            //assert
            Assert.IsFalse(gameTile.IsShip); 
            Assert.IsFalse(gameTile.IsShoot); 
            Assert.IsFalse(gameTile.IsShipDestroyed); 
            Assert.Null(gameTile.Ship); 
            Assert.False(gameTile.IsShipHit);
        }

        [Test]
        public void ShipAssigment()
        {
            //arrange
            var gameTile = new GameTile(new Coordinate(0,0));
            var ship = new Ship(ShipTypeEnum.Battleship);
            //act
            gameTile.AssignShip(ship);
            //assert
            Assert.IsTrue(gameTile.IsShip); 
            Assert.IsFalse(gameTile.IsShoot); 
            Assert.IsFalse(gameTile.IsShipDestroyed); 
            Assert.AreEqual(gameTile.Ship,ship); 
            Assert.False(gameTile.IsShipHit);
        }

        [Test]
        public void ShotOnEmptyTest()
        {
            //arrange
            var gameTile = new GameTile(new Coordinate(0,0));
            //act
            gameTile.Shoot();
            //assert
            Assert.IsFalse(gameTile.IsShip); 
            Assert.IsTrue(gameTile.IsShoot); 
            Assert.IsFalse(gameTile.IsShipDestroyed); 
            Assert.Null(gameTile.Ship); 
            Assert.False(gameTile.IsShipHit);
        }

        [Test]
        public void ShotOnShip()
        {
            //arrange
            var gameTile1 = new GameTile(new Coordinate(0,0));
            var gameTile2 = new GameTile(new Coordinate(0,1));
            var ship = new Ship(ShipTypeEnum.Battleship);
            //act
            gameTile1.AssignShip(ship);
            gameTile2.AssignShip(ship);
            gameTile1.Shoot();
            //assert
            Assert.IsTrue(gameTile1.IsShip); 
            Assert.IsTrue(gameTile1.IsShoot); 
            Assert.IsFalse(gameTile2.IsShoot); 
            Assert.IsFalse(gameTile1.IsShipDestroyed); 
            Assert.IsFalse(gameTile2.IsShipDestroyed); 
            Assert.AreEqual(gameTile1.Ship,ship); 
            Assert.True(gameTile1.IsShipHit);
        }

        [Test]
        public void ClickTestEmptyField()
        {
            //arrange
            var gameTile = new GameTile(new Coordinate(0, 0));
            //act
            gameTile.Click();
            //assert
            Assert.True(gameTile.IsShoot);
        }
        
        [Test]
        public void DoubleClickTestEmptyField()
        {
            //arrange
            var gameTile = new GameTile(new Coordinate(0, 0));
            //act
            gameTile.Click();
            gameTile.Click();
            //assert
            Assert.False(gameTile.IsShoot);
        }
        
        [Test]
        public void TripleClickTestEmptyField()
        {
            //arrange
            var gameTile = new GameTile(new Coordinate(0, 0));
            //act
            gameTile.Click();
            gameTile.Click();
            gameTile.Click();
            //assert
            Assert.IsTrue(gameTile.IsShoot);
        }
        
        [Test]
        public void QuadClickTestEmptyField()
        {
            //arrange
            var gameTile = new GameTile(new Coordinate(0, 0));
            //act
            gameTile.Click();
            gameTile.Click();
            gameTile.Click();
            gameTile.Click();
            //assert
            Assert.IsFalse(gameTile.IsShoot);
        }
        
        [Test]
        public void SingleClickTestWithShip()
        {
            //arrange
            var gameTile = new GameTile(new Coordinate(0, 0));
            var ship = new Ship(ShipTypeEnum.Submarine);
            gameTile.AssignShip(ship);
            //act
            gameTile.Click();
            
            //assert
            Assert.IsTrue(gameTile.IsShoot);
        }
        
        [Test]
        public void DoubleClickTestWithShip()
        {
            //arrange
            var gameTile = new GameTile(new Coordinate(0, 0));
            var ship = new Ship(ShipTypeEnum.Submarine);
            gameTile.AssignShip(ship);
            //act
            gameTile.Click();
            
            //assert
            Assert.IsTrue(gameTile.IsShoot);
        }
    }
}