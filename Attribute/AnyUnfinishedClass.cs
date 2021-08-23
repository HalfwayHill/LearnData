using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnAttribute
{
    [Unfinished("当前类未完成")]
    public class AnyUnfinishedClass
    {
        [Unfinished("当前函数方法未完成")]
        public static void Old()
        {

        }

        //[Unfinished("")] 由于我们的限制 在属性前无效
        public string Info { get; set; }
    }
}
