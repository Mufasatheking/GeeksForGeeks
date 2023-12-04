using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class JumpGameIIIter
{
    [TestMethod]
    //[DataRow(new int[] {2,3,1,1,4})]
    [DataRow(new int[] { 1, 2, 1, 1, 1 }, 3)]
    public void JumpGameIIIterTest(int[] nums, int j)
    {
        // if (nums.Length == 1) return 0;
        var res = JumpIter(nums, 0);
        Assert.AreEqual(j,res);
    }

    public int JumpIter(int[] nums, int index)
    {
        int count = 0;
        while (index < nums.Length)
        {
            int maxJumps = nums[index];
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

            index = next;
            count++;
        }

        return count;
    }
}