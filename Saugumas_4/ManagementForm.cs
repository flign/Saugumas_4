using System;
using System.Windows.Forms;

namespace Saugumas_4
{
    public partial class ManagementForm : Form
    {
        private User user;
        public ManagementForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void ManagementForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            FileManager fileManager = new FileManager();
            string data = user.ToString();
            Console.WriteLine(data);
            fileManager.WriteAFile(Naming.GetPathTxt(user.GetUsername()), data);
            FileEncryptionTool.EncryptCombo(Naming.GetPathTxt(user.GetUsername()));
            user = null;
        }

        private void addPasswordButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            Form form = new PasswordBaseForm(user) { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            flowLayoutPanel1.Controls.Add(form);
            form.Show();
        }

        private void manageButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            Form form = new PasswordManagementForm(user) {TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            flowLayoutPanel1.Controls.Add(form);
            form.Show();
        }

    }
}
