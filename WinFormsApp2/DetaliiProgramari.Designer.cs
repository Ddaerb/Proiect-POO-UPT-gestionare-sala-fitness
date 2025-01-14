namespace WinFormsApp2
{
    partial class DetaliiProgramari
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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            button3 = new Button();
            button4 = new Button();
            listView1 = new ListView();
            Antrenor = new ColumnHeader();
            Specializare = new ColumnHeader();
            Data = new ColumnHeader();
            Ore = new ColumnHeader();
            Status = new ColumnHeader();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Navy;
            button1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(62, 65);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(219, 65);
            button1.TabIndex = 0;
            button1.Text = "Adauga Programare";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.MediumSlateBlue;
            button2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(21, 523);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(131, 51);
            button2.TabIndex = 14;
            button2.Text = "Inapoi";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(342, 503);
            label1.Name = "label1";
            label1.Size = new Size(527, 50);
            label1.TabIndex = 15;
            label1.Text = "Daca depasiti orele [din cod], se adauga o \r\n                              taxa de penalizare de x RON/ora!!!";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(220, 495);
            label2.Name = "label2";
            label2.Size = new Size(116, 35);
            label2.TabIndex = 16;
            label2.Text = "ATENTIE!";
            // 
            // button3
            // 
            button3.BackColor = Color.DarkViolet;
            button3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ButtonFace;
            button3.Location = new Point(62, 264);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(219, 67);
            button3.TabIndex = 17;
            button3.Text = "Anuleaza Programare";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Indigo;
            button4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Location = new Point(62, 168);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(219, 61);
            button4.TabIndex = 18;
            button4.Text = "Modifica Programare";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { Antrenor, Specializare, Data, Ore, Status });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(325, 65);
            listView1.Margin = new Padding(3, 4, 3, 4);
            listView1.Name = "listView1";
            listView1.Size = new Size(564, 400);
            listView1.TabIndex = 19;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // Antrenor
            // 
            Antrenor.Text = "Antrenor";
            Antrenor.Width = 110;
            // 
            // Specializare
            // 
            Specializare.Text = "Specializare";
            Specializare.Width = 100;
            // 
            // Data
            // 
            Data.Text = "Data";
            Data.Width = 150;
            // 
            // Ore
            // 
            Ore.Text = "Ore";
            Ore.Width = 40;
            // 
            // Status
            // 
            Status.Text = "Status";
            Status.Width = 80;
            // 
            // DetaliiProgramari
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(listView1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DetaliiProgramari";
            Text = "DetaliiProgramari";
            Load += DetaliiProgramari_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Button button3;
        private Button button4;
        private ListView listView1;
        private ColumnHeader Antrenor;
        private ColumnHeader Specializare;
        private ColumnHeader Data;
        private ColumnHeader Ore;
        private ColumnHeader Status;
    }
}