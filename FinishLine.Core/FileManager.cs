using KBCsv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine.Core
{
    public static class FileManager
    {
        //private static RunnerDict _runnerDict;
        private static string _path = @"C:\Users\transformer2\source\repos\git\IndividualneZadanie2\Data\countries.csv";
        private static string _pathRuners= "runners.txt";
        public static List<Country> ReadCSV()
        {
            using (var streamReader = new StreamReader(_path))
            using (var reader = new CsvReader(streamReader))
            {
                List<Country> CountryList = new List<Country>();
                reader.ValueSeparator = ';';
                reader.ReadHeaderRecord();
                while (reader.HasMoreRecords)
                {
                    var dataRecord = reader.ReadDataRecord();
                    CountryList.Add(new Country() { NameSVK = dataRecord[1], Abbr = dataRecord[0] });
                }
                return CountryList;

            }
        }
        public static Dictionary<int, Runner> LoadDict()
        {
            if (!File.Exists(_pathRuners))
            {
                File.Create(_pathRuners).Close();
            }
            string line;
            using (StreamReader sr = new StreamReader(_pathRuners))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    string[] loadFile = line.Split('\t');
                    RunnerDict.RunnerDikt.Add(key:int.Parse(loadFile[0]), value: new Runner(int.Parse(loadFile[0]), loadFile[1], loadFile[2], int.Parse(loadFile[3]), loadFile[4]));
                }
            }
            return RunnerDict.RunnerDikt;
            
        }
        public static void SaveDict()
        {
            File.Delete(_pathRuners);
            foreach (var item in RunnerDict.RunnerDikt.Values)
            {
                File.AppendAllText(_pathRuners, item.DescribeRunner());
            }
        }

}
}
