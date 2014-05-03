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
    public partial class CategoryManagerForm : Form
    {
        private bool isDirty = false;
        private string language;

        public CodeNoteCategoryDataOperation CodeNoteCategoryDataOperation = null;

        public CategoryManagerForm(string language)
        {
            InitializeComponent();

            this.language = language;

            this.Text = string.Format("{0}分類", this.language);

            string connectionString = CodeNotesPackage.Instance.Option.ConnectionString;

            this.CodeNoteCategoryDataOperation = new CodeNoteCategoryDataOperation(connectionString);
        }

        private void CategoryManagerForm_Shown(object sender, EventArgs e)
        {
            this.btnEdit.Enabled = false;
            this.btnRemove.Enabled = false;

            this.BindCodeNoteCategoryData();
        }

        private bool BindCodeNoteCategoryData()
        {
            this.tvCodeNoteCategory.Nodes.Clear();

            int result = -1;

            CodeNoteCategoryDataEntityCollection codeNoteCategoryDataEntities = this.CodeNoteCategoryDataOperation.Select(this.language, out result);

            if (result == -1)
            {
                MessageBox.Show("程式碼筆記存取失敗,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Close();
            }

            foreach (CodeNoteCategoryDataEntity codeNoteCategoryDataEntity in codeNoteCategoryDataEntities)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Text = codeNoteCategoryDataEntity.Name;
                treeNode.Tag = codeNoteCategoryDataEntity;

                this.tvCodeNoteCategory.Nodes.Add(treeNode);
            }

            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CategoryNewForm categoryNewForm = new CategoryNewForm(this.language);
            categoryNewForm.Font = this.Font;

            DialogResult dialogResult = categoryNewForm.ShowDialog();

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.BindCodeNoteCategoryData();

                this.isDirty = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.tvCodeNoteCategory.SelectedNode == null) return;

            DialogResult dialogResult = MessageBox.Show("是否確定要刪除選擇的分類?", "程式碼筆記", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult != DialogResult.Yes) return;

            TreeNode treeNode = this.tvCodeNoteCategory.SelectedNode;

            CodeNoteCategoryDataEntity codeNoteCategoryDataEntity = treeNode.Tag as CodeNoteCategoryDataEntity;

            int result = this.CodeNoteCategoryDataOperation.Delete(codeNoteCategoryDataEntity);

            if (result == -1)
            {
                MessageBox.Show("程式碼筆記分類刪除失敗,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            this.BindCodeNoteCategoryData();

            this.isDirty = true;
        }

        private void tvCodeNoteCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvCodeNoteCategory.SelectedNode == null) return;

            this.btnEdit.Enabled = true;
            this.btnRemove.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.tvCodeNoteCategory.SelectedNode == null) return;

            TreeNode treeNode = this.tvCodeNoteCategory.SelectedNode;

            CodeNoteCategoryDataEntity codeNoteCategoryDataEntity = treeNode.Tag as CodeNoteCategoryDataEntity;

            CategoryEditForm categoryEditForm = new CategoryEditForm(codeNoteCategoryDataEntity);
            categoryEditForm.Font = this.Font;

            DialogResult dialogResult = categoryEditForm.ShowDialog();

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.BindCodeNoteCategoryData();

                this.isDirty = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.isDirty)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                this.DialogResult = System.Windows.Forms.DialogResult.Ignore;

            this.Close();
        }
    }
}
