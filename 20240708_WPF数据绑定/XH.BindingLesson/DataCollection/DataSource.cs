using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.BindingLesson.DataCollection
{
    public class DataSource
    {
        public string Name { get; set; } = "Hello";

        public int CurrentId { get; set; }
        public object CurrentItem { get; set; }
        // ObservableCollection 通知属性
        public ObservableCollection<DataItem> List { get; set; } =
            new ObservableCollection<DataItem>() {
                new DataItem { Id =1,Header ="AAA",State = 0 },
                new DataItem { Id =2,Header ="BBB",State = 1 },
                new DataItem { Id =3,Header ="CCC",State = 0 }
            };
        public DataSource()
        {
            List[0].Sub.Add(new DataItem { Id = 1, Header = "AAA_1", State = 0 });
            List[0].Sub.Add(new DataItem
            {
                Id = 1,
                Header = "AAA_2",
                State = 0,
                Sub = new List<DataItem>() {
                    new DataItem { Id =1,Header ="AAA",State = 0 },
                    new DataItem { Id =2,Header ="BBB",State = 1 },
                    new DataItem { Id =3,Header ="CCC",State = 0 }}
            });
            List[1].Sub.Add(new DataItem { Id = 2, Header = "BBB_1", State = 1 });
            List[2].Sub.Add(new DataItem { Id = 3, Header = "CCC_1", State = 0 });
        }
    }
    public class DataItem
    {
        public string Icon { get; set; }
        public int Id { get; set; }
        public string Header { get; set; }
        public int State { get; set; }

        public List<DataItem> Sub { get; set; } = new List<DataItem>();

        // 自己嵌套自己 可以无限层级
    }
}
