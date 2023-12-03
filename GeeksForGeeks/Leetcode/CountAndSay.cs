using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class CountAndSay
{
    [TestMethod]
    [DataRow(4)]
    public void CountAndSayTest(int n)
    {
        var sb = new StringBuilder();
        var res = CountAndSayRecursive(n, sb.Append("1"));
       Console.WriteLine(res);
    }

    public string CountAndSayRecursive(int n, StringBuilder current){
        if(n == 1){
            return current.ToString();
        }
        var res = new StringBuilder();
        for(int i =0; i<current.Length;i++){
            int count = 1;
            while (i + 1 < current.Length && current[i] == current[i + 1]) {
                i++;
                count++;
            }
            res.Append(count.ToString() + current[i].ToString());
        }
        return CountAndSayRecursive(n-1, res);
    }
}