namespace WinFormsApp2
{
    partial class DetaliiCont
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
            label1 = new Label();
            txtNumeComplet = new Label();
            txtNumeUtilizator = new Label();
            txtCNP = new Label();
            txtTipAbonament = new Label();
            txtPretAbonament = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Algerian", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(301, 40);
            label1.Name = "label1";
            label1.Size = new Size(329, 34);
            label1.TabIndex = 0;
            label1.Text = "BINE AI VENIT, USER!!!";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // txtNumeComplet
            // 
            txtNumeComplet.AutoSize = true;
            txtNumeComplet.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNumeComplet.Location = new Point(48, 135);
            txtNumeComplet.Name = "txtNumeComplet";
            txtNumeComplet.Size = new Size(143, 25);
            txtNumeComplet.TabIndex = 1;
            txtNumeComplet.Text = "Nume Complet:\r\n";
            // 
            // txtNumeUtilizator
            // 
            txtNumeUtilizator.AutoSize = true;
            txtNumeUtilizator.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNumeUtilizator.Location = new Point(48, 167);
            txtNumeUtilizator.Name = "txtNumeUtilizator";
            txtNumeUtilizator.Size = new Size(175, 25);
            txtNumeUtilizator.TabIndex = 2;
            txtNumeUtilizator.Text = "Nume de Utilizator:";
            // 
            // txtCNP
            // 
            txtCNP.AutoSize = true;
            txtCNP.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCNP.Location = new Point(48, 199);
            txtCNP.Name = "txtCNP";
            txtCNP.Size = new Size(53, 25);
            txtCNP.TabIndex = 3;
            txtCNP.Text = "CNP:";
            // 
            // txtTipAbonament
            // 
            txtTipAbonament.AutoSize = true;
            txtTipAbonament.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTipAbonament.Location = new Point(48, 232);
            txtTipAbonament.Name = "txtTipAbonament";
            txtTipAbonament.Size = new Size(145, 25);
            txtTipAbonament.TabIndex = 4;
            txtTipAbonament.Text = "Tip Abonament:";
            // 
            // txtPretAbonament
            // 
            txtPretAbonament.AutoSize = true;
            txtPretAbonament.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPretAbonament.Location = new Point(48, 265);
            txtPretAbonament.Name = "txtPretAbonament";
            txtPretAbonament.Size = new Size(153, 25);
            txtPretAbonament.TabIndex = 5;
            txtPretAbonament.Text = "Pret Abonament:";
            // 
            // button1
            // 
            button1.BackColor = Color.CornflowerBlue;
            button1.Font = new Font("Century", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(29, 524);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(115, 47);
            button1.TabIndex = 6;
            button1.Text = "Inapoi";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Navy;
            button2.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(330, 389);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(235, 77);
            button2.TabIndex = 7;
            button2.Text = "Schimba Parola";
            button2.UseVisualStyleBackColor = false;
            // 
            // DetaliiCont
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtPretAbonament);
            Controls.Add(txtTipAbonament);
            Controls.Add(txtCNP);
            Controls.Add(txtNumeUtilizator);
            Controls.Add(txtNumeComplet);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DetaliiCont";
            Text = "DetaliiCont";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label txtNumeComplet;
        private Label txtNumeUtilizator;
        private Label txtCNP;
        private Label txtTipAbonament;
        private Label txtPretAbonament;
        private Button button1;
        private Button button2;
    }
}