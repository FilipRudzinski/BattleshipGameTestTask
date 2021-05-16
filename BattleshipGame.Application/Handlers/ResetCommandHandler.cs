using System.Threading;
using System.Threading.Tasks;
using BattleshipGame.Application.Requests;
using MediatR;

namespace BattleshipGame.Application.Handlers
{
    public class ResetCommandHandler : INotificationHandler<ResetRequest>
    {
        private IAppManager _appManager;
        
        public ResetCommandHandler(IAppManager appManager)
        {
            _appManager = appManager;
        }
        
        public async Task Handle(ResetRequest notification, CancellationToken cancellationToken)
        {
            _appManager.ResetGame();
        }
    }
}