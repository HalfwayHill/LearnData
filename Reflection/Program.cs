using Microsoft.Extensions.DependencyInjection;
using Reflection.ReflectionPrinciple;
using System;
using System.Reflection;

namespace Reflection
{
    /* 反射不是C#的特性，是.Net独有的
     * 依赖注入、单元测试和泛型编程都是从反射基础上发展而来
     * 程序不是在编译的时候产生的需求，而是在用户使用时，动态的需求，这就是反射所要解决的
     */

    /* 反射的原理
     * 反射是动态地从内存中拿到对象地描述，再利用它的描述创建对象 
     * 这些是会对程序地性能产生影响地，所以不要频繁地 过多地使用，这样反而是程序性能更差
     * 与反射密切相关的就是依赖注入
     * 
     */

    class Program
    {
        static void Main(string[] args)
        {
            #region 反射原理

            ITank tank = new HeavyTank();
            //----------分割线----------//

            /* 使用反射实例化对象(原理使用)
            //1.获取对象在内存中地对象描述信息
            Type t = tank.GetType();
            //2.创建一个Object对象
            object o = Activator.CreateInstance(t);
            //3.利用描述信息通过反射调用对象函数方法成员
            MethodInfo shotMi = t.GetMethod("Shot");
            MethodInfo runMi = t.GetMethod("Run");
            //4.通过对象o调用函数方法
            shotMi.Invoke(o, null);
            runMi.Invoke(o, null);

            */

            /*使用封装好的方法 利用反射实例化对象*/
            //其中最重要地一个功能就是依赖注入(Dependency Injection)
            //依赖反转(DIP)是一种概念，而依赖注入(DI)是以此来实现地一种应用
            //1.建立ServiceCollection容器
            var sc = new ServiceCollection();
            //2.添加类型
            sc.AddScoped(typeof(ITank), typeof(HeavyTank));
            sc.AddScoped(typeof(IVehicle), typeof(Car));
            sc.AddScoped<Driver>();
            var sp = sc.BuildServiceProvider();
            //以上就是一次性地注册
            //----------分割线----------//
            ITank tank1 = sp.GetService<ITank>();
            tank1.Shot();
            tank1.Run();

            var driver = sp.GetService<Driver>();
            driver.Drive();

            #endregion

            Console.Read();
        }
    }
}
