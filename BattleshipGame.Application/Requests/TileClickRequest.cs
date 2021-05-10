using BattleshipGame.Domain.Domain;
using MediatR;

namespace BattleshipGame.Application.Requests
{
    public class TileClickRequest : INotification
    {
        public int CoordX { get; }
        public int CoordY { get; }
        public MatrixTypeEnum MatrixType { get; }
        
        public TileClickRequest(int x, int y, MatrixTypeEnum matrixType)
        {
            CoordX = x;
            CoordY = y;
            MatrixType = matrixType;
        }
    }
}