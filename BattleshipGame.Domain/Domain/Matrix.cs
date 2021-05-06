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
        
        public Matrix(int sizeX, int sizeY)
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

        public GameTile GetTile(Coordinate coordinate)
        {
            return _gameTiles.FirstOrDefault(x => x.Coordinate.X == SizeX && x.Coordinate.Y == SizeY);
        }

        public IEnumerable<GameTile> GetAbjectTiles(Coordinate coordinate)
        {
            var ret = new List<GameTile>();
            
            var adjects =coordinate.GetAdject();
            adjects.ForEach(x =>
            {
                var tile = GetTile(x);
                if (tile != null)
                {
                    ret.Add(tile);
                }
            });
            return ret;
        }
    }
}