using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public class DiagonalMatrix<T>:SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public DiagonalMatrix(T[][] matrix):base(matrix)
        {
            int n = matrix.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        this.matrix[i][j] = default(T);
                    }
                    else
                    {
                        this.matrix[i][j] = matrix[i][j];
                    }
                }
                
            }
        }
    }
}
