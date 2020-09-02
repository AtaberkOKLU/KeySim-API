using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeySim_API
{
    public partial class ButtonSettingForm : Form
    {
        public ButtonSettingForm(Int16 buttonNumber)
        {
            InitializeComponent(buttonNumber);
        }

    }
}
