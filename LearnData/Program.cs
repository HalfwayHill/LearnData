using LearnData.Algorithm;
using LearnData.MyArray;
using LearnData.MyDictionary;
using LearnData.MyLinkedList;
using LearnData.MyQueue;
using LearnData.MySet;
using LearnData.MyStack;
using LearnData.MyTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace LearnData
{
    class Program
    {
        /// <summary>
        /// 比较数组栈和链表栈的性能（使用接口来进行方法扩展）
        /// </summary>
        /// <returns></returns>
        public static long TestStack(IStack<int> stack, int n)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            for (int i = 0; i < n; i++)
                stack.Push(i);
            for (int i = 0; i < n; i++)
                stack.Pop();

            t.Stop();

            return t.ElapsedMilliseconds;
        }

        /// <summary>
        /// 比较数组队列和循环队列性能（使用接口来进行方法扩展）
        /// </summary>
        /// <returns></returns>
        public static long TestQueue(IQueue<int> queue, int n)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            for (int i = 0; i < n; i++)
                queue.Enqueue(i);
            for (int i = 0; i < n; i++)
                queue.Dequeue();

            t.Stop();

            return t.ElapsedMilliseconds;
        }

        /// <summary>
        /// 比较两种集合(根据链表和根据有序数组)的性能
        /// </summary>
        /// <param name="set"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static long TestSet(MySet.ISet<string> set, List<string> words)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            foreach (var word in words)
                set.Add(word);
            t.Stop();
            return t.ElapsedMilliseconds;
        }

        /// <summary>
        /// 比较两种映射(根据链表和根据有序数组)的性能
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static long TestDictionary(MyDictionary.IDictionary<string, int> dic, List<string> words)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            foreach (var word in words)
            {
                //如果单词不存在字典中，说明是第一次遇见这个单词，频次设为1
                if (!dic.Contains(word))
                    dic.Add(word, 1);
                else  //如果单词已经存在在字典中，将单词对应的频次+1
                    dic.Set(word, dic.Find(word) + 1);
            }
            t.Stop();
            return t.ElapsedMilliseconds;
        }
        static void Main(string[] args)
        {

            /*
             * 数组(顺序存储空间，在内存是一块连续的存储空间)
             * 优点：可以通过索引直接访问数据元素
             * 缺点：在初始化时就需要知道元素的数量，不够灵活，扩充困难
             * 解决方案：动态数组 但是还是无法充分利用全部存储空间
             * 链表(链式存储结构，在内存中不是连续的存储空间，而是通过地址)
             * 可以充分利用存储空间
             * 
             * 数组的尾部的操作 时间复杂度都是O(1)
             * 因为数组其余位置的增删改操作需要移动后续位置的数据，查则不用
             * 链表的头部的操作 时间复杂度都是O(1)
             * 因为链表其余位置的增删改查操作需要从头部通过指针移动
             * 这是两者数据结构的性质导致的
             * 
             * 栈(Stack)
             * 后进先出的数据结构 类似手枪弹夹
             * 只能一端进行添加(入栈)或删除(出栈)操作，这一端称为栈顶
             * 1.撤销操作
             * 2.数组反转
             * 3.递归
             * 
             * 队列(Queue)
             * 先进先出的数据结构 类似排队
             * 只允许在队头删除元素(出队),在队尾添加元素(入队)
             * 
             * 集合(Set)
             * 作为存储数据的容器时：
             * 它是不允许存储相同的元素的。只能保留一份。
             * 能快速的帮助我们进行去重操作，过滤掉重复的元素
             * 应用：词汇量的统计 统计一篇文章的总单词数 判断英文文章的阅读难度
             * 
             * 映射
             * 指两个元素之间相互"对应"的关系
             * 在C#中使用字典(Dictionary)表示，存储键值对的数据
             * 一个键对应一个值
             * 
             * 二叉查找树
             * 1.左子树上所有节点的值均小于它的根节点的值
             * 2.右子树上所有节点的值均大于它的根节点的值
             * 3.任意节点的左、右子树也分别为二叉查找树
             * 没有相等的节点
             * 
             * 二分查找算法
             * 只能对有序排列进行高效查找(排序算法的作用)
             */

            #region 动态数组与静态数组的区别

            /*

            //静态数组 无法动态扩展大小
            int[] arr = new int[10];
            //一旦数据超过数组大小，就会报错
            for (int i = 0; i < 10; i++)
            {
                arr[i] = i;
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            //动态数组(ArrayList List) 拥有动态扩容的能力
            ArrayList a = new ArrayList(10);
            for (int i = 0; i < 15; i++)
            {
                a.Add(i);
                Console.Write(a[i] + " ");
            }

            Console.WriteLine();

            List<int> al = new List<int>(10);
            for (int i = 0; i < 20; i++)
            {
                al.Add(i);
                Console.Write(al[i] + " ");
            }

            Console.WriteLine();

            */

            #endregion

            #region 测试Array1

            /*

            Array1 a = new Array1(10);

            for (int i = 0; i < 10; i++)
            {
                a.Add(i);
            }

            Console.WriteLine(a);

            a.AddFirst(66);
            Console.WriteLine(a);

            a.Insert(2,77);
            Console.WriteLine(a);

            //Console.WriteLine(a.Find(8));
            //Console.WriteLine(a.FindFirst());
            //Console.WriteLine(a.FindLast());

            a.Set(0, 11);
            Console.WriteLine(a);

            a.RemoveAt(2);
            a.RemoveFirst();
            a.RemoveLast();
            a.Remove(4);
            Console.WriteLine(a);

            for (int i = 0; i < 6; i++)
            {
                a.RemoveLast();
                Console.WriteLine(a);
            }

            */

            #endregion

            #region 装箱拆箱

            /*
             * 装箱：值类型转换为引用类型
             * 拆箱：引用类型转换为值类型
             * 引用类型
             * 引用类型包括：数组，用户定义的类、接口、委托，object，字符串，null类型，类。
             * 引用类型的变量持有的是数据的引用，数据存储在数据堆，
             * 分配在托管堆中，变量并不会在创建它们的方法结束时释放内存，
             * 它们所占用的内存会被CLR中的垃圾回收机制释放。 

             * 值类型
             * 值类型包括：数值类型，结构体，bool型，用户定义的结构体，枚举，可空类型。
             * 值类型的变量直接存储数据，分配在托管栈中。
             * 变量会在创建它们的方法返回时自动释放，
             * 例如在一个方法中声明Char型的变量name=’C’，
             * 当实例化它的方法结束时，name变量在栈上占用的内存就会自动释放
             * C#的所有值类型均隐式派生自System.ValueType。
             */

            /*

            int n = 10000000;
            //计时器
            Stopwatch t1 = new Stopwatch();
            Stopwatch t2 = new Stopwatch();
            Stopwatch t3 = new Stopwatch();
            Stopwatch t4 = new Stopwatch();

            Console.WriteLine("测试值类型int");
            t1.Start();
            List<int> l = new List<int>();

            for (int i = 0; i < n; i++)
            {
                l.Add(i);//不发生装箱
                int x = l[i];//不发生拆箱
            }

            t1.Stop();
            Console.WriteLine("List'time:" + t1.ElapsedMilliseconds + "ms");

            t2.Start();
            ArrayList k = new ArrayList();

            for (int i = 0; i < n; i++)
            {
                k.Add(i);//发生装箱
                int x = (int)k[i];//发生拆箱
            }

            t2.Stop();
            Console.WriteLine("ArrayList'time:" + t2.ElapsedMilliseconds + "ms");


            Console.WriteLine("测试引用类型string");
            t3.Start();
            List<string> l2 = new List<string>();

            for (int i = 0; i < n; i++)
            {
                l2.Add("x");//不发生装箱
                string x = l2[i];//不发生拆箱
            }

            t3.Stop();
            Console.WriteLine("List'time:" + t3.ElapsedMilliseconds + "ms");

            t4.Start();
            ArrayList k2 = new ArrayList();

            for (int i = 0; i < n; i++)
            {
                k2.Add("x");//不发生装箱 因为string和object为引用类型
                string x = (string)k2[i];//不发生拆箱 因为string和object为引用类型
            }

            t4.Stop();
            Console.WriteLine("ArrayList'time:" + t4.ElapsedMilliseconds + "ms");

            */

            /*
             * 经测试值类型大约运行效率在7倍以上
             * 引用类型大约在1.5倍以上
             */

            /*
             * 泛型数组List有两个有事：
             * 1.对于存储值类型，性能更优
             * 2.使代码清晰和保证类型安全
             */

            #endregion

            #region 测试泛型

            /*

            int[] n = { 1, 2, 1, 1, 3, 4, 7, 8, 88, 854 ,20};

            Array1<int> a1 = new Array1<int>();
            for (int i = 0; i < n.Length; i++)
            {
                a1.Add(n[i]);
            }
            Console.WriteLine(a1);

            string[] s = { "ss", "343", "5swsws", "gfr4", "455", "dd" };
            Array1<string> a2 = new Array1<string>();
            for (int i = 0; i < s.Length; i++)
            {
                a2.Add(s[i]);
            }
            Console.WriteLine(a2);

            */

            #endregion

            #region 测试LinkedList1

            /*
             * 现在实现的是单链表
             * C#中提供了双链表LinkedList
             */

            /*
            LinkedList1<int> linkedList1 = new LinkedList1<int>();

            for (int i = 0; i < 10; i++)
            {
                linkedList1.AddFirst(i);
                Console.WriteLine(linkedList1);
            }

            linkedList1.Add(666);
            Console.WriteLine(linkedList1);

            linkedList1.Insert(3,888);
            Console.WriteLine(linkedList1);

            linkedList1.Set(4, 1000);
            Console.WriteLine(linkedList1);

            linkedList1.RemoveFirst();
            Console.WriteLine(linkedList1);

            linkedList1.RemoveLast();
            Console.WriteLine(linkedList1);

            linkedList1.RemoveAt(6);
            Console.WriteLine(linkedList1);

            linkedList1.Remove(0);
            Console.WriteLine(linkedList1);

            */

            #endregion

            #region 测试数组栈

            /*

            Array1Stack<int> stack = new Array1Stack<int>();

            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
                Console.WriteLine(stack);
            }

            stack.Pop();

            Console.WriteLine(stack);
            */
            #endregion

            #region 测试链表栈

            /*

            LinkedList1Stack<int> stack = new LinkedList1Stack<int>();

            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
                Console.WriteLine(stack);
            }

            stack.Pop();

            Console.WriteLine(stack);

            */

            #endregion

            /*
             * C# 自带的 Stack 也是使用的动态数组实现的
             */

            #region 比较数组栈和链表栈的性能

            /*

            int n = 10000000;

            Array1Stack<int> array1Stack = new Array1Stack<int>();
            long t1 = TestStack(array1Stack, n);
            Console.WriteLine("执行扩容操作数组栈'Time:" + t1 + "ms");

            Array1Stack<int> array2Stack = new Array1Stack<int>(n);
            long t3 = TestStack(array2Stack, n);
            Console.WriteLine("不执行扩容操作数组栈'Time:" + t3 + "ms");

            LinkedList1Stack<int> linkedList1Stack = new LinkedList1Stack<int>();
            long t2 = TestStack(linkedList1Stack, n);
            Console.WriteLine("LinkedList1Stack'Time:" + t2 + "ms");

            Stack<int> stack = new Stack<int>();
            Stopwatch t = new Stopwatch();
            t.Start();
            for (int i = 0; i < n; i++)
                stack.Push(i);
            for (int i = 0; i < n; i++)
                stack.Pop();

            t.Stop();
            Console.WriteLine("C#自带的Stack'Time:" + t.ElapsedMilliseconds + "ms");

            */

            /*
             * 通过测试
             * 数组栈比链表栈快5倍左右
             * 因为链表栈需要new操作，且在存储位置不连续
             * 数组栈扩容操作所占效率并不多
             * 当然不扩容会减少性能占用
             */

            #endregion

            /*
             * 数组队列中入队O(1)出队O(n)
             */

            #region 测试数组队列

            /*

            Array1Queue<int> array1Queue = new Array1Queue<int>();
            for (int i = 0; i < 5; i++)
            {
                array1Queue.Enqueue(i);
                Console.WriteLine(array1Queue);
            }

            array1Queue.Dequeue();
            Console.WriteLine(array1Queue);

            */

            #endregion

            /*
             * 循环队列需要循环动态数组，Array2
             * 循环动态数组的扩容策略在Array2中
             * 
             * 循环队列就是为了将数组队列中的出队操作由O(n)降为O(1)
             * 其中的方式就是在队列中加入两个指针first和last
             * first指向队首
             * last指向队尾
             * 当执行入队时 last指针向后移动 first不变
             * 当执行出队时 整体数据不用前移 而是first后移 实现出队
             * 当数组整体还有空间时 last到了数组最后 再进行添加时 last移向数组的最前面
             */

            #region 测试循环队列

            /*

            Array2Queue<int> array2Queue = new Array2Queue<int>();
            for (int i = 0; i < 5; i++)
            {
                array2Queue.Enqueue(i);
                Console.WriteLine(array2Queue);
            }

            array2Queue.Dequeue();
            Console.WriteLine(array2Queue);

            */

            #endregion

            #region 比较数组队列和循环队列性能

            /*

            int n = 100000;

            Array1Queue<int> array1Queue = new Array1Queue<int>();
            long t1 = TestQueue(array1Queue, n);
            Console.WriteLine("数组队列'Time:" + t1 + "ms");

            Array2Queue<int> array2Queue = new Array2Queue<int>();
            long t2 = TestQueue(array2Queue, n);
            Console.WriteLine("循环队列'Time:" + t2 + "ms");

            Queue<int> queue = new Queue<int>();

            Stopwatch t = new Stopwatch();
            t.Start();
            for (int i = 0; i < n; i++)
                queue.Enqueue(i);
            for (int i = 0; i < n; i++)
                queue.Dequeue();

            t.Stop();

            Console.WriteLine("C#自带的Queue'Time:" + t.ElapsedMilliseconds + "ms");

            */

            /*
             * 通过测试
             * 数组队列10万级的数据在4位数的毫秒数
             * 循环队列10万级的数据在个位数的毫秒数
             * 差距是巨大的，性能的差距就在出队的操作上
             * 数组队列出队的时间复杂度为O(n)
             * 循环队列出队的时间复杂度为O(1)
             * 这也是数据结构进行优化的原因
             */

            #endregion

            #region 比较两种链表队列的性能

            /*

            int n = 100000;

            LinkedList1Queue<int> linkedList1Queue = new LinkedList1Queue<int>();
            long t1 = TestQueue(linkedList1Queue, n);
            Console.WriteLine("LinkedList1Queue'Time:" + t1 + "ms");

            LinkedList2Queue<int> linkedList2Queue = new LinkedList2Queue<int>();
            long t2 = TestQueue(linkedList2Queue, n);
            Console.WriteLine("LinkedList2Queue'Time:" + t2 + "ms");

            */

            #endregion

            #region 测试Set

            /*

            Stopwatch t = new Stopwatch();

            Console.WriteLine("Article");
            List<string> words = TestHelper.ReadFile("./TestFile/Article.txt");

            Console.WriteLine($"总单词数：{words.Count}");

            LinkedList1Set<string> set = new LinkedList1Set<string>();

            t.Start();

            foreach (var word in words)
                set.Add(word);
            t.Stop();

            Console.WriteLine($"不同的单词总数：{set.Count}");
            Console.WriteLine($"运行时间：{t.ElapsedMilliseconds}ms");

            */

            /*
             * 由于每次向集合添加数据时，
             * 我们都要从头到尾判断数据是否重复
             * 这就导致运行效率低下
             * 
             * 这也是为什么不用动态数组的原因
             * 因为在查找重复的操作上，没有区别
             * 
             * 我们要改变链表的查询算法
             * 二分查找
             */

            #endregion

            #region 测试Dictionary

            /*

            Stopwatch t = new Stopwatch();

            Console.WriteLine("Article");
            List<string> words = TestHelper.ReadFile("./TestFile/Article.txt");

            Console.WriteLine($"总单词数：{words.Count}");

            LinkedList3Dictionary<string,int> dictionary = new LinkedList3Dictionary<string,int>();

            t.Start();

            foreach (var word in words)
            {
                if (!dictionary.Contains(word))
                    dictionary.Add(word, 1);
                else
                    dictionary.Set(word, dictionary.Find(word) + 1);
                
            }
                
            t.Stop();

            Console.WriteLine($"不同的单词总数：{dictionary.Count}");
            Console.WriteLine($"bbc词频：{dictionary.Find("bbc")}");
            Console.WriteLine($"运行时间：{t.ElapsedMilliseconds}ms");

            */

            #endregion

            #region 查询算法的性能比较(二分/顺序)

            /*

            //string filename1 = "TestFile/超市会员表.txt";
            //string filename2 = "TestFile/超市客户表.txt";

            //int[] arr1 = Search.ReadFile(filename1);
            //int[] arr2 = Search.ReadFile(filename2);
            //Console.WriteLine("超市会员数量 :" + arr1.Length);
            //Console.WriteLine("调查客户数量 :" + arr2.Length);

            //Console.WriteLine();

            //Stopwatch t1 = new Stopwatch();
            //Stopwatch t2 = new Stopwatch();

            //Console.WriteLine("顺序查找法");
            //t1.Start();
            //int sum1 = 0;   //记录普通客户数量
            //for (int i = 0; i < arr2.Length; i++)
            //{
            //    int target = arr2[i];
            //    if (Search.OrderSearch(arr1, target) == -1)
            //    {
            //        Console.WriteLine(target);
            //        sum1++;
            //    }
            //}
            //t1.Stop();
            //Console.WriteLine("查找到" + sum1 + "个普通客户");
            //Console.WriteLine("运行时间: " + t1.ElapsedMilliseconds + "ms");

            //Console.WriteLine();

            //Console.WriteLine("二分查找法");
            //t2.Start();
            //Array.Sort(arr1); //调用C#自带的排序方法对数组进行排序，才可以使用二分查找法
            //int sum2 = 0;
            //for (int i = 0; i < arr2.Length; i++)
            //{
            //    int target = arr2[i];
            //    if (Search.BinarySearch(arr1, target) == -1)
            //    {
            //        Console.WriteLine(target);
            //        sum2++;
            //    }
            //}
            //t2.Stop();
            //Console.WriteLine("查找到" + sum2 + "个普通客户");
            //Console.WriteLine("运行时间: " + t2.ElapsedMilliseconds + "ms");

            string filename3 = "TestFile/游戏会员表.txt";
            string filename4 = "TestFile/游戏用户表.txt";

            int[] arr3 = Search.ReadFile(filename3);
            int[] arr4 = Search.ReadFile(filename4);
            Console.WriteLine("游戏会员数量 :" + arr3.Length);
            Console.WriteLine("调查用户数量 :" + arr4.Length);

            Console.WriteLine();

            Stopwatch t3 = new Stopwatch();
            Stopwatch t4 = new Stopwatch();

            //Console.WriteLine("顺序查找法");
            //t3.Start();
            //int sum3 = 0;
            //for (int i = 0; i < arr4.Length; i++)
            //{
            //    int target = arr4[i];
            //    if (Search.OrderSearch(arr3, target) == -1)
            //    {
            //        //Console.WriteLine(target);
            //        sum3++;
            //    }
            //}
            //t3.Stop();
            //Console.WriteLine("查找到 :" + sum3 + "个零充玩家");
            //Console.WriteLine("运行时间: " + t3.ElapsedMilliseconds + "ms");

            Console.WriteLine();

            Console.WriteLine("二分查找法");
            t4.Start();
            Array.Sort(arr3);
            int sum4 = 0;
            for (int i = 0; i < arr4.Length; i++)
            {
                int target = arr4[i];
                if (Search.BinarySearch(arr3, target) == -1)
                {
                    //Console.WriteLine(target);
                    sum4++;
                }
            }
            t4.Stop();
            Console.WriteLine("查找到 :" + sum4 + "个零充玩家");
            Console.WriteLine("运行时间: " + t4.ElapsedMilliseconds + "ms");

            */

            #endregion

            #region 测试有序数组

            /*

            //int类型实现了接口IComparable<Int32> 它是一个可比较的数据类型
            int[] arr = { 84, 48, 68, 10, 18, 98, 12, 23, 54, 57, 33, 16, 77, 11, 29 };

            SortedArray1<int> sortedArray1 = new SortedArray1<int>();
            for (int i = 0; i < arr.Length; i++)
                sortedArray1.Add(arr[i]);

            Console.WriteLine(sortedArray1);
            Console.WriteLine(sortedArray1.Min());
            Console.WriteLine(sortedArray1.Max());
            Console.WriteLine(sortedArray1.Select(5));
            Console.WriteLine(sortedArray1.Floor(15));
            Console.WriteLine(sortedArray1.Ceiling(15));
            sortedArray1.Remove(23);
            Console.WriteLine(sortedArray1);

            //使用有序数组存储我们自定义的Student类型
            Student[] students =
            {
                new Student("小明",180),
                new Student("小红",150),
                new Student("小芳",175),
                new Student("小华",160),
                new Student("小李",190),
            };

            SortedArray1<Student> s = new SortedArray1<Student>();

            for (int i = 0; i < students.Length; i++)
                s.Add(students[i]);

            Console.WriteLine(s);

            */

            #endregion

            #region 比较三种集合的集合(根据链表和、根据有序数组和根据二叉树)的性能

            /*

            Console.WriteLine("Article");

            List<string> words = TestHelper.ReadFile("./TestFile/Article.txt");
            Console.WriteLine("词汇量总数：" + words.Count);

            Console.WriteLine();

            Console.WriteLine("链表集合");
            LinkedList1Set<string> linkedList1Set = new LinkedList1Set<string>();
            long t1 = TestSet(linkedList1Set, words);
            Console.WriteLine("不同单词的总数： " + linkedList1Set.Count);
            Console.WriteLine("运行时间： " + t1 + "ms");

            Console.WriteLine();

            Console.WriteLine("有序数组集合");
            SortedArray1Set<string> sortedArray1Set = new SortedArray1Set<string>();
            long t2 = TestSet(sortedArray1Set, words);
            Console.WriteLine("不同单词的总数： " + sortedArray1Set.Count);
            Console.WriteLine("运行时间： " + t2 + "ms");

            //对于（基于有序数组）实现的集合SortedArray1Set
            //它在查找集合中是否包含有指定键非常快速 O（log n）
            //如果要添加的键就在集合中，找到后会直接return结束Add方法。不需要添加。O（log n）
            //如果要添加的键就不在集合中，为了保持集合的有序性：
            //需要在数组中指定的位置添加。发生元素的移动。如果数据规模n越大，需要移动的元素越多。O（n）
            //所以说添加方法太慢了。如果说我们存储的数据是只涉及到查询。在初始化的时候，花点时间排序是值得的。
            //如果我需要不断地对集合进行添加或删除操作。很明显，它是无法处理大型问题的。
            //在下一章中我们会对集合进行改进，使它添加、删除、查询都达到 O（log n）：）

            //补充：C#并没有提供（基于有序数组）实现的有序集合
            //对于C#提供的有序集合（SortedSet） 它是基于红黑树实现的。
            //在课程的后续，讲到红黑树时，我们会实现一个（基于红黑树）的有序集合 :)
            Console.WriteLine("C#中的有序集合");
            SortedSet<string> set = new SortedSet<string>();

            

            Console.WriteLine("(基于二叉查找树实现)集合");
            BST1Set<string> bst1Set = new BST1Set<string>();
            long t1 = TestSet(bst1Set, words);
            Console.WriteLine("不同单词的总数： " + bst1Set.Count);
            Console.WriteLine("运行时间： " + t1 + "ms");
            Console.WriteLine("树的最大高度： " + bst1Set.MaxHeight());

            Console.WriteLine();

            //对于随机性非常强的测试用例，二叉树的性能非常的好，因为树的高度很矮
            //但是对于有序性非常强（顺序或逆序）的用例呢，二叉树的性能就会变得非常的差，显然是不能接受的
            //因为树的高度会非常的高。我们递归的添加呢，有可能会出现栈溢出的情况。
            //这就是我们需要寻找更好的算法和数据结构的原因，我们会在下一章学习：）

            Random r = new Random();
            //r.Next() [0,2147483647)
            Stopwatch t = new Stopwatch();
            t.Start();
            BST1Set<int> set = new BST1Set<int>();
            for (int i = 0; i < 2000000; i++)
                set.Add(r.Next());
            t.Stop();
            Console.WriteLine("运行时间： " + t.ElapsedMilliseconds + "ms");
            Console.WriteLine("树的最大高度： " + set.MaxHeight());

            */

            #endregion

            #region 比较三种映射(根据链表和、根据有序数组和根据二叉树)的性能

            

            Console.WriteLine("Article");

            List<string> words=TestHelper.ReadFile("./TestFile/Article.txt");
            Console.WriteLine("词汇量总数："+words.Count);

            Console.WriteLine();
            /*

            Console.WriteLine("链表字典");
            LinkedList3Dictionary<string,int> dic1 = new LinkedList3Dictionary<string, int>();
            long t1= TestDictionary(dic1, words);
            Console.WriteLine("不同的单词总数： " + dic1.Count);
            Console.WriteLine("bbc出现的频次： " + dic1.Find("bbc"));
            Console.WriteLine("运行时间： " + t1 + "ms");

            Console.WriteLine();

            Console.WriteLine("有序数组字典");
            SortedArray2Dictionary<string, int> dic2 = new SortedArray2Dictionary<string, int>();
            long t2 = TestDictionary(dic2, words);
            Console.WriteLine("不同的单词总数： " + dic2.Count);
            Console.WriteLine("bbc出现的频次： " + dic2.Find("bbc"));
            Console.WriteLine("运行时间： " + t2 + "ms");

            //SortedList的实现原理和SortedArray2是一样的 ：）
            Console.WriteLine("C#中的有序数组");
            SortedList<string, int> dic3 = new SortedList<string, int>();
            List<string> list = new List<string>();

            //对于红黑树，在后续的课程会介绍 ：）
            Console.WriteLine("C#中的红黑树字典");
            SortedDictionary<string, int> dic4 = new SortedDictionary<string, int>();

            */

            Console.WriteLine("（基于二叉查找树实现）字典");
            BST2Dictionary<string, int> dic1 = new BST2Dictionary<string, int>();
            long t1 = TestDictionary(dic1, words);
            Console.WriteLine("不同的单词总数： " + dic1.Count);
            Console.WriteLine("bbc出现的频次： " + dic1.Find("bbc"));
            Console.WriteLine("运行时间： " + t1 + "ms");

            Console.WriteLine();

            #endregion

            #region 测试二叉查询树

            /*

            int[] a = { 8, 4, 12, 2, 6, 10, 14 };

            ///////////////////////
            //         8         //
            //     /       \     //
            //    4        12    //
            //  /   \     /   \  //
            // 2     6   10   14 //
            ///////////////////////

            BST1<int> bst = new BST1<int>();

            for (int i = 0; i < a.Length; i++)
                bst.Add(a[i]);


            //bst.PreOrder();
            //Console.WriteLine();
            //bst.InOrder();
            //Console.WriteLine();
            //bst.PostOrder();
            //Console.WriteLine();
            //bst.LevelOrder();
            //Console.WriteLine();

            bst.InOrder();
            Console.WriteLine();

            //bst.RemoveMin();
            //bst.InOrder();

            //Console.WriteLine();

            //bst.RemoveMax();
            //bst.InOrder();

            //bst.Remove(10);
            //bst.InOrder();

            //Console.WriteLine();

            //bst.Remove(6);
            //bst.InOrder();

            Console.WriteLine(bst.MaxHeight());

            */

            #endregion




            Console.Read();
        }
    }
}
