using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GeeksForGeeks.Array.Medium;

[TestClass]
public class SwapPositiveNegativeTests
{
    [TestMethod]
    [DataRow(new int[] {-1,2,-3,4,5,6,-7,8,9}, new int[] {9,-7,8,-3,5,-1,2,4,6})]
    [DataRow(new int[] {-1,3,-2,-4,7,-5}, new int[] {7,-2,3,-5,-1,-4})]
    public void TestSwapPositiveNegative(int[] input, int[] output)
    {
        var res = SwapPositiveNegative(input);
        //Assert.AreEqual(output, res);
    }

    public int[] SwapPositiveNegative(int[] input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 0)
            {
                var current = input[i];
                if (current < 0)
                {
                    int j = i + 1;
                    while (j < input.Length)
                    {
                        if (input[j] > 0)
                        {
                            (input[i], input[j]) = (input[j], input[i]);
                            break;
                        }

                        j++;
                    }
                }
            }
            if (i % 2 == 1)
            {
                var current = input[i];
                if (current > 0)
                {
                    int j = i + 1;
                    while (j < input.Length)
                    {
                        if (input[j] < 0)
                        {
                            (input[i], input[j]) = (input[j], input[i]);
                            break;
                        }

                        j++;
                    }
                }
            }
        }

        return input;
    }
}