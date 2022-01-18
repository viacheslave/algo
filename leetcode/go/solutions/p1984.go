package solutions

import (
	"sort"
)

/*
https://leetcode.com/problems/minimum-difference-between-highest-and-lowest-of-k-scores/
https://leetcode.com/submissions/detail/546221865/
*/

func minimumDifference(nums []int, k int) int {
	sort.Ints(nums)

	const MaxInt = int(^uint(0) >> 1)
	var min int = MaxInt

	for i := 0; i < len(nums)-k+1; i++ {
		min = minf(abs(nums[i]-nums[i+k-1]), min)
	}

	return min
}

func minf(a int, b int) int {
	if a < b {
		return a
	}
	return b
}

func abs(a int) int {
	if a < 0 {
		return -a
	}
	return a
}
