using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BattleshipGame.Application.Requests;
using BattleshipGame.Domain.Domain;
using MediatR;
using Xamarin.Forms;

namespace BattleshipGame.Application.ViewModels
{
    public class PlayerMatrixViewModel : INotifyPropertyChanged
    {
        public MatrixTypeEnum MatrixType { get; }
        
        private readonly IMediator _mediator;
        public PlayerMatrixViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}