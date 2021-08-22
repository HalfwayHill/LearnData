using Delegate.AdvancedUse;
using Delegate.Custom;
using Delegate.GeneralUse;
using Delegate.InterfaceReplace;
using Delegate.WhatDelegate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        /* 什么是委托
         * 委托(Delegate)是C++函数指针的升级版
         * 一切皆地址
         * 变量(数据)是以某个地址为起点的一段内存中所存储的值
         * 函数(算法)是以某个地址为起点的一段内存中所存储的一组机器语言指令
         * 直接调用与间接调用
         * 直接调用:通过函数名来调用函数，CPU通过函数名直接获得函数所在地址并开始执行 -> 返回
         * 间接调用:通过函数指针来调用函数，CPU通过读取函数指针存储的值获得函数所在地址开始执行 -> 返回
         * Java中没有与委托相对应的功能实体
         * 委托的简单使用
         * Action委托
         * Func委托
         */

        /* 委托的声明(自定义委托)
         * 委托是一种类(class)，类是数据类型 所以委托也是一种数据类型、
         * 它的声明方式与一般类不同，主要是为了照顾可读性和C/C++传统
         * 注意声明委托的位置
         *      避免写错位置 结果声明成嵌套类型
         * 委托与所封装的方法必须"类型兼容"
         *      返回值的数据类型一致
         *      参数列表在个数和数据类型上一致，参数名可不同
         */

        /* 委托的一般使用
         * 实例:把方法当成参数传给另一个方法
         *      正确使用1：模板方法,"借用"指定的外部方法来产生结果
         *          1.相当于"填空题"
         *          2.常位于代码中部
         *          3.委托有返回值
         *      正确使用2:回调(callback)方法，调用指定的外部方法
         *          1.相当于流水线
         *          2.常位于代码末尾
         *          3.委托无返回值
         * 注意:难精通+易使用+功能强大的东西，一旦被滥用则后果非常严重
         *      缺点1:这是一种方法级别的紧耦合，现实工作中要慎之又慎
         *      缺点2:使可读性下降、debug的难度增加
         *      缺点3:把委托回调、异步调用和多线程纠缠在一起，会让代码变得难以阅读和维护
         *      缺点4:委托使用不当有可能造成内存泄露和程序性能下降
         */

        /* 委托的高级使用
         * 多播(Multicast)委托
         * 隐式异步调用
         *      同步和异步的简介
         *          1.中英文的语言差异
         *          2.同步:按顺序执行函数方法
         *          3.异步:在主线程中执行函数犯法，同时开辟线程另外进行实行其他函数方法，这样两个函数方法同时执行
         *      同步调用和异步调用委托
         *          1.每一个运行的程序是一个进程(process)
         *          2.每个进程可以有一个或多个线程(thread)
         *          3.同步调用是在一个线程内
         *          4.异步调用的底层机制是多线程
         *          5.串行 -> 同步 -> 单线程，并行 -> 异步 -> 多线程
         *      隐式多线程 V.S. 显式多线程
         *          1.直接同步调用:使用方法名
         *          2.间接同步调用:使用单播/多播委托的Invoke方法
         *          3.隐式异步调用:使用委托的BeginInvoke方法
         *          4.显式异步调用:使用Thread或Task
         * 应该适时地使用接口(Interface)取代一些对委托地使用
         *      Java完全地使用接口取代了委托地功能，即Java没有与C#中委托相对应地功能实体
         */

        static void Main(string[] args)
        {
            #region 什么是委托？

            /*

            Calculator1 calculator = new Calculator1();

            //使用C#自带的委托类型
            //Action为无参无返回值委托，直接将函数指针指向action
            //还有一种Action<>为有参无返回值的泛型委托
            Action action = new Action(calculator.Report);
            Console.WriteLine("直接调用无参函数calculator.Report():");
            calculator.Report();
            Console.WriteLine("使用Action间接调用无参函数calculator.Report():");
            //可以直接使用action()
            //action?防止为空 Invoke()在应用程序的主线程上执行指定的委托
            action?.Invoke();

            //Func<>为有参有返回值的泛型委托
            Func<int, int, int> funcAdd = new Func<int, int, int>(calculator.Add);
            Func<int, int, int> funcSub = new Func<int, int, int>(calculator.Sub);

            Console.WriteLine($"直接调用有参有返回值函数Add:{calculator.Add(1, 2)}");
            Console.WriteLine($"使用Func<>间接调用有参有返回值函数Add:{funcAdd?.Invoke(1, 2)}");
            Console.WriteLine($"直接调用有参有返回值函数Sub:{calculator.Sub(2, 1)}");
            Console.WriteLine($"使用Func<>间接调用有参有返回值函数Sub:{funcSub?.Invoke(2, 1)}");

            */

            #endregion

            #region 委托的声明

            /*

            //委托实际上是一种类
            //Type t = typeof(Action);
            //Console.WriteLine(t.IsClass);

            Calculate2 calculate2 = new Calculate2();
            Calc calcAdd = new Calc(calculate2.Add);
            Calc calcSub = new Calc(calculate2.Sub);
            Calc calcMul = new Calc(calculate2.Mul);
            Calc calcDiv = new Calc(calculate2.Div);

            Console.WriteLine($"通过自定义委托调用Add:{calcAdd?.Invoke(100, 200)}");
            Console.WriteLine($"通过自定义委托调用Sub:{calcSub?.Invoke(100, 200)}");
            Console.WriteLine($"通过自定义委托调用Mul:{calcMul?.Invoke(100, 200)}");
            Console.WriteLine($"通过自定义委托调用Div:{calcDiv?.Invoke(100, 200)}");
            */

            #endregion

            #region 委托的一般使用

            /*

            //模板函数和回调函数 使用工厂模式

            ProductFactory productFactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();

            Logger logger = new Logger();
            Action<Product> actionLog = new Action<Product>(logger.Log);

            Func<Product> funcPizza = new Func<Product>(productFactory.MakePizza);
            Func<Product> funcToyCar = new Func<Product>(productFactory.MakeToyCar);

            Console.WriteLine($"通过模板方法获取的产品包装中装的是:{wrapFactory.WrapProduct(funcPizza, actionLog).Product.Name}");
            Console.WriteLine($"通过模板方法获取的产品包装中装的是:{wrapFactory.WrapProduct(funcToyCar, actionLog).Product.Name}");

            */
            #endregion

            #region 委托的高级使用

            /*

            

            Student stu1 = new Student(1, ConsoleColor.Yellow);
            Student stu2 = new Student(2, ConsoleColor.Green);
            Student stu3 = new Student(3, ConsoleColor.Red);

            Action action1 = new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);

            #region 同步

            //单播委托
            //action1?.Invoke();
            //action2?.Invoke();
            //action3?.Invoke();

            //多播委托
            //将action2合并进入action1
            //action1 += action2;
            //将action3合并进入action1
            //action1 += action3;

            //action1?.Invoke();

            #endregion

            #region 异步

            //线程锁问题，Task和Thread的区别

            //单播委托
            //BeginInvoke需要两个参数，第一个参数是回调函数，当执行完毕后，是否要有信息返回
            //.Net Core已经不支持隐式的异步调用，只能使用显式异步调用
            //这里异步调用的时候，我们单独设置的控制台前景色失效，有的时候不再能区分出来
            //原因是我们变成异步调用的时候，多个委托函数在争抢控制台前景色的控制权，结果造成冲突，这时候的解决方案是增加线程锁
            Task.Run(() =>
            {
                action1?.Invoke();
            });
            Task.Run(() =>
            {
                action2?.Invoke();
            });
            Task.Run(() =>
            {
                action3?.Invoke();
            });

            #endregion

            */

            #endregion

            #region 使用接口替代一些委托

            /**/

            IProductFactory _PizzaFactory = new PizzaFactory();
            IProductFactory _ToyCarFactory = new ToyCarFactory();
            InterfaceReplace.WrapFactory wrapFactory = new InterfaceReplace.WrapFactory();

            Console.WriteLine($"通过模板方法获取的产品包装中装的是:{wrapFactory.WrapProduct(_PizzaFactory).Product.Name}");
            Console.WriteLine($"通过模板方法获取的产品包装中装的是:{wrapFactory.WrapProduct(_ToyCarFactory).Product.Name}");

            #endregion

            Console.Read();
        }
    }
}
