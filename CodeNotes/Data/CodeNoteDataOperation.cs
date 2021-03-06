﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likol.CodeNotes.Data
{
    public class CodeNoteDataOperation
    {
        public CodeNoteDataOperation(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string connectionString = "";
        
        public string ConnectionString
        {
            get { return this.connectionString; }
            set { this.connectionString = value; }
        }

        public CodeNoteDataEntity Get(CodeNoteDataEntity codeNoteDataEntity)
        {
            string commandText = "SELECT * FROM CodeNote WHERE CodeNoteID=@CodeNoteID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CodeNoteID", codeNoteDataEntity.CodeNoteID));

            codeNoteDataEntity = null;

            SqlConnection sqlConnection = null;
            SqlDataReader sqlDataReader = null;

            try
            {
                sqlConnection = new SqlConnection(this.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddRange(parameters.ToArray());

                sqlConnection.Open();

                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    codeNoteDataEntity = this.GetFromReader(sqlDataReader);
                }
            }
            catch
            {

            }
            finally
            {
                if (sqlDataReader != null)
                {
                    if (!sqlDataReader.IsClosed)
                        sqlDataReader.Close();

                    sqlDataReader.Dispose();
                }

                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                        sqlConnection.Close();

                    sqlConnection.Dispose();
                }
            }

            return codeNoteDataEntity;
        }

        public int Create(CodeNoteDataEntity codeNoteDataEntity)
        {
            string commandText = "INSERT INTO CodeNote (Title,Language,CodeNoteCategoryID,Description,Context,Created,LatestUpdate)";
            commandText += " VALUES(@Title,@Language,@CodeNoteCategoryID,@Description,@Context,@Created,@LatestUpdate) SELECT @@IDENTITY";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Title", codeNoteDataEntity.Title));
            parameters.Add(new SqlParameter("Language", codeNoteDataEntity.Language));
            parameters.Add(new SqlParameter("CodeNoteCategoryID", codeNoteDataEntity.CodeNoteCategoryID));
            parameters.Add(new SqlParameter("Description", codeNoteDataEntity.Description));
            parameters.Add(new SqlParameter("Context", codeNoteDataEntity.Context));
            parameters.Add(new SqlParameter("Created", codeNoteDataEntity.Created));
            parameters.Add(new SqlParameter("LatestUpdate", codeNoteDataEntity.LatestUpdate));

            object returnValue = -1;

            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = new SqlConnection(this.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddRange(parameters.ToArray());

                sqlConnection.Open();

                returnValue = sqlCommand.ExecuteScalar();
            }
            catch
            {

            }
            finally
            {
                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                        sqlConnection.Close();

                    sqlConnection.Dispose();
                }
            }

            return Convert.ToInt32(returnValue);
        }

        public int Update(CodeNoteDataEntity codeNoteDataEntity)
        {
            string commandText = "UPDATE CodeNote SET";
            commandText += " Title=@Title,Language=@Language,CodeNoteCategoryID=@CodeNoteCategoryID,Description=@Description,Context=@Context,LatestUpdate=@LatestUpdate";
            commandText += " WHERE CodeNoteID=@CodeNoteID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CodeNoteID", codeNoteDataEntity.CodeNoteID));
            parameters.Add(new SqlParameter("Title", codeNoteDataEntity.Title));
            parameters.Add(new SqlParameter("Language", codeNoteDataEntity.Language));
            parameters.Add(new SqlParameter("CodeNoteCategoryID", codeNoteDataEntity.CodeNoteCategoryID));
            parameters.Add(new SqlParameter("Description", codeNoteDataEntity.Context));
            parameters.Add(new SqlParameter("Context", codeNoteDataEntity.Context));
            parameters.Add(new SqlParameter("LatestUpdate", codeNoteDataEntity.LatestUpdate));

            int returnValue = -1;

            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = new SqlConnection(this.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddRange(parameters.ToArray());

                sqlConnection.Open();

                returnValue = sqlCommand.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                        sqlConnection.Close();

                    sqlConnection.Dispose();
                }
            }

            return returnValue;
        }

        public int Delete(CodeNoteDataEntity codeNoteDataEntity)
        {
            string commandText = "DELETE CodeNote WHERE CodeNoteID=@CodeNoteID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CodeNoteID", codeNoteDataEntity.CodeNoteID));

            int returnValue = -1;

            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = new SqlConnection(this.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddRange(parameters.ToArray());

                sqlConnection.Open();

                returnValue = sqlCommand.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                        sqlConnection.Close();

                    sqlConnection.Dispose();
                }
            }

            return returnValue;
        }

        private CodeNoteDataEntity GetFromReader(SqlDataReader sqlDataReader)
        {
            CodeNoteDataEntity codeNoteDataEntity = new CodeNoteDataEntity();

            codeNoteDataEntity.CodeNoteID = (int)sqlDataReader["CodeNoteID"];
            codeNoteDataEntity.Title = (string)sqlDataReader["Title"];
            codeNoteDataEntity.Language = (string)sqlDataReader["Language"];
            codeNoteDataEntity.CodeNoteCategoryID = (int)sqlDataReader["CodeNoteCategoryID"];
            codeNoteDataEntity.Description = (string)sqlDataReader["Description"];
            codeNoteDataEntity.Context = (string)sqlDataReader["Context"];
            codeNoteDataEntity.Created = (DateTime)sqlDataReader["Created"];
            codeNoteDataEntity.LatestUpdate = (DateTime)sqlDataReader["LatestUpdate"];

            return codeNoteDataEntity;
        }

        public CodeNoteDataEntityCollection Select(string language, int codeNoteCategoryID, out int result)
        {
            string commandText = "SELECT * FROM CodeNote";
            commandText += " WHERE 1=1";

            if (codeNoteCategoryID != 0)
                commandText += " AND CodeNoteCategoryID=@CodeNoteCategoryID";

            if (!string.IsNullOrEmpty(language))
                commandText += " AND Language=@Language";

            commandText += " ORDER BY Created ASC";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Language", language));
            parameters.Add(new SqlParameter("CodeNoteCategoryID", codeNoteCategoryID));

            CodeNoteDataEntityCollection codeNoteDataEntities = new CodeNoteDataEntityCollection();

            SqlConnection sqlConnection = null;
            SqlDataReader sqlDataReader = null;

            try
            {
                sqlConnection = new SqlConnection(this.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddRange(parameters.ToArray());

                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    CodeNoteDataEntity codeNoteDataEntity = this.GetFromReader(sqlDataReader);

                    codeNoteDataEntities.Add(codeNoteDataEntity);
                }

                result = codeNoteDataEntities.Count;
            }
            catch
            {
                result = -1;
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    if (!sqlDataReader.IsClosed)
                        sqlDataReader.Close();

                    sqlDataReader.Dispose();
                }

                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                        sqlConnection.Close();

                    sqlConnection.Dispose();
                }
            }

            return codeNoteDataEntities;
        }
    }
}
