using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class MinDistanceTests
{
    [TestMethod]
    [DataRow("horse","ros", 3)]
    public void TestMinDistance(string word1, string word2, int c)
    {
        var res = MinDistance(word1, word2);
        Assert.AreEqual(c,res);
    }
    
    
    public int MinDistance(string word1, string word2) {
        var firstL = word1.Length+1;
        var secondL = word2.Length+1;
        var dp = new int[firstL][];
        for(int i =0; i<firstL;i++){
            dp[i] = new int[secondL];
        }

        for(int i =0; i<firstL;i++){
            dp[i][0] =i;
        }
        for(int j =0; j<secondL;j++){
            dp[0][j] =j;
        }
        dp[0][0] = 0;

        for(int i =1; i<firstL;i++ ){
            for (int j = 1; j < secondL; j++)
            {
                if (word1[i-1] == word2[j-1])
                {
                    dp[i][j] = dp[i - 1][j - 1];
                }
                else
                {
                    var up = dp[i - 1][j];
                    var left = dp[i][j-1];
                    var diag = dp[i - 1][j - 1];
                    var min = Math.Min(Math.Min(up, left), diag);
                    dp[i][j] = min+1;
                }
            }
        }

        return dp[firstL - 1][secondL - 1];
    }
}