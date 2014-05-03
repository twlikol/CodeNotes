using Likol.CodeNotes.Data;
using Likol.CodeNotes.Options;
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
    public partial class EditCodeForm : Form
    {
        private CodeNoteDataEntity codeNoteDataEntity = null;

        public CodeNoteDataOperation CodeNoteDataOperation = null;
        public CodeNoteCategoryDataOperation CodeNoteCategoryDataOperation = null;

        public EditCodeForm(CodeNoteDataEntity codeNoteDataEntity)
        {
            InitializeComponent();

            this.codeNoteDataEntity = codeNoteDataEntity;

            string connectionString = CodeNotesPackage.Instance.Option.ConnectionString;

            this.CodeNoteDataOperation = new CodeNoteDataOperation(connectionString);
            this.CodeNoteCategoryDataOperation = new CodeNoteCategoryDataOperation(connectionString);
        }

        private void SaveCodeForm_Shown(object sender, EventArgs e)
        {
            int result = -1;

            CodeNoteCategoryDataEntityCollection codeNoteCategoryDataEntities = this.CodeNoteCategoryDataOperation.Select(this.codeNoteDataEntity.Language, out result);

            if (result == -1)
            {
                MessageBox.Show("程式碼筆記存取失敗,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Close();
            }

            foreach (CodeNoteCategoryDataEntity codeNoteCategoryDataEntity in codeNoteCategoryDataEntities)
            {
                this.cbCodeNoteCategory.Items.Add(codeNoteCategoryDataEntity);
            }

            if (this.cbCodeNoteCategory.Items.Count != 0)
            {
                int itemIndex = 0;

                foreach (CodeNoteCategoryDataEntity codeNoteCategoryDataEntity in codeNoteCategoryDataEntities)
                {
                    if (codeNoteCategoryDataEntity.CodeNoteCategoryID == this.codeNoteDataEntity.CodeNoteCategoryID)
                    {
                        this.cbCodeNoteCategory.SelectedIndex = itemIndex;
                        break;
                    }

                    itemIndex++;
                }
            }

            this.txtTitle.Text = this.codeNoteDataEntity.Title;
            this.txtDescription.Text = this.codeNoteDataEntity.Description;
            this.txtCode.Text = this.codeNoteDataEntity.Context;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtTitle.Text == "")
            {
                MessageBox.Show("必須輸入程式碼名稱.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            CodeNoteDataEntity codeDataEntity = new CodeNoteDataEntity();
            codeDataEntity.CodeNoteID = this.codeNoteDataEntity.CodeNoteID;
            codeDataEntity.Title = this.txtTitle.Text;
            codeDataEntity.Language = this.codeNoteDataEntity.Language;
            codeDataEntity.CodeNoteCategoryID = ((CodeNoteCategoryDataEntity)this.cbCodeNoteCategory.SelectedItem).CodeNoteCategoryID;
            codeDataEntity.Description = this.txtDescription.Text;
            codeDataEntity.Context = this.txtCode.Text;
            codeDataEntity.LatestUpdate = DateTime.Now;

            int result = this.CodeNoteDataOperation.Update(codeDataEntity);

            if (result == -1)
            {
                MessageBox.Show("程式碼筆記更新失敗,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Close();
            }
            else
            {
                //MessageBox.Show("程式碼筆記更新完成.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                CodeNotesPackage.Instance.OnRefresh(true);

                this.Close();
            }
        }
    }
}
