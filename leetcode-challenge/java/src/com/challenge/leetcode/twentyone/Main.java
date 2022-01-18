package com.challenge.leetcode.twentyone;

public class Main {
    public static void main(String[] args) {
        findDuplicate(new int[] {1,2,3,4});
    }

    public static int findDuplicate(int[] nums) {
        int left = 0, right = nums.length;
        while(left<right){
            int mid = left + (right-left)/2;
            int count = 0;
            for(int i:nums) if(i<=mid) count++;
            if(count > mid){
                right = mid;
            }else{
                left = mid+1;
            }
        }
        return left;
    }
}
