namespace WinFormsApp2
{
    partial class DetaliiProgramariAdmin
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
            button3 = new Button();
            button2 = new Button();
            listView1 = new ListView();
            Username = new ColumnHeader();
            Antrenor = new ColumnHeader();
            Data = new ColumnHeader();
            DurataOre = new ColumnHeader();
            Status = new ColumnHeader();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            groupBox1 = new GroupBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.Navy;
            button3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(39, 362);
            button3.Name = "button3";
            button3.Size = new Size(105, 46);
            button3.TabIndex = 7;
            button3.Text = "Inapoi";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.MediumVioletRed;
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(25, 24);
            button2.Name = "button2";
            button2.Size = new Size(238, 41);
            button2.TabIndex = 6;
            button2.Text = "Sterge Programare";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { Username, Antrenor, Data, DurataOre, Status });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(283, 24);
            listView1.Name = "listView1";
            listView1.Size = new Size(496, 402);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // Username
            // 
            Username.Text = "Username";
            Username.Width = 120;
            // 
            // Antrenor
            // 
            Antrenor.Text = "Antrenor";
            Antrenor.Width = 120;
            // 
            // Data
            // 
            Data.Text = "Data";
            // 
            // DurataOre
            // 
            DurataOre.Text = "Durata Ore";
            DurataOre.Width = 90;
            // 
            // Status
            // 
            Status.Text = "Status";
            Status.Width = 80;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(17, 45);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(184, 24);
            radioButton1.TabIndex = 8;
            radioButton1.TabStop = true;
            radioButton1.Text = "Ordonare dupa numele";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(17, 96);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(178, 24);
            radioButton2.TabIndex = 9;
            radioButton2.TabStop = true;
            radioButton2.Text = "Ordonare dupa durata";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Location = new Point(25, 87);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(238, 169);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ordonari:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 72);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 10;
            label1.Text = "antrenorului";
            // 
            // DetaliiProgramariAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listView1);
            Name = "DetaliiProgramariAdmin";
            Text = "DetaliiProgramariAdmin";
            Load += DetaliiProgramariAdmin_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button3;
        private Button button2;
        private ListView listView1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private GroupBox groupBox1;
        private Label label1;
        private ColumnHeader Username;
        private ColumnHeader Antrenor;
        private ColumnHeader Data;
        private ColumnHeader DurataOre;
        private ColumnHeader Status;
    }
}