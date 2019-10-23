namespace FileGuardian
{
    partial class MainFrm
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.files = new System.Windows.Forms.ListView();
            this.nameHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.encryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // files
            // 
            this.files.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHdr,
            this.typeHdr,
            this.sizeHdr});
            this.files.FullRowSelect = true;
            this.files.GridLines = true;
            this.files.HideSelection = false;
            this.files.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.files.Location = new System.Drawing.Point(12, 12);
            this.files.Name = "files";
            this.files.Size = new System.Drawing.Size(776, 426);
            this.files.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.files.TabIndex = 2;
            this.files.UseCompatibleStateImageBehavior = false;
            this.files.View = System.Windows.Forms.View.Details;
            this.files.MouseClick += new System.Windows.Forms.MouseEventHandler(this.files_MouseClick);
            // 
            // nameHdr
            // 
            this.nameHdr.Text = "Name";
            this.nameHdr.Width = 375;
            // 
            // typeHdr
            // 
            this.typeHdr.Text = "Type";
            this.typeHdr.Width = 70;
            // 
            // sizeHdr
            // 
            this.sizeHdr.Text = "Size";
            this.sizeHdr.Width = 70;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encryptToolStripMenuItem,
            this.decryptToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 68);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // encryptToolStripMenuItem
            // 
            this.encryptToolStripMenuItem.Name = "encryptToolStripMenuItem";
            this.encryptToolStripMenuItem.Size = new System.Drawing.Size(146, 32);
            this.encryptToolStripMenuItem.Text = "Encrypt";
            // 
            // decryptToolStripMenuItem
            // 
            this.decryptToolStripMenuItem.Name = "decryptToolStripMenuItem";
            this.decryptToolStripMenuItem.Size = new System.Drawing.Size(146, 32);
            this.decryptToolStripMenuItem.Text = "Decrypt";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.files);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileGuardian";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView files;
        private System.Windows.Forms.ColumnHeader nameHdr;
        private System.Windows.Forms.ColumnHeader typeHdr;
        private System.Windows.Forms.ColumnHeader sizeHdr;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem encryptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decryptToolStripMenuItem;
    }
}

