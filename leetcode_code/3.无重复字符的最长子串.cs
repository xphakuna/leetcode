/*
 * @lc app=leetcode.cn id=3 lang=csharp
 *
 * [3] 无重复字符的最长子串
 */

// @lc code=start
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }
        Dictionary<char, int> dict_char_idx = new Dictionary<char, int>();
        int ret = 1;
        dict_char_idx[s[0]] = 0;
        int idx = 0;
        while (idx<s.Length-1)
        {
            if (idx + dict_char_idx.Count>=s.Length)
            {
                break;
            }
            //
            for (int j=idx+ dict_char_idx.Count; j<s.Length;j++)
            {
                if (dict_char_idx.ContainsKey(s[j]))
                {
                    int find_idx = dict_char_idx[s[j]];
                    for (int i=idx;i<find_idx;i++)
                    {
                        dict_char_idx.Remove(s[i]);
                    }
                    idx = find_idx + 1;
                    dict_char_idx[s[j]] = j;
                    break;
                }
                else
                {
                    dict_char_idx[s[j]] = j;

                    ret = Math.Max(ret, dict_char_idx.Count);
                }
            }
            
        }

        return ret;

    }
}
// @lc code=end

