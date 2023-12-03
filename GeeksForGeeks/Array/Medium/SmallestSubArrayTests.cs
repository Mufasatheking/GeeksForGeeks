using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GeeksForGeeks.Array.Medium;

[TestClass]
public class SmallestSubArrayTests
{
    [TestMethod]
    [DataRow(new int[]{1,4,45,6,0,19},51,3)]
    [DataRow(new int[]{1,10,5,2,7},9,1)] 
    [DataRow(new int[]{1,11,100,1,0,200,3,2,1,250},280,4)] 
    [DataRow(new int[]{100,1,0,200},8,1)] 
    public void TestSmallestSubArray(int[]input,int sum,int length)
    {
        var res = SmallestSubArray(input, sum);
        Assert.AreEqual(length,res);
    }

    public int SmallestSubArray(int[] input, int target)
    {
        var left = 0;
        var right = 0;

        int sum = 0;
        int minLength = int.MaxValue;
        
        while (right < input.Length)
        {
            if (sum <= target)
            {
                int r = input[right];
                sum += r;
                right++;
            }
            else
            {
                minLength = right - left < minLength ? right - left : minLength;
                int l = input[left];
                sum -= l;
                left++;
            }
        }

        return minLength == input.Length ? -1 : minLength;
    }
}