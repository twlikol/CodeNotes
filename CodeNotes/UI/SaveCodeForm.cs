﻿using Likol.CodeNotes.Data;
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
        private string codeContext = "";

        public CodeNoteDataOperation CodeNoteDataOperation = null;
        public CodeNoteCategoryDataOperation CodeNoteCategoryDataOperation = null;

        public SaveCodeForm(string language, string codeContext)
        {
            InitializeComponent();

            this.language = language;
            this.codeContext = codeContext;

            string connectionString = CodeNotesPackage.Instance.Option.ConnectionString;

            this.CodeNoteDataOperation = new CodeNoteDataOperation(connectionString);
            this.CodeNoteCategoryDataOperation = new CodeNoteCategoryDataOperation(connectionString);
        }

        private void SaveCodeForm_Shown(object sender, EventArgs e)
        {
            int result = -1;

            CodeNoteCategoryDataEntityCollection codeNoteCategoryDataEntities = this.CodeNoteCategoryDataOperation.Select(this.language, out result);

            if (result == -1)
            {
                MessageBox.Show("程式碼筆記存取失敗,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Close();
            }
            else if (result == 0)
            {
                MessageBox.Show("儲存程式碼前必須先新增分類設定,請先新增分類設定.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Close();
            }

            foreach (CodeNoteCategoryDataEntity codeNoteCategoryDataEntity in codeNoteCategoryDataEntities)
            {
                this.cbCodeNoteCategory.Items.Add(codeNoteCategoryDataEntity);
            }

            if (this.cbCodeNoteCategory.Items.Count != 0)
                this.cbCodeNoteCategory.SelectedIndex = 0;
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
            codeDataEntity.CodeNoteCategoryID = ((CodeNoteCategoryDataEntity)this.cbCodeNoteCategory.SelectedItem).CodeNoteCategoryID;
            codeDataEntity.Description = this.txtDescription.Text;
            codeDataEntity.Context = this.codeContext;
            codeDataEntity.Created = DateTime.Now;
            codeDataEntity.LatestUpdate = DateTime.Now;

            int result = this.CodeNoteDataOperation.Create(codeDataEntity);

            if (result == -1)
            {
                MessageBox.Show("程式碼筆記新增失敗,請確認是否正確設定資料庫連線.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Close();
            }
            else
            {
                MessageBox.Show("程式碼筆記新增完成.", "程式碼筆記", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                CodeNotesPackage.Instance.OnRefresh(true);

                this.Close();
            }
        }
    }
}
