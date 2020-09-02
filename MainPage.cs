using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeySim_API
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Key1_button_Click(object sender, EventArgs e)
        {
            Form ButtonSettingPage = new ButtonSettingForm(0);
            ButtonSettingPage.Show();
        }
    }
}
