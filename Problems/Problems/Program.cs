﻿


using Problems;
using System.Numerics;
//Get top stock
void GetTopStock(/*string[] stocks, float[,] prices*/)
{
string[] stocks = {"A" , "B" , "C" };
float[,] prices =
{
    {10,2,3 }, 
    {3,4,5 },
    {4,5,6 },
    {5,6,7 }
    // 3.25 4.25 5.25
};

Dictionary<String, float> stockValue = new Dictionary<String, float>();

for(int i =0;i<stocks.Length; i++)
{
    float total = 0;
    for(int j =0;j<prices.GetLength(0); j++)
    {
        total += prices[j,i];
    }
    stockValue[stocks[i]] = total / prices.GetLength(0);
}
var a = stockValue.OrderByDescending(x => x.Value);
var b = a.Take(1).OrderBy(x => x.Key).ToArray();

Console.WriteLine(b[0]);
}



//26. Remove Duplicates from Sorted Array
void RemoveDuplicates(int[] nums)
{
    Dictionary<int,int> result = new Dictionary<int,int>();
    for(int i =0;i <nums.Length;i++)
    {
        //if (result.ContainsValue(i))
        //{

        //}
        //else { result[nums[i]] = i; }
        if (result.ContainsKey(nums[i]))
        {

        }
        else { result[nums[i]] = i; }
    }
    result.OrderBy(x => x.Value);
    foreach(var a in result)
    {
        Console.WriteLine(a.Key);

        //Console.WriteLine(a.Value);
    }
    Console.WriteLine(result.Keys.Count);
}



//2391. Minimum Amount of Time to Collect Garbage
void GarbageCollection(string[] garbage, int[] travel)
{
    int time = 0;
    foreach (String s in garbage)
    {
        time += s.Length;
    }
    for(int i =0;i<travel.Length;i++)
    {
        time += 3 * travel[i];
    }
    for (int i = garbage.Length-1;i>0; i--)
    {
        if (!garbage[i].Contains('M'))
        {
            time -= travel[i-1];
        }
        else
        {
            break;
        }
    }
    for (int i = garbage.Length - 1; i > 0; i--)
    {
        if (!garbage[i].Contains('P'))
        {
            time -= travel[i - 1];
        }
        else
        {
            break;
        }
    }
    for (int i = garbage.Length - 1; i > 0; i--)
    {
        if (!garbage[i].Contains('G'))
        {
            time -= travel[i - 1];
        }
        else
        {
            break;
        }
    }
    Console.WriteLine(time.ToString());
}



//1814. Count Nice Pairs in an Array
 int CountNicePairs(int[] nums)
{
    int mod = 1000000007;
    int count = 0;
    Dictionary<int, int> pairs = new Dictionary<int, int>();
    foreach (int i in nums)
    {
        int diff = Math.Abs(i - Extension.GetInstance().ReverseInt(i));
        if (pairs.ContainsKey(diff))
        {
            count += pairs[diff];
            count %= mod;
            pairs[diff]++;
        }
        else
        {
            pairs[diff] = 1;
        }
    }
    
    long result = 0;
    foreach (int value in pairs.Values)
    {
        result = (result % mod + ((long)value * ((long)value - 1) / 2)) % mod;
    }
    return (int)result;
}



//1424. Diagonal Traverse II
int[] FindDiagonalOrder(List<List<int>> nums)
{
    Dictionary<int, List<int>> groups = new Dictionary<int, List<int>>();
    for (int i = 0; i < nums.Count; i++)
    {
        for(int j = 0;  j < nums[i].Count; j++) 
        {
            int diagonal = i + j;
            if (groups.ContainsKey(diagonal)) 
            {
                groups[diagonal].Add(nums[i][j]);
            } 
            else
            {
                groups[diagonal] = new List<int> { nums[i][j] };
            }
        }
    }
    List<int> result = new List<int>();
    foreach (List<int> value in groups.Values)
    {
        if(value.Count > 1) {
            value.Reverse();
        }
        result.AddRange(value);

    }
    return result.ToArray();
}



//1561. Maximum Number of Coins You Can Get
int MaxCoins(int[] piles)
{
    Array.Sort(piles);
    int min = 0;
    int max = piles.Length - 1;
    int coins = 0;
    // 0: alice 1:me 2:bob
    int i = 0;
    while(min < max) {
        //coins[0] += piles[max - i];
        coins += piles[max - i - 1];
        //coins[2] += piles[min];
        min++;
        max -= 2;
    }
    return coins;
}



//191. Number of 1 Bits
int HammingWeight(uint n)
{
    return Convert.ToString(n, 2).Count(x => x == '1');
}



//1611. Minimum One Bit Operations to Make Integers Zero
int MinimumOneBitOperations(int n)
{
    int result = 0;
    while (n > 0)
    {
        result ^= n;  // Flip the rightmost bit
        n >>= 1;      // Right-shift the number
    }
    return result;
}



//1266.Minimum Time Visiting All Points
int MinTimeToVisitAllPoints(int[][] points)
{
    int count = 0;
    for (int i = 0; i < points.GetLength(0) - 1; i++)
    {
        //var startP = points[i];
        //var endP = points[i+1];
        //int xDiff = Math.Abs(startP[0] - endP[0]);
        //int yDiff = Math.Abs(startP[1] - endP[1]);
        //int diagonalMove = Math.Min(xDiff, yDiff);
        //int remainingVerticalMove = Math.Abs(yDiff - diagonalMove); 
        //int remainingHorizontallMove = Math.Abs(xDiff - diagonalMove);
        //count += diagonalMove + remainingHorizontallMove + remainingVerticalMove;

        var startP = points[i];
        var endP = points[i + 1];

        int xDiff = Math.Abs(endP[0] - startP[0]);
        int yDiff = Math.Abs(endP[1] - startP[1]);

        // The maximum of xDiff and yDiff represents the diagonal movement
        count += Math.Max(xDiff, yDiff);
    }
    return count;
}



//2264. Largest 3-Same-Digit Number in String
string LargestGoodInteger(string num)
{
    var result = "";
    for (int i = 0; i <= num.Length - 3; i++)
    {
        if (num[i] == num[i+1] && num[i] == num[i+2]) 
        {
            if(result == "" || String.Compare(num.Substring(i,3),result) > 0)
            {
                result = num.Substring(i,3);
            }
        }
    }
    return result;
}



//1. Two Sum
int[] TwoSum(int[] nums, int target)
{
    Dictionary<int, int> result = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++)
    {
        if(result.ContainsKey(target - nums[i]))
        {
            return new int[] { result[target - nums[i]], i };
        }
        if (!result.ContainsKey(nums[i]))
        {
            result[nums[i]] = i;
        }
    }
    return Array.Empty<int>();
}



//1688. Count of Matches in Tournament
int NumberOfMatches(int n)
{
    //int result = 0;
    //while (n>1)
    //{
    //    if(n % 2 == 0)
    //    {
    //        n /= 2;
    //        result += n;
    //    }
    //    else
    //    {
    //        n = (n - 1) / 2 + 1;
    //        result += n - 1;
    //    }
    //}
    //return result;

    return n - 1;
}



//2549. Count Distinct Numbers on Board
int DistinctIntegers(int n)
{
    return n != 1 ? n - 1 : 1;
}



//1929. Concatenation of Array
int[] GetConcatenation(int[] nums)
{
    var result = nums.ToList();
    for (int i = 0; i < nums.Length; i++)
    {
        result.Add(nums[i]);
    }
    return result.ToArray();
}



//1859. Sorting the Sentence
string SortSentence(string s) {
    string[] sToArray = s.Split(" ");
    Dictionary<int, string> resultMap = new Dictionary<int,string>();
    foreach (var item in sToArray)
    {
        var indicate = item[item.Length - 1] - '0';
        var word = item.Substring(0, item.Length - 1);
        resultMap[indicate] = word;
    }
    return String.Join(" ", resultMap.OrderBy(x => x.Key).Select(x => x.Value).ToArray());
}



//1716. Calculate Money in Leetcode Bank
int TotalMoney(int n)
{
    var total = 0;
    int weelyBounus = 0;
    int dailyMoney = 1;
    for (int i = 1; i <= n; i++)
    {
        total += weelyBounus + dailyMoney;
        dailyMoney++;
        if (i % 7 == 0)
        {
            weelyBounus++;
            dailyMoney = 1;
        }
    }
    return total;
}



//1903. Largest Odd Number in String
string LargestOddNumber(string num)
{
    for (int i = num.Length; i > 0; i--)
    {
        var a = (int)num[i - 1];
        if (Extension.GetInstance().CheckOdd(a))
        {
            return num.Substring(0,i);
        }
    }
    return "";
}



//606. Construct String from Binary Tree
//string Tree2str(TreeNode root)
//{
//    if (root == null)
//    {
//        return "";
//    }
//    var result = root.val.ToString();
//    if (root.left != null)
//    {
//        result += "(" + Tree2str(root.left) + ")";
//    }
//    if (root.right != null)
//    {
//        result += "(" + Tree2str(root.right) + ")";
//    }
//    return result;
//}



//94. Binary Tree Inorder Traversal
//IList<int> InorderTraversal(TreeNode root)
//{
//    List<int> result = new List<int>();
//    if (root == null)
//    {
//        return result;
//    }
//    if(root.left != null)
//    {
//        result.AddRange(InorderTraversal(root.left));
//    }
//    result.Add(root.val);
//    if (root.right != null)
//    {
//        result.AddRange(InorderTraversal(root.right));
//    }
//    return result;
//}



//34. Find First and Last Position of Element in Sorted Array
int[] SearchRange(int[] nums, int target)
{
    if(nums.Where(x => x == target).Count() < 1)
    {
        return new int[] { -1, -1 };
    }
    //Dictionary<int,int> result = new();
    //for (int i = 0; i < nums.Length; i++)
    //{
    //    if (nums[i] == target)
    //    {
    //        result[i] = i;
    //    }
    //}
    //if(result.Any())
    //{
    //    return new int[] { result.Values.Min(), result.Values.Max() };
    //}
    //else
    //{
    //    return new int[] { -1, -1 };
    //}    

    int a = -1;
    int b = -1;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == target)
        {
            if(a == -1)
            {
                a = i;
            }
            b = i;
        }
    }
    return new int[] { a, b };
}