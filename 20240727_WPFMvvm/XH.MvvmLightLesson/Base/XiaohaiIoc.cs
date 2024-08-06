using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XH.MvvmLightLesson.Base
{
    // 自定义IOC
    public class XiaohaiIoc
    {
        private static XiaohaiIoc _default;
        private static readonly object _instanceLock = new object();
        // 初始化
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
        //Dictionary<string, Type> _objectDic = new Dictionary<string, Type>();
        Dictionary<string, InstenceModel> _instenceDic = new Dictionary<string, InstenceModel>();

        #region 单个类型的注册

        // 瞬时状态 
        public void Register<T>()
        {
            //_objectDic.Add(typeof(T).FullName!, typeof(T));
            _instenceDic.Add(typeof(T).FullName!,
                new InstenceModel
                {
                    ObjectType = typeof(T),
                    IsSinglton = false,
                });
        }
        // 单例模式
        public void RegisterSingle<T>()
        {
            _instenceDic.Add(typeof(T).FullName!,
                new InstenceModel
                {
                    ObjectType = typeof(T),
                    IsSinglton = true,
                });
        }

        #endregion

        #region 带接口的注册

        // TTo 必须继承或引用 TFrom
        public void Register<TFrom, TTo>(String token = "") where TTo : TFrom
        {
            GetRegister<TFrom, TTo>(false, token);
        }
        public void RegisterSingle<TFrom, TTo>(String token = "") where TTo : TFrom
        {
            GetRegister<TFrom, TTo>(true, token);
        }

        // 获得带接口的注册
        private void GetRegister<TFrom, TTo>(bool bl, String token = "")
        {
            string key = typeof(TFrom).FullName + "_%XH%_" + (string.IsNullOrEmpty(token) ? typeof(TTo).Name : token);
            _instenceDic.Add(key, new InstenceModel
            {
                ObjectType = typeof(TTo),
                IsSinglton = bl,
            });
        }

        #endregion

        #region 获取

        // 获取瞬时
        //public T Resolve<T>()
        //{
        //    string key = typeof(T).FullName!;
        //    if (_instenceDic.ContainsKey(key) && !_instenceDic[key].IsSinglton)
        //    {
        //        // 创建新的实例 并返回
        //        return (T)Activator.CreateInstance(_instenceDic[key].ObjectType)!;
        //    }
        //    else
        //        return default(T)!;
        //}


        public T Resolve<T>()
        {
            string key = typeof(T).FullName!;
            if (_instenceDic.ContainsKey(key))
            {

                #region 合并

                // 单例模式下，之前没有创建实例的前提下调用
                //if (_instenceDic[key].IsSinglton)
                //{
                //    if (_instenceDic[key].Instence is null)
                //    {
                //        return CreateInstence<T>(key);
                //    }
                //    return (T)_instenceDic[key].Instence;
                //}
                // 在瞬时模式下，每次都调用
                //else
                //{
                //    return CreateInstence<T>(key);
                //}

                #endregion

                // 单例模式没有对象 和瞬时模式都需要创建对象
                if ((_instenceDic[key].IsSinglton && _instenceDic[key].Instence is null) || !_instenceDic[key].IsSinglton)
                    return (T)CreateInstence(key, _instenceDic[key].ObjectType);
                //单例模式 有对象直接返回
                return (T)_instenceDic[key].Instence;
            }
            else
                return default(T)!;
        }

        #endregion

        // 创建对象 单例和非单例通用
        private object CreateInstence(string key, Type type)
        {
            #region 检查构造函数

            // 获取所有的构造函数
            ConstructorInfo[] cis = _instenceDic[key].ObjectType.GetConstructors();
            // 获取所有的参数
            ParameterInfo[] cpis = cis[0].GetParameters();
            // 创建args 参数列表
            List<object> objects = new List<object>();
            foreach (ParameterInfo cpi in cpis)
            {
                string paramTypeKey = cpi.ParameterType.FullName!;
                if (cpi.IsDefined(typeof(DependyAttribute), false))
                {
                    var attr = cpi.GetCustomAttribute<DependyAttribute>();
                    paramTypeKey += "_%XH%_" + attr.Token;
                }

                if (_instenceDic.ContainsKey(paramTypeKey!))
                {
                    if (_instenceDic[paramTypeKey].IsSinglton)
                    {
                        if (_instenceDic[paramTypeKey].Instence is null)
                            //_instenceDic[paramTypeKey].Instence = Activator.CreateInstance(_instenceDic[paramTypeKey].ObjectType)!;
                            _instenceDic[paramTypeKey].Instence = CreateInstence(paramTypeKey, _instenceDic[paramTypeKey].ObjectType);
                    }
                    else
                        _instenceDic[paramTypeKey].Instence = CreateInstence(paramTypeKey, _instenceDic[paramTypeKey].ObjectType);

                    objects.Add(_instenceDic[paramTypeKey].Instence);
                }
                else
                    objects.Add(null!);
            }

            #endregion

            // 实例化对象
            var obj = Activator.CreateInstance(_instenceDic[key].ObjectType, objects.ToArray());
            _instenceDic[key].Instence = obj!;

            #region 检查属性的注入

            // 那些属性需要注入 可以通过特性进行区分
            PropertyInfo[] pis = type.GetProperties();
            foreach (var pi in pis)
            {
                // 判断属性是否有特定标记 如果有实例化这个属性
                if (pi.IsDefined(typeof(DependyAttribute), false))
                {
                    var attr = pi.GetCustomAttribute<DependyAttribute>();

                    // 获得属性注入 
                    string paramTypeKey = pi.PropertyType.FullName! + "_%XH%_" + attr.Token;
                    if (_instenceDic.ContainsKey(paramTypeKey!))
                    {
                        if (_instenceDic[paramTypeKey].IsSinglton)
                        {
                            if (_instenceDic[paramTypeKey].Instence is null)
                                //_instenceDic[paramTypeKey].Instence = Activator.CreateInstance(_instenceDic[paramTypeKey].ObjectType)!;
                                _instenceDic[paramTypeKey].Instence = CreateInstence(paramTypeKey, _instenceDic[paramTypeKey].ObjectType);
                        }
                        else
                            _instenceDic[paramTypeKey].Instence = CreateInstence(paramTypeKey, _instenceDic[paramTypeKey].ObjectType);

                        // 如果有实例，已经创建过，设置给当前对象的对应属性
                        // 参数：设置给哪个对象实例的属性
                        pi.SetValue(obj, _instenceDic[paramTypeKey].Instence);
                    }
                }
            }

            #endregion

            return _instenceDic[key].Instence;
        }

        // 1、对象中的参数未注入
        // 2、多个实现的使用
        // 3、属性注入
        // 4、瞬时注入/单例模式
    }

    class InstenceModel
    {
        public bool IsSinglton { get; set; } // 是不是单例模式
        public Type ObjectType { get; set; } // 数据类型
        public object Instence { get; set; } // 初始化数据
    }
}
