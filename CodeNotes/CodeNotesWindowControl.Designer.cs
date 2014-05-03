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
            this.tvCodeNote = new System.Windows.Forms.TreeView();
            this.cmsCodeNote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cbCodeNoteCategory = new System.Windows.Forms.ComboBox();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvCodeNote
            // 
            this.tvCodeNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvCodeNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvCodeNote.ContextMenuStrip = this.cmsCodeNote;
            this.tvCodeNote.FullRowSelect = true;
            this.tvCodeNote.HideSelection = false;
            this.tvCodeNote.ItemHeight = 22;
            this.tvCodeNote.Location = new System.Drawing.Point(0, 22);
            this.tvCodeNote.Name = "tvCodeNote";
            this.tvCodeNote.ShowLines = false;
            this.tvCodeNote.ShowPlusMinus = false;
            this.tvCodeNote.ShowRootLines = false;
            this.tvCodeNote.Size = new System.Drawing.Size(450, 278);
            this.tvCodeNote.TabIndex = 1;
            this.tvCodeNote.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvCodeNote_ItemDrag);
            this.tvCodeNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvCodeNote_MouseDown);
            // 
            // cmsCodeNote
            // 
            this.cmsCodeNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEdit,
            this.tsmiDelete});
            this.cmsCodeNote.Name = "cmsCodeNotes";
            this.cmsCodeNote.Size = new System.Drawing.Size(153, 70);
            this.cmsCodeNote.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCodeNote_Opening);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(152, 22);
            this.tsmiDelete.Text = "刪除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // cbCodeNoteCategory
            // 
            this.cbCodeNoteCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCodeNoteCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCodeNoteCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCodeNoteCategory.FormattingEnabled = true;
            this.cbCodeNoteCategory.Items.AddRange(new object[] {
            "全部",
            "<新增...>"});
            this.cbCodeNoteCategory.Location = new System.Drawing.Point(0, 0);
            this.cbCodeNoteCategory.Name = "cbCodeNoteCategory";
            this.cbCodeNoteCategory.Size = new System.Drawing.Size(450, 21);
            this.cbCodeNoteCategory.TabIndex = 0;
            this.cbCodeNoteCategory.SelectedIndexChanged += new System.EventHandler(this.cbCodeNoteCategory_SelectedIndexChanged);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(152, 22);
            this.tsmiEdit.Text = "編輯";
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // CodeNotesWindowControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbCodeNoteCategory);
            this.Controls.Add(this.tvCodeNote);
            this.Name = "CodeNotesWindowControl";
            this.Size = new System.Drawing.Size(450, 300);
            this.Load += new System.EventHandler(this.CodeNotesWindowControl_Load);
            this.cmsCodeNote.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvCodeNote;
        private System.Windows.Forms.ContextMenuStrip cmsCodeNote;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ComboBox cbCodeNoteCategory;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;

    }
}
