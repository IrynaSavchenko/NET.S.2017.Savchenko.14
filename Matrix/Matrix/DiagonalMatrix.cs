using System;

namespace Matrix.Matrix
{
    /// <summary>
    /// Class representing a diagonal matrix
    /// </summary>
    /// <typeparam name="T">Type of elements in the matrix</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        #region Constructors

        /// <summary>
        /// Initializes the matrix with default values
        /// </summary>
        /// <param name="size">Diagonal matrix size</param>
        public DiagonalMatrix(int size)
        {
            Size = size;
            Elements = new T[Size];
        }

        /// <summary>
        /// Initializes the matrix with the specified values
        /// </summary>
        /// <param name="size">Diagonal matrix size</param>
        /// <param name="elements">Elements for initialization</param>
        public DiagonalMatrix(int size, T[] elements) : this(size)
        {
            InitializeElements(elements);
        }

        #endregion

        #region Overriden Methods

        protected override T GetAt(int i, int j)
        {
            return i == j ? Elements[i] : default(T);
        }

        protected override void SetAt(int i, int j, T value)
        {
            if(i != j)
                throw new ArgumentException("Cannot change non diagonal elements!");
            Elements[i] = value;
        }

        #endregion
    }
}
