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
    public partial class InsertCodeForm : Form
    {
        private string language = "";
        private string codeContext = "";

        public string CodeContext
        {
            get { return this.codeContext; }
        }

        public CodeNoteDataOperation CodeNoteDataOperation = null;
        public CodeNoteCategoryDataOperation CodeNoteCategoryDataOperation = null;

        public InsertCodeForm(string language)
        {
            InitializeComponent();

            this.language = language;

            string connectionString = CodeNotesPackage.Instance.Option.ConnectionString;

            this.CodeNoteDataOperation = new CodeNoteDataOperation(connectionString);
            this.CodeNoteCategoryDataOperation = new CodeNoteCategoryDataOperation(connectionString);
        }

        private void InsertCodeForm_Shown(object sender, EventArgs e)
        {
            bool result = this.BindCodeNoteCategoryData();

            if (result) this.BindCodeNodeData();
        }

        private bool BindCodeNoteCategoryData()
        {
            int result = -1;

            CodeNoteCategoryDataEntityCollection codeNoteCategoryDataEntities = this.CodeNoteCategoryDataOperation.Select(this.language, out result);

            if (result == -1)
            {
                MessageBox.Show("程式碼筆記存取失敗,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Close();
            }

            CodeNoteCategoryDataEntity cncdeAll = new CodeNoteCategoryDataEntity();
            cncdeAll.CodeNoteCategoryID = 0;
            cncdeAll.Name = "全部";

            codeNoteCategoryDataEntities.Insert(0, cncdeAll);

            foreach (CodeNoteCategoryDataEntity codeNoteCategoryDataEntity in codeNoteCategoryDataEntities)
            {
                this.cbCodeNoteCategory.Items.Add(codeNoteCategoryDataEntity);
            }

            this.cbCodeNoteCategory.SelectedIndex = 0;

            return true;
        }

        private void BindCodeNodeData()
        {
            if (this.cbCodeNoteCategory.SelectedItem == null) return;

            int codeNoteCategoryID = ((CodeNoteCategoryDataEntity)this.cbCodeNoteCategory.SelectedItem).CodeNoteCategoryID;

            int result = -1;

            CodeNoteDataEntityCollection codeDataEnities = this.CodeNoteDataOperation.Select(this.language, codeNoteCategoryID, out result);

            if (result == -1)
            {
                MessageBox.Show("無法取得程式碼筆記資料,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Close();
            }
            else
            {
                this.cbCodeNoteID.DataSource = codeDataEnities;
            }
        }

        private void cbCodeNoteID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbCodeNoteID.SelectedItem == null)
            {
                this.txtDescription.Text = "";

                return;
            }

            CodeNoteDataEntity codeNoteDataEntity = this.cbCodeNoteID.SelectedItem as CodeNoteDataEntity;

            this.txtDescription.Text = codeNoteDataEntity.Description;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.cbCodeNoteID.SelectedItem == null)
            {
                MessageBox.Show("請選擇要插入的程式碼名稱.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            CodeNoteDataEntity codeNoteDataEntity = this.cbCodeNoteID.SelectedItem as CodeNoteDataEntity;

            if (codeNoteDataEntity == null) return;

            this.codeContext = codeNoteDataEntity.Context;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }
    }
}
