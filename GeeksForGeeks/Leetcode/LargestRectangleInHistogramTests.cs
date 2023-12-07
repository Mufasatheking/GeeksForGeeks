using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class LargestRectangleInHistogramTests
{
    [TestMethod]
    [DataRow(new int[]{2,1,5,6,2,3},10)]
    [DataRow(new int[]{2,4},4)]
    [DataRow(new int[]{1,1},2)]
    [DataRow(new int[]{5,4,1,2},8)]
    public void LargestRectangleInHistogram(int[] heights, int output)
    {
        var res = LargestRectangleArea(heights);
        Assert.AreEqual(output,res);
    }
    public int LargestRectangleArea(int[] heights)
    {
        int maxArea = Int32.MinValue;
        var leftSmallestArray = FindNearestSmallestNumberOnLeft(heights);
        var rightSmallestArray = FindNearestSmallestNumberOnRight(heights);
        int area = 0;

        for (int i = 0; i < heights.Length; i++)
        {
            var current = heights[i];
            var left = leftSmallestArray[i];
            var right = rightSmallestArray[i];
            int length = 0;
            if (left.value == -1 && right.value == -1)
            {
                length = heights.Length;
            }else if (right.value == -1)
            {
                length = heights.Length - left.index-1;
            }
            else if (left.value == -1)
            {
                length = right.index;
            }
            else
            {
                length = (right.index - left.index)-1;
            }
            var cArea = current * length;
            if (cArea > area)
            {
                area = cArea;
            }
            
        }
        return area;
    }
    
    public (int value,int index)[] FindNearestSmallestNumberOnLeft(int[] input)
    {
        var output = new (int value,int index)[input.Length];
        var stack = new Stack<(int value,int index)>();

        for (int i = 0; i < input.Length; i++)
        {
            if (stack.Count() == 0)
            {
                output[i] = (-1,0);
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
                    output[i] = (-1,0);
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
    public (int value,int index)[] FindNearestSmallestNumberOnRight(int[] input)
    {
        var output = new (int value,int index)[input.Length];
        var stack = new Stack<(int value,int index)>();

        for (int i = input.Length-1; i >= 0; i--)
        {
            if (stack.Count() == 0)
            {
                output[i] = (-1,input.Length-1);
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
                    output[i] = (-1,input.Length-1);
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