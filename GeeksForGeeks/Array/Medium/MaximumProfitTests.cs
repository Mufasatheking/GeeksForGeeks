using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GeeksForGeeks.Array.Medium;

[TestClass]
public class MaximumProfitTests
{
    [TestMethod]
    [DataRow(new int[]{10,22,5,75,65,80},87)]
    [DataRow(new int[]{2,30,15,10,8,25,80},100)]
    [DataRow(new int[]{100,30,15,10,8,25,80},72)]
    [DataRow(new int[]{90,80,70,60,50},0)]
    public void TestMaximumProfit(int[] input, int max)
    {
        var res = MaximumProfit(input);
        Assert.AreEqual(max, res);
    }

    public int MaximumProfit(int[] input)
    {
        var profit = new int[input.Length];
        
        //left to right;
        int min = int.MaxValue;
        int maxLR = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] < min)
            {
                min = input[i];
                maxLR = 0;
            }
            
            profit[i] = Math.Max((input[i] - min),maxLR);
            maxLR = profit[i];
        }

        var profitRL = new int[input.Length];
        
        //right to left;
        int max = int.MinValue;
        int maxRL = 0;
        for (int i = input.Length-1; i >=0; i--)
        {
            if (input[i] > max)
            {
                max = input[i];
                maxRL = 0;
            }

            profitRL[i] = Math.Max((max - input[i]),maxRL);
            maxRL = profitRL[i];
        }
        
        var maxProfits = new int[input.Length];

        for (int i = 0; i < input.Length - 1; i++)
        {
            maxProfits[i] = profit[i] + profitRL[i + 1];
        }

        return maxProfits.Max();
    }
}