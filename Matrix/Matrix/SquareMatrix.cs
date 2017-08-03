using System;

namespace Matrix.Matrix
{
    /// <summary>
    /// Class representing a square matrix
    /// </summary>
    /// <typeparam name="T">Type of elements in the matrix</typeparam>
    public class SquareMatrix<T> : Matrix<T>
    {
        private int size;

        /// <summary>
        /// Square matrix size
        /// </summary>
        public int Size
        {
            get => size;
            protected set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(Size)} should be positive!");
                size = value;
            }
        }

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        protected SquareMatrix()
        {
        }

        /// <summary>
        /// Initializes the matrix with default values
        /// </summary>
        /// <param name="size">Square matrix size</param>
        public SquareMatrix(int size)
        {
            Size = size;
            Elements = new T[Size * Size];
        }

        /// <summary>
        /// Initializes the matrix with the specified values
        /// </summary>
        /// <param name="size">Square matrix size</param>
        /// <param name="elements">Elements for initialization</param>
        public SquareMatrix(int size, T[] elements) : this(size)
        {
            InitializeElements(elements);
        }

        #endregion

        #region Overriden Methods

        protected override void CheckIndexes(int i, int j)
        {
            ValidateIndex(i, nameof(i));
            ValidateIndex(j, nameof(j));
        }

        protected override T GetAt(int i, int j)
        {
            return Elements[Size * i + j];
        }

        protected override void SetAt(int i, int j, T value)
        {
            Elements[Size * i + j] = value;
        }

        #endregion

        protected void InitializeElements(T[] elements)
        {
            for (int i = 0; i < elements.Length && i < Elements.Length; i++)
            {
                Elements[i] = elements[i];
            }
        }

        private void ValidateIndex(int index, string indexName)
        {
            if (index < 0 || index >= Size)
                throw new ArgumentException($"Index {indexName} is out of range!");
        }
    }
}
