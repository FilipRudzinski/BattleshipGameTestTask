// using System;
// using BattleshipGame.Domain.Domain.Matrix;
// using BattleshipGame.Domain.Factories;
//
// namespace BattleshipGame.Domain.Domain.Core
// {
//     [Obsolete]
//     public class Game
//     {
//         private GameRules _gameRules = new GameRules();
//         public Battle Battle { get; private set; }
//
//         public bool PlayerWins { get; private set; }
//         public bool EnemyWins { get; private set; }
//         
//         public TileMatrix PlayerTileMatrix { get; }
//         public TileMatrix EnemyTileMatrix { get; }
//
//         private readonly IMatrixFactory _matrixFactory;
//         private readonly ITileFactory _tileFactory;
//
//         public Game(IMatrixFactory matrixFactory, ITileFactory tileFactory)
//         {
//             _matrixFactory = matrixFactory;
//             _tileFactory = tileFactory;
//         }
//
//         // public void StartNewBattle()
//         // {
//         //     Battle = new Battle(
//         //         _matrixFactory.Create(_gameRules.MapSize, _gameRules.MapSize, OwnerTypeEnum.Player, _tileFactory),
//         //         _matrixFactory.Create(_gameRules.MapSize, _gameRules.MapSize, OwnerTypeEnum.Enemy, _tileFactory),
//         //         new ShipRandomFiller(new RandomProvider()));
//         // }
//         
//     }
// }