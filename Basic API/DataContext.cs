using System.Formats.Asn1;
using System.Globalization;

namespace Basic_API
{
    public class DataContext:IDataContext
    {
        public List<Event> EventList { get; set; }

        public DataContext()
        {
            using (var reader = new StreamReader("data.csv"))
            using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
            {
                EventList = csv.GetRecords<Event>().ToList();
            }
        }
    }
}
