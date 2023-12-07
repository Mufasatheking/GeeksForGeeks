using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class SetZeroesTests
{
    [TestMethod]
    public void TestSetZeroes()
    {
        var matrix = new int[][] { new int[] { 1, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 1, 1, 1 } };
        SetZeroes(matrix);
    }
    public void SetZeroes(int[][] matrix) {
        for (int i = 1; i < matrix.Length; i++)
        {
            for (int j = 1; j < matrix.Length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }
        
        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i][0] == 0)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = 0;
                }
            }
        }
        
        for (int i = 0; i < matrix[0].Length; i++)
        {
            if (matrix[0][i] == 0)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[j][i] = 0;
                }
            }
        }
    }
}