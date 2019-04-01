namespace FinishLine
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pretekyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretekaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtRunnerId = new System.Windows.Forms.TextBox();
            this.btnAddLap = new System.Windows.Forms.Button();
            this.Lap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LapTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretekyToolStripMenuItem,
            this.pretekaryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1025, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pretekyToolStripMenuItem
            // 
            this.pretekyToolStripMenuItem.Name = "pretekyToolStripMenuItem";
            this.pretekyToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.pretekyToolStripMenuItem.Text = "Preteky";
            // 
            // pretekaryToolStripMenuItem
            // 
            this.pretekaryToolStripMenuItem.Name = "pretekaryToolStripMenuItem";
            this.pretekaryToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.pretekaryToolStripMenuItem.Text = "Pretekáry";
            this.pretekaryToolStripMenuItem.Click += new System.EventHandler(this.pretekaryToolStripMenuItem_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 47);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Štart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblStartTime.Location = new System.Drawing.Point(94, 50);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(64, 17);
            this.lblStartTime.TabIndex = 2;
            this.lblStartTime.Text = "00:00:00";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lap,
            this.Id,
            this.Meno,
            this.LapTime});
            this.dataGridView1.Location = new System.Drawing.Point(13, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(421, 325);
            this.dataGridView1.TabIndex = 3;
            // 
            // txtRunnerId
            // 
            this.txtRunnerId.Location = new System.Drawing.Point(288, 44);
            this.txtRunnerId.Name = "txtRunnerId";
            this.txtRunnerId.Size = new System.Drawing.Size(54, 20);
            this.txtRunnerId.TabIndex = 4;
            // 
            // btnAddLap
            // 
            this.btnAddLap.Location = new System.Drawing.Point(359, 44);
            this.btnAddLap.Name = "btnAddLap";
            this.btnAddLap.Size = new System.Drawing.Size(75, 23);
            this.btnAddLap.TabIndex = 5;
            this.btnAddLap.Text = "button1";
            this.btnAddLap.UseVisualStyleBackColor = true;
            this.btnAddLap.Click += new System.EventHandler(this.btnAddLap_Click);
            // 
            // Lap
            // 
            this.Lap.FillWeight = 25F;
            this.Lap.HeaderText = "Kolo";
            this.Lap.Name = "Lap";
            // 
            // Id
            // 
            this.Id.FillWeight = 25F;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Meno
            // 
            this.Meno.FillWeight = 70F;
            this.Meno.HeaderText = "Meno";
            this.Meno.Name = "Meno";
            // 
            // LapTime
            // 
            this.LapTime.HeaderText = "Čas posledného kola";
            this.LapTime.Name = "LapTime";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 450);
            this.Controls.Add(this.btnAddLap);
            this.Controls.Add(this.txtRunnerId);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Kros Preteky";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pretekyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretekaryToolStripMenuItem;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtRunnerId;
        private System.Windows.Forms.Button btnAddLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meno;
        private System.Windows.Forms.DataGridViewTextBoxColumn LapTime;
    }
}

