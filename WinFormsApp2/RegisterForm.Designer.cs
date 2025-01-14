namespace WinFormsApp2
{
    partial class RegisterForm
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
            name = new Label();
            txtNume = new TextBox();
            txtCNP = new TextBox();
            label1 = new Label();
            txtPassword = new TextBox();
            Password = new Label();
            txtUsername = new TextBox();
            username = new Label();
            Subscription = new Label();
            cmbSub = new ComboBox();
            textBox1 = new TextBox();
            txtConfirmPassword = new Label();
            RegisterButton = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // name
            // 
            name.AutoSize = true;
            name.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            name.Location = new Point(308, 37);
            name.Name = "name";
            name.Size = new Size(154, 28);
            name.TabIndex = 0;
            name.Text = "Nume Complet";
            // 
            // txtNume
            // 
            txtNume.BorderStyle = BorderStyle.FixedSingle;
            txtNume.Location = new Point(314, 74);
            txtNume.Name = "txtNume";
            txtNume.Size = new Size(125, 27);
            txtNume.TabIndex = 1;
            // 
            // txtCNP
            // 
            txtCNP.BorderStyle = BorderStyle.FixedSingle;
            txtCNP.Location = new Point(314, 154);
            txtCNP.Name = "txtCNP";
            txtCNP.Size = new Size(125, 27);
            txtCNP.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(308, 117);
            label1.Name = "label1";
            label1.Size = new Size(52, 28);
            label1.TabIndex = 2;
            label1.Text = "CNP";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(314, 311);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 7;
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Password.Location = new Point(308, 280);
            Password.Name = "Password";
            Password.Size = new Size(72, 28);
            Password.TabIndex = 6;
            Password.Text = "Parola";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(314, 237);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(125, 27);
            txtUsername.TabIndex = 5;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // username
            // 
            username.AutoSize = true;
            username.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            username.Location = new Point(308, 200);
            username.Name = "username";
            username.Size = new Size(193, 28);
            username.TabIndex = 4;
            username.Text = "Nume de Utilizator";
            // 
            // Subscription
            // 
            Subscription.AutoSize = true;
            Subscription.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Subscription.Location = new Point(308, 433);
            Subscription.Name = "Subscription";
            Subscription.Size = new Size(212, 28);
            Subscription.TabIndex = 8;
            Subscription.Text = "Tipul Abonamentului";
            // 
            // cmbSub
            // 
            cmbSub.FormattingEnabled = true;
            cmbSub.Items.AddRange(new object[] { "Standard - 100 RON", "Premium - 150 RON" });
            cmbSub.Location = new Point(314, 464);
            cmbSub.Name = "cmbSub";
            cmbSub.Size = new Size(151, 28);
            cmbSub.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(314, 385);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 11;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.AutoSize = true;
            txtConfirmPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(308, 354);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(165, 28);
            txtConfirmPassword.TabIndex = 10;
            txtConfirmPassword.Text = "Confirma Parola";
            // 
            // RegisterButton
            // 
            RegisterButton.BackColor = Color.Navy;
            RegisterButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RegisterButton.ForeColor = SystemColors.ButtonHighlight;
            RegisterButton.Location = new Point(314, 509);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(137, 37);
            RegisterButton.TabIndex = 12;
            RegisterButton.Text = "Inregistrare";
            RegisterButton.UseVisualStyleBackColor = false;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Navy;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(24, 529);
            button1.Name = "button1";
            button1.Size = new Size(99, 40);
            button1.TabIndex = 13;
            button1.Text = "Inapoi";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 593);
            Controls.Add(button1);
            Controls.Add(RegisterButton);
            Controls.Add(textBox1);
            Controls.Add(txtConfirmPassword);
            Controls.Add(cmbSub);
            Controls.Add(Subscription);
            Controls.Add(txtPassword);
            Controls.Add(Password);
            Controls.Add(txtUsername);
            Controls.Add(username);
            Controls.Add(txtCNP);
            Controls.Add(label1);
            Controls.Add(txtNume);
            Controls.Add(name);
            Name = "RegisterForm";
            Text = "RegisterForm";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label name;
        private TextBox txtNume;
        private TextBox txtCNP;
        private Label label1;
        private TextBox txtPassword;
        private Label Password;
        private TextBox txtUsername;
        private Label username;
        private Label Subscription;
        private ComboBox cmbSub;
        private TextBox textBox1;
        private Label txtConfirmPassword;
        private Button RegisterButton;
        private Button button1;
    }
}