namespace Matrix.Matrix
{
    /// <summary>
    /// Class representing a symmetric matrix
    /// </summary>
    /// <typeparam name="T">Type of elements in the matrix</typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        #region Constructors

        /// <summary>
        /// Initializes the matrix with default values
        /// </summary>
        /// <param name="size">Symmetric matrix size</param>
        public SymmetricMatrix(int size)
        {
            Size = size;
            Elements = new T[Size * (Size + 1) / 2];
        }

        /// <summary>
        /// Initializes the matrix with the specified values
        /// </summary>
        /// <param name="size">Symmetric matrix size</param>
        /// <param name="elements">Elements for initialization</param>
        public SymmetricMatrix(int size, T[] elements) : this(size)
        {
            InitializeElements(elements);
        }

        #endregion

        #region Overriden Methods

        protected override T GetAt(int i, int j)
        {
            return Elements[GetIndexInOneDimArray(i, j)];
        }

        protected override void SetAt(int i, int j, T value)
        {
            Elements[GetIndexInOneDimArray(i, j)] = value;
        }

        #endregion

        private int GetIndexInOneDimArray(int i, int j)
        {
            int less = i < j ? i : j;
            int more = i > j ? i : j;
            return more * (more + 1) / 2 + less;
        }
    }
}
