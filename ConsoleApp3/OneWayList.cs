﻿using NPOI.SS.Formula.PTG;
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