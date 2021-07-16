/*
 * @lc app=leetcode.cn id=49 lang=csharp
 *
 * [49] 字母异位词分组
 */

// @lc code=start
public class Solution
{
    string sortStr(string a)
    {
        char[] achar = new char[a.Length];
        for (int i=0; i<a.Length; i++)
        {
            achar[i] = a[i];
        }
        Array.Sort(achar);
        string ret = new string(achar);
        return ret;
    }
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        foreach(var s in strs)
        {
            var sorted = sortStr(s);
            if (!dict.ContainsKey(sorted))
            {
                dict[sorted] = new List<string>();
            }
            dict[sorted].Add(s);
        }

        List<IList<string>> ret = new List<IList<string>>();
        foreach (var kv in dict)
        {
            ret.Add(kv.Value);
        }
        return ret;
    }
}
// @lc code=end

