using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine.Core
{
    public class RunnerList
    {
        
        public Dictionary<int, Runner> RunnerDikt = new Dictionary<int, Runner>();
        public static int LastId = 0;
        public int GetNextId()
        {
            return LastId++;
        }

        public bool CanUseId(int id)
        {
            return !RunnerDikt.ContainsKey(id);
        }
        public void AddNewRunner(int id, string name, string gender, int age, string nation)
        {
            Runner runner = new Runner(id, name, gender, age, nation);
            RunnerDikt.Add(id,runner);
        }
    }
}
