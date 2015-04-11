using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public class DatabaseManager
    {

        private static SqlConnection CreateConnection(string server, string dataBase, string userId, string password, string authenticationType)
        {
            var connectionString = "";

            if (authenticationType == "WIN")
            {
                connectionString = "Data Source=" + server + ";Initial Catalog=" + dataBase + ";Integrated Security = True;";
            }
            if (authenticationType == "SQL")
            {
                connectionString = "Data Source=" + server + ";Initial Catalog=" + dataBase + ";User Id=" + userId + ";Password=" + password + ";";
            }
            var connection = new SqlConnection(connectionString);
            return connection;
        }

        private static SqlCommand CreateCommand(SqlConnection connection, string commandText, CommandType commandType)
        {
            var command = new SqlCommand
                              {
                                  Connection = connection,
                                  CommandText = commandText,
                                  CommandType = commandType
                              };
            return command;
        }

        public List<string> GetTableList(string server, string dataBase, string userId, string password, string authenticationType)
        {
            var tablesList = new List<String>();

            var conn = CreateConnection(server, dataBase, userId, password, authenticationType);
            var cmdText = "SELECT TABLE_NAME  FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME";
            var cmd = CreateCommand(conn, cmdText, CommandType.Text);
            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                    tablesList.Add(reader["TABLE_NAME"].ToString());
            }
            conn.Close();
            return tablesList;
        }

        public Dictionary<string, string> GetTableColumnList(string server, string dataBase, string userId, string password, string authenticationType, string tableName)
        {
            var columnsDictionary = new Dictionary<String, String>();
            var conn = CreateConnection(server, dataBase, userId, password, authenticationType);
            var cmdText = "SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + tableName + "' ORDER BY COLUMN_NAME";
            var cmd = CreateCommand(conn, cmdText, CommandType.Text);
            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                    columnsDictionary.Add(reader["COLUMN_NAME"].ToString(), reader["DATA_TYPE"].ToString());
            }
            conn.Close();
            return columnsDictionary;
        }
    }
}
