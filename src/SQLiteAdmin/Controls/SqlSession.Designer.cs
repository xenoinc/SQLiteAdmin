﻿/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-7
 * File:    SqlSession.Designer.cs
 * Description:
 *  
 * To Do:
 * Change Log:
 *  2017-37 * Initial creation
 */

namespace Xeno.SQLiteAdmin.Views
{
  partial class SqlSession
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.tsConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsDbSchema = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsDbUser = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsDbName = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsExecutionTime = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsRowsReturned = new System.Windows.Forms.ToolStripStatusLabel();
      this.textEditor1 = new Xeno.AvalonEditWF.TextEditor();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsConnectionStatus,
            this.tsDbSchema,
            this.tsDbUser,
            this.tsDbName,
            this.tsExecutionTime,
            this.tsRowsReturned});
      this.statusStrip1.Location = new System.Drawing.Point(0, 134);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(473, 22);
      this.statusStrip1.TabIndex = 0;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // tsConnectionStatus
      // 
      this.tsConnectionStatus.Image = global::Xeno.SQLiteAdmin.Properties.Resources.IconDisconnected;
      this.tsConnectionStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.tsConnectionStatus.Name = "tsConnectionStatus";
      this.tsConnectionStatus.Size = new System.Drawing.Size(214, 17);
      this.tsConnectionStatus.Spring = true;
      this.tsConnectionStatus.Text = "Disonnected";
      this.tsConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tsDbSchema
      // 
      this.tsDbSchema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsDbSchema.Name = "tsDbSchema";
      this.tsDbSchema.Size = new System.Drawing.Size(40, 17);
      this.tsDbSchema.Text = "(local)";
      // 
      // tsDbUser
      // 
      this.tsDbUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsDbUser.Name = "tsDbUser";
      this.tsDbUser.Size = new System.Drawing.Size(50, 17);
      this.tsDbUser.Text = "<USER>";
      // 
      // tsDbName
      // 
      this.tsDbName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tsDbName.Name = "tsDbName";
      this.tsDbName.Size = new System.Drawing.Size(38, 17);
      this.tsDbName.Text = "<DB>";
      // 
      // tsExecutionTime
      // 
      this.tsExecutionTime.Name = "tsExecutionTime";
      this.tsExecutionTime.Size = new System.Drawing.Size(75, 17);
      this.tsExecutionTime.Text = "<exec-time>";
      // 
      // tsRowsReturned
      // 
      this.tsRowsReturned.Name = "tsRowsReturned";
      this.tsRowsReturned.Size = new System.Drawing.Size(41, 17);
      this.tsRowsReturned.Text = "0 rows";
      // 
      // textEditor1
      // 
      this.textEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textEditor1.Document = null;
      this.textEditor1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textEditor1.Location = new System.Drawing.Point(0, 0);
      this.textEditor1.Name = "textEditor1";
      this.textEditor1.ShowLineNumbers = true;
      this.textEditor1.Size = new System.Drawing.Size(473, 134);
      this.textEditor1.SyntaxHighlighting = null;
      this.textEditor1.TabIndex = 1;
      // 
      // SqlSession
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.textEditor1);
      this.Controls.Add(this.statusStrip1);
      this.Name = "SqlSession";
      this.Size = new System.Drawing.Size(473, 156);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel tsConnectionStatus;
    private System.Windows.Forms.ToolStripStatusLabel tsDbSchema;
    private System.Windows.Forms.ToolStripStatusLabel tsDbUser;
    private System.Windows.Forms.ToolStripStatusLabel tsDbName;
    private System.Windows.Forms.ToolStripStatusLabel tsExecutionTime;
    private System.Windows.Forms.ToolStripStatusLabel tsRowsReturned;
    private AvalonEditWF.TextEditor textEditor1;
  }
}
