using BattleshipGame.Domain.Domain;
using BattleshipGame.Domain.Domain.Ship;
using BattleshipGame.Domain.Domain.Tile;
using BattleshipGame.Domain.Factories;
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
            Assert.AreEqual(ship.ShipType, shipType);
            Assert.False(ship.IsDestroyed);
        }

        [Test]
        public void ShipDestroyTest()
        {
            //arrange
            var shipType = ShipTypeEnum.Battleship;
            var ship = new Ship(shipType);
            var tileFactory = new TileFactory();
            var tile1 = tileFactory.Create(new Coordinate(0, 1), OwnerTypeEnum.Player) as PlayerTile;
            var tile2 = tileFactory.Create(new Coordinate(0, 2), OwnerTypeEnum.Player) as PlayerTile;
            var tile3 = tileFactory.Create(new Coordinate(0, 3), OwnerTypeEnum.Player) as PlayerTile;
            var tile4 = tileFactory.Create(new Coordinate(0, 4), OwnerTypeEnum.Player) as PlayerTile;
            var tile5 = tileFactory.Create(new Coordinate(0, 5), OwnerTypeEnum.Player) as PlayerTile;
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