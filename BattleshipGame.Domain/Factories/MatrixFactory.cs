using BattleshipGame.Domain.Domain;
using BattleshipGame.Domain.Domain.Matrix;

namespace BattleshipGame.Domain.Factories
{
    public class MatrixFactory : IMatrixFactory
    {
        //TODO: Create interface IMatrix
        public TileMatrix Create(int sizeX, int sizeY, OwnerTypeEnum ownerTypeEnum, ITileFactory tileFactory)
        {
            return new TileMatrix(sizeX, sizeY, ownerTypeEnum, tileFactory);
        }
    }

    public interface IMatrixFactory
    {
        TileMatrix Create(int sizeX, int sizeY, OwnerTypeEnum ownerTypeEnum, ITileFactory tileFactory);
    }
}