using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipGame.Domain.Domain.Ship;
using BattleshipGame.Domain.Domain.Tile;

namespace BattleshipGame.Domain.Domain.Core
{
    public class Battle
    {
        private ShipRandomFiller _shipRandomFiller;

        public IEnumerable<Ship.Ship> PlayerShips => _playerShips.AsEnumerable();
        
        public List<Ship.Ship> _playerShips = new List<Ship.Ship>(); 

        public Matrix.TileMatrix PlayerTileMatrix { get; }
        public Matrix.TileMatrix EnemyTileMatrix { get; }

        public Battle(Matrix.TileMatrix playerTileMatrix, Matrix.TileMatrix enemyTileMatrix, ShipRandomFiller shipRandomFiller)
        {
            _shipRandomFiller = shipRandomFiller;
            PlayerTileMatrix = playerTileMatrix;
            EnemyTileMatrix = enemyTileMatrix;
        }
        

        public void Clear()
        {
            PlayerTileMatrix.Clear();
            EnemyTileMatrix.Clear();
            _playerShips.Clear();
        }

        void FillRandomShips()
        {
            var ships = new GameRules().GameShips;
            _shipRandomFiller.FillShips(PlayerTileMatrix, ships);
            _playerShips = ships;
        }


        public void Reset()
        {
            Clear();
            FillRandomShips();
        }

        public ITile GetTile(Coordinate coordinate, OwnerTypeEnum ownerType)
        {
            switch (ownerType)
            {
                case OwnerTypeEnum.Player:
                    return PlayerTileMatrix.GetTile(coordinate);
                case OwnerTypeEnum.Enemy:
                    return EnemyTileMatrix.GetTile(coordinate);
                default:
                    throw new ArgumentOutOfRangeException(nameof(ownerType), ownerType, null);
            }
        }

        public void TileClicked(Coordinate coordinate, OwnerTypeEnum ownerType)
        {
            ITile tile = null;
            switch (ownerType)
            {
                case OwnerTypeEnum.Player:
                    tile = PlayerTileMatrix.GetTile(coordinate);
                    break;
                case OwnerTypeEnum.Enemy:
                    tile = EnemyTileMatrix.GetTile(coordinate);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ownerType), ownerType, null);
            }
            tile.Click();
        }
    }
}