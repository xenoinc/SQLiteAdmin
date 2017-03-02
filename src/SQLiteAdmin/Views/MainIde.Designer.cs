namespace SQLiteAdmin
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
      ICSharpCode.AvalonEdit.TextEditor textEditor4 = new ICSharpCode.AvalonEdit.TextEditor();
      ICSharpCode.AvalonEdit.Document.TextDocument textDocument4 = new ICSharpCode.AvalonEdit.Document.TextDocument();
      System.ComponentModel.Design.ServiceContainer serviceContainer4 = new System.ComponentModel.Design.ServiceContainer();
      ICSharpCode.AvalonEdit.Document.UndoStack undoStack4 = new ICSharpCode.AvalonEdit.Document.UndoStack();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainIde));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.button3 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.syntaxEditor1 = new SQLiteAdmin.Control.SyntaxEditor();
      this.menuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(562, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // menuNew
      // 
      this.menuNew.Name = "menuNew";
      this.menuNew.Size = new System.Drawing.Size(43, 20);
      this.menuNew.Text = "New";
      this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.button3);
      this.panel1.Controls.Add(this.button2);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Controls.Add(this.syntaxEditor1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 24);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(562, 244);
      this.panel1.TabIndex = 1;
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(199, 13);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(75, 23);
      this.button3.TabIndex = 3;
      this.button3.Text = "Get Text";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(94, 13);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(99, 23);
      this.button2.TabIndex = 2;
      this.button2.Text = "Toggle Lines";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(13, 13);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Set Text";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // syntaxEditor1
      // 
      this.syntaxEditor1.Location = new System.Drawing.Point(12, 42);
      this.syntaxEditor1.Name = "syntaxEditor1";
      this.syntaxEditor1.ShowLineNumbers = false;
      this.syntaxEditor1.Size = new System.Drawing.Size(538, 190);
      this.syntaxEditor1.SyntaxHighlighting = null;
      this.syntaxEditor1.TabIndex = 0;
      // 
      // MainIde
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(562, 268);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainIde";
      this.Text = "SQLite Admin";
      this.Load += new System.EventHandler(this.MainIde_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem menuNew;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private Control.SyntaxEditor syntaxEditor1;
  }
}

