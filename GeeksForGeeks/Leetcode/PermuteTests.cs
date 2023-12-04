using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class PermuteTests
{
    [TestMethod]
    [DataRow(new int[] { 1, 2, 3 })]
    public void TestPermute(int[] arr)
    {
        List<List<int>> result = new List<List<int>>();
         Permute(arr, 0, result);
         int f = 4;
    }

    public void Permute(int[] arr, int index, List<List<int>> result)
    {
        if (index == arr.Length)
        {
            result.Add(arr.ToList());
            return;
        }

        for (int i = index; i < arr.Length; i++)
        {
            (arr[i], arr[index]) = (arr[index], arr[i]);
            Permute(arr, index + 1,result);
            (arr[i], arr[index]) = (arr[index], arr[i]);
        }

    }
}