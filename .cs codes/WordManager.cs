using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;

namespace Flaminguage
{
    internal class WordManager
    {
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Flaminguagedata.mdb");

        private static string connectionString = string.Format(
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Jet OLEDB:Database Password=;",
            dbPath
        );

        /// <summary>
        /// Returns total number of words in the table
        /// </summary>
        public static int GetWordCount(string tableName)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = string.Format("SELECT COUNT(*) FROM {0}", tableName);
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Picks N random words directly from the database without loading all
        /// </summary>
        public static List<string> LoadRandomWords(string tableName, int count)
        {
            List<string> words = new List<string>();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Get total number of rows
                string countQuery = string.Format("SELECT COUNT(*) FROM {0}", tableName);
                int totalRows = 0;
                using (OleDbCommand cmd = new OleDbCommand(countQuery, conn))
                {
                    totalRows = (int)cmd.ExecuteScalar();
                }

                if (totalRows == 0) return words;

                Random rng = new Random();
                HashSet<int> usedIndexes = new HashSet<int>();

                // Pick 'count' unique random row numbers
                while (usedIndexes.Count < Math.Min(count, totalRows))
                {
                    usedIndexes.Add(rng.Next(totalRows)); // 0-based index
                }

                // Fetch each random row using nested SELECT TOP query
                foreach (int rowIndex in usedIndexes)
                {
                    string query = string.Format(
                        "SELECT TOP 1 Word FROM (SELECT TOP {0} Word FROM {1}) AS Temp ORDER BY Word",
                        rowIndex + 1, tableName
                    );

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            words.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return words;
        }

        /// <summary>
        /// Loads all words into a list
        /// </summary>
        public static List<string> LoadAllWords(string tableName)
        {
            List<string> words = new List<string>();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = string.Format("SELECT Word FROM {0}", tableName);
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        words.Add(reader.GetString(0));
                }
            }
            return words;
        }
    }
}