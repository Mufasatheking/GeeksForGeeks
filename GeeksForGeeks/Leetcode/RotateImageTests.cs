using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class RotateImageTests
{
    [TestMethod]
    public void TestRotateImage()
    {
        var matrix = new int[6][];
        matrix[0] = new int[] { 2, 29, 20, 26, 16, 28 };
        matrix[1] = new int[] {12,27,9,25,13,21 };
        matrix[2] = new int[] {32,33,32,2,28,14 };
        matrix[3] = new int[] {13,14,32,27,22,26 };
        matrix[4] = new int[] {33,1,20,7,21,7};
        matrix[5] = new int[] {4,24,1,6,32,34};
        Rotate(matrix);
        int g = 4;
    }
    
    public void Rotate(int[][] matrix) {
        int l = 0;
        int r = matrix.Length-1;
        while(l <= r){
            int n = 0;
            while(n < r){
                var tlc = matrix[l][l+n];
                var trc = matrix[l+n][r];
                var brc = matrix[r][r-n];
                var blc = matrix[r-n][l];

                var temp = tlc;
                matrix[l][l+n] = blc;
                matrix[l+n][r] = tlc;
                matrix[r][r-n] = trc;
                matrix[r-n][l] = brc;

                n++;
            }
            l+=1;
            r-=1;
            
        }
    }
}