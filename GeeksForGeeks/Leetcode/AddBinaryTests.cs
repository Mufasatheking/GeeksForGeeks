using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class AddBinaryTests
{
    [TestMethod]
    //[DataRow("11","1")]
    //[DataRow("1","111")]
    [DataRow("100","110010")]
    public void TestAddBinary(string a, string b)
    {
        var res = AddBinary(a, b);
        int g = 4;
    }
    public string AddBinary(string a, string b) {
        string longer = a.Length >= b.Length ? a : b;
        string shorter = a.Length < b.Length ? a : b;

        int dif = longer.Length - shorter.Length;
        var sb = new StringBuilder();
        bool carry = false;
        for(int i =shorter.Length-1; i>=0;i--){
            bool sh = shorter[i] == '1';
            bool lo = longer[i+dif] == '1';

            bool ls = (sh ^ lo)^carry;
            bool ms = (sh&&lo)||(sh || lo)&&carry;
            carry = ms;
            var toadd = ls == true ? "1" : "0";
            sb.Insert(0,toadd);
        }
        for(int i =longer.Length-shorter.Length-1; i>=0;i--){
            bool sh = longer[i] == '1';
            bool ls = sh ^ carry;
            carry = sh && carry;
            var toadd = ls == true ? "1" : "0";
            sb.Insert(0,toadd);
        }
        if(carry){
            sb.Insert(0,"1");
        }

        return sb.ToString();
    }
}