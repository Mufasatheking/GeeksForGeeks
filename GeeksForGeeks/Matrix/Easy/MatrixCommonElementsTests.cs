using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;

namespace GeeksForGeeks.Matrix.Easy;

[TestClass]
public class MatrixCommonElementsTests
{
    [TestMethod]
    public void TestFindCommonElements()
    {
        // Test case 1
        int[,] matrix1 = { { 2, 1, 4, 3 }, { 1, 2, 3, 2 }, { 3, 6, 2, 3 }, { 5, 2, 5, 3 } };
        var expected1 = new HashSet<int> { 2, 3 };
        var result1 = FindCommonElements(matrix1);
        CollectionAssert.AreEquivalent(expected1.ToList(), result1.ToList());

        // Test case 2
        int[,] matrix2 = { { 12, 1, 14, 3, 16 }, { 14, 2, 1, 3, 35 }, { 14, 1, 14, 3, 11 }, { 14, 25, 3, 2, 1 }, { 1, 18, 3, 21, 14 } };
        var expected2 = new HashSet<int> { 1, 3, 14 };
        var result2 = FindCommonElements(matrix2);
        CollectionAssert.AreEquivalent(expected2.ToList(), result2.ToList());

        // Add more test cases here
    }

    private HashSet<int> FindCommonElements(int[,] matrix)
    {
        var common = new HashSet<int>();
        int x = matrix.GetLength(0);
        int y = matrix.GetLength(1);
        //add all in the first row
        for (int i = 0; i < y; i++)
        {
            common.Add(matrix[0, i]);
        }
        
        for (int i = 1; i < x; i++)
        {
            var temp = new HashSet<int>();

            for (int j = 0; j < y; j++)
            {
                temp.Add(matrix[i, j]);
            }
            common.IntersectWith(temp);
        }

        return common;
    }
}