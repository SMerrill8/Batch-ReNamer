namespace Boundless.ReNamer
{
    partial class FrmError
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
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.tbxError = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.ctlRightMouseMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tlp.Controls.Add(this.tbxError, 1, 1);
            this.tlp.Controls.Add(this.cmdOK, 1, 2);
            this.tlp.Controls.Add(this.lblInstruction, 1, 0);
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
            // tbxError
            // 
            this.tbxError.BackColor = System.Drawing.SystemColors.Control;
            this.tbxError.CausesValidation = false;
            this.tbxError.ContextMenuStrip = this.ctlRightMouseMenu;
            this.tbxError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxError.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxError.ForeColor = System.Drawing.Color.Red;
            this.tbxError.Location = new System.Drawing.Point(23, 23);
            this.tbxError.Multiline = true;
            this.tbxError.Name = "tbxError";
            this.tbxError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxError.Size = new System.Drawing.Size(887, 279);
            this.tbxError.TabIndex = 0;
            this.tbxError.Text = "Text of error message";
            this.tbxError.WordWrap = false;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdOK.AutoSize = true;
            this.cmdOK.Location = new System.Drawing.Point(418, 314);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(96, 32);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblInstruction.Location = new System.Drawing.Point(23, 0);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(336, 20);
            this.lblInstruction.TabIndex = 2;
            this.lblInstruction.Text = "The following source files do not exist:";
            // 
            // ctlRightMouseMenu
            // 
            this.ctlRightMouseMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctlRightMouseMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopy});
            this.ctlRightMouseMenu.Name = "ctlRightMouseMenu";
            this.ctlRightMouseMenu.Size = new System.Drawing.Size(182, 58);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(181, 26);
            this.mnuCopy.Text = "&Copy (Ctl-C)";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // FrmError
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(935, 355);
            this.ControlBox = false;
            this.Controls.Add(this.tlp);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmError";
            this.Text = "Errors";
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.ctlRightMouseMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.TextBox tbxError;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.ContextMenuStrip ctlRightMouseMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
    }
}