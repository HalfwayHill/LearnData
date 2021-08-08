using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyLinkedList
{
    /// <summary>
    /// 单链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedList1<T>
    {
        //内部类防止相关操作
        private class Node
        {
            //当前数据
            public T t;
            //下一节点
            public Node next;

            public Node(T t,Node next)
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
        //当前链表的容量
        private int N;

        public LinkedList1()
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
        /// 链表插入
        /// </summary>
        /// <param name="index"></param>
        /// <param name="t"></param>
        public void Insert(int index, T t)
        {
            if (index < 0 || index > N)
                throw new ArgumentException("非法索引");

            if (index == 0)
            {
                //Node node = new Node(t);
                //node.next = this.head;
                //this.head = node;

                head = new Node(t, this.head);
            }
            else
            {
                Node pre = this.head;

                for (int i = 0; i < index - 1; i++)
                {
                    pre = pre.next;
                }

                //Node node = new Node(t);
                //node.next = pre.next;
                //pre.next = node;

                pre.next = new Node(t, pre.next);
            }

            N++;
        }

        /// <summary>
        /// 添加数据至链表(末尾)
        /// </summary>
        /// <param name="t"></param>
        public void Add(T t)
        {
            this.Insert(N, t);
        }

        /// <summary>
        /// 添加数据至链表头部
        /// </summary>
        /// <param name="t"></param>
        public void AddFirst(T t)
        {
            this.Insert(0, t);
        }

        /*
         * 通过查询数据可以发现链表的缺点
         * 相比数组查询的速度
         * 链表查询需要通过节点一步步查询，查询效率会低
         */

        /// <summary>
        /// 通过索引下标查找链表数据
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Find(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("非法索引");

            Node current = this.head;
            for (int i = 0; i < index; i++)
                current = current.next;

            return current.t;
        }

        public T FindFirst()
        {
            return this.head.t;
        }

        public T FindLast()
        {
            return Find(N - 1);
        }

        public void Set(int index,T newT)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("非法索引");

            Node current = this.head;
            for (int i = 0; i < index; i++)
                current = current.next;

            current.t = newT;
        }

        public bool Contains(T t)
        {
            Node current = this.head;
            while (current != null)
            {
                if (current.t.Equals(t))
                    return true;

                current = current.next;
            }

            return false;
        }

        /// <summary>
        /// 根据索引下标删除链表数据
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("非法索引");

            if (index == 0)
            {
                Node delNode = head;
                head = head.next;
                N--;
                return delNode.t;
            }
            else
            {
                Node pre = this.head;
                for (int i = 0; i < index - 1; i++)
                {
                    pre = pre.next;
                }

                T del = pre.next.t;

                pre.next = pre.next.next;
                N--;
                return del;
            }
        }

        public T RemoveFirst()
        {
            return RemoveAt(0);
        }

        public T RemoveLast()
        {
            return RemoveAt(N - 1);
        }

        public void Remove(T t)
        {
            if (this.head == null)
            {
                return;
            }

            if (this.head.t.Equals(t))
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
                    if (current.t.Equals(t))
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
                res.Append(current.t);
                res.Append("->");

                current = current.next;
            }
            res.Append("Null]");

            return res.ToString();
        }
    }
}
