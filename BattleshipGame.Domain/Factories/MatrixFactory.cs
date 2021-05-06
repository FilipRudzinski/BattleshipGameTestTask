using BattleshipGame.Domain.Domain;

namespace BattleshipGame.Domain.Factories
{
    public class MatrixFactory : IMatrixFactory
    {
        public Matrix Create(int sizeX, int sizeY)
        {
            return new Matrix(sizeX, sizeY);
        }
    }

    public interface IMatrixFactory
    {
        Matrix Create(int sizeX, int sizeY);
    }
}