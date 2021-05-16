using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BattleshipGame.Application.Requests;
using MediatR;
using Xamarin.Forms;

namespace BattleshipGame.Application.ViewModels
{
    public class BattleshipGameViewModel : INotifyPropertyChanged
    {
        private readonly IMediator _mediator;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public ICommand ResetCommand { get; }

        public BattleshipGameViewModel(IMediator mediator)
        {
            _mediator = mediator;
            ResetCommand = new Command(() =>
            {
                _mediator.Publish(new ResetRequest());
            });
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}