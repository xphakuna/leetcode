/*
 * @lc app=leetcode.cn id=38 lang=csharp
 *
 * [38] 外观数列
 */

// @lc code=start
public class Solution
{
    string do_CountAndSay(string s)
    {
        string ret = "";
        int i = 0;
        while (i<s.Length)
        {
            char c = s[i];
            int ib = i;
            i++;
            for (; i<s.Length; i++)
            {
                if (s[i]!= c)
                {
                    ret = ret+"" + (i - ib) + c;
                    break;
                }
            }
            // not find any
            if (i==s.Length)
            {
                ret = ret+"" + (i - ib) + c;
            }
        }
        return ret;
    }
    public string CountAndSay(int n)
    {
        string ret = "1";
        for (int i=1; i<n; i++)
        {
            ret = do_CountAndSay(ret);
        }
        return ret;
    }
}
// @lc code=end

