using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class CombinationSum
{
    [TestMethod]
    [DataRow(new int[]{2,3,6,7},7)]
    public void TestCombinationSum(int[] candidates, int target)
    {
        var res = new List<IList<int>>();
        CombinationSumRecursive(candidates, target, 0, new List<int>(), res);
        int g = 4;
    }

    public void CombinationSumRecursive(int[] candidates, int target, int index, List<int> current,
        List<IList<int>> all)
    {
        if (index >= candidates.Length ) return;

        if (target == 0)
        { 
            all.Add(current);
            return;
        }
        else if (target > 0)
        {
            var i = candidates[index];
            var include = new List<int>(current);
            include.Add(i);
            var exclude = new List<int>(current);
            CombinationSumRecursive(candidates, target-i, index, include, all);
            CombinationSumRecursive(candidates, target, index + 1, exclude, all);
        }
        else
        {
            return;
        }
    }
}