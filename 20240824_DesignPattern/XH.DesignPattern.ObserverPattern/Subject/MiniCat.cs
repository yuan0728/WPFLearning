using XH.DesignPattern.ObserverPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.DesignPattern.ObserverPattern.Subject
{

    public class MiniCat : Cat
    {

        public void MiniMiao()
        {
            //base.observerlist.
            ActionHander.Invoke();
            //base.ActionHander += ();

            ActionHanderEvent += () => { };  //在子类允许+-= 给事件赋值；但是不能执行事件
            //base.ActionHanderEvent.Invoke(); 
        }

    }
}



