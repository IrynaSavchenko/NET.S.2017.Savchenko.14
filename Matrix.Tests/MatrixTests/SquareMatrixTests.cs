using System;
using Matrix.Matrix;
using NUnit.Framework;

namespace Matrix.Tests.MatrixTests
{
    [TestFixture]
    public class SquareMatrixTests
    {
        [TestCase(0, 0, ExpectedResult = 1)]
        [TestCase(0, 1, ExpectedResult = 2)]
        [TestCase(0, 2, ExpectedResult = 3)]
        [TestCase(1, 0, ExpectedResult = 4)]
        [TestCase(1, 1, ExpectedResult = 5)]
        [TestCase(1, 2, ExpectedResult = 6)]
        [TestCase(2, 0, ExpectedResult = 7)]
        [TestCase(2, 1, ExpectedResult = 8)]
        [TestCase(2, 2, ExpectedResult = 9)]
        public static int Indexer_Indexes_MatrixElement(int i, int j)
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(3, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            return matrix[i, j];
        }

        [TestCase(-1, 0)]
        [TestCase(3, 3)]
        public static void Indexer_InvalidIndexes_ThrowsException(int i, int j)
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(3, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Assert.Throws<ArgumentException>(() =>
            {
                matrix[i, j] = 0;
            });
        }
    }
}
