using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class RemoveDuplicatesTests
{
    [TestMethod]
    public void TestRemoveDuplicates()
    {
        var nums = new int[] { 1, 1, 1, 2, 2, 3 };
        var res = RemoveDuplicates(nums);
        int g = 4;
    }
    public int RemoveDuplicates(int[] nums) {
        var beginning = 0;
        var finder = 1;

        while(finder < nums.Length && beginning<nums.Length)
        {
            if (finder != nums.Length - 1)
            {
                while (nums[finder] == nums[finder + 1])
                {
                    finder++;
                }
            }
            else
            {
                beginning -= 1;}
            
           
            nums[beginning]=nums[finder-1];
            nums[beginning+1]=nums[finder];
            beginning+=2;
            finder++;
        }

        return beginning;
    }
}