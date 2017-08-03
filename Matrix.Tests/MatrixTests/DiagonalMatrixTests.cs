using System;
using Matrix.Matrix;
using NUnit.Framework;

namespace Matrix.Tests.MatrixTests
{
    [TestFixture]
    public class DiagonalMatrixTests
    {
        [TestCase(0, 0, ExpectedResult = 9)]
        [TestCase(1, 1, ExpectedResult = 8)]
        [TestCase(2, 2, ExpectedResult = 7)]
        [TestCase(1, 2, ExpectedResult = 0)]
        [TestCase(1, 0, ExpectedResult = 0)]
        public static int Indexer_Indexes_MatrixElement(int i, int j)
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(3, new[] {9, 8, 7});
            return matrix[i, j];
        }

        [TestCase(-1, 0)]
        [TestCase(3, 3)]
        public static void Indexer_InvalidIndexes_ThrowsException(int i, int j)
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(3, new[] { 9, 8, 7 });
            Assert.Throws<ArgumentException>(() =>
            {
                matrix[i, j] = 0;
            });
        }
    }
}
