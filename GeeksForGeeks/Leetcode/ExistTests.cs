using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class ExistTests
{
    [TestMethod]
    public void TestExist()
    {
        var board = new char[][]
        {
            new char[] { 'A', 'B', 'C', 'E' },
            new char[] { 'S', 'F', 'C', 'S' },
            new char[] { 'A', 'D', 'E', 'E' }
        };
        var word = "ABCCED";
        var res = Exist(board, word);
        Assert.IsTrue(res);
    }

    public bool Exist(char[][] board, string word) {
        var firstLetter = word[0];
        for(int i= 0; i< board.Length;i++){
            for(int j = 0; j<board[0].Length;j++){
                if(board[i][j]==firstLetter){
                    var wordFound = FindNextLetter(i,j,new List<(int,int)>(),0,board,word);
                    if(wordFound){
                        return true;
                    }
                }
            }
        }
        Console.WriteLine("end");
        return false;
    }

    public bool FindNextLetter(int i,int j,List<(int,int)> parentCoords, int index, char[][] board, string word){
        if(index == word.Length)return true;
        var searchingFor = word[index];
         Console.WriteLine($"searchingFor:{searchingFor}");
        if(board[i][j] != searchingFor){
            Console.WriteLine("board[i][j] != searchingFor");
             return false;
             }
        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;

        //up
        if(i-1 >=0 && parentCoords.Contains((i-1,j)) ==false){
            parentCoords.Add((i,j));
            up = FindNextLetter(i-1,j,parentCoords,index+1,board,word);
            parentCoords.Remove((i,j));
        }
        if(up)return true;
        //down
        if(i+1 <board.Length  && parentCoords.Contains((i+1,j)) ==false){
            parentCoords.Add((i,j));
            down = FindNextLetter(i+1,j,parentCoords,index+1,board,word);
            parentCoords.Remove((i,j));
        }
        if(down)return true;

        //left
        if(j-1>=0  && parentCoords.Contains((i,j-1)) ==false){
            parentCoords.Add((i,j));
            left = FindNextLetter(i,j-1,parentCoords,index+1,board,word);
            parentCoords.Remove((i,j));

        }
        if(left)return true;

        //right
        if(j+1 <board[0].Length && parentCoords.Contains((i,j+1)) ==false){
            parentCoords.Add((i,j));
            right = FindNextLetter(i,j+1,parentCoords,index+1,board,word);
            parentCoords.Remove((i,j));
        }
        if(right)return true;
        Console.WriteLine("no next");

        return false;
    }
}


    
