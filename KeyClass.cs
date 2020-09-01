using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KeySim_API
{
    class KeyClass
    {
        public char UniqueID { get; set; }      // ArrayID for MCU
        public string Name { get; set; }
        public string ReportID { get; set; }    // Keyboard (0x01)  | Mouse (0x02)
        public char Byte1 { get; set; }         // Modifier Byte    | Button Byte
        public char Byte2 { get; set; }         // KeyCode 1        | NONE
        public KeyClass()
        {

        }
    }
}

