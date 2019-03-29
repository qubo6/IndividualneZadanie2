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
    public partial class RacersForm : Form
    {
        private string _gender;
        private RunnerList _runnerList;
        public RacersForm(RunnerList runnerList)
        {
            InitializeComponent();
            LoadCountries();
            _runnerList = runnerList;
            txtId.Text= _runnerList.GetNextId().ToString();
        }
        public void LoadCountries()
        {
            cmbNation.DataSource = CountryCatalog.ReadCSV();
            cmbNation.DisplayMember = (nameof(Country.NameSVK));
            cmbNation.ValueMember = (nameof(Country.Abbr));
        }
        public void ShowError(string input)
        {
            MessageBox.Show(input);
        }
        public Tuple<bool,int> IsCorrectId(string input)
        {
            int IdR = 0;
            bool isOk = int.TryParse(input, out IdR);
            if (isOk && (IdR >= 1 && IdR <= 999))
            {
                return new Tuple<bool, int>(true, IdR);
            }
            return new Tuple<bool, int>(false, IdR);
        }
        public Tuple<bool,int> IsCorrectAge(string input)
        {
            int ageR = 0;
            bool isOk = int.TryParse(input, out ageR);
            if (isOk && (ageR >= 1 && ageR <= 117))
            {
                return new Tuple<bool, int>(true, ageR);
            }
            return new Tuple<bool, int>(false, ageR);
        }
        public Tuple<bool, string> IsCorrectName(string input)
        {
            string correctStr = input;
            if (!string.IsNullOrEmpty(correctStr))            
            {
                return new Tuple<bool, string>(true, correctStr);
            }
            return new Tuple<bool, string>(false, correctStr);
        }
        private void rbGender_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                _gender = radioButton.Tag.ToString();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var xid = IsCorrectId(txtId.Text);
            if (!xid.Item1) {
                ShowError("Id musí byť číslo");
                return;
            }
            if (!_runnerList.CanUseId(xid.Item2))
            {
                ShowError("Id už existuje");
                return;
            }
            var xage = IsCorrectAge(txtAge.Text);
            if (!xage.Item1)
            {
                ShowError("Vek musí byť číslo");
                return;
            }
            var xname = IsCorrectName(txtName.Text);
            if (!xname.Item1)
            {
                ShowError("Meno nesmie byť prázdne");
                return;
            }
            int id = xid.Item2;
            int age = xage.Item2;
            string name = xname.Item2;
            string gender = _gender;
            string nation = cmbNation.SelectedValue.ToString();
            
            _runnerList.AddNewRunner(id, name, gender, age, nation);
            
            dataGridView1.DataSource = _runnerList.RunnerDikt.Values.ToList();
        }       
    }
}
