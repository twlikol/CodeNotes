using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Likol.CodeNotes.Data;

namespace Likol.CodeNotes.Options
{
    public partial class CodeNotesOptionControl : UserControl
    {
        private CodeNotesOption codeNotesOption;

        public CodeNotesOptionControl(CodeNotesOption codeNotesOption)
        {
            this.codeNotesOption = codeNotesOption;

            InitializeComponent();
        }

        private void CodeNotesOptionControl_Load(object sender, EventArgs e)
        {
            this.txtConnectionString.Text = this.codeNotesOption.ConnectionString;
        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            this.codeNotesOption.ConnectionString = this.txtConnectionString.Text;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            CodeNoteDataOperation codeNoteDataOperation = new CodeNoteDataOperation(codeNotesOption.ConnectionString);

            int result = -1;

            CodeNoteDataEntityCollection codeDataEnities = codeNoteDataOperation.Select(out result);

            if (result == -1)
            {
                MessageBox.Show("連線失敗,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("連線成功.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
