using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class CanJumpTests
{
    [TestMethod]
    //[DataRow(new int[]{2,3,1,1,4},true)]
    [DataRow(new int[]{2,0,0},true)]
    public void CanJump(int[] nums, bool can) {
        var res = CanJumpRecursive(nums, 0);
        Assert.AreEqual(can,res);
    }

    public bool CanJumpRecursive(int[] nums, int index) {
        if(index >= nums.Length -1){
            return true;
        }
        int current = nums[index];

        if(current==0)return false;
        for(int i = 1; i<= current;i++){
            if (CanJumpRecursive(nums, index + i))
            {
                return true;
            }
        }
        return false;
    }
}