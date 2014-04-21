namespace Likol.CodeNotes
{
    partial class CodeNotesWindowControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("少林寺網路上身 向科技人淘金 ");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("美研發智慧手表 號稱取代智慧手機");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("鴻海贊助創業平台 攻6大領域");
            this.tvCodeNotes = new System.Windows.Forms.TreeView();
            this.cmsCodeNotes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvCodeNotes
            // 
            this.tvCodeNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvCodeNotes.ContextMenuStrip = this.cmsCodeNotes;
            this.tvCodeNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCodeNotes.FullRowSelect = true;
            this.tvCodeNotes.HideSelection = false;
            this.tvCodeNotes.ItemHeight = 22;
            this.tvCodeNotes.Location = new System.Drawing.Point(0, 0);
            this.tvCodeNotes.Name = "tvCodeNotes";
            treeNode1.Name = "Node0";
            treeNode1.Text = "少林寺網路上身 向科技人淘金 ";
            treeNode2.Name = "Node1";
            treeNode2.Text = "美研發智慧手表 號稱取代智慧手機";
            treeNode3.Name = "Node2";
            treeNode3.Text = "鴻海贊助創業平台 攻6大領域";
            this.tvCodeNotes.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.tvCodeNotes.ShowLines = false;
            this.tvCodeNotes.ShowPlusMinus = false;
            this.tvCodeNotes.ShowRootLines = false;
            this.tvCodeNotes.Size = new System.Drawing.Size(461, 294);
            this.tvCodeNotes.TabIndex = 0;
            this.tvCodeNotes.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvCodeNotes_ItemDrag);
            this.tvCodeNotes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvCodeNotes_MouseDown);
            // 
            // cmsCodeNotes
            // 
            this.cmsCodeNotes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDelete});
            this.cmsCodeNotes.Name = "cmsCodeNotes";
            this.cmsCodeNotes.Size = new System.Drawing.Size(153, 48);
            this.cmsCodeNotes.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCodeNotes_Opening);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(152, 22);
            this.tsmiDelete.Text = "刪除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // CodeNotesWindowControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvCodeNotes);
            this.Name = "CodeNotesWindowControl";
            this.Size = new System.Drawing.Size(461, 294);
            this.Load += new System.EventHandler(this.CodeNotesWindowControl_Load);
            this.cmsCodeNotes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvCodeNotes;
        private System.Windows.Forms.ContextMenuStrip cmsCodeNotes;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;

    }
}
