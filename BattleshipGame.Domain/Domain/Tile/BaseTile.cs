using System;

namespace BattleshipGame.Domain.Domain.Tile
{
    public class BaseTile : ITile
    {
        public event Action<TileState> StateChanged;

        public virtual TileState State => TileState.Empty;
        
        public Coordinate Coordinate { get; }
        
        protected BaseTile(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        protected void FireStateChanged()
        {
            StateChanged?.Invoke(State);
        }
        
        public virtual void Click()
        {

        }

        public virtual void Clear()
        {
            
        }
    }
}