using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyTree
{
    class BST2<Key,Value> where Key : IComparable<Key>
    {
        private class Node
        {
            //当前数据
            public Key key;
            public Value value;
            //下一节点
            public Node left;
            public Node right;

            public Node(Key key, Value value)
            {
                this.key = key;
                this.value = value;
                this.left = null;
                this.right = null;
            }
            public override string ToString()
            {
                return $"Key:{this.key}-Value:{this.value}";
            }
        }

        private Node root;
        private int N;

        public BST2()
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

        #region 递归添加

        public void Add(Key key, Value value)
        {
            this.root = Add(root, key, value);
        }

        /// <summary>
        /// 递归添加node
        /// 以node为根的树中添加e,添加后返回根节点node
        /// 其实就是从下向上添加
        /// </summary>
        /// <param name="node"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private Node Add(Node node, Key key, Value value)
        {
            if (node == null)
            {
                N++;
                return new Node(key, value);
            }

            if (key.CompareTo(node.key) < 0)
                node.left = Add(node.left, key, value);
            else if (key.CompareTo(node.key) > 0)
                node.right = Add(node.right, key, value);
            else
                node.value = value;

            return node;

        }

        #endregion

        #region 递归比较

        public bool Contains(Key key)
        {
            return FindNode(root, key) != null;
        }

        private bool Contains(Node node, Key key)
        {
            if (node == null)
                return false;

            if (key.CompareTo(node.key) == 0)
                return true;
            else if (key.CompareTo(node.key) < 0)
                return Contains(node.left, key);
            else
                return Contains(node.right, key);
        }

        #endregion

        #region 找到最小值

        public Value Min()
        {
            if (IsEmpty)
                throw new ArgumentException("空树");
            return Min(root).value;
        }

        private Node Min(Node node)
        {
            if (node.left == null)
                return node;

            return Min(node.left);
        }

        #endregion

        #region 删除最小值

        public Value RemoveMin()
        {
            Value t = Min();
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

        #region 删除任意值

        public void Remove(Key key)
        {
            this.root = Remove(root, key);
        }

        private Node Remove(Node node, Key key)
        {
            if (node == null)
            {
                return null;
            }

            if (key.CompareTo(node.key) < 0)
            {
                node.left = Remove(node.left, key);
                return node;
            }
            else if (key.CompareTo(node.key) > 0)
            {
                node.right = Remove(node.right, key);
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

        private Node FindNode(Node node,Key key)
        {
            if (node == null)
                return null;

            if (key.Equals(node.key))
                return node;
            else if (key.CompareTo(node.key) < 0)
                return FindNode(node.left, key);
            else
                return FindNode(node.right, key);
        }

        public Value FindValue(Key key)
        {
            Node node = FindNode(root, key);

            if (node == null)
                throw new ArgumentException($"键{key}不存在");
            else
                return node.value;
        }

        public void SetValue(Key key, Value newValue)
        {
            Node node = FindNode(root, key);

            if (node == null)
                throw new ArgumentException($"键{key}不存在");
            else
                node.value = newValue;
        }



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
