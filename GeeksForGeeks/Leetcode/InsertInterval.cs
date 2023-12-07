using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class InsertInterval
{
    [TestMethod]
    public void TestInsertInterval()
    {
        /*int[][] intervals = new int[2][];
        intervals[0] = new int[] { 1, 3 };
        intervals[1] = new int[] { 6,9 };
        var newInterval = new int[] { 2, 5 };*/
        int[][] intervals = new int[5][];
        intervals[0] = new int[] { 1, 2 };
        intervals[1] = new int[] { 3,5};
        intervals[2] = new int[] { 6,7 };
        intervals[3] = new int[] { 8,10 };
        intervals[4] = new int[] { 12,16 };
        var newInterval = new int[] { 4,8 };
        
        var res = Insert(intervals, newInterval);
        int g = 4;
    }
    
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        if(intervals.Length ==0){
            return new int[][] { newInterval };
        }
        var mergedIntervals = new List<int[]>();

        int start = newInterval[0];
        int end = newInterval[1];
        int temp1 = -1;
        int temp2 = -1;
        for (int i = 0; i < intervals.Length; i++)
        {
            int ifir = intervals[i][0];
            int isec = intervals[i][1];
            if (temp2 == -1 && end < ifir)
            {
                temp2 = end;
            }
            if (temp2 == -1 && end == ifir)
            {
                temp2 = isec;
            }
            if (temp1 > 0 && temp2 > 0)
            {
                mergedIntervals.Add(new int[]{temp1,temp2});
                temp1 = -1;
            }
            if(ifir > end || isec < start){
                mergedIntervals.Add(intervals[i]);
                //continue;
            }

            if (start > ifir && start <= isec)
            {
                temp1 = ifir;
            }
            if (end > ifir && end <= isec)
            {
                temp2 = isec;
            }
        }
        
        return mergedIntervals.ToArray();
    }
}