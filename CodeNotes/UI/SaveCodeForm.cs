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
    public partial class SaveCodeForm : Form
    {
        private string language = "";

        public string Language
        {
            get { return this.language; }
            set { this.language = value; }
        }

        private string codeContext = "";

        public string CodeContext
        {
            get { return this.codeContext; }
            set { this.codeContext = value; }
        }

        private CodeNotesPackage Package = null;

        public CodeNoteDataOperation CodeNoteDataOperation = null;

        public SaveCodeForm(CodeNotesPackage codeNotesPackage, CodeNotesOption codeNotesOption)
        {
            InitializeComponent();

            this.Package = codeNotesPackage;
            this.CodeNoteDataOperation = new CodeNoteDataOperation(codeNotesOption.ConnectionString);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtTitle.Text == "")
            {
                MessageBox.Show("必須輸入程式碼名稱.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            CodeNoteDataEntity codeDataEntity = new CodeNoteDataEntity();
            codeDataEntity.Title = this.txtTitle.Text;
            codeDataEntity.Language = this.language;
            codeDataEntity.Description = this.txtDescription.Text;
            codeDataEntity.Context = this.CodeContext;
            codeDataEntity.Created = DateTime.Now;

            int result = this.CodeNoteDataOperation.Create(codeDataEntity);

            if (result == -1)
            {
                MessageBox.Show("程式碼筆記新增失敗,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("程式碼筆記新增完成.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Package.OnRefresh();

                this.Close();
            }
        }
    }
}
