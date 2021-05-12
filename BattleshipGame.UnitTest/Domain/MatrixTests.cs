using BattleshipGame.Domain.Domain;
using BattleshipGame.Domain.Factories;
using NUnit.Framework;
using Xamarin.UITest;

namespace BattleshipGame.UnitTest.Domain
{
    public class MatrixTests
    {
        [Test]
        public void MatrixCreationTest()
        {
            var matrixFactory = new MatrixFactory();
            //arrange
            var size = 10;
            var matrix = matrixFactory.Create(size, size);

            //act 

            //assert
            
            Assert.AreEqual(matrix.SizeX, 10);
            Assert.AreEqual(matrix.SizeY, 10);
        }

        [Test]
        public void MatrixFieldTest()
        {
            var matrixFactory = new MatrixFactory();
            //arrange
            var size = 10;
            var matrix = matrixFactory.Create(size, size);

            //act 
            var coordX = 2;
            var coordY = 2;
            var tile = matrix.GetTile(new Coordinate(coordX,coordY));

            //assert

            Assert.NotNull(tile);
            Assert.AreEqual(tile.Coordinate.X,coordX);
            Assert.AreEqual(tile.Coordinate.Y,coordY);
        }
        
    }
}