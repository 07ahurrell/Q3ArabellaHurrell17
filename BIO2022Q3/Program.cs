using System;
using System.Collections.Generic;

namespace BIO2022Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] s1 = s.Split(" ");
            string s2 = s1[0];
            int n = s2.Length;
            string alph = "abcdefghijklmnop";
            alph = removeallaftern(alph, n);
            int[] ne = new int[n];
            int j = 0;
            foreach (char i in alph)
            {
                ne[j] = getindexofchar(s2, i);
                j++;
            }
            alph = alph.ToUpper();
            //char[] fin = new char[n];
            //fin[ne[0]] = 'A'; 

            //get all permutations of list
            GetPer(alph.ToCharArray());

            //int i = getindexofchar(s1[0], 'a');
            //int j = getindexofchar(s1[0], 'b');
            //int k = getindexofchar(s1[0], 'c');
            //int l = getindexofchar(s1[0], 'd');
            //if ((int)a % 32 > (int)b % 32)
            //this is the element of which all elements that come before it are smaller and all after are larger than it. in this case it will find an index that is smaller than it
            Console.WriteLine(findElement(ne, n));
            


        }
        
        static string removeallaftern(string s, int n)
        {
            string firstn = s.Remove(n);
            return firstn;
        }


        static int findElement(int[] arr, int n)
        {

            int[] leftMax = new int[n];
            leftMax[0] = int.MinValue;


            for (int i = 1; i < n; i++)
                leftMax[i] = Math.Max(leftMax[i - 1], arr[i - 1]);


            int rightMin = int.MaxValue;


            for (int i = n - 1; i >= 0; i--)
            {

                if (leftMax[i] < arr[i] && rightMin > arr[i])
                    return i;


                rightMin = Math.Min(rightMin, arr[i]);
            }
            return -1;
            }

            private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        public static void GetPer(char[] list)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x);
        }

        private static void GetPer(char[] list, int k, int m)
        {
            if (k == m)
            {
                Console.Write(list);
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }


        public static int getindexofchar(string s, char a)
        {
            
            char[] x = s.ToCharArray();
            int i = Array.IndexOf(x, a);
            return i;

        }
        
    }
}
