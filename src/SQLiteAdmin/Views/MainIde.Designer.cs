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
      this.MenuNew = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuOptions = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.SqlSession1 = new Xeno.SQLiteAdmin.Views.SqlSession();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.tsReady = new System.Windows.Forms.ToolStripStatusLabel();
      this.TextEditor1 = new Xeno.AvalonEditWF.TextEditor();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.tsExecute = new System.Windows.Forms.ToolStripDropDownButton();
      this.tsExecuteAll = new System.Windows.Forms.ToolStripMenuItem();
      this.tsExecuteSelection = new System.Windows.Forms.ToolStripMenuItem();
      this.btnTestSetText = new System.Windows.Forms.ToolStripButton();
      this.btnTestToggleLines = new System.Windows.Forms.ToolStripButton();
      this.btnTestGetText = new System.Windows.Forms.ToolStripButton();
      this.menuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNew,
            this.MenuOptions});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(611, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // MenuNew
      // 
      this.MenuNew.Name = "MenuNew";
      this.MenuNew.Size = new System.Drawing.Size(43, 20);
      this.MenuNew.Text = "New";
      this.MenuNew.Click += new System.EventHandler(this.menuNew_Click);
      // 
      // MenuOptions
      // 
      this.MenuOptions.Name = "MenuOptions";
      this.MenuOptions.Size = new System.Drawing.Size(61, 20);
      this.MenuOptions.Text = "Options";
      this.MenuOptions.Click += new System.EventHandler(this.MenuOptions_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.SqlSession1);
      this.panel1.Controls.Add(this.statusStrip1);
      this.panel1.Controls.Add(this.TextEditor1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 24);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(611, 417);
      this.panel1.TabIndex = 1;
      // 
      // SqlSession1
      // 
      this.SqlSession1.FilePath = null;
      this.SqlSession1.Location = new System.Drawing.Point(3, 207);
      this.SqlSession1.Name = "SqlSession1";
      this.SqlSession1.SetDatabaseProvider = Xeno.SQLiteAdmin.Data.DatabaseProvider.SQLite;
      this.SqlSession1.Size = new System.Drawing.Size(608, 185);
      this.SqlSession1.SyntaxHighlighting = null;
      this.SqlSession1.TabIndex = 6;
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsReady});
      this.statusStrip1.Location = new System.Drawing.Point(0, 395);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(611, 22);
      this.statusStrip1.TabIndex = 5;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // tsReady
      // 
      this.tsReady.Name = "tsReady";
      this.tsReady.Size = new System.Drawing.Size(39, 17);
      this.tsReady.Text = "Ready";
      // 
      // TextEditor1
      // 
      this.TextEditor1.Document = null;
      this.TextEditor1.Location = new System.Drawing.Point(3, 28);
      this.TextEditor1.Name = "TextEditor1";
      this.TextEditor1.ShowLineNumbers = true;
      this.TextEditor1.Size = new System.Drawing.Size(608, 173);
      this.TextEditor1.SyntaxHighlighting = null;
      this.TextEditor1.TabIndex = 4;
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
      // MainIde
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(611, 441);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainIde";
      this.Text = "SQLite Admin";
      this.Load += new System.EventHandler(this.MainIde_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem MenuNew;
    private System.Windows.Forms.Panel panel1;
    private AvalonEditWF.TextEditor TextEditor1;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripDropDownButton tsExecute;
    private System.Windows.Forms.ToolStripMenuItem tsExecuteAll;
    private System.Windows.Forms.ToolStripMenuItem tsExecuteSelection;
    private System.Windows.Forms.ToolStripButton btnTestSetText;
    private System.Windows.Forms.ToolStripButton btnTestToggleLines;
    private System.Windows.Forms.ToolStripButton btnTestGetText;
    private System.Windows.Forms.ToolStripStatusLabel tsReady;
    private Views.SqlSession SqlSession1;
    private System.Windows.Forms.ToolStripMenuItem MenuOptions;
  }
}

