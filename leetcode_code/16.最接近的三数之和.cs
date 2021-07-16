/*
 * @lc app=leetcode.cn id=16 lang=csharp
 *
 * [16] 最接近的三数之和
 */

// @lc code=start
public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);
        int ret = 999999;
        int min = 999999;
        for (int i=0; i<=nums.Length-3; i++)
        {
            int pl = i + 1;
            int pr = nums.Length - 1;
            while (pl<pr)
            {
                int sum = nums[i] + nums[pl] + nums[pr];
                if (Math.Abs(sum-target)< min)
                {
                    ret = sum;
                    min = Math.Abs(sum - target);
                }
                if (sum> target)
                {
                    pr--;
                }
                else if (sum< target)
                {
                    pl++;
                }
                else
                {
                    return target;
                }
            }

        }
        return ret;
    }
}
// @lc code=end

