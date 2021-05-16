using BattleshipGame.Domain.Domain;
using MediatR;

namespace BattleshipGame.Application.Requests
{
    public class TileClickRequest : INotification
    {
        public int CoordX { get; }
        public int CoordY { get; }
        public OwnerTypeEnum OwnerType { get; }
        
        public TileClickRequest(int x, int y, OwnerTypeEnum ownerType)
        {
            CoordX = x;
            CoordY = y;
            OwnerType = ownerType;
        }
    }
}