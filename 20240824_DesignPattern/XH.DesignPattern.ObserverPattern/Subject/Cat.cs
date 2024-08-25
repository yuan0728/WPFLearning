using XH.DesignPattern.ObserverPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.DesignPattern.ObserverPattern;

namespace XH.DesignPattern.ObserverPattern.Subject
{
    /// <summary>
    /// 一只神奇的猫 
    /// 猫叫一声之后触发 一系列的行为：
    /// 1、小孩儿哭了
    /// 2、兄弟醒了
    /// 3、狗叫了
    /// 4、爸爸生气了~·
    /// 5、邻....
    /// 
    /// 要求：以面向对象的想来模拟当前的这个场景：
    /// 
    /// 
    /// 
    /// baby cry
    /// brother turn
    /// dog wang
    /// father roar
    /// mother whisper
    /// mouse run
    /// neighbor awake
    /// stealer hide
    /// 
    /// </summary>
    public class Cat
    {

        /// <summary>
        /// Miao了一声~~
        /// 代码这样写好吗？--- 出门左拐~~~
        /// 
        /// 1、猫不纯粹(违背了单一职责)---猫就是猫； 猫只能Miao一声
        /// 2、猫依赖太重； 依赖也特别多
        /// 3、猫只应该做自己的事儿
        /// 4、顺序也是固定的； 如果要修改下顺序，也要修改这个猫； 
        /// 猫会变的极其不稳定；
        /// 
        /// 今天的主题：行为型设计模式---甩锅---行为的转移；
        /// 
        /// </summary>
        //public void Miao()
        //{
        //    Console.WriteLine("{0} Miao.....", this.GetType().Name);
        //    new Mouse().Run();//猫和老鼠是啥关系--依赖
        //    new Chicken().Woo();
        //    new Baby().Cry();
        //    new Brother().Turn();
        //    new Dog().Wang();
        //    new Father().Roar();
        //    new Mother().Whisper();
        //    new Neighbor().Awake();
        //    new Stealer().Hide();
        //}


        //观察者模式：
        //下面方式的完成：
        //1. 保证了这个猫就是猫，就是一个纯粹的猫
        //2. 而且是一个稳定的猫； 

        //用到的核心：转移； 甩锅
        //转移：转移的是对象；

        //保存一堆对象---对象中有行为的
        public List<IObserver> observerlist = new List<IObserver>();
        public void MiaoObserver()
        {
            Console.WriteLine("{0} MiaoObserver.....", this.GetType().Name);
            foreach (var observer in observerlist) //具体执行的是什么玩意， 猫不关注；  集合中有什么行为，就执行什么行为；
            {
                observer.Action();
            }
        }

        //从底层本质来说，二者有区别？  没有区别； 
        //OOP： 把一堆的对象保存起来
        //委托：把方法包装到委托中去了------委托的本质：其实是一个类； 
        //通过委托来实现观察者   把行为甩锅给上端
        public Action ActionHander;
        public void MiaoDelegate()
        {
            Console.WriteLine("{0} MiaoDelegate.....", this.GetType().Name);
            ActionHander?.Invoke();
        }

        /// <summary>
        /// 事件---执行的执行，只允许在当前定义时间的这个类里面执行，不允许在外面执行，就是子类都不能执行；
        /// 搭建框架的时候，需要一些权限的管控； WPF 控件  Winform 控件里面；+= 方法的时候，都是事件，而不是委托；
        /// 
        /// </summary>
        public event Action ActionHanderEvent;
        public void MiaoEventHander()
        {
            Console.WriteLine("{0} MiaoEventHander.....", this.GetType().Name);
            ActionHanderEvent?.Invoke();
        }

    }
}



