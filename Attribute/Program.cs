using System;

namespace LearnAttribute
{
    class Program
    {
        /* 特性(Attribute)
         * 特性是被指定给某一声明的一则附加的声明性信息
         * 
         * 特性是可以添加到编程元素（例如程序集，类型，成员和参数）的注释。
         * 它们存储在程序集的元数据中，可以使用反射API在运行时访问。
         * 
         * .Net 框架提供了三种预定义特性：
         * 
         * AttributeUsage
         * 预定义特性 AttributeUsage 描述了如何使用一个自定义特性类。它规定了特性可应用到的项目的类型。
         * 
         * Conditional
         * Obsolete
         * 
         */

        static void Main(string[] args)
        {
            AnyClass.Old();

            AnyUnfinishedClass anyUnfinishedClass = new AnyUnfinishedClass();

            AnyUnfinishedClass.Old();
        }
    }
}
