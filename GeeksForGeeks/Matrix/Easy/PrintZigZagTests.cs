using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Matrix.Easy;

[TestClass]
public class PrintZigZagTests
{
    [TestMethod]
    public void TestPrintZigZag()
    {
        // Test case 1
        /*int[,] matrix1 =
        {
            { 1, 2, 3 }, 
            { 4, 5, 6 }, 
            { 7, 8, 9 }
        };*/
        
        // Test case 2
        int[,] matrix2 =
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 }
        };
        PrintZigZag(matrix2);

    }

    private void PrintZigZag(int[,] matrix)
    {
        var n = matrix.GetLength(0);
        //First Half
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine();
            //i is the total sum of coordinates
            if (i % 2 == 0)
            {
                int x = i;
                int y = 0;
                while (x >= 0)
                {
                    Console.Write(matrix[x,y]+ " ");
                    x-=1;
                    y+=1;
                }
            }
            else
            {
                int x = 0;
                int y = i;
                while (y >= 0)
                {
                    Console.Write(matrix[x,y]+ " ");
                    x+=1;
                    y-=1;
                }
            }
            
        }
        
        //Second Half
        for (int sum = n; sum < 2 * n - 1; sum++)
        {
            Console.WriteLine();
            //i is the total sum of coordinates
            if (sum % 2 == 0)
            {
                // Top to bottom
                for (int x = n - 1; x >= sum - n + 1; x--)
                {
                    int y = sum - x;
                    if (y < n)
                    {
                        Console.Write(matrix[x, y] + " ");
                    }
                }
            }
            else
            {
                // Bottom to top
                for (int y = n - 1; y >= sum - n + 1; y--)
                {
                    int x = sum - y;
                    if (x < n)
                    {
                        Console.Write(matrix[x, y] + " ");
                    }
                }
            }
            
        }
    }
}