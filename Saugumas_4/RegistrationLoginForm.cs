using System;
using System.Windows.Forms;

namespace Saugumas_4
{
    public partial class RegistrationLoginForm : Form
    {
        private User user;
        public RegistrationLoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User(nameTextBox.Text, passwordTextBox.Text);
                user.SetAccountPassword(BCrypt.Net.BCrypt.HashPassword(passwordTextBox.Text));
                Console.WriteLine(user.ToString());

                FileManager fileManager = new FileManager();
                fileManager.WriteAFile(Naming.GetPathTxt(user.GetUsername()), user.ToString());
                FileEncryptionTool.EncryptCombo(Naming.GetPathTxt(user.GetUsername()));

                MessageBox.Show("Pavyko prisiregistruoti");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                MessageBox.Show(exc.Message);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                FileManager fileManager = new FileManager();
                FileEncryptionTool.DecryptCombo(Naming.GetPathAes(nameTextBox.Text));
                string[] data = fileManager.ReadFile(Naming.GetPathTxt(nameTextBox.Text));
                user = UserStringConverter.GetStringToUser(data);

                if (!BCrypt.Net.BCrypt.Verify(passwordTextBox.Text, user.GetAccountPassword()))
                    throw new Exception("Slaptazodziai nesutampa");

                Form form = new ManagementForm(user);
                form.ShowDialog();
            }
            catch (Exception exc)
            {
                if (user != null)
                    FileEncryptionTool.EncryptCombo(Naming.GetPathTxt(user.GetUsername()));
                MessageBox.Show(exc.Message);
            }
        }
    }
}
