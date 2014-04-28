using System;
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
            string commandText = "INSERT INTO CodeNote (Title,Language,Description,Context,Created)";
            commandText += " VALUES(@Title,@Language,@Description,@Context,@Created) SELECT @@IDENTITY";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Title", codeNoteDataEntity.Title));
            parameters.Add(new SqlParameter("Language", codeNoteDataEntity.Language));
            parameters.Add(new SqlParameter("Description", codeNoteDataEntity.Description));
            parameters.Add(new SqlParameter("Context", codeNoteDataEntity.Context));
            parameters.Add(new SqlParameter("Created", codeNoteDataEntity.Created));

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

        public void Update(CodeNoteDataEntity codeNoteDataEntity)
        {
            string commandText = "UPDATE CodeNote SET";
            commandText += " Title=@Title,Language=@Language,Description=@Description,Context=@Context,Created=@Created";
            commandText += " WHERE CodeNoteID=@CodeNoteID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CodeNoteID", codeNoteDataEntity.CodeNoteID));
            parameters.Add(new SqlParameter("Title", codeNoteDataEntity.Title));
            parameters.Add(new SqlParameter("Language", codeNoteDataEntity.Context));
            parameters.Add(new SqlParameter("Description", codeNoteDataEntity.Context));
            parameters.Add(new SqlParameter("Context", codeNoteDataEntity.Context));
            parameters.Add(new SqlParameter("Created", codeNoteDataEntity.Created));

            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = new SqlConnection(this.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddRange(parameters.ToArray());

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
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
        }

        public void Delete(CodeNoteDataEntity codeNoteDataEntity)
        {
            string commandText = "DELETE CodeNote WHERE CodeNoteID=@CodeNoteID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CodeNoteID", codeNoteDataEntity.CodeNoteID));

            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = new SqlConnection(this.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddRange(parameters.ToArray());

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
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
        }

        private CodeNoteDataEntity GetFromReader(SqlDataReader sqlDataReader)
        {
            CodeNoteDataEntity codeNoteDataEntity = new CodeNoteDataEntity();

            codeNoteDataEntity.CodeNoteID = (int)sqlDataReader["CodeNoteID"];
            codeNoteDataEntity.Title = (string)sqlDataReader["Title"];
            codeNoteDataEntity.Language = (string)sqlDataReader["Language"];
            codeNoteDataEntity.Description = (string)sqlDataReader["Description"];
            codeNoteDataEntity.Context = (string)sqlDataReader["Context"];
            codeNoteDataEntity.Created = (DateTime)sqlDataReader["Created"];

            return codeNoteDataEntity;
        }

        public CodeNoteDataEntityCollection Select(string language, out int result)
        {
            string commandText = "SELECT * FROM CodeNote";

            if (!string.IsNullOrEmpty(language))
            {
                commandText += " WHERE Language=@Language";
            }

            commandText += " ORDER BY Created ASC";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Language", language));

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
