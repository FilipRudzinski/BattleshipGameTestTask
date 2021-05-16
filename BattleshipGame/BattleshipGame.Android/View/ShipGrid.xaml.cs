using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BattleshipGame.Domain.Domain;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BattleshipGame.Android.View
{
    public partial class ShipGrid : ContentView
    {
        public OwnerTypeEnum OwnerTypeEnum { get; set; }

        public ShipGrid()
        {
            InitializeComponent();
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            ConfigureGridLine(Stack0, 0);
            ConfigureGridLine(Stack1, 1);
            ConfigureGridLine(Stack2, 2);
            ConfigureGridLine(Stack3, 3);
            ConfigureGridLine(Stack4, 4);
            ConfigureGridLine(Stack5, 5);
            ConfigureGridLine(Stack6, 6);
            ConfigureGridLine(Stack7, 7);
            ConfigureGridLine(Stack8, 8);
            ConfigureGridLine(Stack9, 9);
        }

        void ConfigureGridLine(StackLayout stackLayout, int column)
        {
            int counter = 0;
            stackLayout.Children.ForEach(x =>
            {
                if (x is Tile tile)
                {
                    tile.CoordX = counter;
                    tile.CoordY = column;
                    tile.OwnerTypeEnum = OwnerTypeEnum;
                    tile.Initialize();
                    counter++;
                }
            });
        }
    }
}
