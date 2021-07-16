/*
 * @lc app=leetcode.cn id=11 lang=csharp
 *
 * [11] 盛最多水的容器
 */

// @lc code=start
public class Solution
{
    public int MaxArea(int[] height)
    {
        int max = 0;
        int pl = 0;
        int pr = height.Length - 1;
        while (pl<pr)
        {
            int area = Math.Min(height[pl], height[pr]) * (pr - pl);
            max = Math.Max(max, area);
            if (height[pl] < height[pr])
                pl++;
            else
                pr--;
        }
        return max;
    }
}
// @lc code=end

