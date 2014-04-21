using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Likol.CodeNotes
{
    [Guid("5EB0C48D-F2A7-4877-95C7-2828945FC9B6")]
    public class CodeNotesWindow : ToolWindowPane
    {
        private CodeNotesWindowControl windowControl;

        public CodeNotesWindow() : base(null)
        {
            this.Caption = "程式碼筆記";

            this.windowControl = new CodeNotesWindowControl();
        }

        public override IWin32Window Window
        {
            get
            {
                return (IWin32Window)windowControl;
            }
        }
    }
}
