using System;
using Matrix.Matrix;
using Microsoft.CSharp.RuntimeBinder;

namespace Matrix.MatrixExtensions
{
    /// <summary>
    /// Class for performing arithmetic operations on matrices
    /// </summary>
    public static class MatrixArithmetics
    {
        #region Overloaded Methods

        /// <summary>
        /// Adds square matrices
        /// </summary>
        /// <typeparam name="T">Type of elements in the matrices</typeparam>
        /// <param name="lhs">First matrix</param>
        /// <param name="rhs">Second matrix</param>
        /// <returns>Square matrix - addition result</returns>
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            CheckMatricesCompatible(lhs, rhs);

            SquareMatrix<T> result = new SquareMatrix<T>(lhs.Size);
            PerformBasicSquareAddition(lhs, rhs, result);

            return result;
        }

        /// <summary>
        /// Adds symmetric matrices
        /// </summary>
        /// <typeparam name="T">Type of elements in the matrices</typeparam>
        /// <param name="lhs">First matrix</param>
        /// <param name="rhs">Second matrix</param>
        /// <returns>Symmetric matrix - addition result</returns>
        public static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            return GetAdditionSymmetricResult(lhs, rhs);
        }

        /// <summary>
        /// Adds diagonal matrices
        /// </summary>
        /// <typeparam name="T">Type of elements in the matrices</typeparam>
        /// <param name="lhs">First matrix</param>
        /// <param name="rhs">Second matrix</param>
        /// <returns>Diagonal matrix - addition result</returns>
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            CheckMatricesCompatible(lhs, rhs);

            DiagonalMatrix<T> result = new DiagonalMatrix<T>(lhs.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i, i] = AddElements<T>(lhs[i, i], rhs[i, i]);
            }
            return result;
        }

        /// <summary>
        /// Adds diagonal and symmetric matrices
        /// </summary>
        /// <typeparam name="T">Type of elements in the matrices</typeparam>
        /// <param name="lhs">Diagonal matrix</param>
        /// <param name="rhs">Symmetric matrix</param>
        /// <returns>Symmetric matrix - addition result</returns>
        public static SymmetricMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            return GetAdditionSymmetricResult(lhs, rhs);
        }

        /// <summary>
        /// Adds symmetric and diagonal matrices
        /// </summary>
        /// <typeparam name="T">Type of elements in the matrices</typeparam>
        /// <param name="lhs">Symmetric matrix</param>
        /// <param name="rhs">Diagonal matrix</param>
        /// <returns>Symmetric matrix - addition result</returns>
        public static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            return GetAdditionSymmetricResult(lhs, rhs);
        }

        #endregion

        #region Private Methods

        private static T AddElements<T>(dynamic lhs, dynamic rhs)
        {
            try
            {
                return lhs + rhs;
            }
            catch (RuntimeBinderException)
            {
                throw new InvalidOperationException("Elements cannot be added!");
            }
        }

        private static void CheckMatricesCompatible<T>(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            if(ReferenceEquals(rhs, null))
                throw new ArgumentNullException($"{nameof(rhs)} cannot be null!");
            if(lhs.Size != rhs.Size)
                throw new InvalidOperationException("Cannot add matrices with different sizes!");
        }

        private static void PerformBasicSquareAddition<T>(SquareMatrix<T> lhs, SquareMatrix<T> rhs, SquareMatrix<T> result)
        {
            for (int i = 0; i < result.Size; i++)
            {
                for (int j = 0; j < result.Size; j++)
                {
                    result[i, j] = AddElements<T>(lhs[i, j], rhs[i, j]);
                }
            }
        }

        private static SymmetricMatrix<T> GetAdditionSymmetricResult<T>(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            CheckMatricesCompatible(lhs, rhs);

            SymmetricMatrix<T> result = new SymmetricMatrix<T>(lhs.Size);
            PerformBasicSquareAddition(lhs, rhs, result);

            return result;
        }

        #endregion
    }
}
