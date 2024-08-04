using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XH.MvvmLightLesson.Base
{
    public class XiaohaiIoc
    {
        private static XiaohaiIoc _default;
        private static readonly object _instanceLock = new object();
        public static XiaohaiIoc Default
        {
            get
            {
                if (_default == null)
                {
                    lock (_instanceLock)
                    {
                        if (_default == null)
                        {
                            _default = new XiaohaiIoc();
                        }
                    }
                }
                return _default;
            }
        }
        private XiaohaiIoc() { }
        Dictionary<string, Type> _objectDic = new Dictionary<string, Type>();
        Dictionary<string, InstenceModel> _instenceDic = new Dictionary<string, InstenceModel>();

        public void Register<T>()
        {
            _objectDic.Add(typeof(T).FullName!, typeof(T));
        }
        public void RegisterSingle<T>()
        {
            _instenceDic.Add(typeof(T).FullName!,
                new InstenceModel
                {
                    ObjectType = typeof(T)
                });
        }


        // TTo 必须继承或引用 TFrom
        public void Register<TFrom, TTo>() where TTo : TFrom
        {
            _objectDic.Add(typeof(TFrom).FullName!, typeof(TTo));
        }
        public void RegisterSingle<TFrom, TTo>() where TTo : TFrom
        {
            _instenceDic.Add(typeof(TFrom).FullName!, new InstenceModel
            {
                ObjectType = typeof(TTo)
            });
        }

        public T Resolve<T>()
        {
            string key = typeof(T).FullName!;
            if (_objectDic.ContainsKey(key))
            {
                // 创建新的实例 并返回
                return (T)Activator.CreateInstance(_objectDic[key])!;
            }
            else
                return default(T)!;
        }

        public T ResolveSingle<T>()
        {
            string key = typeof(T).FullName!;
            if (_instenceDic.ContainsKey(key))
            {
                if (_instenceDic[key].Instence is null)
                {
                    // 获取所有的构造函数
                    ConstructorInfo[] cis = _instenceDic[key].ObjectType.GetConstructors();
                    // 获取所有的参数
                    ParameterInfo[] pis = cis[0].GetParameters();
                    // 创建args 参数列表
                    List<object> objects = new List<object>();
                    foreach (ParameterInfo pi in pis)
                    {
                        string paramTypeKey = pi.ParameterType.FullName!;
                        if (_instenceDic.ContainsKey(paramTypeKey!))
                        {
                            if (_instenceDic[paramTypeKey].Instence is null)
                                _instenceDic[paramTypeKey].Instence = Activator.CreateInstance(_instenceDic[paramTypeKey].ObjectType)!;
                            objects.Add(_instenceDic[paramTypeKey].Instence);
                        }
                        else
                            objects.Add(null!);
                    }
                    // 实例化对象
                    var obj = Activator.CreateInstance(_instenceDic[key].ObjectType, objects.ToArray());
                    _instenceDic[key].Instence = obj!;
                }
                return (T)_instenceDic[key].Instence;
            }
            else
                return default(T)!;
        }

        // 1、对象中的参数未注入
        // 2、多个实现的使用
        // 3、属性注入
        // 4、瞬时注入/单例模式
    }

    class InstenceModel
    {
        public Type ObjectType { get; set; }
        public object Instence { get; set; }
    }
}
