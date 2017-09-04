namespace Ideal.ReNamer
{
    partial class FrmResult
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResult));
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.ctlRightMouseMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdOK = new System.Windows.Forms.Button();
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tlp.SuspendLayout();
            this.ctlRightMouseMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp
            // 
            this.tlp.ColumnCount = 3;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp.Controls.Add(this.tbxResult, 1, 1);
            this.tlp.Controls.Add(this.cmdOK, 1, 2);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 3;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp.Size = new System.Drawing.Size(935, 355);
            this.tlp.TabIndex = 0;
            // 
            // tbxResult
            // 
            this.tbxResult.BackColor = System.Drawing.SystemColors.Control;
            this.tbxResult.CausesValidation = false;
            this.tbxResult.ContextMenuStrip = this.ctlRightMouseMenu;
            this.tbxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxResult.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxResult.Location = new System.Drawing.Point(23, 3);
            this.tbxResult.Multiline = true;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxResult.Size = new System.Drawing.Size(887, 299);
            this.tbxResult.TabIndex = 0;
            this.tbxResult.Text = "Text of message";
            this.tbxResult.WordWrap = false;
            // 
            // ctlRightMouseMenu
            // 
            this.ctlRightMouseMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctlRightMouseMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopy,
            this.mnuSelectAll});
            this.ctlRightMouseMenu.Name = "ctlRightMouseMenu";
            this.ctlRightMouseMenu.Size = new System.Drawing.Size(205, 56);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.ShortcutKeyDisplayString = "(Ctrl-C)";
            this.mnuCopy.Size = new System.Drawing.Size(204, 26);
            this.mnuCopy.Text = "&Copy";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdOK.AutoSize = true;
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdOK.Location = new System.Drawing.Point(418, 314);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(96, 32);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Name = "mnuSelectAll";
            this.mnuSelectAll.ShortcutKeyDisplayString = "(Ctrl-A)";
            this.mnuSelectAll.Size = new System.Drawing.Size(204, 26);
            this.mnuSelectAll.Text = "Select &All";
            this.mnuSelectAll.Click += new System.EventHandler(this.mnuSelectAll_Click);
            // 
            // FrmResult
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.CancelButton = this.cmdOK;
            this.ClientSize = new System.Drawing.Size(935, 355);
            this.Controls.Add(this.tlp);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmResult";
            this.ShowInTaskbar = false;
            this.Text = "Results";
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.ctlRightMouseMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ContextMenuStrip ctlRightMouseMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAll;
    }
}