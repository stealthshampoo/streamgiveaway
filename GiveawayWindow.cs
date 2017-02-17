using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamGiveaway
{
    public partial class GiveawayWindow : Form
    {
        public GiveawayWindow()
        {
            InitializeComponent();
        }

        public void changeNameLabel(string username)
        {
            nameLabel.Text = username;
        }
    }
}
