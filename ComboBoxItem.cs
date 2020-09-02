using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeySim_API
{
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public struct ValueStructure
        {
            public ValueStructure(Byte reportID, Byte byte1, Byte byte2)
            {
                ReportID    = reportID;
                Byte1 = byte1;
                Byte2       = byte2;
            }

            public Byte ReportID { get; set; }
            public Byte Byte1 { get; set; }
            public Byte Byte2 { get; set; }

        }

        public ValueStructure Value { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public ComboBoxItem(string text, ValueStructure value)
        {
            this.Text = text;
            this.Value = value;
        }
    }
}
