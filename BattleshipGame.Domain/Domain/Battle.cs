using BattleshipGame.Domain.Factories;

namespace BattleshipGame.Domain.Domain
{
    public class Battle
    {
        private ShipRandomFiller _shipRandomFiller;
        
        public Matrix PlayerMatrix { get; }
        public Matrix EnemyMatrix { get; }
        
        public Battle(Matrix playerMatrix, Matrix enemyMatrix, ShipRandomFiller shipRandomFiller)
        {
            PlayerMatrix = playerMatrix;
            EnemyMatrix = enemyMatrix;
        }

        public void FillRandomShips()
        {
            var ships = new GameRules().GameShips;
            _shipRandomFiller.FillShips(PlayerMatrix, ships);
        }
    }
}