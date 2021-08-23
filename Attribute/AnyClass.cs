using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnAttribute
{
    class AnyClass
    {
        //Obsolete特性 第一个参数是显示的过时信息，指示应该使用哪个方法 第二个参数是编译器是否报错
        [Obsolete("Don't use Old method, use New method", false)]
        public static void Old() { }

        public static void New() { }

    }
}
