using FinishLine.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinishLine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Po kliknutí na pretekáry sa otvorí nové modálne okno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pretekaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RacersForm racersForm = new RacersForm();
            racersForm.ShowDialog();
        }
        /// <summary>
        /// Validácia dátového typu int
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Tuple<bool, int> IsCorrectInt(string input)
        {
            int INT = 0;
            bool isOk = int.TryParse(input, out INT);
            if (isOk && (INT >= 1))
            {
                return new Tuple<bool, int>(true, INT);
            }
            return new Tuple<bool, int>(false, INT);
        }
        /// <summary>
        /// validácia dátoveho typu double
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Tuple<bool, double> IsCorrectDbl(string input)
        {
            double Dbl = 0;
            bool isOk = double.TryParse(input, out Dbl);
            if (isOk && (Dbl > 0))
            {
                return new Tuple<bool, double>(true, Dbl);
            }
            return new Tuple<bool, double>(false, Dbl);
        }
        /// <summary>
        /// validácia Id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Tuple<bool, int> IsCorrectRunnerId(string input)
        {
            int IdR = 0;
            bool isOk = int.TryParse(input, out IdR);
            if (isOk && (IdR >= 1 && IdR <= 999))
            {
                return new Tuple<bool, int>(true, IdR);
            }
            return new Tuple<bool, int>(false, IdR);
        }
        /// <summary>
        /// vlastná metoda na výpis
        /// </summary>
        /// <param name="input"></param>
        public void ShowError(string input)
        {
            MessageBox.Show(input);
        }
        /// <summary>
        /// tlačidlo na štart pretekov, po klinkutí zablokuje komponenty na editácia pretekárov a vlastností pretekov
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            RaceLogic.StartRace = DateTime.Now;
            lblStartTime.Text = RaceLogic.StartRace.ToString();
            RaceRunnerDict.FillDict(RunnerDict.RunnerDikt);
            DisplayRunner();
            var xintL = IsCorrectInt(txtTotalLaps.Text);
            if (!xintL.Item1)
            {
                ShowError("Počet kôl musí byť číslo");
                return;
            }
            RaceLogic.TotalLaps = xintL.Item2;
            var xintP = IsCorrectInt(txtPlaces.Text);
            if (!xintP.Item1)
            {
                ShowError("Počet miest musí byť číslo");
                return;
            }
            RaceLogic.Places = xintP.Item2;
            var xdbl = IsCorrectDbl(txtLapLenght.Text);
            if (!xdbl.Item1)
            {
                ShowError("Počet km musí byť číslo");
                return;
            }
            RaceLogic.LapLenght = xdbl.Item2;
            txtLapLenght.Visible = false;
            txtPlaces.Visible = false;
            txtTotalLaps.Visible = false;
            pretekaryToolStripMenuItem.Visible = false;
        }
        /// <summary>
        /// po zadaní správneho ID bežca a kliknutí mu pripočíta ďalšie kolo a kontroluje či pretekári už odbehli stanovený počet kôl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddLap_Click(object sender, EventArgs e)
        {
            var xid = IsCorrectRunnerId(txtRunnerId.Text);
            if (!xid.Item1)
            {
                ShowError("Id musí byť číslo");
                return;
            }
            if (RunnerDict.CanUseId(xid.Item2))
            {
                ShowError("Id neexistuje" + xid.Item2);
                return;
            }
            RaceLogic.LapTime = DateTime.Now;
            RaceRunnerDict.AddRaceTime(xid.Item2);
            dataGridView1.Rows.Clear();
            DisplayRunner();
            try
            {
                Finnishing(Convert.ToInt32(txtRunnerId.Text));
            }
            catch (ArgumentOutOfRangeException)
            { }
        }
        /// <summary>
        /// kontrola či pretekári už dobehli do ciela, resp. nenaplnil sa počet bodovaných miest
        /// </summary>
        /// <param name="id"></param>
        public void Finnishing(int id)
        {
            if (RaceLogic.FinishedRunner(RunnerDict.RunnerDikt[id]))
            {
                ShowError("Už dokončil pretek");
            }
            else
            {
                if (RaceLogic.CheckIfWin(RunnerDict.RunnerDikt[id]))
                {
                    ShowError($"Bežec {RunnerDict.RunnerDikt[id].Name} dobehol ako {RunnerDict.Winners.Count}");
                    
                }
                if (RaceLogic.CheckEnd())
                {
                    ShowError("Ohodnotené miesta už sú obsadené");
                    string message = string.Empty;

                    for (int i = 0; i < RunnerDict.Winners.Count; i++)
                    {
                        message += ($"{RunnerDict.Winners[id]}. je bežec {RunnerDict.RunnerDikt[id].Name}" + Environment.NewLine);
                    }
                    txtWin.Text = message;
                }
            }
        }
        /// <summary>
        /// zobrazovanie jednotlivých jazdcov s aktuálnym počtom kôl, časom za posledné kolo a celkovým časom
        /// </summary>
        public void DisplayRunner()
        {
            foreach (Runner runner in RunnerDict.RunnerDikt.Values)
            {
                dataGridView1.Rows.Add(RaceRunnerDict.GetLap(runner.Id), runner.Id, runner.Name, RaceRunnerDict.AddLastLapTime(runner.Id), RaceRunnerDict.GetTS(runner.Id));
                
            }
        }
    }
}
