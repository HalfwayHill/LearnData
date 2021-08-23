using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnAttribute
{

    /* AttributeUsage 定义或控制特性的使用
     * 
     * AttributeUsage类是另外一个预定义特性类，它帮助我们控制我们自己的定制特性的使用。它描述了一个定制特性如和被使用。 
     * AttributeUsage有三个属性，我们可以把它放置在定制属性前面。第一个属性是： 
     * 
     * ValidOn 
     * 通过这个属性，我们能够定义定制特性应该在何种程序实体前放置。一个属性可以被放置的所有程序实体在AttributeTargets enumerator中列出。
     * 通过OR操作我们可以把若干个AttributeTargets值组合起来。
     * 可以使用AttributeTargets.All来允许Help特性被放置在任何程序实体前
     * 
     * AllowMultiple 
     * 这个属性标记了我们的定制特性能否被重复放置在同一个程序实体前多次。
     * 
     * Inherited 
     * 我们可以使用这个属性来控制定制特性的继承规则。它标记了我们的特性能否被继承。
     */

    /* sealed 修饰符
     * 应用于某个类时，sealed 修饰符可阻止其他类继承自该类。
     * 
     * 还可以对替代基类中的虚方法或属性的方法或属性使用 sealed 修饰符。 
     * 这使你可以允许类派生自你的类并防止它们替代特定虚方法或属性。
     * 
     * 若要确定是否密封类、方法或属性，通常应考虑以下两点：
     * 1.派生类通过可以自定义类而可能获得的潜在好处。
     * 2.派生类可能采用使它们无法再正常工作或按预期工作的方式来修改类的可能性。
     */

    /// <summary>
    /// 未完成特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class UnfinishedAttribute : Attribute
    {
        public UnfinishedAttribute(String Description_in)
        {
            this.description = Description_in;
        }
        //使用protected关键字
        protected String description;
        //特性显示的描述信息
        public String Description
        {
            get
            {
                return this.description;
            }
        }
    }
}
