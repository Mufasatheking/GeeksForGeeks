using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class IsMatchDPTests
{
    [TestMethod]
   // [DataRow("abc", "*c",true)]
    //[DataRow("aa", "*",true)]
    //[DataRow("cb", "?a",false)]
    [DataRow("adceb", "*a*b",true)]
    [DataRow("abcabczzzde", "*abc???de*",true)]
    [DataRow("acdcb", "a*c?b",false)]
    [DataRow("abcabczzzde", "*abc???de*",true)]
    [DataRow("abczzzde", "abc???de*",true)]
    [DataRow("ho", "ho**",true)]
    public void TestIsMatch(string s, string p, bool match)
    {
        var res = IsMatch(s, p);
        Assert.AreEqual(match,res);
    }
    public bool IsMatch(string s, string p)
    {
        var matches = new bool[s.Length+1,p.Length+1];
        matches[0, 0] = true;

        for(int k = 0;k<p.Length;k++)
        {
            matches[0, k + 1] = matches[0, k] && p[k] == '*';
        }
        
        for(int i = 0;i<s.Length;i++)
        {
            for (int j = 0; j < p.Length; j++)
            {
                if (s[i] == p[j] || p[j] == '?')
                {
                    matches[i + 1, j + 1] = matches[i, j];
                }
                if (p[j] == '*')
                {
                    var aaa = matches[i, j + 1]; //Checks if string one char shorter has matched so far
                    var bbb = matches[i+1, j ]; //Check if string of same length matched with pattern one shorter
                    matches[i + 1, j + 1] = aaa || bbb;
                }
            }
        }

        return matches[s.Length, p.Length];
    }
}