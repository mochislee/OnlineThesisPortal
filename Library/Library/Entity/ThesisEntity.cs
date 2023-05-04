using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Library.Entity
{
    public class ThesisEntity
    {
        [Key]
        public int Id { get; set; }
        public string thesisTitle { get; set; }
        public string thesisDescription { get; set; }
        public string thesisAuthor { get; set; }
        public string thesisCourse { get; set; }
        public int yearPublished { get; set; }
        public string FilePath { get; set; }
        public byte[] BinaryContent { get; set; }


    }
    public class PdfFileDatabase
    {
        private readonly string _connectionString;

        public PdfFileDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertPdfFile(ThesisEntity pdfFile)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Turn on IDENTITY_INSERT for the PdfFiles table
                string sql = "SET IDENTITY_INSERT ThesisCollections ON";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

                // Insert the new PDF file record
                sql = "INSERT INTO ThesisCollections (Id, FilePath, BinaryContent) VALUES (@Id, @FilePath, @BinaryContent)";
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", pdfFile.Id);
                command.Parameters.AddWithValue("@FilePath", pdfFile.FilePath);
                command.Parameters.AddWithValue("@BinaryContent", pdfFile.BinaryContent);
                command.ExecuteNonQuery();

            }
        }

    }
}