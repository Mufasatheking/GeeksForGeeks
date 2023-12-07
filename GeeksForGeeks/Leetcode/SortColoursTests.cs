using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class SortColoursTests
{
    [TestMethod]
    public void TestSortColours()
    {
        //var nums = new int[] { 2, 0, 2, 1, 1, 0 };
        var nums = new int[] { 2, 0, 1 };
        SortColors(nums);
    }
    
    public void SortColors(int[] nums) {
        int zero = 0;
        int one = 0;
        int two = nums.Length-1;

        while(one <= two){
            var current = nums[one];
            if(current == 1){
                one++;
            }
            if(current == 0){
                (nums[zero], nums[one])= (nums[one], nums[zero]);
                zero++;
                one++;
            }
            if(current == 2){
                (nums[two], nums[one])= (nums[one], nums[two]);
                two--;
            }
        }
    }
}