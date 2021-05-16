namespace BattleshipGame.Domain.Domain.Tile
{
    public class PlayerTile : BaseTile
    {
        
        public bool IsShipDestroyed
        {
            get
            {
                if (!IsShip) return false;
                return IsShipHit && Ship.IsDestroyed;
            }
        }

        public bool IsShip => Ship != null;
        public Ship.Ship Ship { get; private set; }
        
        public bool IsShipHit => IsShip && IsShoot;
        
        public bool IsShoot { get; protected set; }
        
        
        public override TileState State
        {
            get
            {
                if (IsShipHit) return TileState.ShootShip;
                if (IsShip) return TileState.Ship;
                if (IsShoot) return TileState.EmptyShoot;
                return TileState.Empty;
            }
        }
        
        internal PlayerTile(Coordinate coordinate) : base(coordinate)
        {
           
        }

        public override void Click()
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
            FireStateChanged();
        }

        public void ClearShoot()
        {
            IsShoot = false;
            FireStateChanged();
        }

        public void AssignShip(Ship.Ship ship)
        {
            Ship = ship;
            Ship.AssignTile(this);
            FireStateChanged();
        }

        public override void Clear()
        {
            Ship = null;
            IsShoot = false;
            FireStateChanged();
        }
    }
}