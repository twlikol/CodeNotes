namespace Likol.CodeNotes.UI
{
    partial class CategoryManagerForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("少林寺網路上身 向科技人淘金 ");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("美研發智慧手表 號稱取代智慧手機");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("鴻海贊助創業平台 攻6大領域");
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tvCodeNoteCategory = new System.Windows.Forms.TreeView();
            this.btnNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(277, 85);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(95, 22);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "刪除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(277, 55);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 22);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "編輯";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(12, 9);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(70, 13);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "程式碼分類:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(277, 277);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 22);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "關閉";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tvCodeNoteCategory
            // 
            this.tvCodeNoteCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvCodeNoteCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvCodeNoteCategory.FullRowSelect = true;
            this.tvCodeNoteCategory.HideSelection = false;
            this.tvCodeNoteCategory.ItemHeight = 22;
            this.tvCodeNoteCategory.Location = new System.Drawing.Point(15, 25);
            this.tvCodeNoteCategory.Name = "tvCodeNoteCategory";
            treeNode1.Name = "Node0";
            treeNode1.Text = "少林寺網路上身 向科技人淘金 ";
            treeNode2.Name = "Node1";
            treeNode2.Text = "美研發智慧手表 號稱取代智慧手機";
            treeNode3.Name = "Node2";
            treeNode3.Text = "鴻海贊助創業平台 攻6大領域";
            this.tvCodeNoteCategory.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.tvCodeNoteCategory.ShowLines = false;
            this.tvCodeNoteCategory.ShowPlusMinus = false;
            this.tvCodeNoteCategory.ShowRootLines = false;
            this.tvCodeNoteCategory.Size = new System.Drawing.Size(256, 243);
            this.tvCodeNoteCategory.TabIndex = 0;
            this.tvCodeNoteCategory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCodeNoteCategory_AfterSelect);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(277, 25);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 22);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // CategoryManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(384, 312);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.tvCodeNoteCategory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryManagerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoryManagerForm";
            this.Shown += new System.EventHandler(this.CategoryManagerForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TreeView tvCodeNoteCategory;
        private System.Windows.Forms.Button btnNew;
    }
}