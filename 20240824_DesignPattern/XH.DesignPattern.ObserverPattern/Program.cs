using System;
using XH.DesignPattern.ObserverPattern.Observer;
using XH.DesignPattern.ObserverPattern.Subject;

namespace XH.DesignPattern.ObserverPattern
{
    public class Program
    {
        public static void Main()
        {
            {
                //Cat cat = new Cat();
                //cat.Miao();
            }

            //OOP思想   
            {

                //Cat cat = new Cat(); 
                //cat.observerlist.Add(new Baby());
                //cat.observerlist.Add(new Brother());
                //cat.observerlist.Add(new Chicken());
                //cat.observerlist.Add(new Dog());
                //cat.observerlist.Add(new Father());
                //cat.observerlist.Add(new Mother());
                //cat.MiaoObserver(); 
            }

            //通过委托实现
            Console.WriteLine("委托***************************************");
            {
                Cat cat = new Cat();
                cat.ActionHander += new Baby().Action;
                cat.ActionHander += new Brother().Action;
                cat.ActionHander += new Chicken().Action;
                cat.ActionHander += new Dog().Action; 
                cat.ActionHander += new Father().Action;
                cat.ActionHander += new Mother().Action;
                cat.ActionHander += new Cat().MiaoDelegate;
                //cat.ActionHander.Invoke(); //可以直接执行委托

                cat.MiaoDelegate();
            }
            Console.WriteLine("事件***************************************");
            {
                Cat cat = new Cat();
                cat.ActionHanderEvent += new Baby().Action;
                cat.ActionHanderEvent += new Brother().Turn;
                cat.ActionHanderEvent += new Chicken().Woo;
                cat.ActionHanderEvent += new Dog().Wang;
                cat.ActionHanderEvent += new Father().Roar;
                cat.ActionHanderEvent += new Mother().Whisper;
                cat.ActionHanderEvent += new Cat().MiaoDelegate;
                //cat.ActionHanderEvent.Invoke();  //不允许的

                //cat.MiaoEventHander();
            }

            //委托和事件： 本质区别在于权限管控；
            //

        }
    }
}
