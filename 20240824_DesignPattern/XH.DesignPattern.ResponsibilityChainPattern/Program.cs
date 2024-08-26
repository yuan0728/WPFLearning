using System;
using XH.DesignPattern.ResponsibilityChainPattern.Builder;
using XH.DesignPattern.ResponsibilityChainPattern.Factory;

namespace XH.DesignPattern.ResponsibilityChainPattern
{
    /// <summary>
    /// 行为型设计模式的巅峰之作！
    /// 无止境的行为封装转移
    /// 
    /// 学习设计模式，不在于业务的难度，而在于设计的理解
    /// 经常是兜里两块钱，心中五百万--见微知著，窥一斑而知全豹
    /// 
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            ApplyContext context = new ApplyContext()
            {
                Id = 506,
                Name = "绿页",
                Hour = 30,
                Description = "我想参加北京的2023开发者大会",
                AuditResult = false,
                AuditRemark = ""
            };
            {
                ////思维很清晰，一看就懂---这个暴露了业务细节，面向过程编程
                //Console.WriteLine("找项目经理审批");
                //if (context.Hour <= 8)
                //{
                //    Console.WriteLine("PM审批通过");
                //}
                //Console.WriteLine("找主管审批");
                //if (context.Hour <= 16)
                //{
                //    Console.WriteLine("主管审批通过");
                //}
                //else
                //{
                //    //..... 继续往后去找人审批
                //    Console.WriteLine("************************************");
                //}
            }
            //一看就是菜鸟写的代码：业务逻辑完全暴露在上端，完全没有任何的封装，完全乜有任何的对象，这是面向过程编程； 
            //编程思想的升级~~  POP--OOP

            //二、OOP： 
            //1. 确定对象---PM   Charge
            //2. 重复代码--父类继承    多个类都必须有某一个行为动作，但是具体执行的动作不一样？

            //继承----去掉了重复代码
            //封装业务逻辑，每一个对象都有各自的业务逻辑
            //还有多态：执行同一个类型的同一个方法，但是执行的业务逻辑不一样~~

            {
                //AbstractAuditor pM = new PM()
                //{
                //    Id = 123,
                //    Name = "其乐无穷"
                //};
                //pM.Audit(context);
                //if (context.AuditResult == false)
                //{
                //    AbstractAuditor charge = new Charge()   //请假者自己去找主管审批
                //    {
                //        Id = 234,
                //        Name = "诺"
                //    };
                //    charge.Audit(context);
                //}
            }

            //三、你们觉得以上代码写的咋样？这其实还是菜鸟写的代码，仅仅只是包含了面向对象的编程思想，其实写出的代码不能使用； 因为不符合实际的业务逻辑 
            //实际的业务逻辑： 请假者提交请假条给Pm，如果Pm审批不通过，应该自动转交给主管审批；

            //审批逻辑的自动转交：


            {
                //AbstractAuditor pM = new PM()
                //{
                //    Id = 123,
                //    Name = "其乐无穷"
                //};
                //pM.Audit(context);
            }


            //四、现在这个代码写的咋样？  1. 具备OOP  2.也符合实际的业务逻辑    中高级开发写的代码；
            //为啥不是高级核心开发呢？？？？   这哥们缺乏前瞻性~~  这哥们儿的眼光只看到了现在； 要考虑到未来可能发生什么变化？？？

            //如果将来公司的组织架构发生了改变了；  不要这个主管的职位了；  但是代码中Pm审批之后，必须要主管审批的；
            //必须的修改代码；   修改历史代码----设计模式原则： 开闭原则---面向修改关闭，面向高扩展开放；


            //升级：问题：在代码中把某一个角色直接写死了；   不能写死； 写死了，万一发生改变，写这个代码的人就要背锅；
            //避免让自己背锅~~    在职场也确实需要有这种警惕性~~
            //适当的甩锅给别人~~ 
            {
                //AbstractAuditor pM = new PM()
                //{
                //    Id = 123,
                //    Name = "其乐无穷"
                //};
                //AbstractAuditor charge = new Charge()   //请假者自己去找主管审批
                //{
                //    Id = 234,
                //    Name = "诺"
                //};
                //AbstractAuditor manager = new Manager()
                //{
                //    Id = 345,
                //    Name = "麦子熟了"
                //};
                //pM.SetNextAuditor(charge);
                //charge.SetNextAuditor(manager);

                // 设置完下一层的时候 执行下审批
                //pM.Audit(context);


                //组织架构改变了： 已经确定好的对象代码 完全不用修改；
                //1. OOP   2. 符合实际的业务逻辑   3.考虑到将来的变化；   高级核心开发~~
                //架构师呢？ 

                //需要让上端也能够灵活的变化---上端---创建对象的事儿； 这个 需要创建型设计模式来解决这个问题；
                //建造者模式；可以来解决问题； 
                //今天核心： 行为的转移，就是甩锅大法；  今天 Richard也甩锅给下次课了~·

                //单个的或者是某几个设计模式，并不是万能的，而且在使用设计模式的时候，在解决及了一些问题之后，其实是有可能会引发新的问题的；  所以可能需要另外的设计模式来进一步解决； 
                //一般都是多个设计模式综合使用； 
                //带流程的---责任链
                //发工资：  20000----扣税----扣除公积金社保-----迟到的----扣工资（请假）------15000；
                //请假： 流程审批~~

                //套路： 要转移，把行为转移----甩锅给别人；    甩锅大法；


                //组装的这个过程，是要创建一个执行的流程； 执行流程，可以定义成一个复杂对象；
                //建造者来完成；

                // 如果组织架构发生变化；
                // 审批历程发生改变；  可以直接换掉建造者；
                //IBuilder builder = new AuditorWorkFlowsBuild();
                IBuilder builder = SimpBuidlerFactory.CreateBuilderInstance(); // new AuditorWorkFlowsNewBuild();
                AbstractAuditor pm = builder.Build();


                //继续来一个新的设计模式：  工厂模式；
                //结果： 如果组织架构发生改变；  只需要实现新的建造者，然后修改配置文件即可，根本就不用去修改历史代码；    这才是设计模式的正确使用方式；


                pm.Audit(context);
            }
        }
    }
}
