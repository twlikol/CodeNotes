using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
    }
}
