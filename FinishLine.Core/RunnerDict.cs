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
        public static List<int> Winners = new List<int>();
        public static int LastId = 0;
        /// <summary>
        /// v prípade prázdneho pola jazdcov inkrementovanie Id
        /// </summary>
        /// <returns></returns>
        public static int GetNextId()
        {
            return LastId++;
        }
        /// <summary>
        /// overovanie či sa Id už nenachádza v zozname
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool CanUseId(int id)
        {
            return !RunnerDikt.ContainsKey(id);
        }
        /// <summary>
        /// pridanie nového bežca do zoznamu
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="age"></param>
        /// <param name="nation"></param>
        public static void AddNewRunner(int id, string name, string gender, int age, string nation)
        {
            Runner runner = new Runner(id, name, gender, age, nation);
            RunnerDikt.Add(id,runner);
        }
    }
}
