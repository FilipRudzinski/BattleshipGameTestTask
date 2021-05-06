using System.Collections.Generic;

namespace BattleshipGame.Domain.Domain
{
    public class GameRules
    {
        public List<Ship> GameShips
        {
            get
            {
                return new List<Ship>
                {
                    new Ship(ShipTypeEnum.Battleship),
                    new Ship(ShipTypeEnum.Carrier),
                    new Ship(ShipTypeEnum.Cruiser),
                    new Ship(ShipTypeEnum.Destroyer),
                    new Ship(ShipTypeEnum.Submarine),
                };
            }
        }

        public int MapSize => 10;
    }
}