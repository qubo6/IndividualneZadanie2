using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine.Core
{
    public class Runner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Nation { get; set; }
        /// <summary>
        /// konštruktor triedy Runner
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="age"></param>
        /// <param name="nation"></param>
        public Runner(int id, string name, string gender, int age, string nation)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;
            Nation = nation;
        }
        /// <summary>
        /// metoda na výpis atributov bežca
        /// </summary>
        /// <returns></returns>
        public string DescribeRunner()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Id}\t");
            sb.Append($"{Name}\t");
            sb.Append($"{Gender}\t");
            sb.Append($"{Age}\t");
            sb.Append($"{Nation}\n");
            return sb.ToString();
        }



    }
}
