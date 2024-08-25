using System;
using System.Collections.Generic;
using System.Text;

namespace XH.DesignPattern.DecoratorPattern.Decorator
{
    /// <summary>
    /// 装饰器 is a  学生---装饰学生
    /// 组合+继承
    /// abstract是为了避免外部直接实例化
    /// </summary>
    public abstract class AbstractDecorator : AbstractStudent// 装饰后还是一个学生
    {
        private AbstractStudent _Student = null;
        public AbstractDecorator(AbstractStudent student) : base()
        {
            _Student = student;
        }
        public override void Study()
        {
            //Console.WriteLine("***********************");
            _Student.Study();
            //Console.WriteLine("***********************");
        }
    }
    // 一方面继承了学生，装饰后还是一个学生
    // 另一方面，组合了一个学生在内部，业务功能来自于这个内置的学生
    // 就可以在前后分别加点东西，变成了一个新的学生(还是一个学生)
}
