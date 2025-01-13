namespace WinFormsApp2
{
    partial class PaginaPrincipala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaginaPrincipala));
            ToLoginButton = new Button();
            ToRegisterButton = new Button();
            ExitButton = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ToLoginButton
            // 
            ToLoginButton.BackColor = Color.Navy;
            ToLoginButton.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ToLoginButton.ForeColor = SystemColors.ButtonFace;
            ToLoginButton.Location = new Point(335, 217);
            ToLoginButton.Name = "ToLoginButton";
            ToLoginButton.Size = new Size(152, 47);
            ToLoginButton.TabIndex = 0;
            ToLoginButton.Text = "Autentificare";
            ToLoginButton.UseVisualStyleBackColor = false;
            ToLoginButton.Click += ToLoginButton_Click;
            // 
            // ToRegisterButton
            // 
            ToRegisterButton.BackColor = Color.Navy;
            ToRegisterButton.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            ToRegisterButton.ForeColor = SystemColors.ButtonFace;
            ToRegisterButton.Location = new Point(335, 270);
            ToRegisterButton.Name = "ToRegisterButton";
            ToRegisterButton.Size = new Size(152, 50);
            ToRegisterButton.TabIndex = 1;
            ToRegisterButton.Text = "Inregistrare";
            ToRegisterButton.UseVisualStyleBackColor = false;
            ToRegisterButton.Click += ToRegisterButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.BackColor = Color.Navy;
            ExitButton.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExitButton.ForeColor = SystemColors.ButtonHighlight;
            ExitButton.Location = new Point(347, 326);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(124, 46);
            ExitButton.TabIndex = 2;
            ExitButton.Text = "Iesire";
            ExitButton.UseVisualStyleBackColor = false;
            ExitButton.Click += ExitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ink Free", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(314, 177);
            label1.Name = "label1";
            label1.Size = new Size(200, 37);
            label1.TabIndex = 3;
            label1.Text = "Bine ai venit!";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(347, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 119);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // PaginaPrincipala
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(ExitButton);
            Controls.Add(ToRegisterButton);
            Controls.Add(ToLoginButton);
            Name = "PaginaPrincipala";
            Text = "PaginaPrincipala";
            Load += PaginaPrincipala_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ToLoginButton;
        private Button ToRegisterButton;
        private Button ExitButton;
        private Label label1;
        private PictureBox pictureBox1;
    }
}