using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XH.BindingLesson.DataValidation
{
    // IDataErrorInfo 数据元对象里面有很对属性需要校验
    public class Data : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int _value;

        [Required(ErrorMessage ="必须输入温度报警值")]
        [DisplayName("温度值")]
        [MaxLength(5)]
        public int Value
        {
            get { return _value; }
            set
            {
                //if (value == 123)
                //    throw new Exception("不能输入123");
                _value = value;
            }
        }
        // 最大长度
        //[MaxLength(5,ErrorMessage = "长度大于5")]
        public string MyProperty { get; set; } = "";
        //[MaxLength(100)]
        //[Url] // 判断url是否合法
        //[EmailAddress(ErrorMessage = "邮箱地址不正确")] // 邮箱地址
        //[CheckRepeat(ErrorMessage = "输入信息有误")]
        [IPCheck(ErrorMessage ="IP不对")]
        public string MyProperty1 { get; set; } = "";
        //[StringLength(maximumLength:20,MinimumLength =10)] // 限制最大和最小长度
        public string Error { get; set; }

        // 索引 获取某一列的值
        public string this[string columnName]
        {
            get
            {
                //if (columnName == "Value" && this.Value >1000)
                //{
                //    return "Value 值大于 1000！！！【IDataErrorInfo】";
                //}
                //if (columnName == "MyProperty" && this.MyProperty.Length > 50)
                //{
                //    return "MyProperty 长度大于 50！！！【IDataErrorInfo】";
                //}

                // 使用反射
                PropertyInfo pi = this.GetType().GetProperty(columnName);

                // 检查当前属性是否添加了指定的特性
                // IsDefined 判断是否有特性
                if (pi.IsDefined(typeof(MaxLengthAttribute)))
                {
                    // 获取当前属性上指定的特定示例 一般是需要获取特性示例中某些值的时候使用
                    MaxLengthAttribute ma = (MaxLengthAttribute)pi.GetCustomAttribute(typeof(MaxLengthAttribute));
                    string value = pi.GetValue(this).ToString();
                    if (value.Length > ma.Length)
                    {
                        //return $"{pi.Name} 长度大于 {ma.Length}！！！【IDataErrorInfo】";
                        return ma.ErrorMessage;
                    }
                }

                // 验证必输
                if (pi.IsDefined(typeof(RequiredAttribute)))
                {
                    DisplayNameAttribute dna = pi.GetCustomAttribute<DisplayNameAttribute>();
                    RequiredAttribute ra = pi.GetCustomAttribute<RequiredAttribute>();
                    string value = pi.GetValue(this).ToString();
                    if (string.IsNullOrEmpty(value) || value == "0")
                        //return $"{dna.DisplayName} 是必输项！！！【IDataErrorInfo】";
                        return ra.ErrorMessage;
                }

                // 验证邮箱
                if (pi.IsDefined(typeof(EmailAddressAttribute)))
                {
                    EmailAddressAttribute eaa = pi.GetCustomAttribute<EmailAddressAttribute>();
                    if (!eaa.IsValid(pi.GetValue(this)))
                        return eaa.ErrorMessage;
                }

                // 验证自定义 
                if (pi.IsDefined(typeof(CheckRepeatAttribute)))
                {
                    CheckRepeatAttribute cra = pi.GetCustomAttribute<CheckRepeatAttribute>();
                    if(!cra.IsValid(pi.GetValue(this)))
                    {
                        return cra.ErrorMessage;
                    }
                }
                // 自定义检验IP
                if (pi.IsDefined(typeof(IPCheckAttribute)))
                {
                    IPCheckAttribute ia = pi.GetCustomAttribute<IPCheckAttribute>();
                    if (!ia.IsValid(pi.GetValue(this)))
                    {
                        return ia.ErrorMessage;
                    }
                }



                //object value = pi.GetValue(this);

                // Value int 不要超过1000
                // MyProperty string 长度不要超过50

                // 1、区分出属性
                // 2、区分属性的判断条件


                return "";
            }
        }

        public Data()
        {
            //Task.Run(async () =>
            //{
            //    await Task.Delay(3000);
            //    try
            //    {
            //        Value = 112;
            //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //});
        }
    }
}
