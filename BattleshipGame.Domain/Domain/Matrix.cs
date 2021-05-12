using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Internals;

namespace BattleshipGame.Domain.Domain
{
    public class Matrix
    {
        public int SizeX { get; }
        public int SizeY { get; }

        private List<GameTile> _gameTiles = new List<GameTile>();
        
        internal Matrix(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            Fill();
        }

        private void Fill()
        {
            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    _gameTiles.Add(new GameTile(new Coordinate(x,y)));
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

        public GameTile GetTile(Coordinate coordinate)
        {
            return _gameTiles.FirstOrDefault(x => x.Coordinate.X == coordinate.X && x.Coordinate.Y == coordinate.Y);
        }
    }
}