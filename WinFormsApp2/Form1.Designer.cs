namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Username = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            LoginButton = new Button();
            label2 = new Label();
            RegisterButton = new Button();
            button1 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Username.Location = new Point(303, 107);
            Username.Name = "Username";
            Username.Size = new Size(193, 28);
            Username.TabIndex = 0;
            Username.Text = "Nume de Utilizator";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(303, 138);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(178, 27);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(303, 204);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(178, 27);
            txtPassword.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(303, 173);
            label1.Name = "label1";
            label1.Size = new Size(72, 28);
            label1.TabIndex = 2;
            label1.Text = "Parola";
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.Navy;
            LoginButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginButton.ForeColor = SystemColors.ButtonHighlight;
            LoginButton.Location = new Point(303, 255);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(178, 48);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "Autentificare";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(346, 318);
            label2.Name = "label2";
            label2.Size = new Size(96, 17);
            label2.TabIndex = 5;
            label2.Text = "*Nu aveti cont?";
            // 
            // RegisterButton
            // 
            RegisterButton.BackColor = Color.Navy;
            RegisterButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RegisterButton.ForeColor = SystemColors.ButtonHighlight;
            RegisterButton.Location = new Point(346, 338);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(96, 34);
            RegisterButton.TabIndex = 6;
            RegisterButton.Text = "Inregistrare";
            RegisterButton.UseVisualStyleBackColor = false;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Navy;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(23, 388);
            button1.Name = "button1";
            button1.Size = new Size(99, 40);
            button1.TabIndex = 7;
            button1.Text = "Inapoi";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.CornflowerBlue;
            label3.Location = new Point(23, 18);
            label3.Name = "label3";
            label3.Size = new Size(171, 20);
            label3.TabIndex = 8;
            label3.Text = "Pagina de autentificare";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(RegisterButton);
            Controls.Add(label2);
            Controls.Add(LoginButton);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Controls.Add(txtUsername);
            Controls.Add(Username);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Username;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label1;
        private Button LoginButton;
        private Label label2;
        private Button RegisterButton;
        private Button button1;
        private Label label3;
    }
}
