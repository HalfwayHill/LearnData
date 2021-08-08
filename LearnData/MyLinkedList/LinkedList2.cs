using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyLinkedList
{
    /// <summary>
    /// 具有尾部指针的单链表（有特殊用处，如果单纯使用链表，只用单链表即可，不会有特别优势）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedList2<T>
    {
        //内部类防止相关操作
        private class Node
        {
            //当前数据
            public T t;
            //下一节点
            public Node next;

            public Node(T t, Node next)
            {
                this.t = t;
                this.next = next;
            }
            public Node(T t)
            {
                this.t = t;
                this.next = null;
            }
            public override string ToString()
            {
                return t.ToString();
            }
        }

        //链表的头
        private Node head;
        //链表的头
        private Node tail;
        //当前链表的容量
        private int N;

        public LinkedList2()
        {
            head = null;
            tail = null;
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
        /// 添加数据至链表(末尾)
        /// </summary>
        /// <param name="t"></param>
        public void Add(T t)
        {
            Node node = new Node(t);

            if (this.IsEmpty)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                tail.next = node;
                tail = node;
            }
            N++;
        }


        public T FindFirst()
        {
            if (this.IsEmpty)
                throw new InvalidOperationException("链表为空");

            return this.head.t;
        }


        public T RemoveFirst()
        {
            if (this.IsEmpty)
                throw new InvalidOperationException("链表为空");

            T del = this.head.t;
            this.head = this.head.next;

            N--;

            if (this.head == null)
                this.tail = null;

            return del;
        }
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            //res.Append(string.Format($"LinkedList1 Count:{this.Count}\n"));
            res.Append("[");
            Node current = this.head;
            while (current != null)
            {
                res.Append(current.t);
                res.Append("->");

                current = current.next;
            }
            res.Append("Null]");

            return res.ToString();
        }
    }
}
