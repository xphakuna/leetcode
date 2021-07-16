/*
 * @lc app=leetcode.cn id=7 lang=csharp
 *
 * [7] 整数反转
 */

// @lc code=start
public class Solution {
    public int Reverse(int x) {
        int sign = 1;
        if (x<0)
        {
            x=-x;
            sign=-1;
        }
        int newx = 0;
        int time = 1;
        int oldx = 0;
        while(x>0)
        {
            int n = x%10;
            x = x/10;
            oldx = newx;
            newx = newx*10 + n;
            if ((newx-n)/10 != oldx)
            {
                return 0;
            }
        }
        return sign*newx;
    }
}
// @lc code=end

