using System;

namespace BattleshipGame.Domain.Domain
{
    public class Ship
    {
        public bool IsDestroyed { get; private set; }
        public ShipTypeEnum ShipType { get; } 
        
        public Ship(ShipTypeEnum shipTypeEnum)
        {
            ShipType = shipTypeEnum;
        }

        public int FieldsCount => GetShipFieldCount();

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