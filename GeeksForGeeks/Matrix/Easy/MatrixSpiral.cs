using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Matrix.Easy;

[TestClass]
public class MatrixSpiralTests
{
    [TestMethod]
    public void TestPrintMatrixSpiral()
    {
        // Test case 1
        int[,] matrix1 =
        {
            { 1, 2, 3 }, 
            { 4, 5, 6 }, 
            { 7, 8, 9 }
        };
        PrintSpiral(matrix1);
        Console.WriteLine();
        Console.WriteLine("---");
        // Test case 2
        int[,] matrix2 =
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 }
        };
        PrintSpiral(matrix2);
        Console.WriteLine();
        Console.WriteLine("---");

        // Test case 3
        int[,] matrix3 =
        {
            { 1, 2, 3, 4,5,6 },
            { 7, 8,9,10,11,12 },
            { 13,14,15,16,17,18}
        };
        PrintSpiral(matrix3);

    }

    private void PrintSpiral(int[,] matrix)
    {
        var x = matrix.GetLength(0);
        var y = matrix.GetLength(1);

        var spirals = Math.Min(x, y) / 2 ;
        int offset = 0;
        while (offset <= spirals)
        {
            PrintCircle(offset, matrix);
            offset++;
        }
    }

    public void PrintCircle(int offset, int[,] matrix)
    {
        var x = matrix.GetLength(0);
        var y = matrix.GetLength(1);
        Console.WriteLine();
        //Right
        for (int i = offset; i < y-offset; i++)
        {
            Console.Write(matrix[offset,i] + " ");
        }
        Console.WriteLine();
        //Down
        for (int i = offset+1; i < x-offset; i++)
        {
            Console.Write(matrix[i,(y-1-offset)] + " ");
        }
        Console.WriteLine();
        //Left
        for (int i = y-1-1-offset; i >= offset; i--)
        {
            Console.Write(matrix[x-1-offset,i] + " ");
        }
        Console.WriteLine();
        //Up
        for (int i = x-1-1-offset; i > offset; i--)
        {
            Console.Write(matrix[i,offset] + " ");
        }
    }
}