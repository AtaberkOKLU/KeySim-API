using System;
using System.IO.Ports;
using System.Management;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace KeySim_API
{
    public partial class ButtonSettingForm : Form
    {
        private static readonly ComboBoxItem[] mouseActionsList = new ComboBoxItem[] {
            new ComboBoxItem("Right Click", new ComboBoxItem.ValueStructure(0x02, 0x01, 0x00) ),
            new ComboBoxItem("Left Click", new ComboBoxItem.ValueStructure(0x02, 0x02, 0x00) )
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

        private readonly Int16 buttonNumber;

        public ButtonSettingForm(Int16 buttonNumber)
        {
            InitializeComponent(buttonNumber);
            this.buttonNumber = buttonNumber;
        }
        private void Function_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cmb = (ComboBox)sender;

            if (cmb.SelectedItem.ToString() == "Mouse")
                ValueComboBox.DataSource = mouseActionsList;
            else if (cmb.SelectedItem.ToString() == "Keyboard")
                ValueComboBox.DataSource = keyboardActionsList;
            else
                ValueComboBox.DataSource = customFunctionList;

        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open("C:/Users/ataberk.oklu/Documents/Keys.xlsx");
            Excel.Worksheet xlWorkSheet = xlWorkBook.Worksheets["Sheet1"];
            int SelectedRow = KeyList[buttonNumber].UniqueID + 2; // UniqueID + Header Row + ExcelIndexing
            ComboBoxItem SelectedKey = ValueComboBox.SelectedItem as ComboBoxItem;

            xlWorkSheet.Cells[SelectedRow, 2].value = name_textbox.Text;            // Name
            xlWorkSheet.Cells[SelectedRow, 3].value = SelectedKey.Value.ReportID;   // ReportID
            xlWorkSheet.Cells[SelectedRow, 4].value = SelectedKey.Value.Byte1;      // Byte1
            xlWorkSheet.Cells[SelectedRow, 5].value = SelectedKey.Value.Byte2;      // Byte2

            xlWorkBook.Close();
            xlApp.Quit();

            // CLEAN UP.
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);


            /*SerialPort _serialPort = new SerialPort("COM2", 115200, Parity.Even, 8, StopBits.One);
            _serialPort.Handshake = Handshake.None;

            Byte[] Key_UART_Frame = {
                KeyList[buttonNumber].UniqueID,
                SelectedKey.Value.ReportID,
                SelectedKey.Value.Byte1,
                SelectedKey.Value.Byte2
            };

            try
            {
                if (!(_serialPort.IsOpen))
                    _serialPort.Open();
                _serialPort.Write(Key_UART_Frame, 0, 4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");
            }*/


        }

    }
}
