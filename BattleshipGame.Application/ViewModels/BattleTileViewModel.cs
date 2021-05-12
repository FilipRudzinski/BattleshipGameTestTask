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
        public TileState State
        {
            get;
            private set;
        }

        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public MatrixTypeEnum MatrixType { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IMediator _mediator;
        private readonly IAppManager _appManager;
        
        public ICommand ClickCommand { get; }

        public BattleTileViewModel(IMediator mediator, IAppManager appManager)
        {
            _mediator = mediator;
            _appManager = appManager;
            appManager.GameInitialized += AppManagerOnGameInitialized;

            ClickCommand = new Command(() =>
            {
                _mediator.Publish(new TileClickRequest(CoordX,CoordY,MatrixType));
            });
        }

        private void AppManagerOnGameInitialized()
        {
            var gameTile = _appManager.GetTile(CoordX, CoordY, MatrixType);
            gameTile.StateChanged += GameTileOnStateChanged;
        }

        private void GameTileOnStateChanged(TileState tileState)
        {
            State = tileState;
            OnPropertyChanged(nameof(State));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}