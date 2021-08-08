using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyTree
{
    /*
     * 二叉查找树
     * 支持有序的相关操作
     * Rank\Select\Floor\Ceiling
     */


    /// <summary>
    /// Binary Search Tree
    /// </summary>
    class BST1<T> where T:IComparable<T>
    {
        private class Node
        {
            //当前数据
            public T t;
            //下一节点
            public Node left;
            public Node right;

            public Node(T t)
            {
                this.t = t;
                this.left = null;
                this.right = null;
            }
            public override string ToString()
            {
                return t.ToString();
            }
        }

        private Node root;
        private int N;

        public BST1()
        {
            root = null;
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

        #region 非递归添加

        //public void Add(T t)
        //{
        //    if (root == null)
        //    {
        //        this.root = new Node(t);
        //        N++;
        //        return;
        //    }

        //    Node pre = null;
        //    Node current = this.root;

        //    while (current != null)
        //    {
        //        if (t.CompareTo(current.t) == 0)
        //            return;

        //        pre = current;

        //        if (t.CompareTo(current.t) < 0)
        //            current = current.left;
        //        else
        //            current = current.right;

        //    }

        //    current = new Node(t);

        //    if (t.CompareTo(pre.t) < 0)
        //        pre.left = current;
        //    else
        //        pre.right = current;

        //    N++;
        //}

        #endregion

        #region 递归添加

        public void Add(T t)
        {
            this.root = Add(root, t);
        }

        /// <summary>
        /// 递归添加node
        /// 以node为根的树中添加e,添加后返回根节点node
        /// 其实就是从下向上添加
        /// </summary>
        /// <param name="node"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private Node Add(Node node,T t)
        {
            if (node == null)
            {
                N++;
                return new Node(t);
            }

            if (t.CompareTo(node.t) < 0)
                node.left = Add(node.left, t);
            else if (t.CompareTo(node.t) > 0)
                node.right = Add(node.right, t);

            return node;

        }

        #endregion

        #region 递归比较

        public bool Contains(T t)
        {
            return Contains(this.root, t);
        }

        private bool Contains(Node node,T t)
        {
            if (node == null)
                return false;

            if (t.CompareTo(node.t) == 0)
                return true;
            else if (t.CompareTo(node.t) < 0)
                return Contains(node.left, t);
            else
                return Contains(node.right, t);
        }

        #endregion

        #region 前序遍历

        //前序遍历：先root，再左子树，再右子树
        //对于每一个节点都遵循根左右进行访问

        /// <summary>
        /// 前序遍历
        /// </summary>
        public void PreOrder()
        {
            PreOrder(this.root);
        }

        private void PreOrder(Node node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.t);
            PreOrder(node.left);
            PreOrder(node.right);
        }

        #endregion

        #region 中序遍历

        //中序遍历：先左子树，再root，再右子树
        //对于每一个节点都遵循左根右进行访问

        /// <summary>
        /// 中序遍历
        /// </summary>
        public void InOrder()
        {
            InOrder(this.root);
        }

        private void InOrder(Node node)
        {
            if (node == null)
                return;


            InOrder(node.left);
            Console.WriteLine(node.t);
            InOrder(node.right);
        }

        #endregion

        #region 后序遍历

        //中序遍历：先左子树，再右子树，再root
        //对于每一个节点都遵循左右根进行访问

        /// <summary>
        /// 后序遍历
        /// </summary>
        public void PostOrder()
        {
            PostOrder(this.root);
        }

        private void PostOrder(Node node)
        {
            if (node == null)
                return;


            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine(node.t);
        }

        #endregion

        #region 层序遍历

        //层序遍历：从树根开始逐层访问
        //实际上使用队列进行操作

        public void LevelOrder()
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                Node current = q.Dequeue();
                Console.WriteLine(current.t);

                if (current.left != null)
                    q.Enqueue(current.left);

                if (current.right != null)
                    q.Enqueue(current.right);

            }

        }



        #endregion

        #region 找到最小值

        public T Min()
        {
            if (IsEmpty)
                throw new ArgumentException("空树");
            return Min(root).t;
        }

        private Node Min(Node node)
        {
            if (node.left == null)
                return node;

            return Min(node.left);
        }

        #endregion

        #region 找到最大值

        public T Max()
        {
            if (IsEmpty)
                throw new ArgumentException("树为空");
            return Max(root).t;
        }

        private Node Max(Node node)
        {
            if (node.left == null)
                return node;

            return Max(node.left);
        }

        #endregion

        #region 删除最小值

        public T RemoveMin()
        {
            T t = Min();
            this.root = RemoveMin(root);
            return t;
        }

        private Node RemoveMin(Node node)
        {
            if (node.left == null)
            {
                N--;
                //此时node节点一定时该树的最小值
                //我们也不用管node.right为多少
                //他一定比是要衔接上node的上一个节点
                return node.right;
            }


            node.left = RemoveMin(node.left);

            return node;
        }

        #endregion

        #region 删除最大值

        public T RemoveMax()
        {
            T t = Max();
            this.root = RemoveMax(root);
            return t;
        }

        private Node RemoveMax(Node node)
        {
            if (node.right == null)
            {
                N--;
                return node.left;
            }


            node.right = RemoveMax(node.right);

            return node;
        }

        #endregion

        #region 删除任意值

        public void Remove(T t)
        {
            this.root = Remove(root, t);
        }

        private Node Remove(Node node,T t)
        {
            if (node== null)
            {
                return null;
            }

            if (t.CompareTo(node.t) < 0)
            {
                node.left = Remove(node.left, t);
                return node;
            }
            else if (t.CompareTo(node.t) > 0)
            {
                node.right = Remove(node.right, t);
                return node;
            }
            else
            {
                if (node.right == null)
                {
                    N--;
                    return node.left;
                }

                if (node.left == null)
                {
                    N--;
                    return node.right;
                }

                // 要删除的节点左右都有孩子
                // 找到比待删除节点大的最小节点, 即待删除节点右子树的最小节点
                // 用这个节点顶替待删除节点的位置

                Node newNode = Min(node.right);
                newNode.right = RemoveMin(node.right);//这里有N--
                newNode.left = node.left;

                return newNode;
            }

        }

        #endregion

        #region 计算二叉树的高度

        public int MaxHeight()
        {
            return MaxHeight(root);
        }

        private int MaxHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            //int l = MaxHeight(node.left);
            //int r = MaxHeight(node.right);

            return Math.Max(MaxHeight(node.left), MaxHeight(node.right)) + 1;

        }

        #endregion
    }
}
