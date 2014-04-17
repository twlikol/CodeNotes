using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Likol.CodeNotes.Options;

namespace Likol.CodeNotes
{
    [ProvideOptionPage(typeof(CodeNotesOption), "程式碼筆記", "一般", 0, 0, true)]
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidCodeNotesPkgString)]
    public sealed class CodeNotesPackage : Package
    {
        public CodeNotesPackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        protected override void Initialize()
        {
            Debug.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            OleMenuCommandService oleMenuCommandService = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;

            if (null != oleMenuCommandService)
            {
                CommandID menuCommandID = new CommandID(GuidList.guidCodeNotesCmdSet, (int)PkgCmdIDList.cmdidInsertCode);
                MenuCommand menuCommand = new MenuCommand(this.InsertCode, menuCommandID);

                oleMenuCommandService.AddCommand(menuCommand);

                CommandID menuCommandID2 = new CommandID(GuidList.guidCodeNotesCmdSet, (int)PkgCmdIDList.cmdidSaveCode);
                MenuCommand menuCommand2 = new MenuCommand(this.SaveCode, menuCommandID2);

                oleMenuCommandService.AddCommand(menuCommand2);
            }
        }

        private void InsertCode(object sender, EventArgs e)
        {
            
        }

        private void SaveCode(object sender, EventArgs e)
        {
            
        }
    }
}
