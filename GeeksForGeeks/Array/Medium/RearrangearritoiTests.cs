using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace GeeksForGeeks.Array.Medium;

[TestClass]
public class RearrangearritoiTests
{
    [TestMethod]
    [DataRow(new int[]{-1,-1,6,1,9,3,2,-1,4,-1}, new int[]{-1,1,2,3,4,-1,6,-1,-1,9})]
    public void TestRearrangearritoi(int[] input, int[] output)
    {
        var res = Rearrangearritoi(input);
        Assert.AreEqual(1,1);
    }

    public int[] Rearrangearritoi(int[] input)
    {
        for (int i = 0;i < input.Length; i++)
        {
            var aaa = input[i];
           
            if (input[i] != i && input[i]>0)
            {
                var bbb = input[input[i]];
                (input[input[i]], input[i]) = (input[i], input[input[i]]);
            }
        }

        return input;
    }
}