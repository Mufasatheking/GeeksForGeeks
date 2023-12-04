using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class JumpGameII
{
    [TestMethod]
    //[DataRow(new int[] {2,3,1,1,4})]
    [DataRow(new int[] { 1, 2, 1, 1, 1 })]
    public void Jump(int[] nums)
    {
       // if (nums.Length == 1) return 0;
        var res = JumpRecursive(nums, 0, 0);
    }

    public int JumpRecursive(int[] nums, int index, int count)
    {

        int maxJumps = nums[index];
        if (maxJumps == 0) return 0;
        if (index + maxJumps >= nums.Length - 1)
        {
            count += 1;
            return count;
        }

        int next = 0;
        int max = Int32.MinValue;
        for (int i = index + 1; i < index + maxJumps + 1; i++)
        {
            if (nums[i] + i >= max)
            {
                next = i;
                max = nums[i] + i;
            }
        }

        return JumpRecursive(nums, next, count + 1);
    }
}