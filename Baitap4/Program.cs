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
            Random rand = new Random();
            int[] ArrO = new int[10];
            int[] Index = new int[10];
            for (int i = 0; i < 10; i++)
            {
                ArrO[i] = rand.Next(1, 100);
                Index[i] = i;
            }
            foreach (int Arr in ArrO)
            {
                Console.Write(Arr + " ");
            }
            Console.WriteLine();
            int x = Convert.ToInt32(Console.ReadLine());
            int[] ArrCopy = (int[])ArrO.Clone();
            Array.Sort(ArrCopy, Index);
            int r1 = BinSearch(ArrCopy, x);
            int r2 = BinSearchRand(ArrCopy, x);
            int r3 = TriSearch(ArrCopy, x);
            if (r1 != -1 && r2 != -1 && r3 != -1) 
            {
                r1 = Index[r1];
                r2 = Index[r2];
                r3 = Index[r3];
            }            
            Console.WriteLine($"{x} nằm ở vị trí {r1}");
            Console.WriteLine($"{x} nằm ở vị trí {r2}");
            Console.WriteLine($"{x} nằm ở vị trí {r3}");

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
