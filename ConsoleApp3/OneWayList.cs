using NPOI.SS.Formula.PTG;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class OneWayList
    {
        public int length = 0;
        public Node firstNode;
        Node lastNode;
        public void Remove(int index)
        {
            if(index==0)
            {
                lastNode.nextNode = firstNode.nextNode;
                firstNode = firstNode.nextNode;
                length--;
            }else if(index==this.length - 1)
            {
                Node current = firstNode;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.nextNode;
                }
                current.nextNode = firstNode;
                lastNode = current;
                length--;
            }
            else if (length > 1)
            {
                Node current = firstNode;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.nextNode;
                }
                current.nextNode = current.nextNode.nextNode;
                length--;
            }
            else
            {
                firstNode = lastNode = null;
            }
        }
        public void Add(int data)
        {
            Node tnode = new Node(data);
            if (this.length == 0) this.firstNode = this.lastNode = tnode;
            else
            {
                this.lastNode.nextNode = tnode;
                this.lastNode = tnode;
                this.lastNode.nextNode = this.firstNode;
            }

            this.length++;
        }
        public void Show()
        {
            Node current = firstNode;
            for (int i=0;i<this.length;i++)
            {
                Console.Write(current.data + "| ");
                current = current.nextNode;
            }
            Console.WriteLine();
        }
        public int Get(int index)
        {
            Node current = firstNode;
            for (int i = 0; i < index; i++) 
            {
                current = current.nextNode;
            }
            return current.data;
        }

        public int[] ToArray()
        {
            Node cur = this.firstNode;
            int[] arr = new int[this.length];
            for (int i = 0; i < this.length; i++)
            {
                arr[i] = cur.data;
                cur = cur.nextNode;
            }
            return arr;
        }
        public OneWayList ToList(int[] arr)
        {
            OneWayList list = new OneWayList();
            for (int i = 0; i < arr.Length; i++)
                list.Add(arr[i]);
            return list;
        }
        public void Sort()
        {
            int[] arr = this.ToArray();
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr.Length - 1 - i; j++)
                    if (arr[j] > arr[j + 1]) 
                    {
                        int t = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = t;
                    }
        }
        // Some sorts will be here
        public OneWayList SortCounting()
        {
            int[] arr = this.ToArray();
            if (arr.Length <= 1) return this;
            int max, min;
            max = min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                if (arr[i] < min)
                    min = arr[i];
            }
            if (min >= 0)
            {
                int[] t = new int[max + 1];
                for (int i = 0; i < arr.Length; i++)
                    t[arr[i]]++;
                for (int i = 0, j = 0; i <= max; i++)
                    for (int z = 0; z < t[i]; z++)
                        arr[j++] = i;
                return this.ToList(arr);
            }
            else
            {
                return this;
            }
        }
        //
        public class Node
        {
            internal int data;
            internal Node nextNode;//pointer

            public Node(int data)
            {
                this.data = data;
            }
        }
    }
}
