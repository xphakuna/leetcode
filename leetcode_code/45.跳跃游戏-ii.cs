/*
 * @lc app=leetcode.cn id=45 lang=csharp
 *
 * [45] 跳跃游戏 II
 */

// @lc code=start
public class Solution
{
    public int Jump(int[] nums)
    {
        //if (nums.Length == 1)
        //    return 0;

        int min = 0;
        int max = 0;
        int times = 0;
        while (max<nums.Length-1)
        {
            //int newmin = 999999;
            int newmax = -999999;
            for (int i=min; i<=max; i++)
            {
                if (nums[i] == 0) continue;
                newmax = Math.Max(newmax, nums[i] + i);
            }
            min = min + 1;
            max = newmax;
            times++;
        }
        
        return times;
    }
}
// @lc code=end

