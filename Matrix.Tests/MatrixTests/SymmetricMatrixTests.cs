using System;
using Matrix.Matrix;
using NUnit.Framework;

namespace Matrix.Tests.MatrixTests
{
    [TestFixture]
    public class SymmetricMatrixTests
    {
        [TestCase(0, 0, ExpectedResult = 1)]
        [TestCase(1, 0, ExpectedResult = 2)]
        [TestCase(0, 1, ExpectedResult = 2)]
        [TestCase(1, 1, ExpectedResult = 3)]
        [TestCase(2, 0, ExpectedResult = 4)]
        [TestCase(0, 2, ExpectedResult = 4)]
        [TestCase(2, 1, ExpectedResult = 0)]
        [TestCase(1, 2, ExpectedResult = 0)]
        public static int Indexer_Indexes_MatrixElement(int i, int j)
        {
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(3, new[] { 1, 2, 3, 4 });
            return matrix[i, j];
        }

        [TestCase(-1, 0)]
        [TestCase(3, 3)]
        public static void Indexer_InvalidIndexes_ThrowsException(int i, int j)
        {
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(3, new[] { 1, 2, 3, 4 });
            Assert.Throws<ArgumentException>(() =>
            {
                matrix[i, j] = 0;
            });
        }
    }
}
