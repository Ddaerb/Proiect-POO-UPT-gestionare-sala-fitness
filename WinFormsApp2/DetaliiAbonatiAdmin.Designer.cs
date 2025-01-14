namespace WinFormsApp2
{
    partial class DetaliiAbonatiAdmin
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
            NumeComplet = new ColumnHeader();
            CNP = new ColumnHeader();
            Username = new ColumnHeader();
            TipAbonament = new ColumnHeader();
            PretAbonament = new ColumnHeader();
            listView2 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.Navy;
            button3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(22, 362);
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
            button2.Location = new Point(22, 24);
            button2.Name = "button2";
            button2.Size = new Size(164, 41);
            button2.TabIndex = 6;
            button2.Text = "Sterge Abonat";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { NumeComplet, CNP, Username, TipAbonament, PretAbonament });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(205, 55);
            listView1.Name = "listView1";
            listView1.Size = new Size(572, 149);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // NumeComplet
            // 
            NumeComplet.Text = "Nume Complet";
            NumeComplet.Width = 150;
            // 
            // CNP
            // 
            CNP.Text = "CNP";
            CNP.Width = 130;
            // 
            // Username
            // 
            Username.Text = "Username";
            Username.Width = 110;
            // 
            // TipAbonament
            // 
            TipAbonament.Text = "Tip Abonament";
            TipAbonament.Width = 100;
            // 
            // PretAbonament
            // 
            PretAbonament.Text = "Pret Abonament";
            PretAbonament.Width = 100;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            listView2.FullRowSelect = true;
            listView2.Location = new Point(205, 252);
            listView2.Name = "listView2";
            listView2.Size = new Size(572, 156);
            listView2.TabIndex = 8;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Nume Complet";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "CNP";
            columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Username";
            columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Tip Abonament";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Pret Abonament";
            columnHeader5.Width = 100;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(205, 24);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 9;
            label1.Text = "Abonati Standard:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(205, 218);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 10;
            label2.Text = "Abonati Premium:";
            // 
            // DetaliiAbonatiAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listView1);
            Name = "DetaliiAbonatiAdmin";
            Text = "DetaliiAbonatiAdmin";
            Load += DetaliiAbonatiAdmin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button2;
        private ListView listView1;
        private ColumnHeader NumeComplet;
        private ColumnHeader CNP;
        private ColumnHeader Username;
        private ColumnHeader TipAbonament;
        private ColumnHeader PretAbonament;
        private ListView listView2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Label label1;
        private Label label2;
    }
}