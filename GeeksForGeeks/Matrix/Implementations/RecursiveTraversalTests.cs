using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Matrix.Implementations;

[TestClass]
public class RecursiveTraversalTests
{
    [TestMethod]
    public void TestRecursiveTraversal()
    {
        var arr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        Traverse(arr,0,0);
    }
    
    private  void Traverse(int[,] arr, int i, int j)
    {
        if (i == arr.GetLength(0)-1 && j == arr.GetLength(1)-1)
        {
            Console.WriteLine(arr[i, j]);
            return;
        }
        Console.Write($"{arr[i, j]}, ");

        if (j < arr.GetLength(1) -1)
        {
            Traverse(arr, i, j+1);
        }
        if (i < arr.GetLength(0) -1)
        {
            Traverse(arr, i+1, 0);
        }
    }
}