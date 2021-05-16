using System;
using BattleshipGame.Domain.Domain;
using BattleshipGame.Domain.Domain.Tile;

namespace BattleshipGame.Domain.Factories
{
    public class TileFactory : ITileFactory
    {
        public ITile Create(Coordinate coordinate, OwnerTypeEnum ownerType)
        {
            switch (ownerType)
            {
                case OwnerTypeEnum.Player:
                    return new PlayerTile(coordinate);
                case OwnerTypeEnum.Enemy:
                    return new EnemyTile(coordinate);
                default:
                    throw new ArgumentOutOfRangeException(nameof(ownerType), ownerType, null);
            }
        }
    }

    public interface ITileFactory
    {
        ITile Create(Coordinate coordinate, OwnerTypeEnum ownerType);
    }
}