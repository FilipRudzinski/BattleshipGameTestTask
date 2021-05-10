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
        
    }
}