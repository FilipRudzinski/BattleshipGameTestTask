using System;

namespace BattleshipGame.Domain.Domain.Tile
{
    public class EnemyTile : BaseTile
    {
        private TileState _tileState;
        public override TileState State => _tileState;


        internal EnemyTile(Coordinate coordinate) : base(coordinate)
        {
            
        }

        public override void Click()
        {
            _tileState  = NextState();
            FireStateChanged();
        }

        TileState NextState()
        {
            switch (State)
            {
                case TileState.Empty:
                    return TileState.EmptyShoot;
                case TileState.EmptyShoot:
                    return TileState.ShootShip;
                case TileState.ShootShip:
                    return TileState.Empty;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        public override void Clear()
        {
            _tileState = TileState.Empty;
            FireStateChanged();
        }
    }
}