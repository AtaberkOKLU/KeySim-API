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

        private void Key2_button_Click(object sender, EventArgs e)
        {
            Form ButtonSettingPage = new ButtonSettingForm(1);
            ButtonSettingPage.Show();
        }

        private void Key3_button_Click(object sender, EventArgs e)
        {
            Form ButtonSettingPage = new ButtonSettingForm(2);
            ButtonSettingPage.Show();
        }

        private void Key4_button_Click(object sender, EventArgs e)
        {
            Form ButtonSettingPage = new ButtonSettingForm(3);
            ButtonSettingPage.Show();
        }

        private void Key5_button_Click(object sender, EventArgs e)
        {
            Form ButtonSettingPage = new ButtonSettingForm(4);
            ButtonSettingPage.Show();
        }

        private void Key6_button_Click(object sender, EventArgs e)
        {
            Form ButtonSettingPage = new ButtonSettingForm(5);
            ButtonSettingPage.Show();
        }

        private void Key7_button_Click(object sender, EventArgs e)
        {
            Form ButtonSettingPage = new ButtonSettingForm(6);
            ButtonSettingPage.Show();
        }

        private void Key8_button_Click(object sender, EventArgs e)
        {
            Form ButtonSettingPage = new ButtonSettingForm(7);
            ButtonSettingPage.Show();
        }
    }
}
