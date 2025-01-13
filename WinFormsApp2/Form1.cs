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
                return;
            }

            if (password == null || password == "")
            {
                MessageBox.Show("Password is required");
                return;
            }

            AbonatManager abonatManager = new AbonatManager();
            AbonatStandard abonat = abonatManager.GasesteAbonatDupaUsername(username);
            if (abonat == null || abonat.Password != password) 
            {
                MessageBox.Show("Invalid username or password, please try again");
                return;
            }
            MessageBox.Show($"Hello, {abonat.NumeComplet}");
        }
    }
}
