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
        public RacersForm()
        {
            InitializeComponent();
            LoadCountries();

            txtId.Text = RunnerDict.GetNextId().ToString();
            dataGridView1.Refresh();

        }
        /// <summary>
        /// načítanie krajín do comboboxu
        /// </summary>
        public void LoadCountries()
        {
            cmbNation.DataSource = FileManager.ReadCSV();
            cmbNation.DisplayMember = (nameof(Country.NameSVK));
            cmbNation.ValueMember = (nameof(Country.Abbr));
        }
        /// <summary>
        /// vlastná metóda na výpis
        /// </summary>
        /// <param name="input"></param>
        public void ShowError(string input)
        {
            MessageBox.Show(input);
        }
        /// <summary>
        /// validácia Id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Tuple<bool, int> IsCorrectId(string input)
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
        /// validácia veku
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Tuple<bool, int> IsCorrectAge(string input)
        {
            int ageR = 0;
            bool isOk = int.TryParse(input, out ageR);
            if (isOk && (ageR >= 1 && ageR <= 117))
            {
                return new Tuple<bool, int>(true, ageR);
            }
            return new Tuple<bool, int>(false, ageR);
        }
        /// <summary>
        /// validácia mena
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Tuple<bool, string> IsCorrectName(string input)
        {
            string correctStr = input;
            if (!string.IsNullOrEmpty(correctStr))
            {
                return new Tuple<bool, string>(true, correctStr);
            }
            return new Tuple<bool, string>(false, correctStr);
        }
        /// <summary>
        /// validácia pohlavia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbGender_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                _gender = radioButton.Tag.ToString();
            }
        }
        /// <summary>
        /// pridanie bežca do zoznamu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var xid = IsCorrectId(txtId.Text);
            if (!xid.Item1)
            {
                ShowError("Id musí byť číslo");
                return;
            }
            if (!RunnerDict.CanUseId(xid.Item2))
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

            RunnerDict.AddNewRunner(id, name, gender, age, nation);
            dataGridView1.DataSource = RunnerDict.RunnerDikt.Values.ToList();
            FileManager.SaveDict();
            txtId.Clear();
            txtName.Clear();
            txtAge.Clear();
        }
        /// <summary>
        /// načítanie dictionary zo súboru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                    dataGridView1.DataSource = FileManager.LoadDict().Values.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        /// <summary>
        /// metoda načítanie označeného bežca z DGV do komponentov
        /// </summary>
        /// <param name="loadRunner"></param>
        private void LoadRunner(Runner loadRunner)
        {
            txtId.Text = loadRunner.Id.ToString();
            txtAge.Text = loadRunner.Age.ToString();
            txtName.Text = loadRunner.Name;
            if (loadRunner.Gender == "Muž")
            {
                rbMale.Checked = true;
            }
            if (loadRunner.Gender == "žena")
            {
                rbFemale.Checked = true;
            }
            cmbNation.Text = loadRunner.Nation;
        }
        /// <summary>
        /// update bežca-je potrebné označiť riadok-kliknuť na btnUpdate a prepísať, následne je potrebné uložiž ho pomocou btnAdd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadRunner(RunnerDict.RunnerDikt[(int)dataGridView1.SelectedRows[0].Cells[0].Value]);
            RemoveRunner((int)dataGridView1.SelectedRows[0].Cells[0].Value);
        }
        /// <summary>
        /// vymazanie bežca
        /// </summary>
        /// <param name="id"></param>
        public void RemoveRunner(int id)
        {
            RunnerDict.RunnerDikt.Remove(id);
        }
        /// <summary>
        /// vymazanie bežca na označenom riadku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveRunner((int)dataGridView1.SelectedRows[0].Cells[0].Value);
            FileManager.SaveDict();
            //dataGridView1.DataSource = null;
            //dataGridView1.DataSource = FileManager.LoadDict().Values.ToList();
            //dataGridView1.Rows.RemoveAt((int)dataGridView1.SelectedRows[0].Cells[0].Value);
            //dataGridView1.Refresh();
            //dataGridView1.Update();
            //dataGridView1.Rows.Clear();
            //dataGridView1.DataSource = FileManager.LoadDict().Values.ToList();

        }
    }
}
