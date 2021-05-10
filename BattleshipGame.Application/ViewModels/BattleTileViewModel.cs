using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BattleshipGame.Application.Requests;
using BattleshipGame.Domain.Domain;
using MediatR;
using Xamarin.Forms;

namespace BattleshipGame.Application.ViewModels
{
    public class BattleTileViewModel : INotifyPropertyChanged
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public MatrixTypeEnum MatrixType { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IMediator _mediator;
        
        public ICommand ClickCommand { get; }

        public BattleTileViewModel(IMediator mediator)
        {
            _mediator = mediator;
            ClickCommand = new Command(() =>
            {
                _mediator.Publish(new TileClickRequest(CoordX,CoordY,MatrixType));
            });
        }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}