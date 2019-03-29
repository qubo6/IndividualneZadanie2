using KBCsv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine.Core
{
    public static class CountryCatalog
    {
        private static string path = @"C:\Users\transformer2\source\repos\git\IndividualneZadanie2\Data\countries.csv";   
        public static List<Country>  ReadCSV()
        {
            using (var streamReader = new StreamReader(path))
            using (var reader = new CsvReader(streamReader))
            {
                List<Country> CountryList = new List<Country>();
                reader.ValueSeparator = ';';
                reader.ReadHeaderRecord();
                while (reader.HasMoreRecords)
                {
                    var dataRecord = reader.ReadDataRecord();
                    CountryList.Add(new Country() {  NameSVK = dataRecord[1], Abbr = dataRecord[0] } );
                }
                return CountryList;
               
            }
        }
    }
}
