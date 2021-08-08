using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyLinkedList
{
    /// <summary>
    /// 支持两个泛型参数的单链表
    /// </summary>
    class LinkedList3<Key,Value>
    {
        //内部类防止相关操作
        private class Node
        {
            //当前键
            public Key key;
            //当前数据
            public Value value;
            //下一节点
            public Node next;

            public Node(Key key, Value value, Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }
            public Node(Key key, Value value) : this(key, value, null) { }
            public override string ToString()
            {
                return $"Key:{this.key}-Value:{this.value}";
            }
        }

        //链表的头
        private Node head;
        //当前链表的容量
        private int N;


        public LinkedList3()
        {
            head = null;
            N = 0;
        }

        //存储容量
        public int Count
        {
            get { return N; }
        }
        //数据是否为空
        public bool IsEmpty
        {
            get { return N == 0; }
        }

        /// <summary>
        /// 通过Key值寻找相应节点,用于判断该键是否已经存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private Node FindNode(Key key)
        {
            Node current = this.head;

            while (current != null)
            {
                if (current.key.Equals(key))
                    return current;

                current = current.next;
            }

            return null;
        }


        public void Add(Key key,Value value)
        {
            Node node = FindNode(key);

            if (node == null)
            {
                head = new Node(key, value, head);
                N++;
            }
            else
                node.value = value;
        }

        public bool Contains(Key key)
        {
            return FindNode(key) != null;
        }

        public Value FindValue(Key key)
        {
            Node node = FindNode(key);

            if (node == null)
                throw new ArgumentException($"键{key}不存在");
            else
                return node.value;
        }

        public void Set(Key key,Value value)
        {
            Node node = FindNode(key);

            if (node == null)
                throw new ArgumentException($"键{key}不存在");
            else
                node.value = value;
        }

        public void Remove(Key key)
        {
            if (this.head == null)
            {
                return;
            }

            if (this.head.key.Equals(key))
            {
                this.head = this.head.next;
                N--;
            }
            else
            {
                Node pre = null;
                Node current = this.head;

                while (current != null)
                {
                    if (current.key.Equals(key))
                        break;

                    pre = current;
                    current = current.next;
                }

                if (current != null)
                {
                    pre.next = current.next;
                    N--;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            //res.Append(string.Format($"LinkedList1 Count:{this.Count}\n"));
            res.Append("[");
            Node current = this.head;
            while (current != null)
            {
                res.Append(current.ToString());
                res.Append("->");

                current = current.next;
            }
            res.Append("Null]");

            return res.ToString();
        }
    }
}
