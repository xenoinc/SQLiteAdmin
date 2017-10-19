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
      this.MenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuTools = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuToolsOptions = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.tsExecute = new System.Windows.Forms.ToolStripDropDownButton();
      this.tsExecuteAll = new System.Windows.Forms.ToolStripMenuItem();
      this.tsExecuteSelection = new System.Windows.Forms.ToolStripMenuItem();
      this.btnTestSetText = new System.Windows.Forms.ToolStripButton();
      this.btnTestToggleLines = new System.Windows.Forms.ToolStripButton();
      this.btnTestGetText = new System.Windows.Forms.ToolStripButton();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.MenuEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuEditCut = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
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
            this.MenuFileSave,
            this.toolStripMenuItem1,
            this.MenuFileExit});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // MenuFileNew
      // 
      this.MenuFileNew.Name = "MenuFileNew";
      this.MenuFileNew.Size = new System.Drawing.Size(98, 22);
      this.MenuFileNew.Text = "New";
      this.MenuFileNew.Click += new System.EventHandler(this.MenuFileNew_Click);
      // 
      // MenuFileSave
      // 
      this.MenuFileSave.Name = "MenuFileSave";
      this.MenuFileSave.Size = new System.Drawing.Size(98, 22);
      this.MenuFileSave.Text = "Save";
      this.MenuFileSave.Click += new System.EventHandler(this.MenuFileSave_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(95, 6);
      // 
      // MenuFileExit
      // 
      this.MenuFileExit.Name = "MenuFileExit";
      this.MenuFileExit.Size = new System.Drawing.Size(98, 22);
      this.MenuFileExit.Text = "Exit";
      this.MenuFileExit.Click += new System.EventHandler(this.MenuFileExit_Click);
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
            this.tsExecute,
            this.btnTestSetText,
            this.btnTestToggleLines,
            this.btnTestGetText});
      this.toolStrip1.Location = new System.Drawing.Point(0, 24);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(611, 25);
      this.toolStrip1.TabIndex = 2;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // tsExecute
      // 
      this.tsExecute.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsExecuteAll,
            this.tsExecuteSelection});
      this.tsExecute.Image = global::Xeno.SQLiteAdmin.Properties.Resources.IconPlay;
      this.tsExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsExecute.Name = "tsExecute";
      this.tsExecute.Size = new System.Drawing.Size(76, 22);
      this.tsExecute.Text = "Execute";
      this.tsExecute.Click += new System.EventHandler(this.tsExecute_Click);
      // 
      // tsExecuteAll
      // 
      this.tsExecuteAll.Enabled = false;
      this.tsExecuteAll.Name = "tsExecuteAll";
      this.tsExecuteAll.Size = new System.Drawing.Size(165, 22);
      this.tsExecuteAll.Text = "Execute All";
      this.tsExecuteAll.Click += new System.EventHandler(this.tsExecuteAll_Click);
      // 
      // tsExecuteSelection
      // 
      this.tsExecuteSelection.Enabled = false;
      this.tsExecuteSelection.Name = "tsExecuteSelection";
      this.tsExecuteSelection.Size = new System.Drawing.Size(165, 22);
      this.tsExecuteSelection.Text = "Execute Selection";
      this.tsExecuteSelection.Click += new System.EventHandler(this.tsExecuteSelection_Click);
      // 
      // btnTestSetText
      // 
      this.btnTestSetText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnTestSetText.Image = ((System.Drawing.Image)(resources.GetObject("btnTestSetText.Image")));
      this.btnTestSetText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnTestSetText.Name = "btnTestSetText";
      this.btnTestSetText.Size = new System.Drawing.Size(51, 22);
      this.btnTestSetText.Text = "Set Text";
      this.btnTestSetText.Click += new System.EventHandler(this.btnTestSetText_Click);
      // 
      // btnTestToggleLines
      // 
      this.btnTestToggleLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnTestToggleLines.Image = ((System.Drawing.Image)(resources.GetObject("btnTestToggleLines.Image")));
      this.btnTestToggleLines.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnTestToggleLines.Name = "btnTestToggleLines";
      this.btnTestToggleLines.Size = new System.Drawing.Size(77, 22);
      this.btnTestToggleLines.Text = "Toggle Lines";
      this.btnTestToggleLines.Click += new System.EventHandler(this.btnTestToggleLines_Click);
      // 
      // btnTestGetText
      // 
      this.btnTestGetText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnTestGetText.Image = ((System.Drawing.Image)(resources.GetObject("btnTestGetText.Image")));
      this.btnTestGetText.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnTestGetText.Name = "btnTestGetText";
      this.btnTestGetText.Size = new System.Drawing.Size(53, 22);
      this.btnTestGetText.Text = "Get Text";
      this.btnTestGetText.Click += new System.EventHandler(this.btnTestGetText_Click);
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
      // MenuEdit
      // 
      this.MenuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEditCut,
            this.MenuEditCopy,
            this.MenuEditPaste});
      this.MenuEdit.Name = "MenuEdit";
      this.MenuEdit.Size = new System.Drawing.Size(39, 20);
      this.MenuEdit.Text = "Edit";
      // 
      // MenuEditCut
      // 
      this.MenuEditCut.Name = "MenuEditCut";
      this.MenuEditCut.Size = new System.Drawing.Size(152, 22);
      this.MenuEditCut.Text = "Cut";
      this.MenuEditCut.Click += new System.EventHandler(this.MenuEditCut_Click);
      // 
      // MenuEditCopy
      // 
      this.MenuEditCopy.Name = "MenuEditCopy";
      this.MenuEditCopy.Size = new System.Drawing.Size(152, 22);
      this.MenuEditCopy.Text = "Copy";
      this.MenuEditCopy.Click += new System.EventHandler(this.MenuEditCopy_Click);
      // 
      // MenuEditPaste
      // 
      this.MenuEditPaste.Name = "MenuEditPaste";
      this.MenuEditPaste.Size = new System.Drawing.Size(152, 22);
      this.MenuEditPaste.Text = "Paste";
      this.MenuEditPaste.Click += new System.EventHandler(this.MenuEditPaste_Click);
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
    private System.Windows.Forms.ToolStripDropDownButton tsExecute;
    private System.Windows.Forms.ToolStripMenuItem tsExecuteAll;
    private System.Windows.Forms.ToolStripMenuItem tsExecuteSelection;
    private System.Windows.Forms.ToolStripButton btnTestSetText;
    private System.Windows.Forms.ToolStripButton btnTestToggleLines;
    private System.Windows.Forms.ToolStripButton btnTestGetText;
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
  }
}

