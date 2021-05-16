using BattleshipGame.Domain.Domain;
using BattleshipGame.Domain.Domain.Ship;
using BattleshipGame.Domain.Domain.Tile;
using BattleshipGame.Domain.Factories;
using NUnit.Framework;

namespace BattleshipGame.UnitTest.Domain
{
    
    public class GameTileTests
    {
        [Test]
        public void CreationTest()
        {
            //arrange
            var tileFactory = new TileFactory();
            var gameTile = tileFactory.Create(new Coordinate(0, 0), OwnerTypeEnum.Player) as PlayerTile;
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
            var tileFactory = new TileFactory();
            var gameTile = tileFactory.Create(new Coordinate(0, 0), OwnerTypeEnum.Player) as PlayerTile;
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
            var tileFactory = new TileFactory();
            var gameTile = tileFactory.Create(new Coordinate(0, 0), OwnerTypeEnum.Player) as PlayerTile;
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
            var tileFactory = new TileFactory();
            var gameTile1 = tileFactory.Create(new Coordinate(0, 0), OwnerTypeEnum.Player) as PlayerTile;
            var gameTile2 = tileFactory.Create(new Coordinate(0, 1), OwnerTypeEnum.Player) as PlayerTile;
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
            var tileFactory = new TileFactory();
            var gameTile = tileFactory.Create(new Coordinate(0, 0), OwnerTypeEnum.Player) as PlayerTile;
            //act
            gameTile.Click();
            //assert
            Assert.True(gameTile.IsShoot);
        }
        
        [Test]
        public void DoubleClickTestEmptyField()
        {
            //arrange
            var tileFactory = new TileFactory();
            var gameTile = tileFactory.Create(new Coordinate(0, 0), OwnerTypeEnum.Player) as PlayerTile;
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
            var tileFactory = new TileFactory();
            var gameTile = tileFactory.Create(new Coordinate(0, 0), OwnerTypeEnum.Player) as PlayerTile;
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
            var tileFactory = new TileFactory();
            var gameTile = tileFactory.Create(new Coordinate(0, 0), OwnerTypeEnum.Player) as PlayerTile;
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
            var tileFactory = new TileFactory();
            var gameTile = tileFactory.Create(new Coordinate(0, 0), OwnerTypeEnum.Player) as PlayerTile;
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
            var tileFactory = new TileFactory();
            var gameTile = tileFactory.Create(new Coordinate(0, 0), OwnerTypeEnum.Player) as PlayerTile;
            var ship = new Ship(ShipTypeEnum.Submarine);
            gameTile.AssignShip(ship);
            //act
            gameTile.Click();
            
            //assert
            Assert.IsTrue(gameTile.IsShoot);
        }
    }
}