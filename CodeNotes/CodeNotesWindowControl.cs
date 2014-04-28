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

namespace Likol.CodeNotes
{
    public partial class CodeNotesWindowControl : UserControl
    {
        private CodeNoteDataOperation codeNoteDataOperation;

        public CodeNotesWindowControl()
        {
            InitializeComponent();
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

        private void tvCodeNotes_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode treeNode = e.Item as TreeNode;

            if (treeNode == null) return;

            CodeNoteDataEntity codeNoteDataEntity = treeNode.Tag as CodeNoteDataEntity;

            if (codeNoteDataEntity == null) return;

            OleDataObject oleDataObject = new OleDataObject();
            oleDataObject.SetData(codeNoteDataEntity.Context);

            DoDragDrop(oleDataObject, DragDropEffects.Move);
        }

        private void tvCodeNotes_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode treeNode = tvCodeNotes.GetNodeAt(e.X, e.Y);

            tvCodeNotes.SelectedNode = treeNode;
        }

        private void CodeNotesWindowControl_Load(object sender, EventArgs e)
        {
            string connectionString = CodeNotesPackage.Instance.Option.ConnectionString;

            this.codeNoteDataOperation = new CodeNoteDataOperation(connectionString);

            CodeNotesPackage.Instance.Refresh += new EventHandler(CodeNotesPackage_Refresh);

            //this.BindCodeNoteData();
        }

        private void CodeNotesPackage_Refresh(object sender, EventArgs e)
        {
            this.BindCodeNoteData();
        }

        private void BindCodeNoteData()
        {
            this.tvCodeNotes.Nodes.Clear();

            int result = -1;

            if (CodeNotesPackage.Instance.DTE.ActiveDocument == null) return;

            TextDocument textDocument = CodeNotesPackage.Instance.DTE.ActiveDocument.Object() as TextDocument;

            if (textDocument == null) return;

            string language = textDocument.Language;

            CodeNoteDataEntityCollection codeNoteDataEntities = codeNoteDataOperation.Select(language, out result);

            if (result == -1)
            {
                MessageBox.Show("程式碼筆記存取失敗,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            foreach (CodeNoteDataEntity codeNoteDataEntity in codeNoteDataEntities)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Text = codeNoteDataEntity.Title;
                treeNode.Tag = codeNoteDataEntity;

                this.tvCodeNotes.Nodes.Add(treeNode);
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否確定要刪除選擇的程式碼?", "程式碼筆記", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult != DialogResult.Yes) return;

            TreeNode treeNode = this.tvCodeNotes.SelectedNode;

            CodeNoteDataEntity codeNoteDataEntity = treeNode.Tag as CodeNoteDataEntity;

            this.codeNoteDataOperation.Delete(codeNoteDataEntity);

            this.BindCodeNoteData();
        }

        private void cmsCodeNotes_Opening(object sender, CancelEventArgs e)
        {
            if (this.tvCodeNotes.SelectedNode == null)
                e.Cancel = true;
        }
    }
}
