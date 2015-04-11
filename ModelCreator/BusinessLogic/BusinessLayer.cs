using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BusinessLogic
{
    public class BusinessLayer
    {
        readonly DatabaseManager _db = new DatabaseManager();
        public List<string> GetTableList(string server, string dataBase, string userId, string password, string authenticationType)
        {
            return _db.GetTableList(server, dataBase, userId, password, authenticationType);
        }

        public Dictionary<string, string> GetTableColumnList(string server, string dataBase, string userId, string password, string authenticationType, string tableName)
        {
            return _db.GetTableColumnList(server, dataBase, userId, password, authenticationType, tableName);
        }

        public bool GenerateModel(string nameSpace, string fileName, Dictionary<string, string> colList)
        {
            var body = "";
            foreach (var model in colList)
            {
                var modelContent = "\n\t\t public {dType} {name} {get; set;}";
                switch (model.Value.ToLower())
                {
                    case "datetime":
                        modelContent = modelContent.Replace("{dType}", TypeConvertor.ToNetType(SqlDbType.DateTime).UnderlyingSystemType.Name);
                        break;
                    case "bigint":
                        modelContent = modelContent.Replace("{dType}", TypeConvertor.ToNetType(SqlDbType.BigInt).UnderlyingSystemType.Name);
                        break;
                    case "nvarchar":
                        modelContent = modelContent.Replace("{dType}", TypeConvertor.ToNetType(SqlDbType.NVarChar).UnderlyingSystemType.Name);
                        break;
                    case "varchar":
                        modelContent = modelContent.Replace("{dType}", TypeConvertor.ToNetType(SqlDbType.VarChar).UnderlyingSystemType.Name);
                        break;
                    case "int":
                        modelContent = modelContent.Replace("{dType}", TypeConvertor.ToNetType(SqlDbType.Int).UnderlyingSystemType.Name);
                        break;
                    case "timestamp":
                        modelContent = modelContent.Replace("{dType}", TypeConvertor.ToNetType(SqlDbType.Timestamp).UnderlyingSystemType.Name);
                        break;
                    case "float":
                        modelContent = modelContent.Replace("{dType}", TypeConvertor.ToNetType(SqlDbType.Float).UnderlyingSystemType.Name);
                        break;
                    case "double":
                        modelContent = modelContent.Replace("{dType}", TypeConvertor.ToNetType(SqlDbType.Decimal).UnderlyingSystemType.Name);
                        break;
                    case "bit":
                        modelContent = modelContent.Replace("{dType}", TypeConvertor.ToNetType(SqlDbType.Bit).UnderlyingSystemType.Name);
                        break;
                    case "uniqueidentifier":
                        modelContent = modelContent.Replace("{dType}", TypeConvertor.ToNetType(SqlDbType.UniqueIdentifier).UnderlyingSystemType.Name);
                        break;
                }

                modelContent = modelContent.Replace("{name}", model.Key);
                body += modelContent;
            }

            var directory = new DirectoryInfo(".");
            directory.CreateSubdirectory(nameSpace.Replace('.', '/'));

            var file = new FileInfo(Path.Combine(nameSpace.Replace('.', '/'), fileName + ".cs"));

            var stream = file.CreateText();
            var fileContent = GetFileTemplate();
            fileContent = fileContent.Replace("{nameSpace}", nameSpace);
            fileContent = fileContent.Replace("{fileName}", fileName);
            fileContent = fileContent.Replace("{body}", body);
            stream.Write(fileContent);
            stream.Flush();
            return true;
        }

        private static string GetFileTemplate()
        {
            const string template = "using System;\n" +
                                    "using System.Collections.Generic;\n" +
                                    "using System.Linq;\n" +
                                    "using System.Text;\n" +

                                    "namespace {nameSpace} \n" +
                                    "{ \n" +
                                    "\t public class {fileName} \n" +
                                    "\t { \n" +
                                    "\t\t {body} \n" +
                                    "\t } \n" +
                                    "}\n";

            return template;
        }
    }
}
