using System;
using System.Windows.Forms;

namespace Saugumas_4
{
    public partial class PasswordBaseForm : Form
    {
        protected User user;
        public PasswordBaseForm()
        {
            InitializeComponent();
        }

        public PasswordBaseForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                string password = EncryptionTool.Encrypt(passwordTextBox.Text);
                user.AddPassword(new PasswordEntry(
                    titleTextBox.Text, password, urlTextBox.Text, commentTextBox.Text));

                MessageBox.Show("Pavyko pridėti slaptažodį");
                ClearFields();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void generationButton_Click(object sender, EventArgs e)
        {
            passwordTextBox.Text = EncryptionTool.GeneratePassword();
        }

        protected void ClearFields()
        {
            titleTextBox.Text = "";
            passwordTextBox.Text = "";
            urlTextBox.Text = "";
            commentTextBox.Text = "";
        }

        private void PasswordBaseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
