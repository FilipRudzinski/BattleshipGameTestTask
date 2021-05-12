using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipGame.Domain.Utils;
using Xamarin.Forms.Internals;

namespace BattleshipGame.Domain.Domain
{
    public class ShipRandomFiller
    {
        private RandomProvider _provider;
        public ShipRandomFiller(RandomProvider provider)
        {
            _provider = provider;
        } 
        
        public void FillShips(Matrix matrix, IEnumerable<Ship> ships)
        {
            ships.ForEach(x =>
            {
                var shipCoords = FillShip(matrix, x);
                if (shipCoords == null) throw new Exception("Error! Cannot fill Ship");
                
            });
        }

        List<Coordinate> FillShip(Matrix matrix, Ship ship)
        {
            for (int i = 0; i < 1000; i++)
            {
                var shipCoords = TryFillShip(matrix, ship);
                if (shipCoords != null)
                {
                    return shipCoords;
                }
            }
            return null;
        }
        
        List<Coordinate> TryFillShip(Matrix matrix, Ship ship)
        {
            var shipCoords = new List<Coordinate>();
            var initial = _provider.GetRandomCoord(matrix.SizeX);
            shipCoords.Add(initial);
            var tile = matrix.GetTile(initial);
            if (tile.IsShip)
            {
                return null;
            }

            var direction = Helper.RandomEnumValue<DirectionEnum>();
            var lastCoord = initial;
            for (int i = 0; i < ship.FieldsCount; i++)
            {
                var coordinate = TryAddField(matrix, ship, lastCoord,direction);
                lastCoord = coordinate;
                if (coordinate == null) return null;
            }

            MarkTiles(shipCoords, matrix, ship);
            return shipCoords;
        }

        void MarkTiles(IEnumerable<Coordinate> coordinates, Matrix matrix, Ship ship)
        {
            coordinates.ForEach(x =>
            {
                var tile = matrix.GetTile(x);
                tile.AssignShip(ship);
            });
        }

        Coordinate TryAddField(Matrix matrix, Ship ship, Coordinate last, DirectionEnum directionEnum)
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
            var nextTile = matrix.GetTile(nextCoord);
            if (nextTile != null && !nextTile.IsShip)
            {
                var adject = nextTile.Coordinate.GetAdject();
                var isAdjectShip = adject.Select(x => matrix.GetTile(x)).Any(x => x?.IsShip == true);
                if (!isAdjectShip) return nextCoord;
            }
            return null;
        }
    }
}