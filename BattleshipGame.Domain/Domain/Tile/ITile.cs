using System;

namespace BattleshipGame.Domain.Domain.Tile
{
    public interface ITile
    {
        event Action<TileState> StateChanged;
        
        TileState State { get; }
        
        Coordinate Coordinate { get; }

        void Click();

        void Clear();
    }
}