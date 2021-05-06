using System;
using System.Collections.Generic;
using BattleshipGame.Application.ViewModels;
using Xamarin.Forms;

namespace BattleshipGame.Android.View
{
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();

            this.BindingContext = App.Resolve<BattleshipGameViewModel>();
        }
    }
}
