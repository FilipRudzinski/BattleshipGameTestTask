using System;
using BattleshipGame.Domain.Domain;
using BattleshipGame.Domain.Factories;

namespace BattleshipGame.Application
{
    public class AppManager : IAppManager
    {
        private Battle _battle;
        private IMatrixFactory _matrixFactory;

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
        }

        public void ResetGame()
        {
            _battle.Reset();
        }

        public void TileClicked(Coordinate coordinate, MatrixTypeEnum matrixType)
        {
            _battle.TileClicked(coordinate, matrixType);
        }
    }

    public interface IAppManager
    {
        void ResetGame();

        void TileClicked(Coordinate coordinate, MatrixTypeEnum matrixType);
    }
}