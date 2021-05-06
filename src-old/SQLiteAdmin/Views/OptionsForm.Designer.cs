/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-8
 * File:    Options.Designer.cs
 * Description:
 *  
 * To Do:
 * Change Log:
 *  2017-38 * Initial creation
 */

namespace Xeno.SQLiteAdmin.Views
{
  partial class OptionsForm
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
      this.BtnOK = new System.Windows.Forms.Button();
      this.BtnCancel = new System.Windows.Forms.Button();
      this.ComboDefaultDbProvider = new System.Windows.Forms.ComboBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // BtnOK
      // 
      this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.BtnOK.Location = new System.Drawing.Point(378, 242);
      this.BtnOK.Name = "BtnOK";
      this.BtnOK.Size = new System.Drawing.Size(75, 23);
      this.BtnOK.TabIndex = 0;
      this.BtnOK.Text = "OK";
      this.BtnOK.UseVisualStyleBackColor = true;
      // 
      // BtnCancel
      // 
      this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.BtnCancel.Location = new System.Drawing.Point(459, 242);
      this.BtnCancel.Name = "BtnCancel";
      this.BtnCancel.Size = new System.Drawing.Size(75, 23);
      this.BtnCancel.TabIndex = 1;
      this.BtnCancel.Text = "Cancel";
      this.BtnCancel.UseVisualStyleBackColor = true;
      // 
      // ComboDefaultDbProvider
      // 
      this.ComboDefaultDbProvider.FormattingEnabled = true;
      this.ComboDefaultDbProvider.Location = new System.Drawing.Point(6, 45);
      this.ComboDefaultDbProvider.Name = "ComboDefaultDbProvider";
      this.ComboDefaultDbProvider.Size = new System.Drawing.Size(174, 21);
      this.ComboDefaultDbProvider.TabIndex = 2;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.ComboDefaultDbProvider);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(200, 100);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Default DB Provider";
      // 
      // Options
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(546, 277);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.BtnCancel);
      this.Controls.Add(this.BtnOK);
      this.Name = "Options";
      this.Text = "Options";
      this.Load += new System.EventHandler(this.Options_Load);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button BtnOK;
    private System.Windows.Forms.Button BtnCancel;
    private System.Windows.Forms.ComboBox ComboDefaultDbProvider;
    private System.Windows.Forms.GroupBox groupBox1;
  }
}