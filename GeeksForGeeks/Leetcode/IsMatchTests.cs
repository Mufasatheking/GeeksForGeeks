using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class IsMatchTests
{
    [TestMethod]
    /*[DataRow("aa", "*",true)]
    [DataRow("cb", "?a",false)]
    [DataRow("adceb", "*a*b",true)]
    [DataRow("abcabczzzde", "*abc???de*",true)]
    [DataRow("acdcb", "a*c?b",false)]
    [DataRow("abcabczzzde", "*abc???de*",true)]
    [DataRow("abczzzde", "abc???de*",true)]*/
    [DataRow("ho", "ho**",true)]
    public void TestIsMatch(string s, string p, bool match)
    {
        var res = IsMatch(s, p);
        Assert.AreEqual(match,res);
    }
    public bool IsMatch(string s, string p) {
        if(p.Length == 0 && s.Length == 0)return true;
        if(p.Length == 0)return false;
        if(s.Length ==0 && p.Length >0){
            for(int k = 0; k< p.Length;k++){
                if (p[k]!='*')return false;
            }
            return true;
        }
        int i = 0;
        int j = 0;

        while(i<s.Length && j<p.Length)
        {
            if(p[j]==s[i]){
                i++;
                j++;
            }
            else if(p[j]=='?'){
                i++;
                j++;
            }else if(p[j]=='*')
            {
                j++;
                if(j == p.Length) return true;

                while (i < s.Length && IsMatch(s[i..],p[j..]) == false)
                {
                    i++;
                }
                if (i == s.Length) return false;
            }
            else
            {
                return false;
            }

            if (i == s.Length && j != p.Length)
            {
                while (j < p.Length)
                {
                    if (p[j] != '*') return false;
                    j++;
                }

                return true;
            }
            if((i == s.Length ^ j==p.Length))
            {
                return false;
            }
        }
        return true;
    }
}