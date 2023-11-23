using Basic_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class DataContextFake: IDataContext
    {
        public List<Event> EventList { get; set; }

        public DataContextFake()
        {
            EventList = new List<Event>();
            EventList.Add(new Event { Id = 1, Title = "Hello" });
            EventList.Add(new Event { Id = 2, Title = "World" });
        }
    }
}
