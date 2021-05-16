using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipGame.Domain.Domain.Matrix;
using BattleshipGame.Domain.Domain.Tile;
using BattleshipGame.Domain.Utils;
using Xamarin.Forms.Internals;

namespace BattleshipGame.Domain.Domain.Ship
{
    public class ShipRandomFiller
    {
        private RandomProvider _provider;
        public ShipRandomFiller(RandomProvider provider)
        {
            _provider = provider;
        }
        
        public void FillShips(TileMatrix tileMatrix, IEnumerable<Ship> ships)
        {
            TryFillShips(tileMatrix,ships);
        }

        void TryFillShips(TileMatrix tileMatrix, IEnumerable<Ship> ships)
        {
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    ships.ForEach(x =>
                    { 
                        TryFillShip(tileMatrix, x);
                    });
                    if(ships.All(x => x.IsAssigned)) return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        void TryFillShip(TileMatrix tileMatrix, Ship ship)
        {
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    FillShip(tileMatrix, ship);
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            throw new Exception("Cannot Fill Ship");
        }
        
        void FillShip(TileMatrix tileMatrix, Ship ship)
        {
            var shipCoords = new List<Coordinate>();
            var initial = _provider.GetRandomCoord(tileMatrix.SizeX);
            shipCoords.Add(initial);
            if (CheckTileIsCollidingWithOther(initial, tileMatrix))
            {
                //TODO: Business exception
                throw new Exception("Cannot Fill Ship");
            }

            var direction = Helper.RandomEnumValue<DirectionEnum>();
            var lastCoord = initial;
            for (int i = 0; i < ship.FieldsCount - 1; i++)
            {
                var coordinate = TryAddField(tileMatrix, ship, lastCoord,direction);
                shipCoords.Add(coordinate);
                lastCoord = coordinate;
            }

            MarkTiles(shipCoords, tileMatrix, ship);
        }

        public bool CheckTileIsCollidingWithOther(Coordinate coordinate, TileMatrix tileMatrix)
        {
            var tile = (PlayerTile)tileMatrix.GetTile(coordinate);
            if (tile.IsShip) return true;
            var adject = tile.Coordinate.GetAdject();
            var isAdjectTileOccupied = adject.Select(x => (PlayerTile)tileMatrix.GetTile(x)).Any(x => x?.IsShip == true);
            return isAdjectTileOccupied;
        }

        void MarkTiles(IEnumerable<Coordinate> coordinates, Matrix.TileMatrix tileMatrix, Ship ship)
        {
            coordinates.ForEach(x =>
            {
                var tile = (PlayerTile)tileMatrix.GetTile(x);
                tile.AssignShip(ship);
            });
        }

        Coordinate TryAddField(TileMatrix tileMatrix, Ship ship, Coordinate last, DirectionEnum directionEnum)
        {
            Coordinate nextCoord = null; 
            switch (directionEnum)
            {
                case DirectionEnum.Up:
                    nextCoord = last.Upper;
                    break;
                case DirectionEnum.Down:
                    nextCoord = last.LowerCoord;
                    break;
                case DirectionEnum.Left:
                    nextCoord = last.LeftCoord;
                    break;
                case DirectionEnum.Right:
                    nextCoord = last.RightCoord;
                    break;
            }

            var isColliding = CheckTileIsCollidingWithOther(nextCoord, tileMatrix);
            if (isColliding) throw new Exception("Tile is Colliding");
            return nextCoord;
        }
    }
}