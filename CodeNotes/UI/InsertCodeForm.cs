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
        private string codeContext = "";

        public string CodeContext
        {
            get { return this.codeContext; }
        }

        public CodeNoteDataOperation CodeNoteDataOperation = null;

        public InsertCodeForm(CodeNotesOption codeNotesOption)
        {
            InitializeComponent();

            this.CodeNoteDataOperation = new CodeNoteDataOperation(codeNotesOption.ConnectionString);
        }

        private void InsertCodeForm_Shown(object sender, EventArgs e)
        {
            int result = -1;

            CodeNoteDataEntityCollection codeDataEnities = this.CodeNoteDataOperation.Select(out result);

            if (result == -1)
            {
                MessageBox.Show("無法取得程式碼筆記資料,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.cbCodeNoteID.DataSource = codeDataEnities;
            }
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
