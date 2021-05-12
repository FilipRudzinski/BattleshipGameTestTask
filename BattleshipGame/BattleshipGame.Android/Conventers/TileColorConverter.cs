using System;
using System.Drawing;
using System.Globalization;
using BattleshipGame.Domain.Domain;
using Xamarin.Forms;
using Color = Xamarin.Forms.Color;

namespace BattleshipGame.Android.Conventers
{
    public class TileColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Color.Aqua;
            var tileState = value is TileState ? (TileState) value : TileState.Empty;
            switch (tileState)
            {
                case TileState.Empty:
                    return Color.Aqua;
                case TileState.EmptyShoot:
                    return Color.Navy;
                case TileState.ShootShip:
                    return Color.Red;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}