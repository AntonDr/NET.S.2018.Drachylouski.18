using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using MatrixLogic;
using NUnit.Framework;

namespace NUnitMatrixTest
{
    [TestFixture]
    public class NUnitMatrixTest
    {
        [Test]
        public void TestAdd()
        {
            int[][] matrix = new int[][]
            {
                new[] {1, 2, 3, 5},
                new[] {11, 2, -3, 5},
                new[] {0, 122, -1, 11},
                new[] {0, 0, 0, 0}

            };

            var matrix1 = new DiagonalMatrix<int>(matrix);

            int[][] matrixx = new int[][]
            {
                new[] {1, 2, 3, 5},
                new[] {11, 2, -3, 5},
                new[] {0, 122, -1, 11},
                new[] {0, 0, 0, 0}

            };

            var matrix2 = new SquareMatrix<int>(matrixx);

            int[][] expected = new int[][]
            {
                new[] {2, 2, 3, 5},
                new[] {11, 4, -3, 5},
                new[] {0, 122, -2, 11},
                new[] {0, 0, 0, 0}

            };


            var actual = new MatrixVisitor<int>().Add(matrix1, matrix2);

            CollectionAssert.AreEqual(expected,actual.ToArray());
        }

        [Test]
        public void TestAdd2()
        {
            int[][] matrix = new int[][]
            {
                new [] {1, 0, 0},
                new [] {0, 1, 0},
                new [] {0, 0, 1}
            };

            var matrix1 = new SymmetricalMatrix<int>(matrix);

            int[][] matrixx = new int[][]
            {
                new [] {1, 0, 0},
                new [] {0, 1, 0},
                new [] {0, 0, 1}
            };

            var matrix2 = new DiagonalMatrix<int>(matrixx);

            int[][] expected = new int[][]
            {
                new [] {2, 0, 0},
                new [] {0, 2, 0},
                new [] {0, 0,2}
            };


            var actual = new MatrixVisitor<int>().Add(matrix1, matrix2);

            CollectionAssert.AreEqual(expected, actual.ToArray());


        }
    }
}
