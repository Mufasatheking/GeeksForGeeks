using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;

namespace GeeksForGeeks.Matrix.Easy;

[TestClass]
public class MatrixScalarMultiplicationTests
{
    [TestMethod]
    public void TestScalarMultiplyMatrix()
    {
        // Test case 1
        int[,] matrix1 = { { 2, 3 }, { 5, 4 } };
        int k1 = 5;
        int[,] expected1 = { { 10, 15 }, { 25, 20 } };
        var result1 = ScalarMultiplyMatrix(matrix1, k1);
        CollectionAssert.AreEqual(expected1, result1, "Test case 1 failed");

        // Test case 2
        int[,] matrix2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int k2 = 4;
        int[,] expected2 = { { 4, 8, 12 }, { 16, 20, 24 }, { 28, 32, 36 } };
        var result2 = ScalarMultiplyMatrix(matrix2, k2);
        CollectionAssert.AreEqual(expected2, result2, "Test case 2 failed");

        // Add more test cases here
    }

    private int[,] ScalarMultiplyMatrix(int[,] matrix, int scalar)
    {
        var x = matrix.GetLength(0);
        var y = matrix.GetLength(1);
        var result = new int[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }
}