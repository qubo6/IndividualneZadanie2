using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine.Core
{
    public static class RaceRunnerDict
    {
        public static Dictionary<int, List<TimeSpan>> RaceDictionary = new Dictionary<int, List<TimeSpan>>();

        public static Dictionary<int, List<TimeSpan>> FillDict(Dictionary<int, Runner> runnerDict)
        {
            foreach (var item in runnerDict.Keys)
            {
                RaceDictionary.Add(key: item, value: new List<TimeSpan>() { TimeSpan.Zero });
            }
            return RaceDictionary;
        }
        /// <summary>
        /// získanie poslednej hodnoty časového rozdielu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static TimeSpan GetTS(int id)
        {            
            return RaceDictionary[id].Last();
        }
        /// <summary>
        /// zisťovanie počtu kôl bežca
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetLap(int id)
        {
            return RaceDictionary[id].Count-1;
        }
        /// <summary>
        /// zisťovanie času posledného odbehnutého kola
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static TimeSpan AddLastLapTime(int id)
        {
            if (RaceDictionary[id].Count>=2)
            {
                TimeSpan secondTolastLap = RaceDictionary[id][RaceDictionary[id].Count - 2];
                TimeSpan lastLap = RaceDictionary[id][RaceDictionary[id].Count - 1];
                return lastLap - secondTolastLap;
            }
            return TimeSpan.Zero;
        }
        /// <summary>
        /// zisťovanie celkového času pretekára v behu
        /// </summary>
        /// <param name="id"></param>
        public static void AddRaceTime(int id)
        {
            TimeSpan timeDiff = RaceLogic.LapTime - RaceLogic.StartRace;
            RaceDictionary[id].Add(timeDiff);

        }

    }
}
