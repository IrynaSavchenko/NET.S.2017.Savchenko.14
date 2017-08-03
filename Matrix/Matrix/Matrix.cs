using System;

namespace Matrix.Matrix
{
    /// <summary>
    /// Abstract class representing a matrix
    /// </summary>
    /// <typeparam name="T">Type of elements in the matrix</typeparam>
    public abstract class Matrix<T>
    {
        /// <summary>
        /// Array of main elements in the matrix
        /// </summary>
        protected T[] Elements { get; set; }

        /// <summary>
        /// Eventhandler for processing element changing
        /// </summary>
        public event EventHandler<MatrixElementChangedEventArgs<T>> ElementChanged = delegate { };

        /// <summary>
        /// Indexator for getting and setting matrix elements
        /// </summary>
        /// <param name="i">Row index</param>
        /// <param name="j">Column index</param>
        /// <returns></returns>
        public T this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);
                return GetAt(i, j);
            }
            set
            {
                CheckIndexes(i, j);
                T oldValue = GetAt(i, j);
                SetAt(i, j, value);
                OnElementChanged(new MatrixElementChangedEventArgs<T>(i, j, oldValue, value));
            }
        }

        #region Abstract Methods

        protected abstract void CheckIndexes(int i, int j);
        protected abstract T GetAt(int i, int j);
        protected abstract void SetAt(int i, int j, T value);

        #endregion

        private void OnElementChanged(MatrixElementChangedEventArgs<T> e)
        {
            EventHandler<MatrixElementChangedEventArgs<T>> temp = ElementChanged;
            temp?.Invoke(this, e);
        }
    }

    /// <summary>
    /// Class containing data for the matrix changing event
    /// </summary>
    /// <typeparam name="T">Type of elements in the matrix</typeparam>
    public class MatrixElementChangedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Row number
        /// </summary>
        public int RowNumber { get; }
        /// <summary>
        /// Column number
        /// </summary>
        public int ColumnNumber { get; }
        /// <summary>
        /// Value before changing
        /// </summary>
        public T OldValue { get; }
        /// <summary>
        /// Value after changing
        /// </summary>
        public T NewValue { get; }

        /// <summary>
        /// Initializes data for the element changing event
        /// </summary>
        /// <param name="rowNumber">Row number</param>
        /// <param name="columnNumber">Column number</param>
        /// <param name="oldValue">Value before changing</param>
        /// <param name="newValue">Value after changing</param>
        public MatrixElementChangedEventArgs(int rowNumber, int columnNumber, T oldValue, T newValue)
        {
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
