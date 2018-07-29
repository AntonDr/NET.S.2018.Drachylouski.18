using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil;

namespace MatrixLogic
{
    /// <summary>
    /// Class with work with matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SquareMatrix<T>
    {
        /// <summary>
        /// Occurs when [change element event handler].
        /// </summary>
        public event EventHandler<ChangeElementEventArgs> ChangeElementEventHandler = delegate { };

        /// <summary>
        /// The matrix
        /// </summary>
        protected T[][] matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public SquareMatrix(T[][] matrix)
        {
            Validate(matrix);

            this.matrix = matrix.Clone() as T[][];
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width => matrix[0].Length;

        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified i.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public T this[int i, int j]
        {
            get
            {
                if (i>this.Length || i<0 || j>this.Width || j<0 )
                {
                    throw new ArgumentOutOfRangeException($"Invalid index");
                }

                return matrix[i][j];
            }

            set
            {
                matrix[i][j] = value;
                OnChangeElementEventHandler(new ChangeElementEventArgs($"{i} {j} element changed"));
            }
        }

        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public int Length => matrix.Length;

        /// <summary>
        /// To the array.
        /// </summary>
        /// <returns></returns>
        public T[][] ToArray()
        {
            return matrix.Clone() as T[][];
        }

        /// <summary>
        /// Validates the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <exception cref="ArgumentNullException">matrix</exception>
        /// <exception cref="ArgumentException">
        /// matrix
        /// </exception>
        private void Validate(T[][] matrix)
        {
            if (matrix==null)
            {
                throw new ArgumentNullException($"{nameof(matrix)} can not be null");
            }

            if (matrix.Length == 0)
            {
               throw new ArgumentException();
            }

            if (matrix.Length!=matrix[0].Length)
            {
                throw new ArgumentException($"{nameof(matrix)} is not square");
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ChangeElementEventHandler" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ChangeElementEventArgs"/> instance containing the event data.</param>
        protected virtual void OnChangeElementEventHandler(ChangeElementEventArgs e)
        {
            ChangeElementEventHandler(this, e);
        }
    }
}
