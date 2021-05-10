using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipGame.Domain.Domain
{
    public class Ship
    {
        public bool IsDestroyed => Tiles.Any() && Tiles.All(x => x.IsShoot);
        public ShipTypeEnum ShipType { get; } 
        
        public Ship(ShipTypeEnum shipTypeEnum)
        {
            ShipType = shipTypeEnum;
        }

        public List<GameTile> Tiles { get; } = new List<GameTile>();

        public int FieldsCount => GetShipFieldCount();

        public void AssignTile(GameTile gameTile)
        {
            if (Tiles.Count > FieldsCount ) throw new Exception("Ship tiles exceeded");
            Tiles.Add(gameTile);
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