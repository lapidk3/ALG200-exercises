using System;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ALG200
{
    class Program
    {
        static void Main(string[] args)
        {
            Recursion.Main2(args);
            Sort.GetArrayFromUserInput();
        }

        public static void Swap(int[] toSwap, int i, int j)
        {
            int temp = toSwap[i];
            toSwap[i] = toSwap[j];
            toSwap[j] = temp;
        }
    }
    
    public class Recursion
    {
        public static void Main2(string[] args) {
            Console.WriteLine("Welcome to Fizz-Buzz-Bang! Please enter a number: ");
            int number;
            Boolean isNumber = int.TryParse(Console.ReadLine(),out number);
            
            while(!isNumber) {
                Console.WriteLine("Please enter an integer value! ");
                isNumber = int.TryParse(Console.ReadLine(),out number);
            }

            Recursion.FizzBuzzBang(number);
            Console.WriteLine();
        }

        public static void FizzBuzzBang(int x) {
            if(x == 0) {
                return;
            }

            if(x % 3 == 0 && x % 5 == 0) {
                Console.WriteLine("Bang");
            } else if(x % 3 == 0) {
                Console.WriteLine("Fizz");
            } else if (x % 5 == 0) {
                Console.WriteLine("Buzz");
            } else {
                Console.WriteLine(x);
            }

            Recursion.FizzBuzzBang(x-1);
        }
    }

    public class Sort
    {
        public static void GetArrayFromUserInput()
        {
            Console.WriteLine("Hi! In this section you will input your array contents and we will sort it for you. Please enter the contents of your array.");
            Console.WriteLine("Input should only be integers, and each value should be separated by commas.");
            Console.WriteLine("For example: To produce the array [1,2,3] you would type in: 1,2,3");
            Console.WriteLine();
            string input = Console.ReadLine();
            string[] values = input.Split(',');
            int[] arr = Array.ConvertAll(values, int.Parse);

            Console.WriteLine("Please choose a sorting algorithm: Bubblesort, Insertionsort, Mergesort, or Quicksort");
            input = Console.ReadLine();

            switch(input) {
                case "Bubblesort":
                    Sort.BubbleSort(arr);
                    break;
                case "Insertionsort":
                    Sort.InsertionSort(arr);
                    break;
                case "Mergesort":
                    Sort.MergeSort(arr, 0, arr.Length-1);
                    break;
                case "Quicksort":
                    Sort.QuickSort(arr, 0, arr.Length-1);
                    break;
            }

            Console.WriteLine();

            Console.WriteLine("The array is now sorted. Here are the contents:");
            foreach (var value in arr)
            {
                Console.Write(value.ToString() + " ");
            }

            Console.WriteLine();

        }
        public static void BubbleSort(int[] toSort)
        {
            for(int i = 0; i < toSort.Length - 1; i++) {
                for(int j = 0; j < toSort.Length - i - 1; j++) {
                    if(toSort[j] > toSort[j+1]) {
                        Program.Swap(toSort,j,j+1);
                    }
                }
            }
        }

        public static void InsertionSort(int[] toSort)
        {
            for(int i = 1; i < toSort.Length; i++) {
                int key = toSort[i];
                int j = i - 1;

                while(j >= 0 && toSort[j] >key) {
                    toSort[j+1] = toSort[j];
                    j--;
                }
                toSort[j+1] = key;
            }

        }

        public static void MergeSort(int[] toSort, int left, int right)
        {
            if (left < right) {
                int mid = left + (right - left)/ 2;
                Sort.MergeSort(toSort, left, mid);
                Sort.MergeSort(toSort,mid+1,right);
                Sort.Merge(toSort,left,mid,right);
            }
        }

        public static void Merge(int[] arr, int left, int middle, int right)
        {
            int l_size = middle - left + 1;
            int r_size = right - middle;

            int[] leftArr = new int[l_size];
            int[] rightArr = new int[r_size];

            int i, j;

            for(i = 0; i < l_size; i++) {
                leftArr[i] = arr[left + i];
            }

            for(j = 0; j < r_size; j++) {
                rightArr[j] = arr[middle + 1 + j];
            }

            i = 0;
            j = 0;
            int k = left;

            while(i < l_size && j < r_size) {
                if(leftArr[i] <= rightArr[j]) {
                    arr[k] = leftArr[i];
                    i++;
                } else {
                    arr[k] = rightArr[j];
                    j++;
                }
                k++;
            }

            while(i < l_size) {
                arr[k] = leftArr[i];
                i++;
                k++;
            }

            while(j < r_size) {
                arr[k] = rightArr[j];
                j++;
                k++;
            }
        }

        public static void QuickSort(int[] toSort, int low, int high)
        {
            if(low < high) {
                int index = Sort.Partition(toSort, low, high);

                Sort.QuickSort(toSort, low, index-1);
                Sort.QuickSort(toSort, index + 1, high);
            }
        }

        public static int Partition(int[] toSort, int low, int high)
        {
            int pivot = toSort[high];
            int i = low - 1;

            for(int j = low; j <= high-1; j++) {
                if(toSort[j] < pivot) {
                    i++;
                    Program.Swap(toSort,i,j);
                }
            }
            Program.Swap(toSort, i+1, high);
            return i+1;
        }
    }

    public class LinkedList
    {
        Node head;

        public class Node
        {
            public int data;
            public Node next;

            public Node(int d) 
            {
                data = d;
                next = null;
            }
        }

        public void Reverse()
        {
            Node prev = null;
            Node next = null;
            Node curr = this.head;
            while(curr != null) {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            this.head = prev;

        }

        public void Print()
        {
            if(this.head == null)
            {
                Console.WriteLine("The List is empty");
            }

            Node curr = this.head;
            while(curr != null)
            {
                Console.Write(curr.data + " ");
                curr = curr.next;
            }
        }
    }
}
