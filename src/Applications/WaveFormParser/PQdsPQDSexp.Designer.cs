//Copyright © 2019 Electric Power Research Institute, Inc. All rights reserved.
//
//Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met: 
//  Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//  Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
//  Neither the name of the EPRI nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
// 

namespace PQio
{
    partial class PQdsPQDSexp
    {
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PQdsPQDSexp));
            this.chLstBoxAsset = new System.Windows.Forms.CheckedListBox();
            this.chLstBoxEvt = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkGUID = new System.Windows.Forms.CheckBox();
            this.chkAuthor = new System.Windows.Forms.CheckBox();
            this.CustomMetaData = new System.Windows.Forms.CheckBox();
            this.chkWaveForm = new System.Windows.Forms.CheckBox();
            this.chkTimeMD = new System.Windows.Forms.CheckBox();
            this.chkAssetMD = new System.Windows.Forms.CheckBox();
            this.chkEvtMD = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.chkDeviceMD = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chLstBoxAsset
            // 
            this.chLstBoxAsset.FormattingEnabled = true;
            this.chLstBoxAsset.Location = new System.Drawing.Point(18, 64);
            this.chLstBoxAsset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chLstBoxAsset.Name = "chLstBoxAsset";
            this.chLstBoxAsset.Size = new System.Drawing.Size(242, 556);
            this.chLstBoxAsset.TabIndex = 0;
            this.chLstBoxAsset.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chLstBoxAsset_SelectedIndexChanged);
            // 
            // chLstBoxEvt
            // 
            this.chLstBoxEvt.FormattingEnabled = true;
            this.chLstBoxEvt.Location = new System.Drawing.Point(294, 64);
            this.chLstBoxEvt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chLstBoxEvt.Name = "chLstBoxEvt";
            this.chLstBoxEvt.Size = new System.Drawing.Size(242, 556);
            this.chLstBoxEvt.TabIndex = 1;
            this.chLstBoxEvt.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chLstBoxEvt_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkGUID);
            this.groupBox1.Controls.Add(this.chkAuthor);
            this.groupBox1.Controls.Add(this.CustomMetaData);
            this.groupBox1.Controls.Add(this.chkWaveForm);
            this.groupBox1.Controls.Add(this.chkTimeMD);
            this.groupBox1.Controls.Add(this.chkAssetMD);
            this.groupBox1.Controls.Add(this.chkEvtMD);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.chkDeviceMD);
            this.groupBox1.Location = new System.Drawing.Point(580, 126);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(256, 469);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // chkGUID
            // 
            this.chkGUID.AutoSize = true;
            this.chkGUID.Checked = true;
            this.chkGUID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGUID.Enabled = false;
            this.chkGUID.Location = new System.Drawing.Point(9, 34);
            this.chkGUID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkGUID.Name = "chkGUID";
            this.chkGUID.Size = new System.Drawing.Size(178, 24);
            this.chkGUID.TabIndex = 9;
            this.chkGUID.Text = "Include Event GUID";
            this.chkGUID.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkGUID.UseVisualStyleBackColor = true;
            // 
            // chkAuthor
            // 
            this.chkAuthor.AutoSize = true;
            this.chkAuthor.Checked = true;
            this.chkAuthor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuthor.Location = new System.Drawing.Point(9, 69);
            this.chkAuthor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAuthor.Name = "chkAuthor";
            this.chkAuthor.Size = new System.Drawing.Size(224, 24);
            this.chkAuthor.TabIndex = 8;
            this.chkAuthor.Text = "Include Author Information";
            this.chkAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAuthor.UseVisualStyleBackColor = true;
            // 
            // CustomMetaData
            // 
            this.CustomMetaData.AutoSize = true;
            this.CustomMetaData.Checked = true;
            this.CustomMetaData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomMetaData.Location = new System.Drawing.Point(10, 245);
            this.CustomMetaData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CustomMetaData.Name = "CustomMetaData";
            this.CustomMetaData.Size = new System.Drawing.Size(218, 24);
            this.CustomMetaData.TabIndex = 7;
            this.CustomMetaData.Text = "Include Custom Metadata";
            this.CustomMetaData.UseVisualStyleBackColor = true;
            // 
            // chkWaveForm
            // 
            this.chkWaveForm.AutoSize = true;
            this.chkWaveForm.Checked = true;
            this.chkWaveForm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWaveForm.Location = new System.Drawing.Point(10, 209);
            this.chkWaveForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkWaveForm.Name = "chkWaveForm";
            this.chkWaveForm.Size = new System.Drawing.Size(235, 24);
            this.chkWaveForm.TabIndex = 6;
            this.chkWaveForm.Text = "Inculde Waveform Metadata";
            this.chkWaveForm.UseVisualStyleBackColor = true;
            // 
            // chkTimeMD
            // 
            this.chkTimeMD.AutoSize = true;
            this.chkTimeMD.Checked = true;
            this.chkTimeMD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTimeMD.Location = new System.Drawing.Point(10, 285);
            this.chkTimeMD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTimeMD.Name = "chkTimeMD";
            this.chkTimeMD.Size = new System.Drawing.Size(209, 24);
            this.chkTimeMD.TabIndex = 5;
            this.chkTimeMD.Text = "Include Timing Metadata";
            this.chkTimeMD.UseVisualStyleBackColor = true;
            // 
            // chkAssetMD
            // 
            this.chkAssetMD.AutoSize = true;
            this.chkAssetMD.Checked = true;
            this.chkAssetMD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAssetMD.Location = new System.Drawing.Point(10, 175);
            this.chkAssetMD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAssetMD.Name = "chkAssetMD";
            this.chkAssetMD.Size = new System.Drawing.Size(204, 24);
            this.chkAssetMD.TabIndex = 4;
            this.chkAssetMD.Text = "Include Asset Metadata";
            this.chkAssetMD.UseVisualStyleBackColor = true;
            // 
            // chkEvtMD
            // 
            this.chkEvtMD.AutoSize = true;
            this.chkEvtMD.Checked = true;
            this.chkEvtMD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEvtMD.Location = new System.Drawing.Point(10, 140);
            this.chkEvtMD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkEvtMD.Name = "chkEvtMD";
            this.chkEvtMD.Size = new System.Drawing.Size(204, 24);
            this.chkEvtMD.TabIndex = 3;
            this.chkEvtMD.Text = "Include Event Metadata";
            this.chkEvtMD.UseVisualStyleBackColor = true;
            this.chkEvtMD.CheckedChanged += new System.EventHandler(this.chkEvtMD_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(14, 357);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(192, 26);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(10, 317);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(168, 24);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Change Start Time";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chkDeviceMD
            // 
            this.chkDeviceMD.AutoSize = true;
            this.chkDeviceMD.Checked = true;
            this.chkDeviceMD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeviceMD.Location = new System.Drawing.Point(10, 105);
            this.chkDeviceMD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDeviceMD.Name = "chkDeviceMD";
            this.chkDeviceMD.Size = new System.Drawing.Size(211, 24);
            this.chkDeviceMD.TabIndex = 0;
            this.chkDeviceMD.Text = "Include Device Metadata";
            this.chkDeviceMD.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 649);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 60);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(560, 643);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(234, 72);
            this.button2.TabIndex = 4;
            this.button2.Text = "Continue";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(580, 20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(252, 97);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Metadata";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(10, 62);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(158, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Include Metadata";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 31);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(151, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Anonymize Data";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(296, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 31);
            this.button3.TabIndex = 6;
            this.button3.Text = "Select All";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(402, 25);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 31);
            this.button4.TabIndex = 7;
            this.button4.Text = "DeSelect All";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(127, 25);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 31);
            this.button5.TabIndex = 9;
            this.button5.Text = "DeSelect All";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(21, 25);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 31);
            this.button6.TabIndex = 8;
            this.button6.Text = "Select All";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // PQdsPQDSexp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 735);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chLstBoxEvt);
            this.Controls.Add(this.chLstBoxAsset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PQdsPQDSexp";
            this.Text = "PQds Export PQDS";
            this.Load += new System.EventHandler(this.PQioPQDSexp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chLstBoxAsset;
        private System.Windows.Forms.CheckedListBox chLstBoxEvt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox chkDeviceMD;
        private System.Windows.Forms.CheckBox chkTimeMD;
        private System.Windows.Forms.CheckBox chkAssetMD;
        private System.Windows.Forms.CheckBox chkEvtMD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox chkWaveForm;
        private System.Windows.Forms.CheckBox CustomMetaData;
        private System.Windows.Forms.CheckBox chkAuthor;
        private System.Windows.Forms.CheckBox chkGUID;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}