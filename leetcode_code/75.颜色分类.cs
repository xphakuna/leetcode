/*
 * @lc app=leetcode.cn id=75 lang=csharp
 *
 * [75] 颜色分类
 */

// @lc code=startpublic class Solution
public class Solution
{
    public void SortColors(int[] nums)
    {
        int sum_0 = 0;
        int sum_1 = 0;
        int sum_2 = 0;
        for(int i=0; i<nums.Length; i++)
        {
            if (nums[i] == 0)
                sum_0++;
            else if (nums[i] == 1)
                sum_1++;
            else
                sum_2++;
        }
        for (int i=0; i<sum_0; i++)
        {
            nums[i] = 0;
        }
        for (int i=sum_0; i<sum_0+sum_1; i++)
        {
            nums[i] = 1;
        }
        for (int i = sum_0 + sum_1; i < sum_0 + sum_1+sum_2; i++)
        {
            nums[i] = 2;
        }
    }
}
// @lc code=end

