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
        public int UniqueID { get; set; }   // ArrayID for MCU
        public string Name { get; set; }
        public int ReportID { get; set; }   // Keyboard (0x01)  | Mouse (0x02)
        public int Byte1 { get; set; }      // Modifier Byte    | Button Byte
        public int Byte2 { get; set; }      // KeyCode 1        | NONE

        /*
        public KeyClass(char UniqueID, string Name, char ReportID, char Byte1 , char Byte2)
        {
            this.UniqueID   = UniqueID;
            this.Name       = Name;
            this.ReportID   = ReportID;
            this.Byte1      = Byte1;
            this.Byte2      = Byte2;
        }
        */
    }
}

