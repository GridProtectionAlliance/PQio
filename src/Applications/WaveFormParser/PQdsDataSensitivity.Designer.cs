﻿//Copyright © 2019 Electric Power Research Institute, Inc. All rights reserved.
//
//Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met: 
//  Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//  Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
//  Neither the name of the EPRI nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
// 

namespace PQio
{
    partial class PQdsDataSensitivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PQdsDataSensitivity));
            this.Cncl_Btn = new System.Windows.Forms.Button();
            this.Save_BTN = new System.Windows.Forms.Button();
            this.DataSensitivityCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DataSensitivityNoteText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Cncl_Btn
            // 
            this.Cncl_Btn.Location = new System.Drawing.Point(18, 366);
            this.Cncl_Btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cncl_Btn.Name = "Cncl_Btn";
            this.Cncl_Btn.Size = new System.Drawing.Size(244, 63);
            this.Cncl_Btn.TabIndex = 0;
            this.Cncl_Btn.Text = "Cancel";
            this.Cncl_Btn.UseVisualStyleBackColor = true;
            this.Cncl_Btn.Click += new System.EventHandler(this.Cncl_Btn_Click);
            // 
            // Save_BTN
            // 
            this.Save_BTN.Location = new System.Drawing.Point(272, 366);
            this.Save_BTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Save_BTN.Name = "Save_BTN";
            this.Save_BTN.Size = new System.Drawing.Size(244, 63);
            this.Save_BTN.TabIndex = 1;
            this.Save_BTN.Text = "Save";
            this.Save_BTN.UseVisualStyleBackColor = true;
            this.Save_BTN.Click += new System.EventHandler(this.Save_BTN_Click);
            // 
            // DataSensitivityCombo
            // 
            this.DataSensitivityCombo.FormattingEnabled = true;
            this.DataSensitivityCombo.Location = new System.Drawing.Point(224, 43);
            this.DataSensitivityCombo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DataSensitivityCombo.Name = "DataSensitivityCombo";
            this.DataSensitivityCombo.Size = new System.Drawing.Size(229, 28);
            this.DataSensitivityCombo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Data Sensitivity Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data Sensitivity Note";
            // 
            // DataSensitivityNoteText
            // 
            this.DataSensitivityNoteText.AcceptsReturn = true;
            this.DataSensitivityNoteText.Enabled = false;
            this.DataSensitivityNoteText.Location = new System.Drawing.Point(44, 135);
            this.DataSensitivityNoteText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DataSensitivityNoteText.Multiline = true;
            this.DataSensitivityNoteText.Name = "DataSensitivityNoteText";
            this.DataSensitivityNoteText.Size = new System.Drawing.Size(422, 193);
            this.DataSensitivityNoteText.TabIndex = 5;
            // 
            // PQdsDataSensitivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 448);
            this.Controls.Add(this.DataSensitivityNoteText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataSensitivityCombo);
            this.Controls.Add(this.Save_BTN);
            this.Controls.Add(this.Cncl_Btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PQdsDataSensitivity";
            this.Text = "PQio Data Sensitivity";
            this.Load += new System.EventHandler(this.MetaData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cncl_Btn;
        private System.Windows.Forms.Button Save_BTN;
        private System.Windows.Forms.ComboBox DataSensitivityCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DataSensitivityNoteText;
    }
}