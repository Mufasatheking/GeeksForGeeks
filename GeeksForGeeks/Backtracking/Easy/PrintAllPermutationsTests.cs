using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Backtracking.Easy;

[TestClass]
public class PrintAllPermutationsTests
{
    [TestMethod]
    [DataRow("ABC")]
    [DataRow("ABCDE")]
    [DataRow("1234567")]
    public void TestPrintAllPermutations(string str)
    {
        PrintAllPermutations(str.ToArray(), 0);
        Console.WriteLine("--------");
    }

    public void PrintAllPermutations(char[] str, int index)
    {
        if (index == str.Length-1)
        {
            Console.WriteLine(String.Join("",str));
            return;
        }

        for (int i = index; i < str.Length; i++)
        {
            (str[i], str[index]) = (str[index], str[i]);
            PrintAllPermutations(str, index + 1);
            (str[i], str[index]) = (str[index], str[i]);
        }
    }
}