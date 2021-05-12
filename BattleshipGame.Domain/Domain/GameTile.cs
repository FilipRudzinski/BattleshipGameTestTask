using System;

namespace BattleshipGame.Domain.Domain
{
    public class GameTile
    {
        public event Action<TileState> StateChanged;
        
        public TileState State
        {
            get
            {
                if (IsShipHit) return TileState.ShootShip;
                if (IsShoot) return TileState.EmptyShoot;
                return TileState.Empty;
            }
        }

        public bool IsShoot { get; private set; }

        public bool IsShipHit => IsShip && IsShoot;

        public bool IsShipDestroyed
        {
            get
            {
                if (!IsShip) return false;
                return IsShipHit && Ship.IsDestroyed;
            }
        }

        public bool IsShip => Ship != null;
        public Ship Ship { get; private set; }
        
        public Coordinate Coordinate { get; }
        
        public GameTile(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public void Click()
        {
            if (IsShoot)
            {
                ClearShoot();
            }
            else
            {
                Shoot();
            }
        }

        public void Shoot()
        {
            IsShoot = true;
            StateChanged?.Invoke(State);
        }

        public void ClearShoot()
        {
            IsShoot = false;
            StateChanged?.Invoke(State);
        }

        public void AssignShip(Ship ship)
        {
            Ship = ship;
            Ship.AssignTile(this);
            StateChanged?.Invoke(State);
        }

        public void Clear()
        {
            Ship = null;
            IsShoot = false;
        }
    }
}