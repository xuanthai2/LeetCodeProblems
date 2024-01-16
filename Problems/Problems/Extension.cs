using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class Extension
    {
        private static Extension? instance;
        public static Extension GetInstance()
        {
            if(instance == null)
            {
                instance = new Extension();
            }
            return instance;
        }
        public int ReverseInt(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }
        public int[] Sort2DArray(int[,] nums)
        {
            List<int> result = new();
            foreach (int i in nums)
            {
                result.Add(i);
            }
            var returnArray = result.ToArray();
            Array.Sort(returnArray);
            return returnArray;
        }
        public bool CheckOdd(int num)
        {
            if (num % 2 == 1)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }



    //380. Insert Delete GetRandom O(1)
    public class RandomizedSet
    {
        public Dictionary<int, int> dict = new();
        public Random random = new();
        public List<int> list = new();
        public RandomizedSet() {}
        public bool Insert(int val)
        {
            if (dict.ContainsKey(val)) return false;
            else
            {
                list.Add(val);
                dict[val] = list.Count - 1;
                return true;
            }
        }
        public bool Remove(int val)
        {
            if (!dict.ContainsKey(val)) return false;
            else 
            {
                int lastVal = list[list.Count - 1];
                list[list.Count - 1] = val;
                list[dict[val]] = lastVal;
                dict[lastVal] = dict[val];
                dict.Remove(val);
                list.RemoveAt(list.Count - 1);
                return true;
            }
        }
        public int GetRandom()
        {
            return list[random.Next(0, list.Count)];
        }
    }
}
