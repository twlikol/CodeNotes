using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using Likol.CodeNotes.Data;
using EnvDTE;
using Likol.CodeNotes.UI;

namespace Likol.CodeNotes
{
    public partial class CodeNotesWindowControl : UserControl
    {
        private CodeNoteDataOperation codeNoteDataOperation;
        private CodeNoteCategoryDataOperation codeNoteCategoryDataOperation;

        public CodeNotesWindowControl()
        {
            InitializeComponent();

            Font vsFont = CodeNotesPackage.Instance.GetVsDefaultFont();

            if (vsFont != null) this.Font = vsFont;
        }

        private void CodeNotesWindowControl_Load(object sender, EventArgs e)
        {
            string connectionString = CodeNotesPackage.Instance.Option.ConnectionString;

            this.codeNoteDataOperation = new CodeNoteDataOperation(connectionString);
            this.codeNoteCategoryDataOperation = new CodeNoteCategoryDataOperation(connectionString);

            CodeNotesPackage.Instance.Refresh += new CodeNotesWindowRefreshEventHandler(RefreshEvent);
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

            base.OnDragEnter(e);
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

            base.OnDragOver(e);
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            Type type = e.Data.GetType();

            if (e.Data.GetDataPresent(typeof(string)))
            {
                object data = e.Data.GetData(typeof(string));
            }

            base.OnDragDrop(e);
        }

        private void tvCodeNote_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode treeNode = e.Item as TreeNode;

            if (treeNode == null) return;

            CodeNoteDataEntity codeNoteDataEntity = treeNode.Tag as CodeNoteDataEntity;

            if (codeNoteDataEntity == null) return;

            OleDataObject oleDataObject = new OleDataObject();
            oleDataObject.SetData(codeNoteDataEntity.Context);

            DoDragDrop(oleDataObject, DragDropEffects.Move);
        }

        private void tvCodeNote_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode treeNode = tvCodeNote.GetNodeAt(e.X, e.Y);

            tvCodeNote.SelectedNode = treeNode;
        }

        private string currentTextLanguage = "None";

        private void RefreshEvent(object sender, CodeNotesWindowRefreshEventArgs e)
        {
            if (e.IsForce || this.currentTextLanguage != this.TextLanguage)
            {
                this.OnRefresh();
            }
        }

        private void OnRefresh()
        {
            this.cbCodeNoteCategory.Items.Clear();
            this.tvCodeNote.Nodes.Clear();

            bool result = this.BindCodeNoteCategoryData();

            if (result) this.BindCodeNoteData();

            this.currentTextLanguage = this.TextLanguage;
        }

        private string TextLanguage
        {
            get
            {
                string language = "";

                if (CodeNotesPackage.Instance.DTE.ActiveDocument != null)
                {
                    TextDocument textDocument = CodeNotesPackage.Instance.DTE.ActiveDocument.Object() as TextDocument;

                    if (textDocument != null)
                        language = textDocument.Language;
                }

                return language;
            }
        }

        private bool BindCodeNoteCategoryData()
        {
            this.cbCodeNoteCategory.Items.Clear();

            if (this.TextLanguage == "") return false;

            int result = -1;

            CodeNoteCategoryDataEntityCollection codeNoteCategoryDataEntities = codeNoteCategoryDataOperation.Select(this.TextLanguage, out result);

            if (result == -1)
            {
                MessageBox.Show("程式碼筆記存取失敗,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            CodeNoteCategoryDataEntity cncdeAll = new CodeNoteCategoryDataEntity();
            cncdeAll.CodeNoteCategoryID = 0;
            cncdeAll.Name = "全部";
            cncdeAll.Language = this.TextLanguage;

            codeNoteCategoryDataEntities.Insert(0, cncdeAll);

            CodeNoteCategoryDataEntity cncdeManager = new CodeNoteCategoryDataEntity();
            cncdeManager.CodeNoteCategoryID = -1;
            cncdeManager.Name = "<設定...>";
            cncdeManager.Language = this.TextLanguage;

            codeNoteCategoryDataEntities.Insert(codeNoteCategoryDataEntities.Count, cncdeManager);

            foreach (CodeNoteCategoryDataEntity codeNoteCategoryDataEntity in codeNoteCategoryDataEntities)
            {
                this.cbCodeNoteCategory.Items.Add(codeNoteCategoryDataEntity);
            }

            this.cbCodeNoteCategory.SelectedIndex = 0;

            return true;
        }

        private bool BindCodeNoteData()
        {
            this.tvCodeNote.Nodes.Clear();

            if (this.TextLanguage == "") return false;

            int codeNoteCategoryID = ((CodeNoteCategoryDataEntity)this.cbCodeNoteCategory.SelectedItem).CodeNoteCategoryID;

            int result = -1;

            CodeNoteDataEntityCollection codeNoteDataEntities = codeNoteDataOperation.Select(this.TextLanguage, codeNoteCategoryID, out result);

            if (result == -1)
            {
                MessageBox.Show("程式碼筆記存取失敗,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            foreach (CodeNoteDataEntity codeNoteDataEntity in codeNoteDataEntities)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Text = codeNoteDataEntity.Title;
                treeNode.Tag = codeNoteDataEntity;

                this.tvCodeNote.Nodes.Add(treeNode);
            }

            return true;
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = this.tvCodeNote.SelectedNode;

            CodeNoteDataEntity codeNoteDataEntity = treeNode.Tag as CodeNoteDataEntity;

            EditCodeForm editCodeForm = new EditCodeForm(codeNoteDataEntity);

            Font vsFont = CodeNotesPackage.Instance.GetVsDefaultFont();

            if (vsFont != null) editCodeForm.Font = vsFont;

            DialogResult dialogResult = editCodeForm.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否確定要刪除選擇的程式碼?", "程式碼筆記", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult != DialogResult.Yes) return;

            TreeNode treeNode = this.tvCodeNote.SelectedNode;

            CodeNoteDataEntity codeNoteDataEntity = treeNode.Tag as CodeNoteDataEntity;

            this.codeNoteDataOperation.Delete(codeNoteDataEntity);

            this.BindCodeNoteData();
        }

        private void cmsCodeNote_Opening(object sender, CancelEventArgs e)
        {
            if (this.tvCodeNote.SelectedNode == null)
                e.Cancel = true;
        }

        private void cbCodeNoteCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbCodeNoteCategory.SelectedItem == null) return;

            CodeNoteCategoryDataEntity codeNoteCategoryDataEntity = (CodeNoteCategoryDataEntity)this.cbCodeNoteCategory.SelectedItem;

            if (codeNoteCategoryDataEntity.CodeNoteCategoryID >= 0)
            {
                this.BindCodeNoteData();

                return;
            }

            CategoryManagerForm categoryManagerForm = new CategoryManagerForm(codeNoteCategoryDataEntity.Language);

            Font vsFont = CodeNotesPackage.Instance.GetVsDefaultFont();

            if (vsFont != null) categoryManagerForm.Font = vsFont;

            DialogResult dialogResult = categoryManagerForm.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                this.OnRefresh();
            }
            else
            {
                this.cbCodeNoteCategory.SelectedIndex = 0;

                this.BindCodeNoteData();
            }
        }
    }
}
