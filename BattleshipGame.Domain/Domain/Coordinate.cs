using System.Collections.Generic;

namespace BattleshipGame.Domain.Domain
{
    public class Coordinate
    {
        public int X
        {
            get;
        }

        public int Y
        {
            get;
        }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinate Upper => new Coordinate(X, Y + 1);
        public Coordinate UpperLeftCoord => new Coordinate(X - 1, Y + 1);
        public Coordinate UpperRightCoord => new Coordinate(X + 1, Y + 1);
        public Coordinate LowerCoord => new Coordinate(X, Y - 1);
        public Coordinate LowerLeftCoord => new Coordinate(X - 1, Y - 1);
        public Coordinate LowerRightCoord => new Coordinate(X + 1, Y - 1);
        public Coordinate RightCoord => new Coordinate(X + 1, Y);
        public Coordinate LeftCoord => new Coordinate(X - 1, Y);

        public IEnumerable<Coordinate> GetAdject()
        {
            return new[]
            {
                Upper, UpperLeftCoord, UpperRightCoord, LowerCoord, LowerLeftCoord, LowerRightCoord, RightCoord,
                LeftCoord
            };
        }
        
        public IEnumerable<Coordinate> GetCross()
        {
            return new[]
            {
                Upper, LowerCoord, RightCoord, LeftCoord
            };
        }
    }
}