using BattleshipGame.Domain.Domain;
using NUnit.Framework;

namespace BattleshipGame.UnitTest.Domain
{
    public class ShipTest
    {
        [Test]
        public void CreationTest()
        {
            //arrange
            var shipType = ShipTypeEnum.Battleship;
            var ship = new Ship(shipType);
            //act
            //Assert
            Assert.AreEqual(ship.ShipType,shipType);
            Assert.False(ship.IsDestroyed);
        }

        [Test]
        public void ShipDestroyTest()
        {
            //arrange
            var shipType = ShipTypeEnum.Battleship;
            var ship = new Ship(shipType);
            var tile1 = new GameTile(new Coordinate(0,1));
            var tile2 = new GameTile(new Coordinate(0,2));
            var tile3 = new GameTile(new Coordinate(0,3));
            var tile4 = new GameTile(new Coordinate(0,4));
            var tile5 = new GameTile(new Coordinate(0,5));
            //act
            tile1.AssignShip(ship);
            tile2.AssignShip(ship);
            tile3.AssignShip(ship);
            tile4.AssignShip(ship);
            tile5.AssignShip(ship);

            tile1.Shoot();
            tile2.Shoot();
            tile3.Shoot();
            tile4.Shoot();
            tile5.Shoot();
            //Assert
            Assert.True(ship.IsDestroyed);
        }
    }
}