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
using EnvDTE;
using System.Windows.Forms;
using Likol.CodeNotes.UI;
using Likol.CodeNotes.Common;
using System.Drawing;

namespace Likol.CodeNotes
{
    [ProvideOptionPage(typeof(CodeNotesOption), "程式碼筆記", "一般", 0, 0, true)]
    [ProvideToolWindow(typeof(CodeNotesWindow))]
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidCodeNotesPkgString)]
    public sealed class CodeNotesPackage : Package
    {
        public static CodeNotesPackage Instance = null;

        public event EventHandler Refresh = null;

        public CodeNotesOption Option = null;

        private DTE dte;

        public DTE DTE
        {
            get { return this.dte; }
        }

        public CodeNotesPackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));

            this.dte = Package.GetGlobalService(typeof(DTE)) as DTE;

            this.dte.Events.WindowEvents.WindowActivated += new _dispWindowEvents_WindowActivatedEventHandler(WindowEvents_WindowActivated);
        }

        private void WindowEvents_WindowActivated(Window GotFocus, Window LostFocus)
        {
            this.OnRefresh();
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

                CommandID menuCommandID3 = new CommandID(GuidList.guidCodeNotesCmdSet, (int)PkgCmdIDList.cmdidCodeNotes);
                MenuCommand menuCommand3 = new MenuCommand(this.DisplayWindow, menuCommandID3);

                oleMenuCommandService.AddCommand(menuCommand3);
            }

            CodeNotesPackage.Instance = this;

            this.Option = this.GetDialogPage(typeof(CodeNotesOption)) as CodeNotesOption;
        }

        private void InsertCode(object sender, EventArgs e)
        {
            if (this.Option == null) return;

            if (this.DTE.ActiveWindow.Document == null) return;

            TextDocument textDocument = this.DTE.ActiveWindow.Document.Object() as TextDocument;

            string language = textDocument.Language;

            InsertCodeForm insertCodeForm = new InsertCodeForm(this.Option);
            insertCodeForm.Language = language;

            Font vsFont = this.GetVsDefaultFont();

            if (vsFont != null)
                insertCodeForm.Font = vsFont;   

            DialogResult dialogResult = insertCodeForm.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                if (this.DTE.ActiveWindow.Document == null) return;

                TextSelection textSelection = (TextSelection)this.DTE.ActiveWindow.Document.Selection;

                textSelection.Insert(insertCodeForm.CodeContext);
                textSelection.NewLine();

                this.DTE.ExecuteCommand("Edit.FormatDocument", "");
            }
        }

        private void SaveCode(object sender, EventArgs e)
        {
            if (this.Option == null) return;

            if (this.DTE.ActiveWindow.Document == null) return;

            string typeGUID = this.DTE.ActiveWindow.ObjectKind;
            string typeClass = Microsoft.VisualBasic.Information.TypeName(this.DTE.ActiveWindow.Object);

            string docClass = Microsoft.VisualBasic.Information.TypeName(this.DTE.ActiveWindow.Document.Object());

            TextSelection textSelection = (TextSelection)this.DTE.ActiveWindow.Document.Selection;

            string selectionText = textSelection.Text;

            if (selectionText == "")
            {
                MessageBox.Show("請先選取你要儲存的程式碼.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            TextDocument textDocument = this.DTE.ActiveWindow.Document.Object() as TextDocument;

            string language = textDocument.Language;

            SaveCodeForm saveCodeForm = new SaveCodeForm(this, this.Option);

            Font vsFont = this.GetVsDefaultFont();

            if (vsFont != null)
                saveCodeForm.Font = vsFont;            

            saveCodeForm.Language = language;
            saveCodeForm.CodeContext = selectionText;
            saveCodeForm.ShowDialog();
        }

        private void DisplayWindow(object sender, EventArgs e)
        {
            ToolWindowPane toolWindowPane = this.FindToolWindow(typeof(CodeNotesWindow), 0, true);

            if ((null == toolWindowPane) || (null == toolWindowPane.Frame))
            {
                throw new NotSupportedException("開啟程式碼筆記視窗失敗.");
            }

            IVsWindowFrame vsWindowFrame = (IVsWindowFrame)toolWindowPane.Frame;

            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(vsWindowFrame.Show());
        }

        public void OnRefresh()
        {
            if (this.Refresh != null)
            {
                this.Refresh(this, EventArgs.Empty);
            }
        }

        public Font GetVsDefaultFont()
        {
            IUIHostLocale2 service = this.GetService<IUIHostLocale2, IUIHostLocale>();

            if (service != null)
            {
                UIDLGLOGFONT[] array = new UIDLGLOGFONT[1];

                int dialogFont = service.GetDialogFont(array);

                if (dialogFont >= 0)
                {
                    return VsUtil.FontFromUIDLGLOGFONT(array[0]);
                }
            }

            return null;
        }

        public InterfaceType GetService<InterfaceType, ServiceType>()
            where InterfaceType : class
            where ServiceType : class
        {
            return VsUtil.GetService<InterfaceType, ServiceType>(this);
        }
    }
}
