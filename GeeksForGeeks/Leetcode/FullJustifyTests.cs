using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class FullJustifyTests
{
    [TestMethod]
    public void TestFullJustify()
    {
        // var str = new string[] { "This", "is", "an", "example", "of", "text", "justification." };
        //var str = new string[] {"What", "must", "be", "acknowledgment", "shall", "be" };
        //var str = new string[] {"Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to",
        //    "a", "computer.", "Art", "is", "everything", "else", "we", "do" };
        var str = new string[] {"a", "computer.", "Art", "is"};
    var res = FullJustify(str, 20);
        int g = 4;
    }
    
    public IList<string> FullJustify(string[] words, int maxWidth) {
        int i = 0;
        var res = new List<string>();
        while(i< words.Length){
            var currentWords = new List<string>();
            var currentLength = 0;
            while(currentLength <maxWidth){
                if(i== words.Length)break;
                if(currentLength + words[i].Length+1 < maxWidth || currentLength + words[i].Length == maxWidth){
                    currentWords.Add(words[i]);
                    currentLength+=words[i].Length+1;
                    i++;
                }else{
                    break;
                }
            }
            int currCount = currentWords.Count();
            int totalSpacesToAdd = maxWidth - currentLength+currCount;
            int eachSpaceToAdd = currCount == 1 ? 0: totalSpacesToAdd/(currCount-1);
            int remaining =  currCount == 1 ? 0: totalSpacesToAdd%(currCount-1);

            string toshow = "";
            if (i == words.Length)
            {
                toshow = string.Join(' ', currentWords)+string.Concat(System.Linq.Enumerable.Repeat(' ', (int)totalSpacesToAdd+1));
            }
            else
            {
                if (eachSpaceToAdd > 0)
                {
                    var first = currentWords.FirstOrDefault()+string.Concat(System.Linq.Enumerable.Repeat(' ', (int)eachSpaceToAdd+remaining));
                    toshow = first + String.Join(string.Concat(System.Linq.Enumerable.Repeat(' ', (int)eachSpaceToAdd)),currentWords.Skip(1));
                }
                else
                {
                    toshow = currentWords.FirstOrDefault() +
                             string.Concat(System.Linq.Enumerable.Repeat(' ', (int)totalSpacesToAdd));
                }
            }
            
            res.Add(toshow);
        }

        return res;
    }
}