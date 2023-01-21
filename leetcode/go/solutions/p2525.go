package solutions

/*
https://leetcode.com/problems/categorize-box-according-to-criteria/
https://leetcode.com/problems/categorize-box-according-to-criteria/submissions/877908044/
*/

func categorizeBox(length int, width int, height int, mass int) string {
    var tenInFourth int64 = 10_000
    var tenInNinth int64 = 1_000_000_000 
    
    var v string
    var m string
    var category string

    if int64(length) >= tenInFourth || int64(width) >= tenInFourth || int64(height) >= tenInFourth {
        v = "Bulky"
    } 

    if int64(length) * int64(width) * int64(height) >= tenInNinth {
        v = "Bulky"
    }

    if mass >= 100 {
        m = "Heavy"
    }

    if v == "Bulky" && m == "Heavy" {
        category = "Both"
    }
    if v != "Bulky" && m != "Heavy" {
        category = "Neither"
    }
    if v == "Bulky" && m != "Heavy" {
        category = "Bulky"
    }
    if v != "Bulky" && m == "Heavy" {
        category = "Heavy"
    }

    return category
}