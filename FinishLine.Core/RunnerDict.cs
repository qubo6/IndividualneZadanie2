using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine.Core
{
    public static class RunnerDict
    {
        
        public static Dictionary<int, Runner> RunnerDikt = new Dictionary<int, Runner>();
        public static int LastId = 0;
        public static int GetNextId()
        {
            return LastId++;
        }

        public static bool CanUseId(int id)
        {
            return !RunnerDikt.ContainsKey(id);
        }
        public static void AddNewRunner(int id, string name, string gender, int age, string nation)
        {
            Runner runner = new Runner(id, name, gender, age, nation);
            RunnerDikt.Add(id,runner);
        }
    }
}
