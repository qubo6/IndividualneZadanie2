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

        private void pretekaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RacersForm racersForm = new RacersForm();
            racersForm.ShowDialog();
        }
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
        public void ShowError(string input)
        {
            MessageBox.Show(input);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            RaceLogic.StartRace = DateTime.Now;
            lblStartTime.Text = RaceLogic.StartRace.ToString();
            RaceRunnerDict.FillDict(RunnerDict.RunnerDikt);
            DisplayRunner();
        }
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
            //MessageBox.Show(RaceRunnerDict.AddLastLapTime(xid.Item2).ToString());
        }
        public void DisplayRunner()
        {
            foreach (Runner runner in RunnerDict.RunnerDikt.Values)
            {
                //dataGridView1.Rows.Add(RaceRunnerDict.GetLap(runner.Id), runner.Id, runner.Name, RaceRunnerDict.AddLastLapTime(runner.Id), RaceRunnerDict.GetTS(runner.Id));
                dataGridView1.Rows.Add(RaceRunnerDict.GetLap(runner.Id), runner.Id, runner.Name, RaceRunnerDict.AddLastLapTime(runner.Id));
            }
        }
    }
}
