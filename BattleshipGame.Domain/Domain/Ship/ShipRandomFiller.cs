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

        public void FillShips(Matrix.TileMatrix tileMatrix, IEnumerable<Ship> ships)
        {
            List<Coordinate> shipCoords = null;
            for (int i = 0; i < 100; i++)
            {
                ships.ForEach(x => { shipCoords = FillShip(tileMatrix, x); });
            }

            if (shipCoords == null) throw new Exception("Error! Cannot fill Ships");
        }

        List<Coordinate> FillShip(Matrix.TileMatrix tileMatrix, Ship ship)
        {
            for (int i = 0; i < 100; i++)
            {
                var shipCoords = TryFillShip(tileMatrix, ship);
                if (shipCoords != null)
                {
                    return shipCoords;
                }
            }
            return null;
        }
        
        List<Coordinate> TryFillShip(TileMatrix tileMatrix, Ship ship)
        {
            var shipCoords = new List<Coordinate>();
            var initial = _provider.GetRandomCoord(tileMatrix.SizeX);
            shipCoords.Add(initial);
            var tile = (PlayerTile)tileMatrix.GetTile(initial);
            if (tile.IsShip)
            {
                return null;
            }

            var direction = Helper.RandomEnumValue<DirectionEnum>();
            var lastCoord = initial;
            for (int i = 0; i < ship.FieldsCount - 1; i++)
            {
                var coordinate = TryAddField(tileMatrix, ship, lastCoord,direction);
                shipCoords.Add(coordinate);
                lastCoord = coordinate;
                if (coordinate == null) return null;
            }

            MarkTiles(shipCoords, tileMatrix, ship);
            return shipCoords;
        }

        void CheckTileIsCollidingWithOther(Coordinate coordinate, )
        {
            
        }

        void MarkTiles(IEnumerable<Coordinate> coordinates, Matrix.TileMatrix tileMatrix, Ship ship)
        {
            coordinates.ForEach(x =>
            {
                var tile = (PlayerTile)tileMatrix.GetTile(x);
                tile.AssignShip(ship);
            });
        }

        Coordinate TryAddField(Matrix.TileMatrix tileMatrix, Ship ship, Coordinate last, DirectionEnum directionEnum)
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
            var nextTile = (PlayerTile)tileMatrix.GetTile(nextCoord);
            if (nextTile != null && !nextTile.IsShip)
            {
                var adject = nextTile.Coordinate.GetAdject();
                var isAdjectShip = adject.Select(x => (PlayerTile)tileMatrix.GetTile(x)).Any(x => x?.IsShip == true);
                if (!isAdjectShip) return nextCoord;
            }
            return null;
        }
    }
}