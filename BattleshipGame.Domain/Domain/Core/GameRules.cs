using System.Collections.Generic;
using BattleshipGame.Domain.Domain.Ship;

namespace BattleshipGame.Domain.Domain.Core
{
    public class GameRules
    {
        public List<Ship.Ship> GameShips
        {
            get
            {
                return new List<Ship.Ship>
                {
                    new Ship.Ship(ShipTypeEnum.Battleship),
                    new Ship.Ship(ShipTypeEnum.Carrier),
                    new Ship.Ship(ShipTypeEnum.Cruiser),
                    new Ship.Ship(ShipTypeEnum.Destroyer),
                    new Ship.Ship(ShipTypeEnum.Submarine),
                };
            }
        }

        public int MapSize => 10;
    }
}