using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Backtracking.Easy;

[TestClass]
public class PrintAllStringsWithSpacesTests
{
    [TestMethod]
    [DataRow("ABC")]
    public void TestPrintAllStringsWithSpaces(string str)
    {
        var arr = str.ToArray();
        PrintAllWithSpace(arr,  0, new List<char>());

    }

    public void PrintAllWithSpace(char[] str, int index, List<char> current)
    {
        current.Add(str[index]);

        if (index == str.Length-1)
        {
            Console.WriteLine(String.Join("", current));
            return;
        }
        var include = new List<char>(current);
        var exclude = new List<char>(current);
        include.Add(' ');

        PrintAllWithSpace(str, index + 1, include);
        PrintAllWithSpace(str, index + 1, exclude);
    }
}