namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginButton_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == null || username == "")
            {
                MessageBox.Show("Username is required");
            }

            if (password == null || password == "")
            {
                MessageBox.Show("Password is required");
            }
        }
    }
}
