using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipGame.Domain.Domain.Tile;

namespace BattleshipGame.Domain.Domain.Ship
{
    public class Ship
    {
        public bool IsDestroyed => Tiles.Any() && Tiles.All(x => x.IsShoot);
        public ShipTypeEnum ShipType { get; } 
        
        public Ship(ShipTypeEnum shipTypeEnum)
        {
            ShipType = shipTypeEnum;
        }

        public List<PlayerTile> Tiles { get; } = new List<PlayerTile>();

        public int FieldsCount => GetShipFieldCount();

        public void AssignTile(PlayerTile playerTile)
        {
            if (Tiles.Count > FieldsCount ) throw new Exception("Ship tiles exceeded");
            Tiles.Add(playerTile);
        }
        
        int GetShipFieldCount()
        {
            switch (ShipType)
            {
                case ShipTypeEnum.Carrier:
                    return 5;
                case ShipTypeEnum.Battleship:
                    return 4;
                case ShipTypeEnum.Cruiser:
                    return 3;
                case ShipTypeEnum.Submarine:
                    return 2;
                case ShipTypeEnum.Destroyer:
                    return 1;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}