using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class MultiplyTests
{
    [TestMethod]
    [DataRow("123","456","56088")]
    public void Multiply(string num1, string num2, string result) {
        int m = num1.Length, n = num2.Length;
        int[] pos = new int[m + n];

        for (int i = m - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                int mul = (num1[i] - '0') * (num2[j] - '0');
                int sum = mul + pos[i + j + 1];

                pos[i + j] += sum / 10;
                pos[i + j + 1] = sum % 10;
            }
        }  

        StringBuilder sb = new StringBuilder();
        foreach (int p in pos) if (!(sb.Length == 0 && p == 0)) sb.Append(p);
        var res= sb.Length == 0 ? "0" : sb.ToString();
        Assert.AreEqual(result, res);
    }
}