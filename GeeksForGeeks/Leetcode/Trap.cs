using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class Trap
{
    [TestMethod]
    [DataRow(new int[]{0,1,0,2,1,0,1,3,2,1,2,1},6)]
    [DataRow(new int[]{4,2,0,3,2,5},9)]
    [DataRow(new int[]{4,2,3},1)]
    public void TrapTest(int[] height,int water)
    {
        int res = TotalWater(height);
        Assert.AreEqual(water,res);
    }

    public int TotalWater(int[] height){
        int start = 0;
        while(height[start]==0){
            start++;
        }

        int water = 0;
        int left = start;
        while (left < height.Length-1)
        {
                int right = left+1;
                while(right < height.Length && height[right] < height[left]){
                    right+=1;
                }

                if (right < height.Length)
                {
                    water += GetWater(height, left, right);
                    left = right;
                }
                else
                {
                    int right2 = left+1;
                    if (right2 > height.Length)
                    {
                        left += 1;
                        continue;
                    }
                    int maxHeight = height[right2];
                    int maxRightIndex = right2;
                    while(right2 < height.Length){
                        if (height[right2] > maxHeight)
                        {
                            maxHeight = height[right2];
                            maxRightIndex = right2;
                        }
                        right2+=1;
                    }
                    if (maxRightIndex == left+1)
                    {
                        left += 1;
                        if(left == height.Length)break;
                    }
                    else
                    {
                        water += GetWater(height, left, maxRightIndex);
                        left = maxRightIndex;
                    }
                   
                }
            
        }
        return water;
    }

    public int GetWater(int[] height, int left, int right)
    {
        int sum = 0;
        int lower = Math.Min(height[left], height[right]);
        for (int i = left + 1; i < right; i++)
        {
            sum += lower - height[i];
        }

        return sum;
    }
}