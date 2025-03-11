using Baitap3._3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap4
{
    // B1: Cài đặt BinSearch với hai mốc
    // B2: So sánh số bước lặp của BinSearch, BinSearchRand và BinSearch2Point (TriSearch)
    // B3: So sánh thời gian thực thi (đo 1000 lần)
    // B4: Cài đặt lại BinSearch với đệ quy
    class Program
    {
        static int SeqSearch(int[] Array, int x)
        {
            int i = 0;
            while (i < Array.Length && Array[i] != x)
                i++;
            return i;
        }
        static int BinSearch(int[]Array, int x)
        {
            int left = 0; int right = Array.Length - 1;
            while (left <= right)
            {   
                int mid = left + (right - left) / 2;
                if (Array[mid] == x) return mid;
                if (Array[mid] < x) left = mid + 1;
                else right = mid - 1;                
            }
            return -1;
        }
        static int BinSearchRand(int[] Array, int x)
        {
            int left = 0; int right = Array.Length - 1;
            Random rand = new Random();
            while (left <= right)
            {
                int mid = rand.Next(left, right + 1);
                if (Array[mid] == x) return mid;
                if (Array[mid] < x) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }
        static int TriSearch(int[] Array, int x)
        {
            int left = 0; int right = Array.Length - 1;
            while (left <= right)
            {
                int mid1 = left + (right - left) / 3;
                int mid2 = right - (right - left) / 3;
                if (Array[mid1] == x) return mid1;
                if (Array[mid2] == x) return mid2;
                if (Array[mid1] > x) right = mid1 - 1;
                else if (Array[mid2] < x) left = mid2 + 1;
                else
                {
                    left = mid1 + 1;
                    right = mid2 - 1;   
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] Arr = { 2, 6, 9, 15, 10, 20, 14 };
            int x = 14;
            int[] ArrCopy = (int[])Arr.Clone();
            Array.Sort(ArrCopy);
            int r1 = BinSearch(ArrCopy, x);
            int r2 = BinSearchRand(ArrCopy, x);
            int r3 = TriSearch(ArrCopy, x);
            Console.WriteLine(r1);
            Console.WriteLine(r2);
            Console.WriteLine(r3);

            Timing t = new Timing();
            int ntimes = 10000;
            t.StartTime();
            for (int i = 0; i < ntimes; i++)
                r1 = BinSearch(ArrCopy, x);
            t.StopTime();
            Console.WriteLine("Time for BinSearch: {0}", t.Result().TotalMilliseconds);

            t.StartTime();
            for (int i = 0; i < ntimes; i++)
                r2 = BinSearchRand(ArrCopy, x);
            t.StopTime();
            Console.WriteLine("Time for BinSearchRand: {0}", t.Result().TotalMilliseconds);

            t.StartTime();
            for (int i = 0; i < ntimes; i++)
                r3 = TriSearch(ArrCopy, x);
            t.StopTime();
            Console.WriteLine("Time for BinSearch2Point: {0}", t.Result().TotalMilliseconds);
        }
    }
}
