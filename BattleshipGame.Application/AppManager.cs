using System;
using BattleshipGame.Domain.Domain;
using BattleshipGame.Domain.Factories;

namespace BattleshipGame.Application
{
    public class AppManager : IAppManager
    {
        private Battle _battle;
        private IMatrixFactory _matrixFactory;

        public event Action GameInitialized;

        public AppManager(IMatrixFactory matrixFactory)
        {
            _matrixFactory = matrixFactory;
            Initialize();
        }

        void Initialize()
        {
            var gameRules = new GameRules();
            _battle = new Battle(_matrixFactory.Create(gameRules.MapSize, gameRules.MapSize),
                _matrixFactory.Create(gameRules.MapSize, gameRules.MapSize),
                new ShipRandomFiller(new RandomProvider()));
            
            GameInitialized?.Invoke();
        }

        public void ResetGame()
        {
            _battle.Reset();
        }

        public void TileClicked(Coordinate coordinate, MatrixTypeEnum matrixType)
        {
            _battle.TileClicked(coordinate, matrixType);
        }

        public GameTile GetTile(int coordX, int coordY, MatrixTypeEnum matrixType)
        {
            return _battle.GetTile(new Coordinate(coordX, coordY), matrixType);
        }
    }

    public interface IAppManager
    {
        event Action GameInitialized;
        void ResetGame();

        void TileClicked(Coordinate coordinate, MatrixTypeEnum matrixType);

        GameTile GetTile(int coordX, int coordY, MatrixTypeEnum matrixType);
    }
}