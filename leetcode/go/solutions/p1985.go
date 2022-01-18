package solutions

import (
	"sort"
)

/*
https://leetcode.com/problems/find-the-kth-largest-integer-in-the-array/
https://leetcode.com/submissions/detail/546235422/
*/

func kthLargestNumber(nums []string, k int) string {
	sort.Slice(nums, func(i int, j int) bool {
		if len(nums[i]) == len(nums[j]) {
			return nums[i] < nums[j]
		}
		return len(nums[j]) > len(nums[i])
	})

	return nums[len(nums)-k]
}
