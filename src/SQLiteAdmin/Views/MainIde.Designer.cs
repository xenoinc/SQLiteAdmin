namespace Xeno.SQLiteAdmin
{
  partial class MainIde
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainIde));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuFileNew = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuFileOpenFile = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuEditCut = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuTools = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuToolsOptions = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.ToolSqlExecute = new System.Windows.Forms.ToolStripDropDownButton();
      this.ToolDebugging = new System.Windows.Forms.ToolStripSplitButton();
      this.ToolDbgGetText = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolDbgToggleLines = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolDbgSetText = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolNewQuery = new System.Windows.Forms.ToolStripButton();
      this.menuStrip1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.MenuEdit,
            this.MenuTools,
            this.MenuHelp});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(611, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileNew,
            this.MenuFileOpenFile,
            this.MenuFileSave,
            this.toolStripMenuItem1,
            this.MenuFileExit});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // MenuFileNew
      // 
      this.MenuFileNew.Name = "MenuFileNew";
      this.MenuFileNew.Size = new System.Drawing.Size(124, 22);
      this.MenuFileNew.Text = "New";
      this.MenuFileNew.Click += new System.EventHandler(this.MenuFileNew_Click);
      // 
      // MenuFileOpenFile
      // 
      this.MenuFileOpenFile.Name = "MenuFileOpenFile";
      this.MenuFileOpenFile.Size = new System.Drawing.Size(124, 22);
      this.MenuFileOpenFile.Text = "Open File";
      this.MenuFileOpenFile.Click += new System.EventHandler(this.MenuFileOpenFile_Click);
      // 
      // MenuFileSave
      // 
      this.MenuFileSave.Name = "MenuFileSave";
      this.MenuFileSave.Size = new System.Drawing.Size(124, 22);
      this.MenuFileSave.Text = "Save";
      this.MenuFileSave.Click += new System.EventHandler(this.MenuFileSave_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
      // 
      // MenuFileExit
      // 
      this.MenuFileExit.Name = "MenuFileExit";
      this.MenuFileExit.Size = new System.Drawing.Size(124, 22);
      this.MenuFileExit.Text = "Exit";
      this.MenuFileExit.Click += new System.EventHandler(this.MenuFileExit_Click);
      // 
      // MenuEdit
      // 
      this.MenuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEditCut,
            this.MenuEditCopy,
            this.MenuEditPaste});
      this.MenuEdit.Name = "MenuEdit";
      this.MenuEdit.Size = new System.Drawing.Size(39, 20);
      this.MenuEdit.Text = "&Edit";
      // 
      // MenuEditCut
      // 
      this.MenuEditCut.Name = "MenuEditCut";
      this.MenuEditCut.Size = new System.Drawing.Size(102, 22);
      this.MenuEditCut.Text = "Cut";
      this.MenuEditCut.Click += new System.EventHandler(this.MenuEditCut_Click);
      // 
      // MenuEditCopy
      // 
      this.MenuEditCopy.Name = "MenuEditCopy";
      this.MenuEditCopy.Size = new System.Drawing.Size(102, 22);
      this.MenuEditCopy.Text = "Copy";
      this.MenuEditCopy.Click += new System.EventHandler(this.MenuEditCopy_Click);
      // 
      // MenuEditPaste
      // 
      this.MenuEditPaste.Name = "MenuEditPaste";
      this.MenuEditPaste.Size = new System.Drawing.Size(102, 22);
      this.MenuEditPaste.Text = "Paste";
      this.MenuEditPaste.Click += new System.EventHandler(this.MenuEditPaste_Click);
      // 
      // MenuTools
      // 
      this.MenuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolsOptions});
      this.MenuTools.Name = "MenuTools";
      this.MenuTools.Size = new System.Drawing.Size(47, 20);
      this.MenuTools.Text = "Tools";
      // 
      // MenuToolsOptions
      // 
      this.MenuToolsOptions.Name = "MenuToolsOptions";
      this.MenuToolsOptions.Size = new System.Drawing.Size(116, 22);
      this.MenuToolsOptions.Text = "Options";
      this.MenuToolsOptions.Click += new System.EventHandler(this.MenuToolsOptions_Click);
      // 
      // MenuHelp
      // 
      this.MenuHelp.Name = "MenuHelp";
      this.MenuHelp.Size = new System.Drawing.Size(44, 20);
      this.MenuHelp.Text = "Help";
      // 
      // toolStrip1
      // 
      this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolNewQuery,
            this.ToolSqlExecute,
            this.ToolDebugging});
      this.toolStrip1.Location = new System.Drawing.Point(0, 24);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(611, 25);
      this.toolStrip1.TabIndex = 2;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // tabControl1
      // 
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 49);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(611, 392);
      this.tabControl1.TabIndex = 7;
      this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
      // 
      // ToolSqlExecute
      // 
      this.ToolSqlExecute.Image = global::Xeno.SQLiteAdmin.Properties.Resources.IconPlay;
      this.ToolSqlExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ToolSqlExecute.Name = "ToolSqlExecute";
      this.ToolSqlExecute.Size = new System.Drawing.Size(76, 22);
      this.ToolSqlExecute.Text = "E&xecute";
      this.ToolSqlExecute.Click += new System.EventHandler(this.ToolSqlExecute_Click);
      // 
      // ToolDebugging
      // 
      this.ToolDebugging.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.ToolDebugging.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolDbgGetText,
            this.ToolDbgToggleLines,
            this.ToolDbgSetText});
      this.ToolDebugging.Image = ((System.Drawing.Image)(resources.GetObject("ToolDebugging.Image")));
      this.ToolDebugging.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ToolDebugging.Name = "ToolDebugging";
      this.ToolDebugging.Size = new System.Drawing.Size(82, 22);
      this.ToolDebugging.Text = "Debugging";
      // 
      // ToolDbgGetText
      // 
      this.ToolDbgGetText.Name = "ToolDbgGetText";
      this.ToolDbgGetText.Size = new System.Drawing.Size(152, 22);
      this.ToolDbgGetText.Text = "Get Text";
      this.ToolDbgGetText.Click += new System.EventHandler(this.ToolDbgGetText_Click);
      // 
      // ToolDbgToggleLines
      // 
      this.ToolDbgToggleLines.Name = "ToolDbgToggleLines";
      this.ToolDbgToggleLines.Size = new System.Drawing.Size(152, 22);
      this.ToolDbgToggleLines.Text = "Toggle Lines";
      this.ToolDbgToggleLines.Click += new System.EventHandler(this.ToolDbgToggleLines_Click);
      // 
      // ToolDbgSetText
      // 
      this.ToolDbgSetText.Name = "ToolDbgSetText";
      this.ToolDbgSetText.Size = new System.Drawing.Size(152, 22);
      this.ToolDbgSetText.Text = "Set Text";
      this.ToolDbgSetText.Click += new System.EventHandler(this.ToolDbgSetText_Click);
      // 
      // ToolNewQuery
      // 
      this.ToolNewQuery.Image = ((System.Drawing.Image)(resources.GetObject("ToolNewQuery.Image")));
      this.ToolNewQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ToolNewQuery.Name = "ToolNewQuery";
      this.ToolNewQuery.Size = new System.Drawing.Size(86, 22);
      this.ToolNewQuery.Text = "&New Query";
      this.ToolNewQuery.Click += new System.EventHandler(this.ToolNewQuery_Click);
      // 
      // MainIde
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(611, 441);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainIde";
      this.Text = "SQLite Admin";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainIde_FormClosing);
      this.Load += new System.EventHandler(this.MainIde_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripDropDownButton ToolSqlExecute;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem MenuFileNew;
    private System.Windows.Forms.ToolStripMenuItem MenuFileSave;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem MenuFileExit;
    private System.Windows.Forms.ToolStripMenuItem MenuTools;
    private System.Windows.Forms.ToolStripMenuItem MenuToolsOptions;
    private System.Windows.Forms.ToolStripMenuItem MenuHelp;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.ToolStripMenuItem MenuEdit;
    private System.Windows.Forms.ToolStripMenuItem MenuEditCut;
    private System.Windows.Forms.ToolStripMenuItem MenuEditCopy;
    private System.Windows.Forms.ToolStripMenuItem MenuEditPaste;
    private System.Windows.Forms.ToolStripMenuItem MenuFileOpenFile;
    private System.Windows.Forms.ToolStripSplitButton ToolDebugging;
    private System.Windows.Forms.ToolStripMenuItem ToolDbgGetText;
    private System.Windows.Forms.ToolStripMenuItem ToolDbgToggleLines;
    private System.Windows.Forms.ToolStripMenuItem ToolDbgSetText;
    private System.Windows.Forms.ToolStripButton ToolNewQuery;
  }
}

