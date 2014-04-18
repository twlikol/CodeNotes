namespace Likol.CodeNotes.UI
{
    partial class InsertCodeForm
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
            this.cbCodeNoteID = new System.Windows.Forms.ComboBox();
            this.cbShowCode = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbCodeNoteID
            // 
            this.cbCodeNoteID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCodeNoteID.FormattingEnabled = true;
            this.cbCodeNoteID.Location = new System.Drawing.Point(12, 12);
            this.cbCodeNoteID.Name = "cbCodeNoteID";
            this.cbCodeNoteID.Size = new System.Drawing.Size(360, 21);
            this.cbCodeNoteID.TabIndex = 0;
            // 
            // cbShowCode
            // 
            this.cbShowCode.AutoSize = true;
            this.cbShowCode.Location = new System.Drawing.Point(12, 39);
            this.cbShowCode.Name = "cbShowCode";
            this.cbShowCode.Size = new System.Drawing.Size(86, 17);
            this.cbShowCode.TabIndex = 1;
            this.cbShowCode.Text = "顯示程式碼";
            this.cbShowCode.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(297, 77);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(216, 77);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "確定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // InsertCodeForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 112);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbShowCode);
            this.Controls.Add(this.cbCodeNoteID);
            this.Name = "InsertCodeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "插入程式碼";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCodeNoteID;
        private System.Windows.Forms.CheckBox cbShowCode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}