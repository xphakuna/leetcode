/*
 * @lc app=leetcode.cn id=5 lang=csharp
 *
 * [5] 最长回文子串
 */

// @lc code=start
public class Solution
{
    public string LongestPalindrome(string s)
    {
        string ret = ""+s[0];
        int max = 1;

        for (int i=0; i<s.Length-max; i++)
        {
            for (int len=max+1; len<=s.Length-i; len++)
            {
                bool isok = true;
                for (int ii=0; ii<len; ii++)
                {
                    if (s[i+ii] != s[i+len-ii-1])
                    {
                        isok = false;
                        break;
                    }
                }
                if (isok)
                {
                    ret = s.Substring(i, len);
                    max = len;
                }
            }
        }
        //
        return ret;
    }
}
// @lc code=end

