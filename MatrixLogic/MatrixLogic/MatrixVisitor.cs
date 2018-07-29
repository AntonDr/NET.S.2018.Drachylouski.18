using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil;

namespace MatrixLogic
{
    /// <summary>
    /// Expansion of functionality
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MatrixVisitor<T>
    {
        /// <summary>
        /// Adds the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        public SquareMatrix<T> Add(SquareMatrix<T> lhs, SquareMatrix<T> rhs) => Add((dynamic) lhs, (dynamic) rhs);

        /// <summary>
        /// Adds the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">It is impossible to add two matrices with different dimensions</exception>
        private SquareMatrix<T> Add(DiagonalMatrix<T> lhs, SymmetricalMatrix<T> rhs)
        {
            if (lhs.Width!=rhs.Width || lhs.Length!=rhs.Length)
            {
                throw new ArgumentException("It is impossible to add two matrices with different dimensions");
            }

            T[][] temp = CreateArray(lhs.Length, lhs.Width);

            for (int i = 0; i < lhs.Length; i++)
            {
                for (int j = 0; j < lhs.Width; j++)
                { 
                    temp[i][j] = Operator<T>.Add(lhs[i,j],rhs[i,j]);
                }
            }

            return new SquareMatrix<T>(temp);
        }

        /// <summary>
        /// Adds the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        private SquareMatrix<T> Add(SymmetricalMatrix<T> lhs, DiagonalMatrix<T> rhs) => Add(rhs, lhs);

        /// <summary>
        /// Adds the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">It is impossible to add two matrices with different dimensions</exception>
        private SquareMatrix<T> Add(SymmetricalMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            if (lhs.Width != rhs.Width || lhs.Length != rhs.Length)
            {
                throw new ArgumentException("It is impossible to add two matrices with different dimensions");
            }

            T[][] temp = CreateArray(lhs.Length, lhs.Width);

            for (int i = 0; i < lhs.Length; i++)
            {
                for (int j = 0; j < lhs.Width; j++)
                {
                    temp[i][j] = Operator<T>.Add(lhs[i, j], rhs[i, j]);
                }
            }

            return new SquareMatrix<T>(temp);
        }

        /// <summary>
        /// Adds the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        private SquareMatrix<T> Add(SquareMatrix<T> lhs, SymmetricalMatrix<T> rhs) => Add(rhs, lhs);

        /// <summary>
        /// Adds the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">It is impossible to add two matrices with different dimensions</exception>
        private SquareMatrix<T> Add(SquareMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            if (lhs.Width != rhs.Width || lhs.Length != rhs.Length)
            {
                throw new ArgumentException("It is impossible to add two matrices with different dimensions");
            }

            T[][] temp = CreateArray(lhs.Length, lhs.Width);

            for (int i = 0; i < lhs.Length; i++)
            {
                for (int j = 0; j < lhs.Width; j++)
                {
                    temp[i][j] = Operator<T>.Add(lhs[i, j], rhs[i, j]);
                }
            }

            return new SquareMatrix<T>(temp);
        }

        /// <summary>
        /// Adds the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        private SquareMatrix<T> Add(DiagonalMatrix<T> lhs, SquareMatrix<T> rhs) => Add(rhs, lhs);

        /// <summary>
        /// Creates the array.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        private T[][] CreateArray(int n, int m)
        {
            T[][] temp = new T[n][];

            for (int i = 0; i < n; i++)
            {
                temp[i] = new T[m];  
            }

            return temp;
        }
    }
}
