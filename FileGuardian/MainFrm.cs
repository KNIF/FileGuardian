using System;
using System.Windows.Forms;
using System.IO;

namespace FileGuardian
{
    public partial class MainFrm : Form
    {
        string password = string.Empty;

        public MainFrm() {
            InitializeComponent();
        }

        private void refreshFiles() {
            files.Items.Clear();
            string[] allFiles = Directory.GetFiles(Application.StartupPath + @"\Files");
            for (int i = 0; i < allFiles.Length; i++) {
                files.Items.Add(new ListViewItem {
                    Text = Path.GetFileName(allFiles[i]),
                    SubItems = {
                        Path.GetExtension(allFiles[i]).Substring(1),
                        getFileSize(allFiles[i])
                    },
                });
            }
        }

        private static string getFileSize(string filename) {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = new FileInfo(filename).Length;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1) {
                order++;
                len = len / 1024;
            }
            return String.Format("{0:0.##} {1}", len, sizes[order]);
        }

        private void files_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                if (files.FocusedItem.Bounds.Contains(e.Location))
                    contextMenuStrip1.Show(Cursor.Position);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            if (e.ClickedItem == encryptToolStripMenuItem) {
                contextMenuStrip1.Hide();

                if (files.FocusedItem.Text.Contains(".crypt"))
                    MessageBox.Show("Can only encrypt not already encrypted files.", "FileGuardian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else {
                    try {
                        FileEncryption.EncryptFile(Application.StartupPath + @"\Files\" + files.FocusedItem.Text,
                            Application.StartupPath + @"\Files\" + files.FocusedItem.Text + ".crypt", password,
                            FileEncryption.salt, FileEncryption.repeat);
                        File.Delete(Application.StartupPath + @"\Files\" + files.FocusedItem.Text);
                    }
                    catch {
                        MessageBox.Show("Failed to encrypt " + files.FocusedItem.Text, "FileGuardian",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        refreshFiles();
                        return;
                    }

                    MessageBox.Show("Encrypted " + files.FocusedItem.Text, "FileGuardian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshFiles();
                }
            }
            else if (e.ClickedItem == decryptToolStripMenuItem) {
                contextMenuStrip1.Hide();

                if (!files.FocusedItem.Text.Contains(".crypt"))
                    MessageBox.Show("Can only decrypt encryped files.", "FileGuardian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else {
                    try {
                        FileEncryption.DecryptFile(Application.StartupPath + @"\Files\" + files.FocusedItem.Text,
                            Application.StartupPath + @"\Files\" +
                            files.FocusedItem.Text.Replace(".crypt", string.Empty), password, FileEncryption.salt,
                            FileEncryption.repeat);
                        File.Delete(Application.StartupPath + @"\Files\" + files.FocusedItem.Text);
                    }
                    catch {
                        MessageBox.Show("Failed to decrypt " + files.FocusedItem.Text, "FileGuardian",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        refreshFiles();
                        return;
                    }

                    MessageBox.Show("Decrypted " + files.FocusedItem.Text, "FileGuardian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshFiles();
                }
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            try {
                password = File.ReadAllText("password.ini");
            }
            catch {
                MessageBox.Show("Please enter your password in password.ini", "FileGuardian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            refreshFiles();
        }
    }
}
