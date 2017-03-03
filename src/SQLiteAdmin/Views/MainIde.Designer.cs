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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnTestGetText = new System.Windows.Forms.Button();
      this.btnTestToggleLines = new System.Windows.Forms.Button();
      this.btnTestSetText = new System.Windows.Forms.Button();
      this.syntaxEditor1 = new Xeno.SQLiteAdmin.Control.SyntaxEditor();
      this.textEditor1 = new Xeno.AvalonEditWF.TextEditor();
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
      this.panel1.Controls.Add(this.textEditor1);
      this.panel1.Controls.Add(this.btnTestGetText);
      this.panel1.Controls.Add(this.btnTestToggleLines);
      this.panel1.Controls.Add(this.btnTestSetText);
      this.panel1.Controls.Add(this.syntaxEditor1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 24);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(562, 244);
      this.panel1.TabIndex = 1;
      // 
      // btnTestGetText
      // 
      this.btnTestGetText.Location = new System.Drawing.Point(199, 13);
      this.btnTestGetText.Name = "btnTestGetText";
      this.btnTestGetText.Size = new System.Drawing.Size(75, 23);
      this.btnTestGetText.TabIndex = 3;
      this.btnTestGetText.Text = "Get Text";
      this.btnTestGetText.UseVisualStyleBackColor = true;
      this.btnTestGetText.Click += new System.EventHandler(this.btnTestGetText_Click);
      // 
      // btnTestToggleLines
      // 
      this.btnTestToggleLines.Location = new System.Drawing.Point(94, 13);
      this.btnTestToggleLines.Name = "btnTestToggleLines";
      this.btnTestToggleLines.Size = new System.Drawing.Size(99, 23);
      this.btnTestToggleLines.TabIndex = 2;
      this.btnTestToggleLines.Text = "Toggle Lines";
      this.btnTestToggleLines.UseVisualStyleBackColor = true;
      this.btnTestToggleLines.Click += new System.EventHandler(this.btnTestToggleLines_Click);
      // 
      // btnTestSetText
      // 
      this.btnTestSetText.Location = new System.Drawing.Point(13, 13);
      this.btnTestSetText.Name = "btnTestSetText";
      this.btnTestSetText.Size = new System.Drawing.Size(75, 23);
      this.btnTestSetText.TabIndex = 1;
      this.btnTestSetText.Text = "Set Text";
      this.btnTestSetText.UseVisualStyleBackColor = true;
      this.btnTestSetText.Click += new System.EventHandler(this.btnTestSetText_Click);
      // 
      // syntaxEditor1
      // 
      this.syntaxEditor1.Location = new System.Drawing.Point(12, 42);
      this.syntaxEditor1.Name = "syntaxEditor1";
      this.syntaxEditor1.ShowLineNumbers = false;
      this.syntaxEditor1.Size = new System.Drawing.Size(269, 190);
      this.syntaxEditor1.SyntaxHighlighting = null;
      this.syntaxEditor1.TabIndex = 0;
      // 
      // textEditor1
      // 
      this.textEditor1.Location = new System.Drawing.Point(287, 42);
      this.textEditor1.Name = "textEditor1";
      this.textEditor1.ShowLineNumbers = true;
      this.textEditor1.Size = new System.Drawing.Size(272, 190);
      this.textEditor1.SyntaxHighlighting = null;
      this.textEditor1.TabIndex = 4;
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
    private System.Windows.Forms.Button btnTestGetText;
    private System.Windows.Forms.Button btnTestToggleLines;
    private System.Windows.Forms.Button btnTestSetText;
    private Control.SyntaxEditor syntaxEditor1;
    private AvalonEditWF.TextEditor textEditor1;
  }
}

