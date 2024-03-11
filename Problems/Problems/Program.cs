


using Problems;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using static Problems.RandomizedSet;
//Get top stock
void GetTopStock(/*string[] stocks, float[,] prices*/)
{
string[] stocks = {"A" , "B" , "C" };
float[,] prices =
{
    {1,2,3 }, 
    {3,4,5 },
    {4,5,6 },
    {5,6,7 }
    //3.25 4.25 5.25
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


// on going with greedy algorithm
//45. Jump Game II
//int Jump(int[] nums)
//{
//    int count = 0;
//    int left = nums[0];
//    int right = nums[nums.Length - 1];
//    Dictionary<int, int> result = new Dictionary<int, int>();

//    while(left < right)
//    {
//        if (nums[0] + nums[left] < )
//    }
//}



//867. Transpose Matrix
int[][] Transpose(int[][] matrix)
{
    var newCol = matrix.Max(x => x.Length);
    Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();
    int[][] returnResult = new int[newCol][];
    for (int i = 0; i < newCol; i++)
    {
        for (int j = 0; j < matrix.Length; j++)
        {
            if(result.ContainsKey(i))
            {
                result[i].Add(matrix[j][i]);
            }
            else
            {
                result[i] = new List<int>
                {
                    matrix[j][i]
                };
            }
        }
    }
    for (int i = 0; i < result.Keys.Count; i++)
    {
        returnResult[i] = result[i].ToArray();
    }
    return returnResult;
}



//1287. Element Appearing More Than 25% In Sorted Array
int FindSpecialInteger(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == arr[i + arr.Length/4])
        {
            return arr[i];
        }
    }
    return 0;
}



//1464. Maximum Product of Two Elements in an Array
int MaxProduct(int[] nums) {
    //LinQ
    //var firstMax = nums.Max();
    //var indexFirstMax = Array.IndexOf(nums, firstMax);
    //nums = nums.Where((val, index) => index != indexFirstMax).ToArray();
    //var secondMax = nums.Max();
    return (nums.Max() - 1) * (nums.Where((value, index) => index != Array.IndexOf(nums, nums.Max())).Max() - 1);

    //Sort Array
    //Array.Sort(nums);
    //return (nums[nums.Length - 1] - 1) * (nums[nums.Length - 2] - 1);

    //ToList
    //var first = 0;
    //var second = 0;
    //var list = nums.ToList();
    //first = nums.Max();
    //list.Remove(first);
    //second = nums.Max();
    //return (first - 1) * (second - 1);
}



//1582. Special Positions in a Binary Matrix
int NumSpecial(int[][] mat)
{
    int m = mat.Length;
    int n = mat[0].Length;
    int[] rowCount = new int[m];
    int[] colCount = new int[n];
    int count = 0;
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            rowCount[i] += mat[i][j];
            colCount[j] += mat[i][j];
        }
    }
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (mat[i][j] == 1 && rowCount[i] == 1 && colCount[j] == 1)
            {
                count++;
            }
        }
    }
    return count;
}



//2482. Difference Between Ones and Zeros in Row and Column
int[][] OnesMinusZeros(int[][] grid)
{
    int m = grid.Length;
    int n = grid[0].Length;
    int[] oneRowCount = new int[m];
    int[] oneColCount = new int[n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            oneRowCount[i] += grid[i][j];
            oneColCount[j] += grid[i][j];
        }
    }
    int[][] result = new int[m][];
    for (int i = 0; i < m; i++)
    {
        var a = new List<int>();
        for (int j = 0; j < n; j++)
        {
            a.Add(oneRowCount[i] + oneColCount[j] - (n - oneColCount[j]) - (m- oneRowCount[i]));
        }
        result[i] = a.ToArray();
    }
    return result;
}



//1436. Destination City
string DestCity(IList < IList<string> > paths) {
    Dictionary<string,string> result = new Dictionary<string,string>();
    foreach (var item in paths)
    {
        result[item[0]] = item[1];
    }
    string cur = paths[0][0];
    while (result.ContainsKey(cur))
    {
        cur = result[cur];
    }
    return cur;
}



//242. Valid Anagram
bool IsAnagram(string s, string t)
{
    if(s.Length != t.Length)
    {
        return false;
    }
    //List<char> result = new List<char>();
    //List<char> result2 = new List<char>();
    //for (int i = 0; i < s.Length; i++)
    //{
    //    result.Add(s[i]);
    //}
    //result.Sort();
    //for (int i = 0; i < s.Length; i++)
    //{
    //    result2.Add(t[i]);
    //}
    //result2.Sort();
    //if(result.SequenceEqual(result2))
    //{
    //    return true;
    //}
    //return false;
    char[] sArray = s.ToCharArray();
    char[] tArray = t.ToCharArray();
    Array.Sort(sArray);
    Array.Sort(tArray);
    return Enumerable.SequenceEqual(sArray, tArray);
}



//2353. Design a Food Rating System
//private Dictionary<string, Dictionary<string, int>> ratings; // cuisine -> food -> rating
//private Dictionary<string, string> highestRated; // cuisine -> highest rated food
//public FoodRatings(string[] foods, string[] cuisines, int[] initialRatings)
//{
//    ratings = new();
//    highestRated = new();
//    for (int i = 0; i < foods.Length; i++)
//    {
//        string food = foods[i];
//        string cuisine = cuisines[i];
//        int rating = initialRatings[i];
//        if (!ratings.ContainsKey(cuisine))
//        {
//            ratings[cuisine] = new Dictionary<string, int>();
//        }
//        ratings[cuisine][food] = rating;
//        if (!highestRated.ContainsKey(cuisine) || rating > ratings[cuisine][highestRated[cuisine]])
//        {
//            highestRated[cuisine] = food;
//        }
//        else if (rating == ratings[cuisine][highestRated[cuisine]] && string.Compare(food, highestRated[cuisine]) < 0)
//        {
//            highestRated[cuisine] = food;
//        }
//    }
//}
//public void ChangeRating(string food, int newRating)
//{
//    foreach (var cuisine in ratings.Keys)
//    {
//        if (ratings[cuisine].ContainsKey(food))
//        {
//            ratings[cuisine][food] = newRating;
//            UpdateHighestRated(cuisine, food, newRating);
//            break;
//        }
//    }
//}
//public string HighestRated(string cuisine)
//{
//    return highestRated[cuisine];
//}
//private void UpdateHighestRated(string cuisine, string food, int newRating)
//{
//    var max = ratings[cuisine].Values.Max();
//    if (highestRated[cuisine] == food)
//    {
//        if (newRating < max)
//        {
//            highestRated[cuisine] = ratings[cuisine].FirstOrDefault(x => x.Value == max).Key;
//            var listMaxKey = ratings[cuisine].Where(x => x.Value == max).ToList();
//            if (lexicographically(highestRated[cuisine], listMaxKey[0].Key) > 0)
//            {
//                highestRated[cuisine] = listMaxKey[0].Key;
//            }
//            foreach (var item in listMaxKey)
//            {
//                if (lexicographically(highestRated[cuisine], item.Key) > 0)
//                {
//                    highestRated[cuisine] = item.Key;
//                }
//            }
//            return;
//        }
//        else
//        {
//            return;
//        }
//    }
//    if (highestRated[cuisine] != food)
//    {
//        var currentHighestRating = ratings[cuisine][highestRated[cuisine]];
//        if (newRating < currentHighestRating)
//        {
//            return;
//        }
//        if (newRating > currentHighestRating)
//        {
//            highestRated[cuisine] = food;
//        }
//        if (newRating == currentHighestRating)
//        {
//            var listMaxKey = ratings[cuisine].Where(x => x.Value == newRating).ToList();
//            foreach (var item in listMaxKey)
//            {
//                if (lexicographically(highestRated[cuisine], item.Key) > 0)
//                {
//                    highestRated[cuisine] = item.Key;
//                }
//            }
//        }
//    }
//}
//private int lexicographically(string x, string y)
//{
//    int minLength = Math.Min(x.Length, y.Length);
//    for (int i = 0; i < minLength; i++)
//    {
//        if (x[i] != y[i])
//        {
//            return x[i].CompareTo(y[i]);
//        }
//    }
//    return x.Length.CompareTo(y.Length);
//}



//2610. Convert an Array Into a 2D Array With Conditions
IList<IList<int>> FindMatrix(int[] nums)
{
    List<IList<int>> result = new List<IList<int>>();
    List<int> tempList = new List<int>();
    tempList = nums.ToList();
    while(tempList.Count > 0)
    {
        Dictionary<int, int> tempDictionary = new();
        for (int i = 0; i < tempList.Count; i++)
        {
            if (!tempDictionary.ContainsKey(tempList[i]))
            {
                tempDictionary[tempList[i]] = tempList[i];
            }
        }
        foreach (int i in tempDictionary.Values)
        {
            tempList.Remove(i);
        }
        result.Add(tempDictionary.Keys.ToList());
    }
    return result;
}



//2125. Number of Laser Beams in a Bank
int NumberOfBeams(string[] bank)
{
    int total = 0;
    List<int> result = new List<int>();
    foreach (var item in bank)
    {
        int n = item.Count(x => x == '1');
        if(n > 0)
        {
            result.Add(n);
        }
    }
    for (int i = 0; i < result.Count - 1; i++)
    {
        total += (result[i] * result[i + 1]);
    }
    return total;
}



//2870. Minimum Number of Operations to Make Array Empty

int MinOperations(int[] nums)
{
    int count = 0;
    Dictionary<int, int> result = new();
    for(int i = 0; i < nums.Length; i++)
    {
        if (!result.ContainsKey(nums[i]))
        {
            result[nums[i]] = 1;
        }
        else
        {
            result[nums[i]]++;
        }
    }
    foreach (var item in result)
    {
        if(item.Value == 1)
        {
            return -1;
        }
        if (item.Value % 3 == 0)
        {
            count += item.Value / 3;
            continue;
        }
        if (item.Value % 3 == 1)
        {
            count += (item.Value / 3 - 1) + 2;
            continue;
        }
        if(item.Value % 3 == 2)
        {
            count += item.Value / 3 + 1;
        }
    }
    return count;
}



//300. Longest Increasing Subsequence
int LengthOfLIS(int[] nums)
{
    int maxLength = 1;
    int[]dp = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        dp[i] = 1;
        for (int j = 0; j < i; j++)
        {
            if (nums[i] > nums[j])
            {
                dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }
        maxLength = Math.Max(maxLength, dp[i]);
    }
    return maxLength;
}



//938. Range Sum of BST
//int RangeSumBST(TreeNode root, int low, int high)
//{
//    if (root == null)
//    {
//        return 0;
//    }
//    int currentVal = (root.val >= low && root.val <= high) ? root.val : 0;
//    int leftVal = RangeSumBST(root.left, low, high);
//    int rightVal = RangeSumBST(root.right, low, high);

//    return currentVal + leftVal + rightVal;
//}



//872. Leaf-Similar Trees
//bool LeafSimilar(TreeNode root1, TreeNode root2)
//{
//    List<int> a = new();
//    List<int> b = new();
//    GetLeafArray(root1, a);
//    GetLeafArray(root2, b);
//    return a.SequenceEqual(b);
//}

//List<int> GetLeafArray(TreeNode root, List<int> result)
//{
//    if(root.left != null)
//    {
//        GetLeafArray(root.left, result);
//    }
//    if(root.right != null)
//    {
//        GetLeafArray(root.right, result);
//    }
//    if (root.left == null && root.right == null)
//    {
//        result.Add(root.val);
//    }

//    return result;
//}
//}



//1026. Maximum Difference Between Node and Ancestor
//int MaxAncestorDiff(TreeNode root)
//{
//    return FindMaxDifference(root, root.val, root.val);
//}
//int FindMaxDifference(TreeNode node, int ancestorMin, int ancestorMax)
//{
//    if(node == null) return 0;
//    var left = FindMaxDifference(node.left, ancestorMin, ancestorMax);
//    int currentMax = Math.Max(Math.Abs(node.val - ancestorMin), Math.Abs(node.val - ancestorMax));
//    ancestorMin = Math.Min(ancestorMin, node.val);
//    ancestorMax = Math.Max(ancestorMax, node.val);
//    var right = FindMaxDifference(node.right, ancestorMin, ancestorMax);
//    return Math.Max(currentMax, Math.Max(left, right));
//}



////783. Minimum Distance Between BST Nodes
//int MinDiffInBST(TreeNode root)
//{
//    List<int> list = new();
//    MakeList(root, list);
//    int min = int.MaxValue;
//    for (int i = 0; i < list.Count - 1; i++)
//    {
//        if (Math.Abs(list[i] - list[i + 1]) < min) min = Math.Abs(list[i] - list[i + 1]);
//    }
//    return min;
//}
//void MakeList(TreeNode root, List<int> list)
//{
//    if(root == null) return;
//    MakeList(root.left, list);
//    list.Add(root.val);
//    MakeList(root.right, list);
//}



//1704. Determine if String Halves Are Alike
bool HalvesAreAlike(string s)
{
    string a = s.Substring(0,s.Length / 2);
    string b = s.Substring(s.Length / 2, s.Length / 2);
    int aCount = 0;
    int bCount = 0;
    char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
    foreach (var item in vowels)
    {
        if (a.Contains(item)) aCount += a.Count(x => x == item);
        if (b.Contains(item)) bCount += b.Count(x => x == item);
    }
    if(aCount == bCount) return true;
    return false;
}



//1347. Minimum Number of Steps to Make Two Strings Anagram
int MinSteps(string s, string t)
{
    char[] sArray = s.ToCharArray();
    char[] tArray = t.ToCharArray();
    Array.Sort(sArray);
    Array.Sort(tArray);
    if(sArray.SequenceEqual(tArray)) return 0;
    SortedDictionary<char, int> sDic = new();
    for (int i = 0; i < s.Length; i++)
    {
        if (!sDic.ContainsKey(s[i])) sDic[s[i]] = 1;
        else sDic[s[i]]++;
    }
    for (int i = 0; i < t.Length; i++)
    {
        if (sDic.ContainsKey(t[i])) sDic[t[i]]--;
    }
    return sDic.Where(x => x.Value > 0).Sum(x => x.Value);
}



//9. Palindrome Number
bool IsPalindrome(int x) {
    int a = 0;
    int b = x;
    while (b > 0)
    {
        a = a * 10 + b % 10;
        b /= 10;
    }
    return a == x;
}



//13. Roman to Integer
int RomanToInt(string s)
{
    Dictionary<string, int> dict = new()
    {
        {"I",1 },
        {"V",5 },
        {"X",10},
        {"L",50},
        {"C",100},
        {"D",500},
        {"M",1000},
        {"IV",4},
        {"IX",9},
        {"XL",40},
        {"XC",90},
        {"CD",400},
        {"CM",900},
    };
    int result = 0;
    s += " ";
    for(int i = 0; i < s.Length - 1; i++)
    {
        var a = s[i].ToString();
        var b = s[i].ToString() + s[i + 1].ToString();
        if (dict.ContainsKey(b))
        {
            result += dict[b];
            i++;
            continue;
        }
        if (dict.ContainsKey(a))
        {
            result += dict[a];
        }
    }
    return result;
}



//21. Merge Two Sorted Lists
ListNode MergeTwoLists(ListNode list1, ListNode list2)
{
    List<int> result = new();
    if(list1 != null) GetNode(list1, result);
    if(list2 != null) GetNode(list2, result);
    result.Sort();
    ListNode dummyHead = new ListNode();
    ListNode currentNode = dummyHead;
    for (int i = 0; i < result.Count; i++)
    {
        currentNode.next = new ListNode(result[i]);
        currentNode = currentNode.next;
    }
    return dummyHead.next;
}
void GetNode(ListNode node, List<int> list)
{
    while (node != null)
    {
        list.Add(node.val);
        node = node.next;
    }
}



//1657. Determine if Two Strings Are Close
bool CloseStrings(string word1, string word2)
{
    //if(word1.Length !=  word2.Length) return false;
    //SortedDictionary<string, int> dict1 = new();
    //SortedDictionary<string, int> dict2 = new();
    //for (int i = 0; i < word1.Length; i++)
    //{
    //    var s = word1[i].ToString();
    //    if (!dict1.ContainsKey(s))
    //    {
    //        dict1[s] = 1;
    //    }
    //    else dict1[s]++;
    //}
    //for (int i = 0; i < word2.Length; i++)
    //{
    //    var s = word2[i].ToString();
    //    if (!dict2.ContainsKey(s))
    //    {
    //        dict2[s] = 1;
    //    }
    //    else dict2[s]++;
    //}
    //var a = dict1.Keys.Order().ToArray();
    //var b = dict2.Keys.Order().ToArray();
    //var c = dict1.Values.Order().ToArray();
    //var d = dict2.Values.Order().ToArray();
    //return a.SequenceEqual(b) && c.SequenceEqual(d);

    int[] freq1 = new int[26];
    int[] freq2 = new int[26];
    foreach (var item in word1.ToCharArray())
    {
        freq1[item - 'a']++;
    }
    foreach (var item in word2.ToCharArray())
    {
        freq2[item - 'a']++;
    }
    for(int i = 0; i < 26; i++)
    {
        if ((freq1[i] == 0 && freq2[i] != 0) || (freq1[i] != 0 && freq2[i] == 0)) return false;
    }
    Array.Sort(freq1);
    Array.Sort(freq2);
    for (int i = 0; i < 26; i++)
    {
        if (freq1[i] != freq2[i]) return false;
    }
    return true;
}



//2225. Find Players With Zero or One Losses
IList<IList<int>> FindWinners(int[][] matches)
{
    SortedDictionary<int, int> loseOne = new();
    List<int> list0Lose = new();
    List<int> List1neLose = new();
    for (int i = 0; i < matches.Length; i++)
    {
        if (!loseOne.ContainsKey(matches[i][1]))
        {
            loseOne[matches[i][1]] = 1;
        }
        else loseOne[matches[i][1]]++;
    }
    var a = loseOne.Where(x => x.Value < 2);
    foreach (var item in a)
    {
        List1neLose.Add(item.Key);
    }
    for (int i = 0; i < matches.Length; i++)
    {
        if (!loseOne.ContainsKey(matches[i][0]))
        {
            list0Lose.Add(matches[i][0]);
        }
    }
    list0Lose.Sort();
    List<IList<int>> result = new()
    {
        list0Lose.Distinct().ToList(),
        List1neLose
    };
    return result;
}



//1207. Unique Number of Occurrences
bool UniqueOccurrences(int[] arr)
{
    Dictionary<int, int> result = new();
    for (int i = 0; i < arr.Length; i++)
    {
        if (!result.ContainsKey(arr[i])) result[arr[i]] = 1;
        else result[arr[i]]++;
    }
    var a = result.Values.ToList();
    return a.Count == a.Distinct().Count();
}



//70. Climbing Stairs
int ClimbStairs(int n)
{
    int[] a = new int[n+1];
    return StairsCases(n, a);
}
int StairsCases(int n, int[] memo)
{
    if (memo[n] != 0) return memo[n];
    if (n <= 2) return n;
    memo[n] = StairsCases(n - 1, memo) + StairsCases(n - 2, memo);
    return memo[n];
}



//198. House Robber
int Rob(int[] nums)
{
    //var num = nums.Length;
    //if (num == 0)
    //{
    //    return 0;
    //}
    //if (num == 1)
    //{
    //    return nums[0];
    //}
    //int[] dp = new int[num];
    //dp[0] = nums[0];
    //dp[1] = Math.Max(nums[0], nums[1]);
    //for (int i = 2; i < num; i++)
    //{
    //    dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
    //}
    //return dp[num - 1];
    int rob1 = 0, rob2 = 0, temp;
    foreach (var item in nums)
    {
        temp = Math.Max(rob1 + item, rob2);
        rob1 = rob2;
        rob2 = temp;
    }
    return rob2;
}



//645. Set Mismatch
int[] FindErrorNums(int[] nums)
{
    Array.Sort(nums);
    var length = nums.Length;
    var realSum = 0;
    for(int i = 0; i < length; i++)
    {
        realSum+= nums[i];
    }
    var expectedSum = (length * (length + 1)) / 2;
    var dupNumb = 0;
    for (int i = 1; i < length; i++)
    {
        if (nums[i] == nums[i-1])
        {
            dupNumb = nums[i];
            break;
        }
    }
    var realNumb = -(realSum - dupNumb - expectedSum);
    return new int[] { dupNumb, realNumb };
    //int first = nums.GroupBy(x => x).Where(g => g.Count() == 2).Select(x => x.Key).First();
    //int second = Enumerable.Range(1, nums.Length).Except(nums).First();

    //return new int[] { first, second };
}


//1913. Maximum Product Difference Between Two Pairs
int MaxProductDifference(int[] nums)
{
    //var length = nums.Length;
    //Array.Sort(nums);
    //return (nums[length - 1] * nums[length - 2]) - (nums[0] * nums[1]);
    var biggestNumb = 0;
    var secondbiggestNumb = 0;
    var smallestNumb = int.MaxValue;
    var secondsmallestNumb = int.MaxValue;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] > biggestNumb)
        {
            secondbiggestNumb = biggestNumb;
            biggestNumb = nums[i];
        }
        else if (nums[i] > secondbiggestNumb) secondbiggestNumb = nums[i];
        if (nums[i] < smallestNumb)
        {
            secondsmallestNumb = smallestNumb;
            smallestNumb = nums[i];
        }
        else if (nums[i] < secondsmallestNumb) secondsmallestNumb = nums[i];
    }
    return biggestNumb * secondbiggestNumb - smallestNumb * secondsmallestNumb;
}



//2706. Buy Two Chocolates
int BuyChoco(int[] prices, int money)
{
    //var cheap = int.MaxValue;
    //var cheapest = int.MaxValue;
    //for (int i = 0; i < prices.Length; i++)
    //{
    //    if (prices[i] < cheapest)
    //    {
    //        cheap = cheapest;
    //        cheapest = prices[i];
    //    }
    //    else if (prices[i] < cheap) cheap = prices[i];
    //}
    //var leftover = money - (cheap + cheapest);
    //return (leftover) < 0 ? money : leftover;
    Array.Sort(prices);
    var a = prices[0] + prices[1];
    if (a > money) return money;
    else return money - a;
}



//1239. Maximum Length of a Concatenated String with Unique Characters
int MaxLength(IList<string> arr)
{
    return MaxLengthRecursive(arr);
}
int MaxLengthRecursive(IList<string> arr, int i = 0, string s = "")
{
    HashSet<char> hs = new HashSet<char>(s);
    if (hs.Count != s.Length) return 0;
    hs = null;
    if (i == arr.Count) return s.Length;
    return Math.Max(MaxLengthRecursive(arr, i + 1, s + arr[i]), MaxLengthRecursive(arr, i + 1, s));
}



//1457. Pseudo-Palindromic Paths in a Binary Tree
int PseudoPalindromicPaths(TreeNode root)
{
    return PseudoPalindromicPathsRecursive(root, 0);
}
int PseudoPalindromicPathsRecursive(TreeNode root,int count)
{
    if (root == null)
    {
        return 0;
    }
    if (root.left == null && root.right == null)
    {
        return 1;
    }
    if (root.left != null)
    {
        count++;
        PseudoPalindromicPathsRecursive(root.left, count);
        if (root.left == null) 
        {
            if(count % 2 == 1)
            {
                count = 0;
            }
        }
    }
    if(root.right != null)
    {
        count++;
        PseudoPalindromicPathsRecursive(root.right, count);
        if (root.right == null)
        {
            if (count % 2 == 1)
            {
                count = 0;
            }
        }
    }
    var left = PseudoPalindromicPathsRecursive(root.left, count);
    var right = PseudoPalindromicPathsRecursive(root.right, count);
    return left + right;
}



//1481. Least Number of Unique Integers after K Removals
int FindLeastNumOfUniqueInts(int[] arr, int k)
{
    Dictionary<int, int> result = new();
    for (int i = 0; i < arr.Length; i++)
    {
        if (result.ContainsKey(arr[i]))
        {
            result[arr[i]]++;
        }
        else { result[arr[i]] = 1; }
    }
    var sorted = result.Values.Order().ToArray();
    int count = 0;
    for (int i = 0; i < sorted.Count(); i++)
    {
        k -= sorted[i];
        if (k < 0) count++;
    }
    return count;
}



//231. Power of Two
bool IsPowerOfTwo(int n)
{
    return n > 0 && (n & n-1) == 0;
    //return Math.Ceiling(Math.Log2(n)) == Math.Floor(Math.Log2(n));
    //for (int i = 0; i < n; i++)
    //{
    //    if (Math.Pow(2, i) > n) return false;
    //    if (n == Math.Pow(2, i)) return true;
    //}
    //return false;
}



//268. Missing Number
int MissingNumber(int[] nums)
{
    int n = nums.Length;
    int actualSum = n*(n+1)/2;
    int sum = 0;
    foreach (var item in nums)
    {
        sum += item;
    }
    return actualSum - sum;
    //if (nums.Length == 1 && nums[0] == 1) return 0;
    //if (nums.Length == 1 && nums[0] == 0) return 1;
    //Array.Sort(nums);
    //if (nums.Length == 1) return 0;
    //var n = nums.Length;
    //if (nums[nums.Length - 1] < n) return n;
    //for (int i = 1; i < nums.Length; i++)
    //{
    //    if (nums[i] != nums[i - 1] + 1) return nums[i] - 1;
    //}
    //return 0;
}



//201. Bitwise AND of Numbers Range
int RangeBitwiseAnd(int left, int right)
{
    if (left < 0) return 0;
    if (left == right) return left;
    int shift = 0;
    while(left < right)
    {
        left >>= 1;
        right >>= 1;
        shift++;
    }
    return left << shift;
}



//997. Find the Town Judge
int FindJudge(int n, int[][] trust)
{
    var result = new int[n+1];

    foreach (var item in trust)
    {
        result[item[0]]--;
        result[item[1]]++;
    }
    for (int i = 1; i <= n; i++)
    {
        if (result[i] == n - 1) return i;
    }
    return -1;
    //Dictionary<int, int> result = new();
    //for (int i = 1 ; i <= n; i++)
    //{
    //    result[i] = 0;   
    //}
    //foreach (var item in trust)
    //{
    //    if (result.ContainsKey(item[1])) result[item[1]]++;
    //    if (result.ContainsKey(item[0])) result[item[0]]--;
    //}
    //var a = result.Where(x => x.Value == n-1);
    //if (a.Any()) return a.First().Key;
    //else return -1;
}



//2108. Find First Palindromic String in the Array
string FirstPalindrome(string[] words)
{
    foreach (var word in words)
    {
        if(CheckWordIfPalindromic(word)) return word;
    }
    return "";
}

bool CheckWordIfPalindromic(string word)
{
    var left = 0;
    var right = word.Length - 1;
    if (word[left] != word[right]) return false;
    while (left < right)
    {
        if (word[left++] != word[right--]) return false;
    }
    return true;
}



//100. Same Tree
bool IsSameTree(TreeNode p, TreeNode q)
{
    if (p == null && q == null) return true;
    if (p == null || q == null) return false;
    if (p.val != q.val) return false;
    return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
}



//543. Diameter of Binary Tree
//int DiameterOfBinaryTree(TreeNode root)
//{

//}



//2864. Maximum Odd Binary Number
string MaximumOddBinaryNumber(string s)
{
    int count0 = 0, count1 = 0;
    foreach (var word in s)
    {
        if(word - '0' == 1) count1++;
        if(word - '0' == 0) count0++;
    }
    return new String('1', count1 - 1) + new String('0', count0) + "1";
    //Dictionary<string,int> result = new();
    //foreach(var word in s)
    //{
    //    var a = word.ToString();
    //    if (result.ContainsKey(a)) result[a]++;
    //    else result[a] = 1;
    //}
    //string resultt = "";
    //if (result.ContainsKey("1") && result["1"] > 1)
    //{
    //    for (int i = 0; i < result["1"] - 1; i++)
    //    {
    //        resultt += "1";
    //    }
    //}
    //if (result.ContainsKey("0") &&result["0"] > 0) 
    //{
    //    for (int i = 0; i < result["0"]; i++)
    //    {
    //        resultt += "0";
    //    }
    //}
    //return resultt += "1";
}



//19. Remove Nth Node From End of List
ListNode RemoveNthFromEnd(ListNode head, int n)
{
    ListNode temp = new ListNode(0);
    temp.next = head;
    ListNode first = temp;
    ListNode second = temp;

    for (int i = 0; i <= n; i++)
    {
        first = first.next;
    }
    while(first != null)
    {
        first = first.next;
        second = second.next;
    }
    second.next = second.next.next;
    return temp.next;
}



//141. Linked List Cycle
bool HasCycle(ListNode head)
{
    //hare and tortoise algorithm
    if (head == null || head.next == null) return false;
    var hare = head;
    var tortoise = head;
    while (tortoise != null && tortoise.next != null)
    {
        hare = hare.next;
        tortoise = tortoise.next.next;
        if (hare == tortoise) return true;
    }
    return false;
    // using a Dictionary to store node, check if last node connect to any
    //if (head == null || head.next == null) return false;
    //Dictionary<ListNode, int> cycle = new();
    //var dummy = head.next;
    //while (dummy != null)
    //{
    //    cycle[dummy] = dummy.val;
    //    if (dummy.next == null) break;
    //    dummy = dummy.next;
    //    if (cycle.ContainsKey(dummy)) return true;
    //}
    //return false;
}



//876. Middle of the Linked List
ListNode MiddleNode(ListNode head)
{
    if (head.next == null) return head;
    var hare = head;
    var tortoise = head;
    while(hare != null && hare.next != null)
    {
        tortoise = tortoise.next;
        hare = hare.next.next;
    }
    return tortoise;
    //if (head.next == null) return head;
    //int i = 1, j = 1;
    //var dummy = head;
    //var dummy2 = head;
    //while(dummy!= null)
    //{
    //    dummy = dummy.next;
    //    i++;
    //}
    //while (dummy2 != null)
    //{
    //    dummy2 = dummy2.next;
    //    j++;
    //    if(i % 2 == 0)
    //    {
    //        if (j == i / 2) return dummy2;
    //    }
    //    else if(i % 2 == 1)
    //    {
    //        if (j == (i / 2) + 1) return dummy2;
    //    }
    //}
    //return dummy2;
}



//3005. Count Elements With Maximum Frequency
int MaxFrequencyElements(int[] nums)
{
    Dictionary<int, int> dict = new();
    foreach (var item in nums)
    {
        if(dict.ContainsKey(item)) dict[item]++;
        else dict[item] = 1;
    }
    var a = dict.Values.Max();
    int result = 0;
    foreach (var item in dict)
    {
        if (item.Value == a) result+=item.Value;
    }
    return result;
}



//791. Custom Sort String
string CustomSortString(string order, string s)
{
    Dictionary<char, int> frequency = new Dictionary<char, int>();

    // Count the frequency of characters in string s
    foreach (char c in s)
    {
        if (frequency.ContainsKey(c))
            frequency[c]++;
        else
            frequency[c] = 1;
    }

    StringBuilder result = new StringBuilder();

    // Append characters in order as per the custom order
    foreach (char c in order)
    {
        if (frequency.ContainsKey(c))
        {
            result.Append(c, frequency[c]);
            frequency.Remove(c);
        }
    }

    // Append remaining characters from s that are not in order
    foreach (var kvp in frequency)
    {
        result.Append(kvp.Key, kvp.Value);
    }

    return result.ToString();
    //Dictionary<char, int> dict2 = new();
    //string result = "";
    //foreach (var item in s.ToCharArray())
    //{
    //    if (dict2.ContainsKey(item)) dict2[item]++;
    //    else dict2[item] = 1;

    //}
    //foreach (var item in order.ToCharArray())
    //{
    //    if (dict2.ContainsKey((char)item))
    //    {
    //        result += item;
    //        dict2[(char)item]--;
    //        if (dict2[(char)item] < 1) dict2.Remove((char)item);
    //        else
    //        {
    //            for (int i = 0; i < dict2[(char)item]; i++)
    //            {
    //                result += item;
    //            }
    //            dict2.Remove((char)item);
    //        }
    //    }
    //}
    //foreach (var item in dict2)
    //{
    //    result += item.Key;
    //}
    //return result;
}
CustomSortString("bcafg", "abcd");