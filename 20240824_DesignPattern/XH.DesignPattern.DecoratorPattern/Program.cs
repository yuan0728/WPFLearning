using System;
using XH.DesignPattern.DecoratorPattern.Decorator;

namespace XH.DesignPattern.DecoratorPattern
{
    /// <summary>
    /// 结构型设计模式-装饰器
    /// 
    /// 默认是直播学习
    /// 
    /// 可以扩展        预习--Real-视频--作业-答疑
    /// 可以控制顺序    预习--Real--作业-答疑-视频
    /// 不能修改代码
    /// 
    /// 包一层的性能问题;
    /// C#任意类型都是继承自object
    /// 任意实例化子类，其实都要先实例化父类，每一个父类
    /// </summary>
    public class Program
    {
        public static void Main()
        {

            //设计原则：建议；

            //装饰器番外篇；
            //俄罗斯套娃式~~  委托的多层嵌套式~~

            //女孩子化妆~

            {
                AbstractStudent student = new StudentVip()
                {
                    Id = 123,
                    Name = "小海"
                };

                // 装饰的顺序不一样 执行也不一样
                student = new StudentDecoratorVideo(student);
                student = new StudentDecoratorAnswer(student);
                student = new StudentDecoratorHomework(student);

                student.Study();

                //可以任意扩展功能   顺序也可以随意调整      --假如我需要预习呢？ 发生在直播之前的


                //AbstractDecorator student1 = new AbstractDecorator(student);//基类
                //AbstractStudent student2= new AbstractDecorator(student);//基类

                //StudentDecoratorVideo student3 = new StudentDecoratorVideo(student2);
                //AbstractDecorator student4 = new StudentDecoratorVideo(student2);
                //AbstractStudent student5 = new StudentDecoratorVideo(student);
                //object student6 = new StudentDecoratorVideo(student2);

                //student = new StudentDecoratorVideo(student);//引用指向新的对象
            }
            //{
            //    object a = new object();
            //    //object b = new object();
            //    a = new object();
            //}



            //{
            //    AbstractStudent student = new StudentFree()
            //    {
            //        Id = 123,
            //        Name = "明日梦"
            //    };
            //    StudentCombination student1 = new StudentCombination(student);
            //    student1.Study();
            //}
            //{
            //    AbstractStudent student = new StudentVip()
            //    {
            //        Id = 234,
            //        Name = "到下个路口"
            //    };
            //    StudentCombination student1 = new StudentCombination(student);
            //    student1.Study();
            //}
            //{
            //    //继承复杂度低一些，少个类
            //    AbstractStudent student = new StudentVipVideo()
            //    {
            //        Id = 345,
            //        Name = "jerry"
            //    };
            //    student.Study();
            //}
        }
    }
}
