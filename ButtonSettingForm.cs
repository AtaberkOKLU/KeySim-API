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
        private static readonly ComboBoxItem[] mouseActionsList = new ComboBoxItem[] {
            new ComboBoxItem("Right Click", new ComboBoxItem.ValueStructure(0x00, 0x01, 0x00) ),
            new ComboBoxItem("Left Click", new ComboBoxItem.ValueStructure(0x00, 0x02, 0x00) )
        };       

        private static readonly ComboBoxItem[] keyboardActionsList = new ComboBoxItem[] {
            new ComboBoxItem("A", new ComboBoxItem.ValueStructure(0x01, 0x02, 0x04) ),
            new ComboBoxItem("B", new ComboBoxItem.ValueStructure(0x01, 0x02, 0x05) ),
            new ComboBoxItem("C", new ComboBoxItem.ValueStructure(0x01, 0x02, 0x06) ),

            new ComboBoxItem("a", new ComboBoxItem.ValueStructure(0x01, 0x00, 0x04) ),
            new ComboBoxItem("b", new ComboBoxItem.ValueStructure(0x01, 0x00, 0x05) ),
            new ComboBoxItem("c", new ComboBoxItem.ValueStructure(0x01, 0x00, 0x06) ),

            new ComboBoxItem("DEL", new ComboBoxItem.ValueStructure(0x01, 0x00, 0x4C) ),
            new ComboBoxItem("BACKSPACE", new ComboBoxItem.ValueStructure(0x01, 0x00, 0x2A) ),
            new ComboBoxItem("SPACE", new ComboBoxItem.ValueStructure(0x01, 0x00, 0x2C) )
        };

        private static readonly object[] customFunctionList = new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"
        };

        public ButtonSettingForm(Int16 buttonNumber)
        {
            InitializeComponent(buttonNumber);
        }

        private void Function_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cmb = (ComboBox)sender;

            ValueComboBox.Items.Clear();

            if (cmb.SelectedItem.ToString() == "Mouse")
                ValueComboBox.Items.AddRange(mouseActionsList);
            else if (cmb.SelectedItem.ToString() == "Keyboard")
                ValueComboBox.Items.AddRange(keyboardActionsList);
            else
                ValueComboBox.Items.AddRange(customFunctionList);

        }
    }
}
