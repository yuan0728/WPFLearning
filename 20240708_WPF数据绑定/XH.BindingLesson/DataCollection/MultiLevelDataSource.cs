using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace XH.BindingLesson.DataCollection
{
    public class MultiLevelDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // 列表中的子项数据：id\Header\ParentId
        public List<Area> AreaAll { get; set; } = new List<Area>();

        public int CurrentCIndex { get; set; } = 0;
        public int CurrentDIndex { get; set; } = 0;

        private int _currentPCode;
        public int CurrentPCode
        {
            get => _currentPCode;
            set
            {
                _currentPCode = value;

                var cs = AreaAll.Where(a => a.ParentCode == value).ToList();
                CityList.Clear();
                foreach (var item in cs)
                {
                    CityList.Add(item);
                }
                var ds = AreaAll.Where(a => a.ParentCode == CityList[0].Code).ToList();
                DistrictList.Clear();
                foreach (var item in ds)
                {
                    DistrictList.Add(item);
                }

                CurrentCIndex = 0;
                CurrentDIndex = 0;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentCIndex"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentDIndex"));
            }
        }

        private int _currentCity;


        public int CurrentCCode
        {
            get => _currentCity;
            set
            {
                _currentCity = value;
                var ds = AreaAll.Where(a => a.ParentCode == value).ToList();
                DistrictList.Clear();
                foreach (var item in ds)
                {
                    DistrictList.Add(item);
                }

                CurrentDIndex = 0;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentDIndex"));
            }
        }
        public int CurrentDCode { get; set; }

        public ObservableCollection<Area> ProvinceList { get; set; }
        public ObservableCollection<Area> CityList { get; set; }
        public ObservableCollection<Area> DistrictList { get; set; }

        public MultiLevelDataSource()
        {
            ProvinceList = new ObservableCollection<Area>();
            CityList = new ObservableCollection<Area>();
            DistrictList = new ObservableCollection<Area>();


            Task.Run(() =>
            {
                // await Task.Delay(1000); // 耗时操作

                // 获取到数据后，进行页面初始化
                AreaAll.Add(new Area { Code = 1, Header = "湖北", ParentCode = 0 });
                AreaAll.Add(new Area { Code = 2, Header = "江苏", ParentCode = 0 });
                AreaAll.Add(new Area { Code = 3, Header = "武汉", ParentCode = 1 });
                AreaAll.Add(new Area { Code = 4, Header = "襄阳", ParentCode = 1 });
                AreaAll.Add(new Area { Code = 5, Header = "南京", ParentCode = 2 });
                AreaAll.Add(new Area { Code = 6, Header = "苏州", ParentCode = 2 });
                AreaAll.Add(new Area { Code = 7, Header = "武昌", ParentCode = 3 });
                AreaAll.Add(new Area { Code = 8, Header = "洪山", ParentCode = 3 });
                AreaAll.Add(new Area { Code = 9, Header = "江岸", ParentCode = 3 });
                AreaAll.Add(new Area { Code = 10, Header = "襄城", ParentCode = 4 });
                AreaAll.Add(new Area { Code = 11, Header = "樊成", ParentCode = 4 });
                AreaAll.Add(new Area { Code = 12, Header = "襄州", ParentCode = 4 });
                AreaAll.Add(new Area { Code = 13, Header = "玄武", ParentCode = 5 });
                AreaAll.Add(new Area { Code = 14, Header = "建邺", ParentCode = 5 });
                AreaAll.Add(new Area { Code = 15, Header = "鼓楼", ParentCode = 5 });
                AreaAll.Add(new Area { Code = 16, Header = "姑苏", ParentCode = 6 });
                AreaAll.Add(new Area { Code = 17, Header = "相城", ParentCode = 6 });
                AreaAll.Add(new Area { Code = 18, Header = "吴中", ParentCode = 6 });

                Application.Current.Dispatcher.Invoke(() =>
                {
                    var ps = AreaAll.Where(a => a.ParentCode == 0).ToList();
                    foreach (var item in ps)
                    {
                        ProvinceList.Add(item);
                    }
                    //var cs = AreaAll.Where(a => a.ParentCode == ProvinceList[0].Code).ToList();
                    //foreach (var item in cs)
                    //{
                    //    CityList.Add(item);
                    //}
                    //var ds = AreaAll.Where(a => a.ParentCode == CityList[0].Code).ToList();
                    //foreach (var item in ds)
                    //{
                    //    DistrictList.Add(item);
                    //}

                    // SelectedValue
                    // 从保存的数据中获取，如果获取到，直接赋值，如果没有获取到，显示第0个
                    CurrentPCode = ProvinceList[0].Code;
                    CurrentCCode = CityList[0].Code;
                    CurrentDCode = DistrictList[0].Code;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentPCode"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentCCode"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentDCode"));
                });

                //CurrentCIndex = 0;
                //CurrentDIndex = 0;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentCIndex"));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentDIndex"));


                // SelectedIndex
            });


        }
    }

    public class Area
    {
        public int Code { get; set; }
        public string Header { get; set; }
        public int ParentCode { get; set; }
    }
}
