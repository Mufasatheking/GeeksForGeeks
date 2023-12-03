using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GeeksForGeeks.Bitwise;

[TestClass]
public class BinaryRepresentationTests
{
    [TestMethod]
    [DataRow(1,"1")]
    [DataRow(2,"10")]
    [DataRow(5,"101")]
    [DataRow(6,"110")]
    [DataRow(7,"111")]
    [DataRow(12,"1100")]
    [DataRow(13,"1101")]
    [DataRow(25,"11001")]
    [DataRow(123,"1111011")]
    public void TestBinaryRepresentation(int dec, string binary)
    {
        Console.WriteLine();
        ConvertToBinary(dec);
        //Assert.AreEqual(binary, res);
    }

    public void ConvertToBinary(int dec)
    {
        if (dec > 1)
        {
            ConvertToBinary(dec / 2);
        }
        Console.Write(dec % 2);
       
    }
}