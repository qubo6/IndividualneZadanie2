using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine.Core
{
    public static class RaceLogic
    {
        public static DateTime StartRace { get; set; }
        public static DateTime LapTime { get; set; }
        public static int TotalLaps { get; set; }
        public static double LapLenght { get; set; }
        public static int Places { get; set; }
        public static int WinRunners { get; set; } = 0;
        /// <summary>
        /// overovanie či niektorý z bežcov už neodbehol stanovený počet kôl
        /// </summary>
        /// <param name="runner"></param>
        /// <returns></returns>
        public static bool CheckIfWin(Runner runner)
        {
            if (RaceRunnerDict.RaceDictionary[runner.Id].Count==TotalLaps+1)
            {
                RunnerDict.Winners.Add(runner.Id);   
                return true;
            }
            return false;
        }
        /// <summary>
        /// overovanie či počet hodnotených miest už nebol obsadený
        /// </summary>
        /// <returns></returns>
        public static bool CheckEnd()
        {
            if (RunnerDict.Winners.Count==Places)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// overovanie či konkrétny jazdec už neodbehol pretek
        /// </summary>
        /// <param name="runner"></param>
        /// <returns></returns>
        public static bool FinishedRunner(Runner runner)
        {
            if (RunnerDict.Winners.Contains(runner.Id))
            {
                return true;
            }
            return false;
        }
    }
}