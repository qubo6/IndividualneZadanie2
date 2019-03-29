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

        public Runner(int id, string name, string gender, int age, string nation)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;
            Nation = nation;
        }


    }
}
