/*
 * @lc app=leetcode.cn id=31 lang=csharp
 *
 * [31] 下一个排列
 */

// @lc code=start
public class Solution
{

    public void swap(int[] nums, int i, int j)
    {
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }
    public void NextPermutation(int[] nums)
    {
        for (int i = nums.Length - 1; i >= 1; i--)
        {
            if (nums[i] > nums[i - 1])
            {
                int idx = i;
                int min = nums[i];
                for (int j = i; j <= nums.Length - 1; j++)
                {
                    if (nums[j] < min && nums[j]> nums[i - 1])
                    {
                        min = nums[j];
                        idx = j;
                    }
                }
                //
                swap(nums, i - 1, idx);
                // sort after i
                for (int j = i; j < nums.Length; j++)
                {
                    min = nums[j];
                    idx = j;
                    for (int k = idx; k < nums.Length; k++)
                    {
                        if (nums[k] < min)
                        {
                            min = nums[k];
                            idx = k;
                        }
                    }
                    if (idx != j)
                    {
                        swap(nums, j, idx);
                    }
                }
                return;
            }
        }
        //
        for (int i = 0; i < nums.Length / 2; i++)
        {
            swap(nums, i, nums.Length - i - 1);

        }
    }
}
// @lc code=end

