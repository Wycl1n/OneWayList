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
        public void Clear()
        {
            this.firstNode = null;
            this.length = 0;
        }
        public void Add(string login, string password)
        {
            Node tnode = new Node(login, Hash(password));
            if (this.length == 0) this.firstNode = this.lastNode = tnode;
            else
            {
                this.lastNode.nextNode = tnode;
                this.lastNode = tnode;
                this.lastNode.nextNode = this.firstNode;
            }

            this.length++;
        }
        public (string,string) Get(int index)
        {
            Node cur = this.firstNode;
            for (int i = 0; i < index - 1; i++)
                cur = cur.nextNode;
            return (cur.login, cur.passwordHash);
        }
        public bool Check(string login, string password)
        {
            Node cur = this.firstNode;
            for(int i=0;i<this.length;i++)
            {
                if(cur.login==login)
                    if (cur.passwordHash == Hash(password))
                        return true;
                cur = cur.nextNode;
            }
            return false;
        }
        private string Hash(string message)
        {
            string resultString = "";
            /*char[] symbols = new char[63];
            symbols[0] = '_';
            byte tI = 1;
            for (int i = 65; i <= 90; i++)
                symbols[tI++] = (char)i;
            for (int i = 48; i <= 57; i++)
                symbols[tI++] = (char)i;
            for (int i = 97; i <= 122; i++)
                symbols[tI++] = (char)i;

            Random rand = new Random();
            string tNumber = "";
            for (int i = 0; i < message.Length; i++)
                tNumber += symbols[rand.Next() % 62];
            for (int i = 0; i < message.Length; i++)
            {
                resultString += (char)((int)message[i] + (int)tNumber[i]);
                resultString += tNumber[message.Length - 1 - i];
            }*/
            for (int i = 0; i < message.Length; i++)
                resultString += (char)((int)message[i] + 1);
            return resultString;
        }
        public void Show()
        {
            Node current = firstNode;
            for (int i=0;i<this.length;i++)
            {
                Console.WriteLine($"{current.login}|{current.passwordHash}");
                current = current.nextNode;
            }
            Console.WriteLine();
        }

        public class Node
        {
            internal string login, passwordHash;
            internal Node nextNode;

            public Node(string log, string pass)
            {
                this.login = log;
                this.passwordHash = pass;
            }
        }
    }
}
