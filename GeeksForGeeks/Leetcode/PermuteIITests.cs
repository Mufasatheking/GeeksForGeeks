using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class PermuteIITests
{
    [TestMethod]
    [DataRow(new int[] { 1, 1, 3 })]
    //[DataRow(new int[] { 1, 1, 1,4,5,6 })]
    public void PermuteUnique(int[] nums)
    {
        List<IList<int>> result = new List<IList<int>>();
        System.Array.Sort(nums);
        bool[] used = new bool[nums.Length];
        List<int> currentPermutation = new List<int>();
        Permute(nums, used, currentPermutation, result);
        foreach (var res in result)
        {
           Console.WriteLine(String.Join(',',res));
        }
    }

    private void Permute(int[] nums, bool[] used, List<int> currentPermutation, List<IList<int>> result)
    {
        if (currentPermutation.Count == nums.Length)
        {
            result.Add(new List<int>(currentPermutation));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i]) continue; // Skip used elements
            if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue; // Skip duplicates

            used[i] = true;
            currentPermutation.Add(nums[i]);
            Permute(nums, used, currentPermutation, result);
            currentPermutation.RemoveAt(currentPermutation.Count - 1); // Backtrack
            used[i] = false;
        }
    }
}