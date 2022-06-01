using System;
using System.Windows.Forms;

namespace Saugumas_4
{
    public partial class PasswordManagementForm : PasswordBaseForm
    {
        private PasswordEntry passwordEntry;
        public PasswordManagementForm()
        {
            InitializeComponent();
        }

        public PasswordManagementForm(User user) : base(user)
        {
            InitializeComponent();
            DisableFields();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                passwordEntry = user.GetPasswordEntry(titleTextBox.Text);
                if (passwordEntry == null)
                    throw new Exception("Nepavyko rasti tokio slaptažodžio");

                passwordTextBox.Text = passwordEntry.Password;
                urlTextBox.Text = passwordEntry.Url;
                commentTextBox.Text = passwordEntry.Comment;
                EnableFields();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(EncryptionTool.Decrypt(passwordEntry.Password));
        }

        private void generationButton_Click(object sender, EventArgs e)
        {
            passwordTextBox.Text = EncryptionTool.GeneratePassword();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                user.RemovePassword(passwordEntry.Title);
                MessageBox.Show("Pavyko ištrintin slaptažodį");
                
                ClearFields();
                DisableFields();
                passwordEntry = null;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (passwordEntry == null)
                    return;

                string decrypted = EncryptionTool.Decrypt(passwordEntry.Password);
                string password = passwordEntry.Password;
                if (passwordTextBox.Text != password && passwordTextBox.Text != decrypted)
                {
                    password = passwordTextBox.Text;
                    password = EncryptionTool.Encrypt(password);
                }


                    PasswordEntry pe = new PasswordEntry(
                        titleTextBox.Text, password, urlTextBox.Text, commentTextBox.Text);
                user.UpdatePassword(passwordEntry.Title, pe);

                MessageBox.Show("Pavyko atnaujinti slaptažodį");
                ClearFields();
                DisableFields();
                passwordEntry = null;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void DisableFields()
        {
            passwordTextBox.Enabled = false;
            urlTextBox.Enabled = false;
            commentTextBox.Enabled = false;
            showButton.Enabled = false;
            copyButton.Enabled = false;
            generationButton.Enabled = false;
            deleteButton.Enabled = false;
            updateButton.Enabled = false;
        }

        private void EnableFields()
        {
            passwordTextBox.Enabled = true;
            urlTextBox.Enabled = true;
            commentTextBox.Enabled = true;
            showButton.Enabled = true;
            copyButton.Enabled = true;
            generationButton.Enabled = true;
            deleteButton.Enabled = true;
            updateButton.Enabled = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (passwordEntry == null)
                return;

            if (passwordEntry.Password != passwordTextBox.Text)
                return;

            string password = EncryptionTool.Decrypt(passwordEntry.Password);
            passwordTextBox.Text = password;
        }
    }
}
