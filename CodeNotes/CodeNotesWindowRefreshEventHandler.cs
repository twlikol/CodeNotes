using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likol.CodeNotes
{
    public delegate void CodeNotesWindowRefreshEventHandler(object sender, CodeNotesWindowRefreshEventArgs e);

    public class CodeNotesWindowRefreshEventArgs : EventArgs
    {
        private bool isForce;

        public bool IsForce
        {
            get { return this.isForce; }
            set { this.isForce = value; }
        }

        public CodeNotesWindowRefreshEventArgs(bool isForce)
        {
            this.isForce = isForce;
        }
    }
}
