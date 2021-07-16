/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */
// @lc code=start
//using System.Collections.Generic;
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int[] ret = new int[2];

        for (int i=0; i<nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                if (nums[i]*2 == target)
                {
                    ret[0] = dict[nums[i]];
                    ret[1] = i;
                    return ret;
                }
            }
            dict[nums[i]] = i;
        }
        
        foreach(var kv in dict)
        {
            int other = target - kv.Key;
            if (dict.ContainsKey(other) && dict[other]!=kv.Value)
            {
                ret[0] = kv.Value;
                ret[1] = dict[other];
                return ret;
            }
        }
        return ret;
    }
}
// @lc code=end

