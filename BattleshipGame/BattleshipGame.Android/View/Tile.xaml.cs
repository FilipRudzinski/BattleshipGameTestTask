using System;
using System.Collections.Generic;
using BattleshipGame.Application.ViewModels;
using BattleshipGame.Domain.Domain;
using Xamarin.Forms;

namespace BattleshipGame.Android.View
{
    public partial class Tile : ContentView
    {
        public int CoordX
        {
            //TODO: Move binding to xaml
            get => _viewModel.CoordX;
            set => _viewModel.CoordX = value;
        }

        public int CoordY
        {
            //TODO: Move binding to xaml
            get => _viewModel.CoordY;
            set => _viewModel.CoordY = value;
        }

        public OwnerTypeEnum OwnerTypeEnum
        {
            //TODO: Move binding to xaml
            get => _viewModel.OwnerType;
            set => _viewModel.OwnerType = value;
        }
        private BattleTileViewModel _viewModel;
        
        public Tile()
        {
            InitializeComponent();
            _viewModel = App.Resolve<BattleTileViewModel>();
            this.BindingContext = _viewModel;
        }

        public void Initialize()
        {
            _viewModel.Initialize();
        }
    }
}
