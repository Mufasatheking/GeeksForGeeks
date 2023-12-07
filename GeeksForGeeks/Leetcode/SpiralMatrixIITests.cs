using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class SpiralMatrixIITests
{
    [TestMethod]
    public void TestSpiralMatrixII()
    {
        var res = GenerateMatrix(3);
    }
    public int[][] GenerateMatrix(int n) {
        var board = new int[n][];
        for(int i =0; i< n;i++){
            board[i] = new int[n];
        }

        int top = 0;
        int left = 0;
        int right = n-1;
        int bottom = n-1;

        int current = 1;
        Console.WriteLine("A");

        while(current <= n*n){
            int row = top;
            int column = left;
            if (top == bottom && left == right)
            {
                board[row][column] = current;
                break;
            }
            Console.WriteLine($"row:{row} column:{column}");
            //top left to top right
            while(column < right){
                board[row][column] = current;
                current+=1;
                column+=1;
            }

            //top right to bottom right
            while(row < bottom){
                board[row][column] = current;
                current+=1;
                row+=1;
            }
            Console.WriteLine("C");

            //bottom right to bottom left
            while(column > left){
                board[row][column] = current;
                current+=1;
                column-=1;
            }
            Console.WriteLine("D");

            //bottom left to top left
            while(row > top){
                board[row][column] = current;
                current+=1;
                row-=1;
            }
            Console.WriteLine($"current:{current}");
            top+=1;
            right-=1;
            bottom-=1;
            left+=1;
            Console.WriteLine("E");

        }
        return board;
    }
}