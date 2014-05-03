using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likol.CodeNotes.Data
{
    public class CodeNoteCategoryDataOperation
    {
        public CodeNoteCategoryDataOperation(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string connectionString = "";
        
        public string ConnectionString
        {
            get { return this.connectionString; }
            set { this.connectionString = value; }
        }

        public CodeNoteCategoryDataEntity Get(CodeNoteCategoryDataEntity codeNoteCategoryDataEntity)
        {
            string commandText = "SELECT * FROM CodeNoteCategory WHERE CodeNoteCategoryID=@CodeNoteCategoryID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CodeNoteCategoryID", codeNoteCategoryDataEntity.CodeNoteCategoryID));

            codeNoteCategoryDataEntity = null;

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
                    codeNoteCategoryDataEntity = this.GetFromReader(sqlDataReader);
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

            return codeNoteCategoryDataEntity;
        }

        public int Create(CodeNoteCategoryDataEntity codeNoteCategoryDataEntity)
        {
            string commandText = "INSERT INTO CodeNoteCategory (Name,Language,Created,LatestUpdate)";
            commandText += " VALUES(@Name,@Language,@Created,@LatestUpdate) SELECT @@IDENTITY";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Name", codeNoteCategoryDataEntity.Name));
            parameters.Add(new SqlParameter("Language", codeNoteCategoryDataEntity.Language));
            parameters.Add(new SqlParameter("Created", codeNoteCategoryDataEntity.Created));
            parameters.Add(new SqlParameter("LatestUpdate", codeNoteCategoryDataEntity.LatestUpdate));

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

        public int Update(CodeNoteCategoryDataEntity codeNoteCategoryDataEntity)
        {
            string commandText = "UPDATE CodeNoteCategory SET";
            commandText += " Name=@Name,Language=@Language,LatestUpdate=@LatestUpdate";
            commandText += " WHERE CodeNoteCategoryID=@CodeNoteCategoryID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CodeNoteCategoryID", codeNoteCategoryDataEntity.CodeNoteCategoryID));
            parameters.Add(new SqlParameter("Name", codeNoteCategoryDataEntity.Name));
            parameters.Add(new SqlParameter("Language", codeNoteCategoryDataEntity.Language));
            parameters.Add(new SqlParameter("LatestUpdate", codeNoteCategoryDataEntity.LatestUpdate));

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

        public int Delete(CodeNoteCategoryDataEntity codeNoteCategoryDataEntity)
        {
            string commandText = "DELETE CodeNoteCategory WHERE CodeNoteCategoryID=@CodeNoteCategoryID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("CodeNoteCategoryID", codeNoteCategoryDataEntity.CodeNoteCategoryID));

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

        private CodeNoteCategoryDataEntity GetFromReader(SqlDataReader sqlDataReader)
        {
            CodeNoteCategoryDataEntity codeNoteCategoryDataEntity = new CodeNoteCategoryDataEntity();

            codeNoteCategoryDataEntity.CodeNoteCategoryID = (int)sqlDataReader["CodeNoteCategoryID"];
            codeNoteCategoryDataEntity.Name = (string)sqlDataReader["Name"];
            codeNoteCategoryDataEntity.Language = (string)sqlDataReader["Language"];
            codeNoteCategoryDataEntity.Created = (DateTime)sqlDataReader["Created"];
            codeNoteCategoryDataEntity.LatestUpdate = (DateTime)sqlDataReader["LatestUpdate"];

            return codeNoteCategoryDataEntity;
        }

        public CodeNoteCategoryDataEntityCollection Select(string language, out int result)
        {
            string commandText = "SELECT * FROM CodeNoteCategory";

            if (!string.IsNullOrEmpty(language))
            {
                commandText += " WHERE Language=@Language";
            }

            commandText += " ORDER BY Created ASC";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Language", language));

            CodeNoteCategoryDataEntityCollection codeNoteDataEntities = new CodeNoteCategoryDataEntityCollection();

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
                    CodeNoteCategoryDataEntity codeNoteCategoryDataEntity = this.GetFromReader(sqlDataReader);

                    codeNoteDataEntities.Add(codeNoteCategoryDataEntity);
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
