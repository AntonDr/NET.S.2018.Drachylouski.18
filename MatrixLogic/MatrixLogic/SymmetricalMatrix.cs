using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil;

namespace MatrixLogic
{
    public class SymmetricalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricalMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <exception cref="ArgumentException">matrix</exception>
        public SymmetricalMatrix(T[][] matrix) : base(matrix)
        {
            int n = matrix.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Operator<T>.NotEqual(matrix[i][j],matrix[j][i]))
                    {
                        throw new ArgumentException($"{nameof(matrix)} is not symmetrical");
                    }
                }
            }
        }
    }
}
