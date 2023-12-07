using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.Leetcode;

[TestClass]
public class MinWindowTests
{
    [TestMethod]
    public void TestMinWindow()
    {
        var s = "ADOBECODEBANC";
        var t = "ABC";
        var res = MinWindow(s, t);
        int f = 4;
    }
    
   public string MinWindow(string s, string t) {
        var tDict = new Dictionary<char, int>();
        for(int i =0;i<t.Length;i++){
            if(tDict.ContainsKey(t[i]) == false)tDict[t[i]]=1;
            else tDict[t[i]]+=1;
        }

        var validStrings = new List<string>();
        int left = 0;
        int right = 0;
        var currentString = "";
        var sDict = new Dictionary<char, int>();
        while (right < s.Length)
        {
            var currentChar = s[right];
            Console.WriteLine(currentChar);
            if(sDict.ContainsKey(currentChar) == false)sDict[currentChar]=1;
            else sDict[currentChar]+=1;
            currentString += currentChar;
            bool valid = HasSubstring(tDict, sDict);
            while (valid)
            {
                validStrings.Add(currentString);
                var leftChar = s[left];
                sDict[leftChar] -= 1;
                if (!string.IsNullOrEmpty(currentString) && currentString.Length > 1) {
                    currentString = currentString[1..];
                } else {
                    // Handle the case where the string is null, empty, or has only one character
                    currentString = "";
                }                left++;
                valid=StillValid(tDict, sDict, leftChar);
            }

            right++;
        }
        if (validStrings.Any()) {
            return validStrings.MinBy(x => x.Length);
        } else {
            return "";
        }    
    }
    
    public bool StillValid(IDictionary<char, int> t, IDictionary<char, int> s, char removed){
        if(t.ContainsKey(removed)==false)return true;
        if(t[removed]>s[removed])return false;
        return true;
    }
    public bool HasSubstring(IDictionary<char, int> t, IDictionary<char, int> s)
    {
        if (t.Count > s.Count) return false;

        // Check if the keys and values are the same
        foreach (var pair in t)
        {
            int value;
            if (!s.TryGetValue(pair.Key, out value)) return false;
            if (pair.Value > value) return false;
        }

        return true;
    }
}