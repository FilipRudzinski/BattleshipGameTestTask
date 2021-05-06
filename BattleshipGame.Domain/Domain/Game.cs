namespace BattleshipGame.Domain.Domain
{
    public class Game
    {
        private GameRules _gameRules = new GameRules();
        public Battle Battle { get; private set; }

        public bool PlayerWins { get; private set; }
        public bool EnemyWins { get; private set; }
        
        public Matrix PlayerMatrix { get; }
        public Matrix EnemyMatrix { get; }

        public void StartNewBattle()
        {
            Battle = new Battle(new Matrix(_gameRules.MapSize, _gameRules.MapSize),
                new Matrix(_gameRules.MapSize, _gameRules.MapSize), new ShipRandomFiller(new RandomProvider()));
        }

        public void ShootAt(Matrix matrix, Coordinate coordinate)
        {
            
        }
    }
}