using Likol.CodeNotes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Likol.CodeNotes.UI
{
    public partial class CategoryEditForm : Form
    {
        public CodeNoteCategoryDataEntity codeNoteCategoryDataEntity = null;
        public CodeNoteCategoryDataOperation CodeNoteCategoryDataOperation = null;

        public CategoryEditForm(CodeNoteCategoryDataEntity codeNoteCategoryDataEntity)
        {
            InitializeComponent();

            this.codeNoteCategoryDataEntity = codeNoteCategoryDataEntity;

            string connectionString = CodeNotesPackage.Instance.Option.ConnectionString;

            this.CodeNoteCategoryDataOperation = new CodeNoteCategoryDataOperation(connectionString);
        }

        private void CategoryEditForm_Shown(object sender, EventArgs e)
        {
            this.txtName.Text = this.codeNoteCategoryDataEntity.Name;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text == "")
            {
                MessageBox.Show("必須輸入程式碼名稱.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            CodeNoteCategoryDataEntity codeNoteCategoryDataEntity = new CodeNoteCategoryDataEntity();
            codeNoteCategoryDataEntity.CodeNoteCategoryID = this.codeNoteCategoryDataEntity.CodeNoteCategoryID;
            codeNoteCategoryDataEntity.Name = this.txtName.Text;
            codeNoteCategoryDataEntity.Language = this.codeNoteCategoryDataEntity.Language;
            codeNoteCategoryDataEntity.Created = DateTime.Now;
            codeNoteCategoryDataEntity.LatestUpdate = DateTime.Now;

            int result = this.CodeNoteCategoryDataOperation.Update(codeNoteCategoryDataEntity);

            if (result == -1)
            {
                MessageBox.Show("程式碼筆記分類更新失敗,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Close();
            }
            else
            {
                //MessageBox.Show("程式碼筆記分類更新完成.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
        }
    }
}
