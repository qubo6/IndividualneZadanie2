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
        private RunnerList _runnerList = new RunnerList();
        public Form1()
        {
            
            InitializeComponent();
        }

        private void pretekaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RacersForm racersForm = new RacersForm(_runnerList);
            racersForm.ShowDialog();
        }
    }
}
