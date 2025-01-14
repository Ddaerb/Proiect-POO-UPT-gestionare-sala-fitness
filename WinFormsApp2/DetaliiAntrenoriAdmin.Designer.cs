namespace WinFormsApp2
{
    partial class DetaliiAntrenoriAdmin
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
            components = new System.ComponentModel.Container();
            listView1 = new ListView();
            NumeComplet = new ColumnHeader();
            Specializare = new ColumnHeader();
            NrMaxClienti = new ColumnHeader();
            OrarPrestabilit = new ColumnHeader();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            bindingSource1 = new BindingSource(components);
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { NumeComplet, Specializare, NrMaxClienti, OrarPrestabilit });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(252, 21);
            listView1.Name = "listView1";
            listView1.Size = new Size(510, 402);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // NumeComplet
            // 
            NumeComplet.Text = "Nume Complet";
            NumeComplet.Width = 150;
            // 
            // Specializare
            // 
            Specializare.Text = "Specializare";
            Specializare.Width = 120;
            // 
            // NrMaxClienti
            // 
            NrMaxClienti.Text = "Nr. Max. Clienti";
            NrMaxClienti.Width = 120;
            // 
            // OrarPrestabilit
            // 
            OrarPrestabilit.Text = "Orar";
            OrarPrestabilit.Width = 100;
            // 
            // button1
            // 
            button1.BackColor = Color.Indigo;
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(40, 21);
            button1.Name = "button1";
            button1.Size = new Size(181, 41);
            button1.TabIndex = 1;
            button1.Text = "Adauga Antrenor";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.MediumVioletRed;
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(40, 68);
            button2.Name = "button2";
            button2.Size = new Size(181, 41);
            button2.TabIndex = 2;
            button2.Text = "Sterge Antrenor";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Navy;
            button3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(40, 359);
            button3.Name = "button3";
            button3.Size = new Size(105, 46);
            button3.TabIndex = 3;
            button3.Text = "Inapoi";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Indigo;
            button4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Location = new Point(40, 115);
            button4.Name = "button4";
            button4.Size = new Size(181, 41);
            button4.TabIndex = 4;
            button4.Text = "Cauta Antrenor";
            button4.UseVisualStyleBackColor = false;
            // 
            // DetaliiAntrenoriAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Name = "DetaliiAntrenoriAdmin";
            Text = "DetaliiAntrenoriAdmin";
            Load += DetaliiAntrenoriAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private BindingSource bindingSource1;
        private Button button4;
        private ColumnHeader NumeComplet;
        private ColumnHeader Specializare;
        private ColumnHeader NrMaxClienti;
        private ColumnHeader OrarPrestabilit;
    }
}