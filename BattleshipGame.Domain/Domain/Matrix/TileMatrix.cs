using System.Collections.Generic;
using System.Linq;
using BattleshipGame.Domain.Domain.Tile;
using BattleshipGame.Domain.Factories;

namespace BattleshipGame.Domain.Domain.Matrix
{
    public class TileMatrix
    {
        public OwnerTypeEnum OwnerType { get; }
        
        public int SizeX { get; }
        public int SizeY { get; }

        private List<ITile> _gameTiles = new List<ITile>();
        
        internal TileMatrix(int sizeX, int sizeY, OwnerTypeEnum ownerTypeEnum ,ITileFactory tileFactory)
        {
            OwnerType = ownerTypeEnum;
            SizeX = sizeX;
            SizeY = sizeY;
            Fill(tileFactory);
        }

        private void Fill(ITileFactory tileFactory)
        {
            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    _gameTiles.Add(tileFactory.Create(new Coordinate(x,y), OwnerType));
                }
            }
        }

        public void Clear()
        {
            _gameTiles.AsParallel().ForAll(x =>
            {
                x.Clear();
            });
        }

        public ITile GetTile(Coordinate coordinate)
        {
            return _gameTiles.FirstOrDefault(x => x.Coordinate.X == coordinate.X && x.Coordinate.Y == coordinate.Y);
        }
    }
}