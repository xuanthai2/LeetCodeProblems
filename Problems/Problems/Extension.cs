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
            Array.Sort(result.ToArray());
            return result.ToArray();
        }

    }
}
