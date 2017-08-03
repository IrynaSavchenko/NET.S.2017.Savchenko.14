using Matrix.Matrix;
using Matrix.MatrixExtensions;
using NUnit.Framework;

namespace Matrix.Tests.MatrixExtensionsTests
{
    [TestFixture]
    public class MatrixArithmeticsTests
    {
        [Test]
        public static void Addition_SymmetricAndSymmetric_Symmetric()
        {
            SymmetricMatrix<int> first = new SymmetricMatrix<int>(3, new[] { 1, 2, 3, 4 });
            SymmetricMatrix<int> second = new SymmetricMatrix<int>(3, new[] { 1, 2, 3, 4, 5, 6 });
            SymmetricMatrix<int> expected = new SymmetricMatrix<int>(3, new[] { 2, 4, 6, 8, 5, 6 });
            SymmetricMatrix<int> actual = first.Add(second);

            TestEquality(expected, actual);
        }

        [Test]
        public static void Addition_DiagonalAndDiagonal_Diagonal()
        {
            DiagonalMatrix<int> first = new DiagonalMatrix<int>(3, new[] { 1, 2, 3 });
            DiagonalMatrix<int> second = new DiagonalMatrix<int>(3, new[] { 4, 5, 6 });
            DiagonalMatrix<int> expected = new DiagonalMatrix<int>(3, new[] { 5, 7, 9});
            DiagonalMatrix<int> actual = first.Add(second);

            TestEquality(expected, actual);
        }

        [Test]
        public static void Addition_DiagonalAndSymmetric_Diagonal()
        {
            DiagonalMatrix<int> first = new DiagonalMatrix<int>(3, new[] { 1, 2, 3 });
            SymmetricMatrix<int> second = new SymmetricMatrix<int>(3, new[] { 1, 2, 3, 4, 5, 6 });
            SymmetricMatrix<int> expected = new SymmetricMatrix<int>(3, new[] { 2, 2, 5, 4, 5, 9});
            SymmetricMatrix<int> actual1 = first.Add(second);
            SymmetricMatrix<int> actual2 = second.Add(first);

            TestEquality(expected, actual1);
            TestEquality(expected, actual2);
        }

        [Test]
        public static void Addition_SquareAndDiagonal_Square()
        {
            SquareMatrix<int> first = new SquareMatrix<int>(3, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            DiagonalMatrix<int> second = new DiagonalMatrix<int>(3, new[] { 1, 1, 1 });
            SquareMatrix<int> expected = new SquareMatrix<int>(3, new[] { 2, 2, 3, 4, 6, 6, 7, 8, 10 });
            SquareMatrix<int> actual = first.Add(second);

            TestEquality(expected, actual);
        }

        private static void TestEquality<T>(SquareMatrix<T> expected, SquareMatrix<T> actual)
        {
            for (int i = 0; i < expected.Size; i++)
            {
                for (int j = 0; j < expected.Size; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }
    }
}
