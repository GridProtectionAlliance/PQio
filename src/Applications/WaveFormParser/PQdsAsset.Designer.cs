//Copyright © 2019 Electric Power Research Institute, Inc. All rights reserved.
//
//Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met: 
//  Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//  Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
//  Neither the name of the EPRI nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
// 


namespace PQio
{
    partial class PQdsAsset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PQdsAsset));
            this.label1 = new System.Windows.Forms.Label();
            this.AssetNameTxtBox = new System.Windows.Forms.TextBox();
            this.NomVTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NomfTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lenTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.XFTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset Name";
            // 
            // AssetNameTxtBox
            // 
            this.AssetNameTxtBox.Location = new System.Drawing.Point(146, 54);
            this.AssetNameTxtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AssetNameTxtBox.Name = "AssetNameTxtBox";
            this.AssetNameTxtBox.Size = new System.Drawing.Size(524, 26);
            this.AssetNameTxtBox.TabIndex = 1;
            // 
            // NomVTxtBox
            // 
            this.NomVTxtBox.Location = new System.Drawing.Point(204, 108);
            this.NomVTxtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NomVTxtBox.Name = "NomVTxtBox";
            this.NomVTxtBox.Size = new System.Drawing.Size(94, 26);
            this.NomVTxtBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nominal Voltage (kV)";
            // 
            // NomfTxtBox
            // 
            this.NomfTxtBox.Location = new System.Drawing.Point(225, 165);
            this.NomfTxtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NomfTxtBox.Name = "NomfTxtBox";
            this.NomfTxtBox.Size = new System.Drawing.Size(73, 26);
            this.NomfTxtBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nominal Frequency (Hz)";
            // 
            // lenTxtBox
            // 
            this.lenTxtBox.Location = new System.Drawing.Point(450, 108);
            this.lenTxtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lenTxtBox.Name = "lenTxtBox";
            this.lenTxtBox.Size = new System.Drawing.Size(220, 26);
            this.lenTxtBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Length (miles)";
            // 
            // XFTxtBox
            // 
            this.XFTxtBox.Location = new System.Drawing.Point(522, 165);
            this.XFTxtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.XFTxtBox.Name = "XFTxtBox";
            this.XFTxtBox.Size = new System.Drawing.Size(148, 26);
            this.XFTxtBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 169);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Upstream XF Size (kVA)";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(18, 232);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(194, 55);
            this.CancelBtn.TabIndex = 13;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 232);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 55);
            this.button2.TabIndex = 14;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PQdsAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 315);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.XFTxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lenTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NomfTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NomVTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AssetNameTxtBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PQdsAsset";
            this.Text = "PQio Asset";
            this.Load += new System.EventHandler(this.LineForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AssetNameTxtBox;
        private System.Windows.Forms.TextBox NomVTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NomfTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lenTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox XFTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button button2;
    }
}