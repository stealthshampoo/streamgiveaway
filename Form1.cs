using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace StreamGiveaway
{
    public partial class InputForm : Form
    {
        private bool file_loaded_custom;
        private bool file_loaded_ignore;

        private OpenFileDialog dialog;

        private string custom_filename;
        private string ignore_filename;

        public InputForm()
        {
            InitializeComponent();
            this.FormClosing += Form1_SaveData;

            file_loaded_custom = false;
            file_loaded_ignore = false;

            dialog = new OpenFileDialog();
            dialog.Title = "Load a text file with Twitch usernames";
            dialog.InitialDirectory = ".";

            Form1_ReadData();
        }

        /*
         * Username, client_id, and access token are saved in StreamGiveaway in AppData.
         * They are loaded at startup if it's been saved before.
         */
        private void Form1_ReadData()
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (File.Exists(Path.Combine(appdata, "StreamGiveaway", "giveaway.conf")))
            {
                string[] lines;
                try
                {
                    lines = File.ReadAllLines(Path.Combine(appdata, "StreamGiveaway", "giveaway.conf"));
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                foreach (string line in lines)
                {
                    string[] tokens = line.Split(new char[] { '=' });
                    if (tokens.Length > 1)
                    {
                        if (tokens[0].Equals("username"))
                            usernameInput.Text = tokens[1];
                        else if (tokens[0].Equals("client_id"))
                            clientInput.Text = tokens[1];
                        else if (tokens[0].Equals("access_token"))
                            accessInput.Text = tokens[1];
                    }
                }
            }
        }

        private void Form1_SaveData(object sender, EventArgs e)
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(Path.Combine(appdata, "StreamGiveaway")))
            {
                Directory.CreateDirectory(Path.Combine(appdata, "StreamGiveaway"));
            }

            string[] data =
            {
                string.Format("username={0}", usernameInput.Text),
                string.Format("client_id={0}", clientInput.Text),
                string.Format("access_token={0}", accessInput.Text)
            };

            try
            {
                string filepath = Path.Combine(appdata, "StreamGiveaway", "giveaway.conf");
                File.WriteAllLines(filepath, data);
            }
            catch (IOException ex)
            {
                Console.Write(ex.Message);
            }
        }

        // Form reappears when giveaway window is closed.
        private void Form1_Reset(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                this.Show();
            }
        }

        // Reads usernames entered in the text boxes.
        private List<string> readTextBoxInput(RichTextBox box, Giveaway giveaway)
        {
            List<string> users = new List<string>();

            string[] lines = box.Lines;
            foreach (string line in lines)
            {
                string name;
                try
                {
                    name = giveaway.request.getDisplayName(line.ToLower());
                    users.Add(name);
                }
                catch (WebException)
                {
                    MessageBox.Show(string.Format("Invalid username \"{0}\".", line), "Giveaway Error.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }

            return users;
        }

        // Reads usernames written in text files.
        private List<string> readFileInput(string filename, Giveaway giveaway)
        {
            List<string> users = new List<string>();

            string[] lines;
            try
            {
                lines = File.ReadAllLines(filename);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "GiveawayError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            foreach (string line in lines)
            {
                string name;
                try
                {
                    name = giveaway.request.getDisplayName(line.ToLower());
                    users.Add(name);
                }
                catch (WebException)
                {
                    MessageBox.Show(string.Format("Invalid username \"{0}\".", line), "Giveaway Error.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }

            return users;
        }

        private List<string> loadCustomUsers(Giveaway giveaway)
        {
            List<string> custom_users = new List<string>();

            if (customButtonInput.Checked)
            {
                if (!string.IsNullOrEmpty(customInput.Text))
                    custom_users = this.readTextBoxInput(customInput, giveaway);
            }
            else if (customButtonText.Checked && file_loaded_custom)
            {
                custom_users = this.readFileInput(custom_filename, giveaway);
            }

            return custom_users;
        }

        private List<string> loadIgnoredUsers(Giveaway giveaway)
        {
            List<string> ignored_users = new List<string>();

            if (ignoreButtonInput.Checked)
            {
                if (!string.IsNullOrEmpty(ignoreInput.Text))
                    ignored_users = this.readTextBoxInput(ignoreInput, giveaway);
            }
            else if (ignoreButtonText.Checked && file_loaded_ignore)
            {
                ignored_users = this.readFileInput(ignore_filename, giveaway);
            }

            return ignored_users;
        }

        private int checkErrors()
        {
            if (!subBox.Checked && !followBox.Checked && !chatBox.Checked)
            {
                if ((customButtonInput.Checked && string.IsNullOrEmpty(customInput.Text)) ||
                    customButtonText.Checked && !file_loaded_custom)
                {
                    MessageBox.Show("Giveaway requires at least one option selected or custom users entered.",
                        "Giveaway Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 1;
                }
            }

            if (string.IsNullOrEmpty(usernameInput.Text) || 
                string.IsNullOrEmpty(clientInput.Text) || 
                string.IsNullOrEmpty(accessInput.Text))
            {
                MessageBox.Show("Missing user information.", "Giveaway Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }

            return 0;
        }

        /*
         * Assuming no errors, this creates the giveaway userlist and starts the giveaway window
         * All API calls are done here, so any updates will require the giveaway window to be closed
         * and reopened.
         * 
         * Any errors on reading the custom and ignore userlists prevent the giveaway window
         * from opening. Wrong user/client/access data is not checked yet.
         */
        private void buttonGo_Click(object sender, EventArgs e)
        {            
            if (this.checkErrors() == 0)
            {
                buttonGo.Enabled = false;

                string username = usernameInput.Text.ToLower();
                string client_id = clientInput.Text.ToLower();
                string access_token = accessInput.Text.ToLower();

                Giveaway giveaway = new Giveaway(client_id, access_token);

                List<string> blacklist;
                List<string> custom;

                try
                {
                    custom = this.loadCustomUsers(giveaway);
                }
                catch (WebException)
                {
                    return;
                }

                try
                {
                    blacklist = this.loadIgnoredUsers(giveaway);
                }
                catch (WebException)
                {
                    return;
                }

                if (streamerIgnoreBox.Checked)
                    blacklist.Add(giveaway.request.getDisplayName(username));

                giveaway.addCustom(custom);

                if (subBox.Checked)
                    giveaway.addSubscribers(username, blacklist);
                if (followBox.Checked)
                    giveaway.addFollowers(username, blacklist);
                if (chatBox.Checked)
                    giveaway.addChat(username, blacklist, modIgnoreBox.Checked);
 
                giveaway.window.FormClosed += new FormClosedEventHandler(Form1_Reset);
                this.Hide();
                buttonGo.Enabled = true;

                giveaway.initialize();
            }
        }

        private void chatBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chatBox.Checked)
            {
                modIgnoreBox.Enabled = true;
            }

            else
            {
                modIgnoreBox.Enabled = false;
            }
        }

        private void customButtonInput_CheckedChanged(object sender, EventArgs e)
        {
            if (customButtonInput.Checked)
            {
                customInput.Enabled = true;
            }

            else
            {
                customInput.Enabled = false;
            }
        }

        private void ignoreButtonInput_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreButtonInput.Checked)
                ignoreInput.Enabled = true;
            else
                ignoreInput.Enabled = false;
        }

        private void customButtonText_CheckedChanged(object sender, EventArgs e)
        {
            if (customButtonText.Checked)
                customFileButton.Enabled = true;
            else
                customFileButton.Enabled = false;
        }

        private void ignoreButtonText_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreButtonText.Checked)
                ignoreFileButton.Enabled = true;
            else
                ignoreFileButton.Enabled = false;
        }

        private void customFileButton_Click(object sender, EventArgs e)
        {
            if (this.dialog.ShowDialog() == DialogResult.OK)
            {
                this.custom_filename = dialog.FileName;
                this.file_loaded_custom = true;
                customFileButton.Text = "Loaded";
            }
        }

        private void ignoreFileButton_Click(object sender, EventArgs e)
        {
            if (this.dialog.ShowDialog() == DialogResult.OK)
            {
                this.ignore_filename = dialog.FileName;
                this.file_loaded_ignore = true;
                ignoreFileButton.Text = "Loaded";
            }
        }
    }
}
