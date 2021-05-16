using System;
using BattleshipGame.Domain.Domain;
using BattleshipGame.Domain.Domain.Core;
using BattleshipGame.Domain.Domain.Ship;
using BattleshipGame.Domain.Domain.Tile;
using BattleshipGame.Domain.Factories;

namespace BattleshipGame.Application
{
    public class AppManager : IAppManager
    {
        private Battle _battle;
        private IMatrixFactory _matrixFactory;
        private ITileFactory _tileFactory;
        

        public AppManager(IMatrixFactory matrixFactory, ITileFactory tileFactory)
        {
            _matrixFactory = matrixFactory;
            _tileFactory = tileFactory;
            Initialize();
        }

        void Initialize()
        {
            var gameRules = new GameRules();
            _battle = new Battle(_matrixFactory.Create(gameRules.MapSize, gameRules.MapSize, OwnerTypeEnum.Player,_tileFactory ),
                _matrixFactory.Create(gameRules.MapSize, gameRules.MapSize, OwnerTypeEnum.Enemy, _tileFactory),
                new ShipRandomFiller(new RandomProvider()));
            
        }

        public void ResetGame()
        {
            _battle.Reset();
        }

        public void TileClicked(Coordinate coordinate, OwnerTypeEnum ownerType)
        {
            _battle.TileClicked(coordinate, ownerType);
        }

        public ITile GetTile(int coordX, int coordY, OwnerTypeEnum ownerType)
        {
            return _battle.GetTile(new Coordinate(coordX, coordY), ownerType);
        }
    }

    public interface IAppManager
    {
        void ResetGame();

        void TileClicked(Coordinate coordinate, OwnerTypeEnum ownerType);

        ITile GetTile(int coordX, int coordY, OwnerTypeEnum ownerType);
    }
}