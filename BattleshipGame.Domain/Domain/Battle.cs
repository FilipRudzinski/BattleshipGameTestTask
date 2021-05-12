using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipGame.Domain.Factories;

namespace BattleshipGame.Domain.Domain
{
    public class Battle
    {
        private ShipRandomFiller _shipRandomFiller;

        public IEnumerable<Ship> PlayerShips => _playerShips.AsEnumerable();
        
        public List<Ship> _playerShips = new List<Ship>(); 

        public Matrix PlayerMatrix { get; }
        public Matrix EnemyMatrix { get; }

        public Battle(Matrix playerMatrix, Matrix enemyMatrix, ShipRandomFiller shipRandomFiller)
        {
            _shipRandomFiller = shipRandomFiller;
            PlayerMatrix = playerMatrix;
            EnemyMatrix = enemyMatrix;
        }

        public void Initialize()
        {
            FillRandomShips();
        }

        public void Clear()
        {
            PlayerMatrix.Clear();
            EnemyMatrix.Clear();
        }

        void FillRandomShips()
        {
            var ships = new GameRules().GameShips;
            _shipRandomFiller.FillShips(PlayerMatrix, ships);
            _playerShips = ships;
        }


        public void Reset()
        {
            Clear();
            FillRandomShips();
        }

        public GameTile GetTile(Coordinate coordinate, MatrixTypeEnum matrixType)
        {
            switch (matrixType)
            {
                case MatrixTypeEnum.Player:
                    return PlayerMatrix.GetTile(coordinate);
                case MatrixTypeEnum.Enemy:
                    return EnemyMatrix.GetTile(coordinate);
                default:
                    throw new ArgumentOutOfRangeException(nameof(matrixType), matrixType, null);
            }
        }

        public void TileClicked(Coordinate coordinate, MatrixTypeEnum matrixType)
        {
            GameTile tile = null;
            switch (matrixType)
            {
                case MatrixTypeEnum.Player:
                    tile = PlayerMatrix.GetTile(coordinate);
                    break;
                case MatrixTypeEnum.Enemy:
                    tile = EnemyMatrix.GetTile(coordinate);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(matrixType), matrixType, null);
            }
            tile.Click();
        }
    }
}