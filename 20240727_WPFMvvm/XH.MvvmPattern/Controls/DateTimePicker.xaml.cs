using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace XH.MvvmPattern.Controls
{
    /// <summary>
    /// DateTimePicker.xaml 的交互逻辑
    /// </summary>
    public partial class DateTimePicker :UserControl, INotifyPropertyChanged
    {
        // 命令属性
        public ICommand SelectedCommand
        {
            get { return (ICommand)GetValue(SelectedCommandProperty); }
            set { SetValue(SelectedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedCommandProperty =
            DependencyProperty.Register("SelectedCommand", typeof(ICommand), typeof(DateTimePicker), new PropertyMetadata(null));




        public object SelectedCommandParameter
        {
            get { return (object)GetValue(SelectedCommandParameterProperty); }
            set { SetValue(SelectedCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedCommandParameterProperty =
            DependencyProperty.Register("SelectedCommandParameter", typeof(object), typeof(DateTimePicker), new PropertyMetadata(null));




        public event PropertyChangedEventHandler? PropertyChanged;

        public event EventHandler<DateTime> SeletedChanged;

        private int hourInt = DateTime.Now.Hour;

        public int HourInt
        {
            get { return hourInt; }
            set
            {
                hourInt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HourInt"));
            }
        }

        private int minuteInt = DateTime.Now.Minute;

        public int MinuteInt
        {
            get { return minuteInt; }
            set
            {
                minuteInt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinuteInt"));
            }
        }

        private int secondInt = DateTime.Now.Second;

        public int SecondInt
        {
            get { return secondInt; }
            set
            {
                secondInt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SecondInt"));
            }
        }

        public DateTime CurrentDateTime
        {
            get { return (DateTime)GetValue(CurrentDateTimeProperty); }
            set
            {
                SetValue(CurrentDateTimeProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for CurrentDateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentDateTimeProperty =
            DependencyProperty.Register(
                "CurrentDateTime", 
                typeof(DateTime), typeof(DateTimePicker), 
                new PropertyMetadata(DateTime.Now,
                    new PropertyChangedCallback(OnCurentDateTimeChanged)));

        private static void OnCurentDateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as DateTimePicker).Refresh();
        }

        private void Refresh()
        {
            this.calendar.SelectedDate = this.CurrentDateTime; 
            this.calendar.DisplayDate = this.CurrentDateTime; // 确保日历显示正确的月份

            HourInt = this.CurrentDateTime.Hour;
            MinuteInt = this.CurrentDateTime.Minute;
            SecondInt = this.CurrentDateTime.Second;
        }

        public DateTimePicker()
        {
            InitializeComponent();
            calendar.SelectedDate = this.CurrentDateTime;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 把日历和时间合并
            int year = calendar.SelectedDate.Value.Year;
            int month = calendar.SelectedDate.Value.Month;
            int day = calendar.SelectedDate.Value.Day;
            int.TryParse(this.tb_hour.Text.Trim(), out int hour);
            int.TryParse(this.tb_minute.Text.Trim(), out int minute);
            int.TryParse(this.tb_second.Text.Trim(), out int second);
            CurrentDateTime = new DateTime(year, month, day, hour, minute, second);
            this.popup.IsOpen = false;

            SeletedChanged?.Invoke(this, CurrentDateTime);
            // 命令的执行
            SelectedCommand?.Execute(CurrentDateTime);
        }

        private void BtnHourUp_Click(object sender, RoutedEventArgs e)
        {
            var hour_str = string.IsNullOrEmpty(this.tb_hour.Text) ? "0" : this.tb_hour.Text;
            HourInt = int.Parse(hour_str);

            HourInt++;
            HourInt %= 24;

            //this.tb_hour.Text = hourInt.ToString();
        }

        private void BtnHourDown_Click(object sender, RoutedEventArgs e)
        {
            var hour_str = string.IsNullOrEmpty(this.tb_hour.Text) ? "0" : this.tb_hour.Text;
            HourInt = int.Parse(hour_str);

            HourInt--;
            HourInt = (HourInt + 24) % 24;

        }

        private void BtnMinuteDown_Click(object sender, RoutedEventArgs e)
        {
            var minute_str = string.IsNullOrEmpty(this.tb_minute.Text) ? "0" : this.tb_minute.Text;
            MinuteInt = int.Parse(minute_str);

            MinuteInt--;
            MinuteInt = (MinuteInt + 60) % 60;

        }

        private void BtnMinuteUp_Click(object sender, RoutedEventArgs e)
        {
            var minute_str = string.IsNullOrEmpty(this.tb_minute.Text) ? "0" : this.tb_minute.Text;
            MinuteInt = int.Parse(minute_str);

            MinuteInt++;
            MinuteInt %= 60;
        }

        private void BtnSecondUp_Click(object sender, RoutedEventArgs e)
        {
            var second_str = string.IsNullOrEmpty(this.tb_second.Text) ? "0" : this.tb_second.Text;
            SecondInt = int.Parse(second_str);

            SecondInt++;
            SecondInt %= 60;
        }

        private void BtnSecondDown_Click(object sender, RoutedEventArgs e)
        {
            var second_str = string.IsNullOrEmpty(this.tb_second.Text) ? "0" : this.tb_second.Text;
            SecondInt = int.Parse(second_str);

            SecondInt--;
            SecondInt = (SecondInt + 60) % 60;
        }

        private void tb_hour_TextChanged(object sender, TextChangedEventArgs e)
        {
            HourInt = int.Parse(tb_hour.Text);
            if (HourInt >= 24 || HourInt < 0)
                HourInt = 0;
        }

        private void tb_minute_TextChanged(object sender, TextChangedEventArgs e)
        {
            MinuteInt = int.Parse(tb_minute.Text);
            if (MinuteInt >= 60 || MinuteInt < 0)
                MinuteInt = 0;
        }

        private void tb_second_TextChanged(object sender, TextChangedEventArgs e)
        {
            SecondInt = int.Parse(tb_second.Text);
            if (SecondInt >= 60 || SecondInt < 0)
                SecondInt = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.popup.IsOpen = false;
        }
    }
}
