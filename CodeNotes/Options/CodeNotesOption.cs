using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Likol.CodeNotes.Options
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("57B24E78-827D-4F9A-BBD9-3D16CDFD6DA0")]
    public class CodeNotesOption : DialogPage
    {
        private string connectionString = "";

        public string ConnectionString
        {
            get { return this.connectionString; }
            set { this.connectionString = value; }
        }

        protected override System.Windows.Forms.IWin32Window Window
        {
            get
            {
                CodeNotesOptionControl codeNotesOptionControl = new CodeNotesOptionControl(this);

                return codeNotesOptionControl;
            }
        }
    }
}
