using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;

namespace GeeksForGeeks.Other;

[TestClass]
public class FindNearestSmallestNumberOnLeftTests
{
    [TestMethod]
    [DataRow(new int[]{1, 6, 4, 10, 2, 5},new int[]{-1, 1, 1,  4, 1, 2})]
    [DataRow(new int[]{1, 3, 0, 2, 5},new int[]{-1, 1, -1, 0, 2})]
    [DataRow(new int[]{1, 2, 3, 4, 5}, new int[]{-1, 1, 2, 3, 4})]
    [DataRow(new int[]{5, 4, 3, 2, 1}, new int[]{-1, -1, -1, -1, -1})]
    [DataRow(new int[]{2, 2, 1, 1, 3, 3}, new int[]{-1, -1, -1, -1, 1, 1})]
    [DataRow(new int[]{5, 7, 1, 9, 2, 8, 3}, new int[]{-1, 5, -1, 1, 1, 2, 2})]
    public void TestFindNearestSmallestNumberOnLeft(int[] input, (int,int)[] output)
    {
        var res = FindNearestSmallestNumberOnLeft(input);
        CollectionAssert.AreEqual(output,res);
    }

    [TestMethod]
    public void TestFindNearestSmallestNumberOnLeft2()
    {
        var input = new int[] { 1, 6, 4, 10, 2, 5 };
        var output = new (int, int)[] { (-1, -1), (1, 0), (1, 0), (4, 2), (1, 0), (2, 4) };
        var res = FindNearestSmallestNumberOnLeft(input);
        CollectionAssert.AreEqual(output,res);
    }
    [TestMethod]
    public void TestFindNearestSmallestNumberOnLeft3()
    {
        var input = new int[] { 1, 2, 3, 4, 5 };
        var output = new (int, int)[] { (-1, -1), (1, 0), (2, 1), (3, 2), (4, 3) };
        var res = FindNearestSmallestNumberOnLeft(input);
        CollectionAssert.AreEqual(output,res);
    }
    
    [TestMethod]
    public void TestFindNearestSmallestNumberOnLeft4()
    {
        var input = new int[] { 5, 4, 3, 2, 1 };
        var output = new (int, int)[] { (-1, -1), (-1, -1),(-1, -1),(-1, -1),(-1, -1) };
        var res = FindNearestSmallestNumberOnLeft(input);
        CollectionAssert.AreEqual(output,res);
    }
    
    [TestMethod]
    public void TestFindNearestSmallestNumberOnLeft5()
    {
        var input = new int[] { 2, 2, 1, 1, 3, 3 };
        var output = new (int, int)[] { (-1, -1), (-1, -1),(-1, -1),(-1, -1),(1, 3),(1, 3) };
        var res = FindNearestSmallestNumberOnLeft(input);
        CollectionAssert.AreEqual(output,res);
    }
    public (int value,int index)[] FindNearestSmallestNumberOnLeft(int[] input)
    {
        var output = new (int value,int index)[input.Length];
        var stack = new Stack<(int value,int index)>();

        for (int i = 0; i < input.Length; i++)
        {
            if (stack.Count() == 0)
            {
                output[i] = (-1,-1);
            }
            else if (stack.Peek().value < input[i])
            {
                output[i] = stack.Peek();
                
            }else if (stack.Peek().value >= input[i])
            {
                while (stack.Count() > 0 && stack.Peek().value >= input[i])
                {
                    stack.Pop();
                }

                if (stack.Count() == 0)
                {
                    output[i] = (-1,-1);
                }
                else
                {
                    output[i] = stack.Peek();
                }
            }
            stack.Push((input[i],i));
        }

        return output;
    }
}
