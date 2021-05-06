using System.Threading;
using System.Threading.Tasks;
using BattleshipGame.Application.Requests;
using MediatR;

namespace BattleshipGame.Application.Handlers
{
    public class ResetCommandHandler : INotificationHandler<ResetRequest>
    {

        public async Task Handle(ResetRequest notification, CancellationToken cancellationToken)
        {
            //return Task.FromResult();
        }
    }
}