using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class FirstMissingPositiveTests
{
    [TestMethod]
    [DataRow(new int[] { 1, 2, 0 },3)]
    [DataRow(new int[] { 3,4,-1,1},2)]
    [DataRow(new int[] { 7,8,9,11,12},1)]
    [DataRow(new int[] { 1},2)]
    [DataRow(new int[] { 2,1},3)]
    [DataRow(new int[] { 1,1},2)]
    public void TestFirstMissingPositive(int[] nums, int missing)
    {
        int res = 0;
        if(nums.Length == 1){
            if(nums[0] != 1) res= 1;
            else res= 2;
        }
        else
        {
                res = FirstMissingPositive(nums);
                
        }
        Assert.AreEqual(missing,res);
    }

    public int FirstMissingPositive(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++) {
            while (nums[i] > 0 && nums[i] <= nums.Length && nums[nums[i] - 1] != nums[i]) {
                int correctIndex = nums[i] - 1;
                (nums[i], nums[correctIndex]) = (nums[correctIndex], nums[i]);
            }
        }

        
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != i+1)
            {
                return i + 1;
            }
        }

        return nums.Length + 1;

    }
    

}