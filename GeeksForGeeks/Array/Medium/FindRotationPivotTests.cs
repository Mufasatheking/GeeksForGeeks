using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GeeksForGeeks.Array.Medium;

[TestClass]
public class FindRotationPivotTests
{
    [TestMethod]
    [Repeat(5)]
    public void TestFindRotationPivot()
    {
        var rand = new Random();
        int length = rand.Next(5,100);
        var arr = new int[length];
        int offset = 5;
        for (int i = 0; i < length; i++)
        {
            arr[i] = offset + i;
        }
        int k = rand.Next(1,length-2);
        var pivot = arr.Length - 1 - k;
        var end = arr[pivot..];
        var start = arr[..pivot];
        int[] rotated = end.Concat(start).ToArray();
        int res = FindPivotPoint(rotated, 0, rotated.Length - 1);
        Assert.AreEqual(k+1,res);
        
    }

    public int FindPivotPoint(int[] arr, int min, int max)
    {
        var mid = min + (max - min) / 2;
        if (mid >= max) return -1;

        if (arr[mid] < arr[mid + 1] && arr[mid] < arr[mid - 1])
        {
            return mid;
        }

        if (arr[mid] > arr[max])
        {
            return FindPivotPoint(arr, mid, max);
        }
        else
        {
            return FindPivotPoint(arr, min, mid);
        }
    }
}