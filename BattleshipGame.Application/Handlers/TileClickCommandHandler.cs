using System.Threading;
using System.Threading.Tasks;
using BattleshipGame.Application.Requests;
using BattleshipGame.Domain.Domain;
using BattleshipGame.Domain.Domain.Tile;
using MediatR;

namespace BattleshipGame.Application.Handlers
{
    public class TileClickCommandHandler : INotificationHandler<TileClickRequest>
    {
        private IAppManager _appManager;
        
        public TileClickCommandHandler(IAppManager appManager)
        {
            _appManager = appManager;
        }
        
        public async Task Handle(TileClickRequest notification, CancellationToken cancellationToken)
        {
            _appManager.TileClicked(new Coordinate(notification.CoordX,notification.CoordY), notification.OwnerType);
        }
    }
}