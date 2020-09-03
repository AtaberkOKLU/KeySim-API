using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace KeySim_API
{
    partial class ButtonSettingForm
    {
        private static DataTable ReadExcelFile(string sheetName, string path)
        {
            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                string Import_FileName = path;
                string fileExtension = Path.GetExtension(Import_FileName);
                if (fileExtension == ".xls")
                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                if (fileExtension == ".xlsx")
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [" + sheetName + "$]";
                    comm.Connection = conn;
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private static readonly DataTable dataTable1= ReadExcelFile("Sheet1", "C:/Users/ataberk.oklu/Documents/Keys.xlsx");
        
        public object[] ValueComboBoxList = new object[] { };

        List<KeyClass> KeyList = dataTable1.AsEnumerable().Select(row =>
           new KeyClass {
               UniqueID = Convert.ToByte(row[0]),
               Name     = Convert.ToString(row[1]),
               ReportID = Convert.ToByte(row[2]),
               Byte1    = Convert.ToByte(row[3]),
               Byte2    = Convert.ToByte(row[4])
           }).ToList();

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(Int16 buttonNumber)
        {
            this.name_label = new System.Windows.Forms.Label();
            this.function_label = new System.Windows.Forms.Label();
            this.name_textbox = new System.Windows.Forms.TextBox();
            this.function_combobox = new System.Windows.Forms.ComboBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ValueComboBox = new System.Windows.Forms.ComboBox();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(58, 50);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(38, 13);
            this.name_label.TabIndex = 0;
            this.name_label.Text = "Name:";
            // 
            // function_label
            // 
            this.function_label.AutoSize = true;
            this.function_label.Location = new System.Drawing.Point(58, 133);
            this.function_label.Name = "function_label";
            this.function_label.Size = new System.Drawing.Size(51, 13);
            this.function_label.TabIndex = 1;
            this.function_label.Text = "Function:";
            // 
            // name_textbox
            // 
            this.name_textbox.Location = new System.Drawing.Point(144, 47);
            this.name_textbox.Name = "name_textbox";
            this.name_textbox.Size = new System.Drawing.Size(167, 20);
            this.name_textbox.TabIndex = 2;
            this.name_textbox.Text = KeyList[buttonNumber].Name;
            // 
            // function_combobox
            // 
            this.function_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.function_combobox.Items.AddRange(new object[] {
            "Custom",
            "Keyboard",
            "Mouse"});
            this.function_combobox.SelectedIndex = KeyList[buttonNumber].ReportID;
            this.function_combobox.Location = new System.Drawing.Point(144, 130);
            this.function_combobox.Name = "function_combobox";
            this.function_combobox.Size = new System.Drawing.Size(166, 21);
            this.function_combobox.TabIndex = 3;
            this.function_combobox.SelectedIndexChanged += new System.EventHandler(this.Function_combobox_SelectedIndexChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(166, 342);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(102, 47);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // ValueComboBox
            // 
            this.ValueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ValueComboBox.FormattingEnabled = true;
            this.ValueComboBox.Location = new System.Drawing.Point(145, 215);
            this.ValueComboBox.Name = "ValueComboBox";
            this.ValueComboBox.Size = new System.Drawing.Size(166, 21);
            this.ValueComboBox.TabIndex = 5;
            if(KeyList[buttonNumber].ReportID == 0x01) 
                this.ValueComboBox.DataSource = keyboardActionsList;
            else if (KeyList[buttonNumber].ReportID == 0x02)
                this.ValueComboBox.DataSource = mouseActionsList;
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(59, 218);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(37, 13);
            this.ValueLabel.TabIndex = 6;
            this.ValueLabel.Text = "Value:";
            // 
            // ButtonSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 450);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.ValueComboBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.function_combobox);
            this.Controls.Add(this.name_textbox);
            this.Controls.Add(this.function_label);
            this.Controls.Add(this.name_label);
            this.Name = "ButtonSettingForm";
            this.Text = "ButtonSettingForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label function_label;
        private System.Windows.Forms.TextBox name_textbox;
        private System.Windows.Forms.ComboBox function_combobox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ComboBox ValueComboBox;
        private System.Windows.Forms.Label ValueLabel;
    }
}