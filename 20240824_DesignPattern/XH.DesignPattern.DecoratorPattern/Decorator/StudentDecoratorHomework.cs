﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XH.DesignPattern.DecoratorPattern.Decorator
{
    /// <summary>
    /// 装饰器 is a  学生
    /// 组合+继承
    /// </summary>
    public class StudentDecoratorHomework : AbstractDecorator
    {
        public StudentDecoratorHomework(AbstractStudent student) : base(student)
        {
        }
        public override void Study()
        {
            base.Study();
            Console.WriteLine("获取作业巩固。。。");
        }
    }
}
