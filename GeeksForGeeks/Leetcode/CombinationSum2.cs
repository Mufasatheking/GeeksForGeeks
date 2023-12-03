using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class CombinationSum2
{
    [TestMethod]
    [DataRow(new int[]{10,1,2,7,6,1,5}, 8)]
    public void TestCombinationSum2(int[] candidates, int target)
    {
        var res = new List<IList<int>>();
        CombinationSumRecursive2(candidates, target, 0, new List<int>(), res);
        int g = 4;
    }

    public void CombinationSumRecursive2(int[] candidates, int target, int index, List<int> current,
        List<IList<int>> all)
    {
        if (target == 0) {
            all.Add(new List<int>(current));
            return;
        }

        if (target < 0 || index >= candidates.Length) {
            return;
        }

        if (current.Contains(candidates[index]))
        {
            CombinationSumRecursive2(candidates, target, index + 1, current, all);
        }
        else
        {
            current.Add(candidates[index]);
            CombinationSumRecursive2(candidates, target - candidates[index], index+1, current, all);

            current.RemoveAt(current.Count - 1);
            CombinationSumRecursive2(candidates, target, index + 1, current, all);
        }

    }
}