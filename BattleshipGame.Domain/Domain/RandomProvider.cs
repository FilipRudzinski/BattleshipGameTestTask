using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace BattleshipGame.Domain.Domain
{
    public class RandomProvider
    {
        private Random _random;
        
        public RandomProvider()
        {
            _random = new Random();
        }
        
        [Pure]
        public int GetRandom(int max)
        {
            return _random.Next(max);
        }
        
        [Pure]
        public Coordinate GetRandomCoord(int max)
        {
            var x = _random.Next(max);
            var y = _random.Next(max);
            return new Coordinate(x, y);
        }

        [Pure]
        public Coordinate GetRandomAdject(Coordinate coordinate, Matrix matrix)
        {
            var adject = coordinate.GetAdject().ToList();
            do
            {
                var random = GetRandom(adject.Count);
                var randomCoord = adject[random];
                var tile = matrix.GetTile(randomCoord);
                if (tile != null)
                {
                    return randomCoord;
                }
                else
                {
                    adject.Remove(randomCoord);
                }
            } while (adject.Count > 0);

            return null;
        }
        
        [Pure]
        public Coordinate GetRandomEmptyAdject(Coordinate coordinate, Matrix matrix)
        {
            var adject = coordinate.GetAdject().ToList();
            do
            {
                var random = GetRandom(adject.Count);
                var randomCoord = adject[random];
                var tile = matrix.GetTile(randomCoord);
                if (tile != null && !tile.IsShip)
                {
                    return randomCoord;
                }
                else
                {
                    adject.Remove(randomCoord);
                }
            } while (adject.Count > 0);

            return null;
        }
    }
}