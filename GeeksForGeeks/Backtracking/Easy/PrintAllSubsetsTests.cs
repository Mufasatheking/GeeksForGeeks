using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Backtracking.Easy;

[TestClass]
public class PrintAllSubsetsTests
{
    [TestMethod]
    [DataRow(new []{1,2,3})]
    [DataRow(new []{1,2,3,4})]
    [DataRow(new []{1,2,3,4,5,6,7})]
    public void TestPrintAllSubsets(int[] arr)
    {
        Console.WriteLine("--------");
        PrintAllSubsets(arr, 0, new List<int>());
    }

    public void PrintAllSubsets(int[] arr, int index, List<int> current)
    {
        if(index == arr.Length)
        {
            Console.WriteLine(string.Join(",",current));
            return;
        }
        var i = arr[index];
        var include = new List<int>(current);
        var exclude = new List<int>(current);
        include.Add(i);
        PrintAllSubsets(arr, index +1 , include);
        PrintAllSubsets(arr, index +1 , exclude);
    }
}