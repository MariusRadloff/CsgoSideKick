using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace LinqDataAccessLibrary
{
    public static class LinqDataAccess
    {
        #region sql
        //public static void CreateTablesSQL()
        //{
        //    using (SqliteConnection db = new SqliteConnection(SqlDbModel.DbConnectionString))
        //    {
        //        db.Open();
        //        string createTableCommandString;

        //        foreach (List<List<String>> tableData in SqlDbModel.TableDataList)
        //        {
        //            int stringNumber = 0;
        //            createTableCommandString = "CREATE TABLE IF NOT EXISTS " + tableData[0][0] + " ( ";
        //            foreach (List<String> tableDataStrings in tableData)
        //            {
        //                foreach (String tableDataString in tableDataStrings)
        //                {
        //                    if (stringNumber != 0)
        //                    {
        //                        createTableCommandString += tableDataString + " ";
        //                    }
        //                }
        //                if (stringNumber != 0)
        //                {
        //                    createTableCommandString += ", ";
        //                }
        //                stringNumber++;
        //            }
        //            createTableCommandString = createTableCommandString.Remove(createTableCommandString.Length - 2);
        //            createTableCommandString += ");";

        //            SqliteCommand createTableCommand = new SqliteCommand(createTableCommandString, db);
        //            createTableCommand.ExecuteReader();
        //        }
        //        db.Close();
        //    }
        //}

        //public static void DeleteTablesSQL()
        //{
        //    using (SqliteConnection db = new SqliteConnection(SqlDbModel.DbConnectionString))
        //    {
        //        db.Open();
        //        foreach (List<List<String>> tableData in SqlDbModel.TableDataList)
        //        {
        //            string deleteTableCommandString = "DELETE FROM " + tableData[0][0];
        //            SqliteCommand deleteTableCommand = new SqliteCommand(deleteTableCommandString, db);
        //            deleteTableCommand.ExecuteReader();
        //        }
        //        db.Close();
        //    }
        //}

        //public static void DropTablesSQL()
        //{
        //    using (SqliteConnection db = new SqliteConnection(SqlDbModel.DbConnectionString))
        //    {
        //        db.Open();
        //        foreach (List<List<String>> tableData in SqlDbModel.TableDataList)
        //        {
        //            string deleteTableCommandString = "DROP TABLE " + tableData[0][0];
        //            SqliteCommand deleteTableCommand = new SqliteCommand(deleteTableCommandString, db);
        //            deleteTableCommand.ExecuteReader();
        //        }
        //        db.Close();
        //    }
        //}

        //public static void AddDataExample(string inputText)
        //{
        //    using (SqliteConnection db = new SqliteConnection(SqlDbModel.DbConnectionString))
        //    {
        //        db.Open();

        //        using (SqliteCommand insertCommand = new SqliteCommand("INSERT INTO MyTable VALUES (NULL, @Entry);", db))
        //        {
        //            insertCommand.Parameters.AddWithValue("@Entry", inputText);
        //            insertCommand.ExecuteReader();
        //        }

        //        db.Close();
        //    }

        //}

        //public static void AddSteamInventorySQL(string Steam64Id, string Username)
        //{
        //    using (SqliteConnection db = new SqliteConnection(SqlDbModel.DbConnectionString))
        //    {
        //        db.Open();

        //        List<List<String>> TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "steamInventory").First();

        //        List<(String, Object)> csgoInventoryParameter = new List<(String, Object)>
        //        {
        //            (TableData.ElementAt(1).First(), DBNull.Value),
        //            (TableData.ElementAt(2).First(), Steam64Id),
        //            (TableData.ElementAt(3).First(), Username),
        //        };

        //        if (GetIdOfDataSetSQL(csgoInventoryParameter, new List<int> { 1, 2 }, TableData.ElementAt(0).First(), db) == 0)
        //        {
        //            InsertIntoTableSQL(csgoInventoryParameter, TableData.ElementAt(0).First(), db);
        //        }

        //        db.Close();
        //    }

        //}

        //public static void AddGameInventorySQL(string inventoryString, string Steam64Id, string csgoInventoryId)
        //{
        //    using (SqliteConnection db = new SqliteConnection(SqlDbModel.DbConnectionString))
        //    {
        //        JsonObject csgoInventory = new JsonObject();
        //        try
        //        {
        //            csgoInventory = JsonObject.Parse(inventoryString);
        //        }
        //        catch (Exception)
        //        {
        //            //CsgoInventoryJsonObject = JsonObject.Parse(inventoryString);
        //            System.Diagnostics.Debug.Print("inventoryString ungültig");
        //            return;
        //        }

        //        db.Open();

        //        List<List<String>> TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "csgoInventory").First();

        //        List<(String, Object)> csgoInventoryParameter = new List<(String, Object)>
        //        {
        //            (TableData.ElementAt(1).First(), DBNull.Value),
        //            (TableData.ElementAt(2).First(), csgoInventoryId),
        //            (TableData.ElementAt(3).First(), csgoInventory.ContainsKey(TableData.ElementAt(3).First()) ? (Object)csgoInventory.GetNamedBoolean(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
        //            (TableData.ElementAt(4).First(), csgoInventory.ContainsKey(TableData.ElementAt(4).First()) ? (Object)csgoInventory.GetNamedBoolean(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
        //            (TableData.ElementAt(5).First(), csgoInventory.ContainsKey(TableData.ElementAt(5).First()) ? (Object)csgoInventory.GetNamedBoolean(TableData.ElementAt(5).First()) : (Object)DBNull.Value),
        //            (TableData.ElementAt(6).First(), Steam64Id)
        //        };

        //        if (GetIdOfDataSetSQL(csgoInventoryParameter, new List<int> { 1, 2, 3, 4 }, TableData.ElementAt(0).First(), db) == 0)
        //        {
        //            InsertIntoTableSQL(csgoInventoryParameter, TableData.ElementAt(0).First(), db);
        //        }

        //        JsonObject rgInventory = csgoInventory.GetNamedObject("rgInventory");

        //        for (int i = 0; i < rgInventory.Count; i++)
        //        {
        //            JsonObject rgInventoryElement = rgInventory.GetNamedObject(rgInventory.ElementAt(i).Key);

        //            TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "rgInventory").First();

        //            List<(String, Object)> rgInventoryParameter = new List<(String, Object)>
        //            {
        //                (TableData.ElementAt(1).First(), DBNull.Value),
        //                (TableData.ElementAt(2).First(), rgInventoryElement.ContainsKey(TableData.ElementAt(2).First()) ? (Object)rgInventoryElement.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(3).First(), rgInventoryElement.ContainsKey(TableData.ElementAt(3).First()) ? (Object)rgInventoryElement.GetNamedString(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(4).First(), rgInventoryElement.ContainsKey(TableData.ElementAt(4).First()) ? (Object)rgInventoryElement.GetNamedString(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(5).First(), rgInventoryElement.ContainsKey(TableData.ElementAt(5).First()) ? (Object)rgInventoryElement.GetNamedString(TableData.ElementAt(5).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(6).First(), rgInventoryElement.ContainsKey(TableData.ElementAt(6).First()) ? (Object)rgInventoryElement.GetNamedNumber(TableData.ElementAt(6).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(7).First(), csgoInventoryId)
        //            };

        //            if (GetIdOfDataSetSQL(rgInventoryParameter, new List<int> { 1, 2, 3, 4, 5 }, TableData.ElementAt(0).First(), db) == 0)
        //            {
        //                InsertIntoTableSQL(rgInventoryParameter, TableData.ElementAt(0).First(), db);
        //            }
        //        }

        //        JsonObject rgDescriptions = csgoInventory.GetNamedObject("rgDescriptions");

        //        for (int n = 0; n < rgDescriptions.Count; n++)
        //        {
        //            JsonObject rgDescription = rgDescriptions.GetNamedObject(rgDescriptions.ElementAt(n).Key);
        //            long rgDescriptonsId = 0;

        //            TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "rgDescriptions").First();

        //            List<(String, Object)> rgDescriptionParameter = new List<(String, Object)>
        //            {
        //                (TableData.ElementAt(1).First(), DBNull.Value),
        //                (TableData.ElementAt(2).First(), rgDescription.ContainsKey(TableData.ElementAt(2).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(3).First(), rgDescription.ContainsKey(TableData.ElementAt(3).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(4).First(), rgDescription.ContainsKey(TableData.ElementAt(4).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(5).First(), rgDescription.ContainsKey(TableData.ElementAt(5).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(5).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(6).First(), rgDescription.ContainsKey(TableData.ElementAt(6).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(6).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(7).First(), rgDescription.ContainsKey(TableData.ElementAt(7).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(7).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(8).First(), rgDescription.ContainsKey(TableData.ElementAt(8).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(8).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(9).First(), rgDescription.ContainsKey(TableData.ElementAt(9).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(9).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(10).First(), rgDescription.ContainsKey(TableData.ElementAt(10).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(10).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(11).First(), rgDescription.ContainsKey(TableData.ElementAt(11).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(11).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(12).First(), rgDescription.ContainsKey(TableData.ElementAt(12).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(12).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(13).First(), rgDescription.ContainsKey(TableData.ElementAt(13).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(13).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(14).First(), rgDescription.ContainsKey(TableData.ElementAt(14).First()) ? (Object)rgDescription.GetNamedNumber(TableData.ElementAt(14).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(15).First(), rgDescription.ContainsKey(TableData.ElementAt(15).First()) ? (Object)rgDescription.GetNamedNumber(TableData.ElementAt(15).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(16).First(), rgDescription.ContainsKey(TableData.ElementAt(16).First()) ? (Object)rgDescription.GetNamedNumber(TableData.ElementAt(16).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(17).First(), rgDescription.ContainsKey(TableData.ElementAt(17).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(17).First()) : (Object)DBNull.Value),
        //                (TableData.ElementAt(18).First(), csgoInventoryId)
        //            };

        //            rgDescriptonsId = GetIdOfDataSetSQL(rgDescriptionParameter, new List<int> { 2, 3 }, TableData.ElementAt(0).First(), db);

        //            if (rgDescriptonsId == 0)
        //            {
        //                rgDescriptonsId = InsertIntoTableSQL(rgDescriptionParameter, TableData.ElementAt(0).First(), db);
        //            }

        //            if (rgDescription.ContainsKey("descriptions"))
        //            {
        //                JsonArray descriptions = rgDescription.GetNamedArray("descriptions");

        //                for (uint m = 0; m < descriptions.Count; m++)
        //                {
        //                    JsonObject description = descriptions.GetObjectAt(m);
        //                    long descriptonsId = 0;

        //                    TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "descriptions").First();

        //                    List<(String, Object)> descriptionParameter = new List<(String, Object)>
        //                    {
        //                        (TableData.ElementAt(1).First(), DBNull.Value),
        //                        (TableData.ElementAt(2).First(), description.ContainsKey(TableData.ElementAt(2).First()) ? (Object)description.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
        //                        (TableData.ElementAt(3).First(), description.ContainsKey(TableData.ElementAt(3).First()) ? (Object)description.GetNamedString(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
        //                        (TableData.ElementAt(4).First(), description.ContainsKey(TableData.ElementAt(4).First()) ? (Object)description.GetNamedString(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
        //                    };

        //                    descriptonsId = GetIdOfDataSetSQL(descriptionParameter, new List<int> { 1, 2, 3 }, TableData.ElementAt(0).First(), db);

        //                    if (descriptonsId == 0)
        //                    {
        //                        descriptonsId = InsertIntoTableSQL(descriptionParameter, TableData.ElementAt(0).First(), db);
        //                    }

        //                    TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "descriptionsRgDescriptionsRel").First();

        //                    List<(String, Object)> descriptionsRgDescriptionsParameter = new List<(string, object)>
        //                    {
        //                        (TableData.ElementAt(1).First(), DBNull.Value),
        //                        (TableData.ElementAt(2).First(), descriptonsId),
        //                        (TableData.ElementAt(3).First(), rgDescriptonsId),
        //                        (TableData.ElementAt(4).First(), m)
        //                    };

        //                    if (GetIdOfDataSetSQL(descriptionsRgDescriptionsParameter, new List<int> { 1, 2, 3 }, TableData.ElementAt(0).First(), db) == 0)
        //                    {
        //                        InsertIntoTableSQL(descriptionsRgDescriptionsParameter, TableData.ElementAt(0).First(), db);
        //                    }

        //                    if (description.ContainsKey("app_data"))
        //                    {
        //                        JsonObject appData = description.GetNamedObject("app_data");
        //                        long app_dataId = 0;

        //                        TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "app_data").First();

        //                        List<(String, Object)> appDataParameter = new List<(String, Object)>
        //                        {
        //                            (TableData.ElementAt(1).First(), DBNull.Value),
        //                            (TableData.ElementAt(2).First(), appData.ContainsKey(TableData.ElementAt(2).First()) ? (Object)appData.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
        //                            (TableData.ElementAt(3).First(), appData.ContainsKey(TableData.ElementAt(3).First()) ? (Object)appData.GetNamedNumber(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
        //                            (TableData.ElementAt(4).First(), appData.ContainsKey(TableData.ElementAt(4).First()) ? (Object)appData.GetNamedNumber(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
        //                        };

        //                        app_dataId = GetIdOfDataSetSQL(appDataParameter, new List<int> { 1, 2, 3 }, TableData.ElementAt(0).First(), db);

        //                        if (app_dataId == 0)
        //                        {
        //                            app_dataId = InsertIntoTableSQL(appDataParameter, TableData.ElementAt(0).First(), db);
        //                        }

        //                        TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "app_dataDescriptionsRgDescriptionsRel").First();

        //                        List<(String, Object)> appDataDescriptionsRgDescriptionParameter = new List<(String, Object)>
        //                        {
        //                            (TableData.ElementAt(1).First(), DBNull.Value),
        //                            (TableData.ElementAt(2).First(), descriptonsId),
        //                            (TableData.ElementAt(3).First(), rgDescriptonsId),
        //                            (TableData.ElementAt(4).First(), app_dataId)
        //                        };

        //                        if (GetIdOfDataSetSQL(appDataDescriptionsRgDescriptionParameter, new List<int> { 1, 2 }, TableData.ElementAt(0).First(), db) == 0)
        //                        {
        //                            InsertIntoTableSQL(appDataDescriptionsRgDescriptionParameter, TableData.ElementAt(0).First(), db);
        //                        }
        //                    }

        //                }
        //            }

        //            if (rgDescription.ContainsKey("actions"))
        //            {
        //                JsonArray actions = rgDescription.GetNamedArray("actions");
        //                for (uint o = 0; o < actions.Count; o++)
        //                {
        //                    JsonObject action = actions.GetObjectAt(o);

        //                    TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "actions").First();

        //                    List<(String, Object)> actionParameter = new List<(String, Object)>
        //                    {
        //                        (TableData.ElementAt(1).First(), DBNull.Value),
        //                        (TableData.ElementAt(2).First(), action.ContainsKey(TableData.ElementAt(2).First()) ? (Object)action.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
        //                        (TableData.ElementAt(3).First(), action.ContainsKey(TableData.ElementAt(3).First()) ? (Object)action.GetNamedString(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
        //                        (TableData.ElementAt(4).First(), rgDescriptonsId)
        //                    };

        //                    if (GetIdOfDataSetSQL(actionParameter, new List<int> { 1, 2, 3 }, TableData.ElementAt(0).First(), db) == 0)
        //                    {
        //                        InsertIntoTableSQL(actionParameter, TableData.ElementAt(0).First(), db);
        //                    }
        //                }
        //            }

        //            if (rgDescription.ContainsKey("market_actions"))
        //            {
        //                JsonArray marketActions = rgDescription.GetNamedArray("market_actions");
        //                for (uint o = 0; o < marketActions.Count; o++)
        //                {
        //                    JsonObject marketAction = marketActions.GetObjectAt(o);

        //                    TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "market_actions").First();

        //                    List<(String, Object)> marketActionParameter = new List<(String, Object)>
        //                    {
        //                        (TableData.ElementAt(1).First(), DBNull.Value),
        //                        (TableData.ElementAt(2).First(), marketAction.ContainsKey(TableData.ElementAt(2).First()) ? (Object)marketAction.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
        //                        (TableData.ElementAt(3).First(), marketAction.ContainsKey(TableData.ElementAt(3).First()) ? (Object)marketAction.GetNamedString(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
        //                        (TableData.ElementAt(4).First(), rgDescriptonsId)
        //                    };

        //                    if (GetIdOfDataSetSQL(marketActionParameter, new List<int> { 1, 2, 3 }, "market_actions", db) == 0)
        //                    {
        //                        InsertIntoTableSQL(marketActionParameter, "market_actions", db);
        //                    }
        //                }
        //            }

        //            if (rgDescription.ContainsKey("tags"))
        //            {
        //                JsonArray tags = rgDescription.GetNamedArray("tags");
        //                for (uint p = 0; p < tags.Count; p++)
        //                {
        //                    JsonObject tag = tags.GetObjectAt(p);

        //                    TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "tags").First();

        //                    List<(String, Object)> tagParameter = new List<(String, Object)>
        //                    {
        //                        (TableData.ElementAt(1).First(), DBNull.Value),
        //                        (TableData.ElementAt(2).First(), tag.ContainsKey(TableData.ElementAt(2).First()) ? (Object)tag.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
        //                        (TableData.ElementAt(3).First(), tag.ContainsKey(TableData.ElementAt(3).First()) ? (Object)tag.GetNamedString(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
        //                        (TableData.ElementAt(4).First(), tag.ContainsKey(TableData.ElementAt(4).First()) ? (Object)tag.GetNamedString(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
        //                        (TableData.ElementAt(5).First(), tag.ContainsKey(TableData.ElementAt(5).First()) ? (Object)tag.GetNamedString(TableData.ElementAt(5).First()) : (Object)DBNull.Value),
        //                        (TableData.ElementAt(6).First(), tag.ContainsKey(TableData.ElementAt(6).First()) ? (Object)tag.GetNamedString(TableData.ElementAt(6).First()) : (Object)DBNull.Value),
        //                        (TableData.ElementAt(7).First(), rgDescriptonsId)
        //                    };

        //                    if (GetIdOfDataSetSQL(tagParameter, new List<int> { 1, 2, 3 }, "tags", db) == 0)
        //                    {
        //                        InsertIntoTableSQL(tagParameter, "tags", db);
        //                    }
        //                }
        //            }
        //        }
        //        JsonArray rgCurrency = csgoInventory.GetNamedArray("rgCurrency");

        //        db.Close();
        //    }
        //}

        //public static List<String> GetDataExample()
        //{
        //    List<String> entries = new List<string>();

        //    using (SqliteConnection db = new SqliteConnection(SqlDbModel.DbConnectionString))
        //    {
        //        db.Open();

        //        SqliteCommand selectCommand = new SqliteCommand("SELECT * from rgInventory", db);

        //        SqliteDataReader reader = selectCommand.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            entries.Add(reader.GetString(0));
        //        }
        //        db.Close();
        //    }
        //    return entries;
        //}

        //private static void AddJsonItemToTableSQL(SqliteConnection db, string tableName, IJsonValue jValue)
        //{
        //    string commandString = "INSERT OR IGNORE INTO " + tableName + " VALUES (";
        //    int parameterNumber = 0;
        //    string parameterName = "";

        //    Type typeInput = jValue.GetType();

        //    if (typeInput == typeof(JsonObject))
        //    {
        //        JsonObject jObj = (JsonObject)jValue;

        //        using (SqliteCommand command = new SqliteCommand())
        //        {
        //            foreach (var element in jObj)
        //            {
        //                switch (element.Value.ValueType)
        //                {
        //                    case JsonValueType.Null:
        //                        break;
        //                    case JsonValueType.Boolean:
        //                        parameterNumber++;
        //                        parameterName = "@param" + parameterNumber;
        //                        commandString = commandString + parameterName + ", ";
        //                        command.Parameters.AddWithValue(parameterName, element.Value.GetBoolean());
        //                        break;
        //                    case JsonValueType.Number:
        //                        parameterNumber++;
        //                        parameterName = "@param" + parameterNumber;
        //                        commandString = commandString + parameterName + ", ";
        //                        command.Parameters.AddWithValue(parameterName, element.Value.GetNumber());
        //                        break;
        //                    case JsonValueType.String:
        //                        parameterNumber++;
        //                        parameterName = "@param" + parameterNumber;
        //                        commandString = commandString + parameterName + ", ";
        //                        command.Parameters.AddWithValue(parameterName, element.Value.GetString());
        //                        break;
        //                    case JsonValueType.Array:
        //                        break;
        //                    case JsonValueType.Object:
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //            commandString = commandString.Remove(commandString.Length - 2);
        //            commandString = commandString + ");";
        //            command.CommandText = commandString;
        //            command.Connection = db;
        //            command.ExecuteReader();
        //        }
        //    }
        //}

        //private static long InsertIntoTableSQL(List<(String, Object)> parameters, string tableName, SqliteConnection connection)
        //{
        //    string insertCommandString = "INSERT INTO " + tableName + " VALUES ( ";

        //    using (SqliteCommand command = new SqliteCommand())
        //    {
        //        command.Connection = connection;

        //        foreach ((String, Object) parameter in parameters)
        //        {
        //            string name = "@" + parameter.Item1;

        //            insertCommandString = insertCommandString + name + ", ";
        //            command.Parameters.AddWithValue(name, parameter.Item2);
        //        }
        //        insertCommandString = insertCommandString.Remove(insertCommandString.Length - 2);
        //        insertCommandString += " );";
        //        command.CommandText = insertCommandString;
        //        command.ExecuteReader();

        //        command.Parameters.Clear();
        //        command.CommandText = "SELECT last_insert_rowid();";
        //        SqliteDataReader reader = command.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            reader.Read();
        //            return reader.GetInt64(0);
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //}

        //private static long GetIdOfDataSetSQL(List<(String, Object)> parameter, List<int> parameterNumbers, string tableName, SqliteConnection connection)
        //{
        //    string selectCommandText = "SELECT * FROM " + tableName;
        //    int index = 0;

        //    foreach (var num in parameterNumbers)
        //    {
        //        if (parameter[num].Item2.GetType() == typeof(String))
        //        {

        //            var b = parameter[num].Item2;
        //            if (index == 0)
        //            {
        //                selectCommandText = selectCommandText + " WHERE " + parameter[num].Item1 + " = " + "\"" + parameter[num].Item2 + "\"";
        //            }
        //            else
        //            {
        //                selectCommandText = selectCommandText + " AND " + parameter[num].Item1 + " = " + "\"" + parameter[num].Item2 + "\"";
        //            }
        //        }
        //        else if (parameter[num].Item2.GetType() == typeof(Double) || parameter[num].Item2.GetType() == typeof(Int64) || parameter[num].Item2.GetType() == typeof(UInt32))
        //        {
        //            if (index == 0)
        //            {
        //                selectCommandText = selectCommandText + " WHERE " + parameter[num].Item1 + " = " + parameter[num].Item2;
        //            }
        //            else
        //            {
        //                selectCommandText = selectCommandText + " AND " + parameter[num].Item1 + " = " + parameter[num].Item2;
        //            }
        //        }
        //        else if (parameter[num].Item2.GetType() == typeof(Boolean))
        //        {
        //            if (index == 0)
        //            {
        //                if ((Boolean)parameter[num].Item2)
        //                {
        //                    selectCommandText = selectCommandText + " WHERE " + parameter[num].Item1 + " = 1";
        //                }
        //                else
        //                {
        //                    selectCommandText = selectCommandText + " WHERE " + parameter[num].Item1 + " = 0";
        //                }
        //            }
        //            else
        //            {
        //                if ((Boolean)parameter[num].Item2)
        //                {
        //                    selectCommandText = selectCommandText + " ANd " + parameter[num].Item1 + " = 1";
        //                }
        //                else
        //                {
        //                    selectCommandText = selectCommandText + " ANd " + parameter[num].Item1 + " = 0";
        //                }
        //            }
        //        }
        //        else if (parameter[num].Item2.GetType() == typeof(DBNull))
        //        {
        //            if (index == 0)
        //            {
        //                selectCommandText = selectCommandText + " WHERE " + parameter[num].Item1 + " IS NULL";
        //            }
        //            else
        //            {
        //                selectCommandText = selectCommandText + " AND " + parameter[num].Item1 + " IS NULL";
        //            }
        //        }
        //        else
        //        {
        //            //todo error Type nicht unterstützt
        //        }
        //        index++;
        //    }

        //    selectCommandText += ";";

        //    SqliteCommand selectCommand = new SqliteCommand(selectCommandText, connection);

        //    SqliteDataReader reader = selectCommand.ExecuteReader();

        //    if (reader.HasRows)
        //    {
        //        reader.Read();
        //        return reader.GetInt64(0);
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        //#endregion
        #endregion

        public static void InsertLINQ()
        {
            using (var db = new LinqDataAccessLibrary.InventoryDbContext())
            {


                //var action = new LinqDataAccessLibrary.actionsItem { link = "testlink", name = "testname" };

                //var a = db.actions.Add(action);

                //var appdata = new LinqDataAccessLibrary.app_dataItem { def_index = "test" };

                //var x = db.app_data.Add(appdata);



                db.SaveChanges();


            }
        }

        public static void AddGameInventoryLinq(string inventoryString, string Steam64Id, string csgoInventoryId)
        {
            using (InventoryDbContext db = new InventoryDbContext())
            {
                JsonObject csgoInventory = new JsonObject();
                try
                {
                    csgoInventory = JsonObject.Parse(inventoryString);
                }
                catch (Exception)
                {
                    //CsgoInventoryJsonObject = JsonObject.Parse(inventoryString);
                    System.Diagnostics.Debug.Print("inventoryString ungültig");
                    return;
                }

                List<List<String>> TableData = LinqDbModel.TableDataList.Where(tdl => tdl[0][0] == "csgoInventory").First();

                csgoInventoryItem currentCsgoInventoryItem = new csgoInventoryItem
                {
                    gameId = csgoInventoryId,
                    success = csgoInventory.ContainsKey(TableData.ElementAt(3).First()) ? csgoInventory.GetNamedBoolean(TableData.ElementAt(3).First()) : false,
                    more = csgoInventory.ContainsKey(TableData.ElementAt(4).First()) ? csgoInventory.GetNamedBoolean(TableData.ElementAt(4).First()) : false,
                    more_start = csgoInventory.ContainsKey(TableData.ElementAt(5).First()) ? csgoInventory.GetNamedBoolean(TableData.ElementAt(5).First()) : false,
                    //steamInventoryItemId = 0//Steam64Id  todo index für steaminventoryid erstellen und evtl in steam und game in einer funktion hinzufügen
                };

                if (!db.csgoInventory.Any(x => x.gameId == currentCsgoInventoryItem.gameId))
                {
                    db.csgoInventory.Add(currentCsgoInventoryItem);
                    db.SaveChanges();
                }

                int currentCsgoInventoryItemId = db.csgoInventory.Where(x => x.gameId == currentCsgoInventoryItem.gameId).FirstOrDefault().csgoInventoryItemId;

                JsonObject rgInventory = csgoInventory.GetNamedObject("rgInventory");

                for (int i = 0; i < rgInventory.Count; i++)
                {
                    JsonObject rgInventoryElement = rgInventory.GetNamedObject(rgInventory.ElementAt(i).Key);

                    TableData = LinqDbModel.TableDataList.Where(tdl => tdl[0][0] == "rgInventory").First();

                    rgInventoryItem currentRgInventoryItem = new rgInventoryItem
                    {
                        id = rgInventoryElement.ContainsKey(TableData.ElementAt(2).First()) ? rgInventoryElement.GetNamedString(TableData.ElementAt(2).First()) : "",
                        classid = rgInventoryElement.ContainsKey(TableData.ElementAt(3).First()) ? rgInventoryElement.GetNamedString(TableData.ElementAt(3).First()) : "",
                        instanceid = rgInventoryElement.ContainsKey(TableData.ElementAt(4).First()) ? rgInventoryElement.GetNamedString(TableData.ElementAt(4).First()) : "",
                        amount = rgInventoryElement.ContainsKey(TableData.ElementAt(5).First()) ? rgInventoryElement.GetNamedString(TableData.ElementAt(5).First()) : "",
                        pos = rgInventoryElement.ContainsKey(TableData.ElementAt(6).First()) ? (int)rgInventoryElement.GetNamedNumber(TableData.ElementAt(6).First()) : 0,
                        csgoInventoryItemId = currentCsgoInventoryItemId
                    };

                    if (!db.rgInventory.Any(x => x.id == currentRgInventoryItem.id))
                    {
                        db.rgInventory.Add(currentRgInventoryItem);
                    }
                }

                db.SaveChanges();

                JsonObject rgDescriptions = csgoInventory.GetNamedObject("rgDescriptions");

                for (int n = 0; n < rgDescriptions.Count; n++)
                {
                    JsonObject rgDescription = rgDescriptions.GetNamedObject(rgDescriptions.ElementAt(n).Key);

                    TableData = LinqDbModel.TableDataList.Where(tdl => tdl[0][0] == "rgDescriptions").First();

                    rgDescriptionsItem currentRgDescriptionsItem = new rgDescriptionsItem
                    {
                        appid = rgDescription.ContainsKey(TableData.ElementAt(2).First()) ? rgDescription.GetNamedString(TableData.ElementAt(2).First()) : "",
                        classid = rgDescription.ContainsKey(TableData.ElementAt(3).First()) ? rgDescription.GetNamedString(TableData.ElementAt(3).First()) : "",
                        instanceid = rgDescription.ContainsKey(TableData.ElementAt(4).First()) ? rgDescription.GetNamedString(TableData.ElementAt(4).First()) : "",
                        icon_url = rgDescription.ContainsKey(TableData.ElementAt(5).First()) ? rgDescription.GetNamedString(TableData.ElementAt(5).First()) : "",
                        icon_url_large = rgDescription.ContainsKey(TableData.ElementAt(6).First()) ? rgDescription.GetNamedString(TableData.ElementAt(6).First()) : "",
                        icon_drag_url = rgDescription.ContainsKey(TableData.ElementAt(7).First()) ? rgDescription.GetNamedString(TableData.ElementAt(7).First()) : "",
                        name = rgDescription.ContainsKey(TableData.ElementAt(8).First()) ? rgDescription.GetNamedString(TableData.ElementAt(8).First()) : "",
                        market_hast_name = rgDescription.ContainsKey(TableData.ElementAt(9).First()) ? rgDescription.GetNamedString(TableData.ElementAt(9).First()) : "",
                        market_name = rgDescription.ContainsKey(TableData.ElementAt(10).First()) ? rgDescription.GetNamedString(TableData.ElementAt(10).First()) : "",
                        name_color = rgDescription.ContainsKey(TableData.ElementAt(11).First()) ? rgDescription.GetNamedString(TableData.ElementAt(11).First()) : "",
                        background_color = rgDescription.ContainsKey(TableData.ElementAt(12).First()) ? rgDescription.GetNamedString(TableData.ElementAt(12).First()) : "",
                        type = rgDescription.ContainsKey(TableData.ElementAt(13).First()) ? rgDescription.GetNamedString(TableData.ElementAt(13).First()) : "",
                        tradable = rgDescription.ContainsKey(TableData.ElementAt(14).First()) ? (int)rgDescription.GetNamedNumber(TableData.ElementAt(14).First()) : 0,
                        marketable = rgDescription.ContainsKey(TableData.ElementAt(15).First()) ? (int)rgDescription.GetNamedNumber(TableData.ElementAt(15).First()) : 0,
                        commodity = rgDescription.ContainsKey(TableData.ElementAt(16).First()) ? (int)rgDescription.GetNamedNumber(TableData.ElementAt(16).First()) : 0,
                        market_tradable_restriction = rgDescription.ContainsKey(TableData.ElementAt(17).First()) ? rgDescription.GetNamedString(TableData.ElementAt(17).First()) : "",
                        csgoInventoryItemId = currentCsgoInventoryItemId
                    };

                    if (!db.rgDescriptions.Any(x => x.classid == currentRgDescriptionsItem.classid && x.instanceid == currentRgDescriptionsItem.instanceid))
                    {
                        db.rgDescriptions.Add(currentRgDescriptionsItem);
                    }

                    db.SaveChanges();

                    int currentRgDescriptionsItemId = db.rgDescriptions.Where(x => x.classid == currentRgDescriptionsItem.classid && x.instanceid == currentRgDescriptionsItem.instanceid).FirstOrDefault().csgoInventoryItemId;

                    #region todo

                    //    if (rgDescription.ContainsKey("descriptions"))
                    //    {
                    //        JsonArray descriptions = rgDescription.GetNamedArray("descriptions");

                    //        for (uint m = 0; m < descriptions.Count; m++)
                    //        {
                    //            JsonObject description = descriptions.GetObjectAt(m);
                    //            long descriptonsId = 0;

                    //            TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "descriptions").First();

                    //            List<(String, Object)> descriptionParameter = new List<(String, Object)>
                    //            {
                    //                (TableData.ElementAt(1).First(), DBNull.Value),
                    //                (TableData.ElementAt(2).First(), description.ContainsKey(TableData.ElementAt(2).First()) ? (Object)description.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
                    //                (TableData.ElementAt(3).First(), description.ContainsKey(TableData.ElementAt(3).First()) ? (Object)description.GetNamedString(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
                    //                (TableData.ElementAt(4).First(), description.ContainsKey(TableData.ElementAt(4).First()) ? (Object)description.GetNamedString(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
                    //            };

                    //            descriptonsId = GetIdOfDataSetSQL(descriptionParameter, new List<int> { 1, 2, 3 }, TableData.ElementAt(0).First(), db);

                    //            if (descriptonsId == 0)
                    //            {
                    //                descriptonsId = InsertIntoTableSQL(descriptionParameter, TableData.ElementAt(0).First(), db);
                    //            }

                    //            TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "descriptionsRgDescriptionsRel").First();

                    //            List<(String, Object)> descriptionsRgDescriptionsParameter = new List<(string, object)>
                    //            {
                    //                (TableData.ElementAt(1).First(), DBNull.Value),
                    //                (TableData.ElementAt(2).First(), descriptonsId),
                    //                (TableData.ElementAt(3).First(), rgDescriptonsId),
                    //                (TableData.ElementAt(4).First(), m)
                    //            };

                    //            if (GetIdOfDataSetSQL(descriptionsRgDescriptionsParameter, new List<int> { 1, 2, 3 }, TableData.ElementAt(0).First(), db) == 0)
                    //            {
                    //                InsertIntoTableSQL(descriptionsRgDescriptionsParameter, TableData.ElementAt(0).First(), db);
                    //            }

                    //            if (description.ContainsKey("app_data"))
                    //            {
                    //                JsonObject appData = description.GetNamedObject("app_data");
                    //                long app_dataId = 0;

                    //                TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "app_data").First();

                    //                List<(String, Object)> appDataParameter = new List<(String, Object)>
                    //                {
                    //                    (TableData.ElementAt(1).First(), DBNull.Value),
                    //                    (TableData.ElementAt(2).First(), appData.ContainsKey(TableData.ElementAt(2).First()) ? (Object)appData.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
                    //                    (TableData.ElementAt(3).First(), appData.ContainsKey(TableData.ElementAt(3).First()) ? (Object)appData.GetNamedNumber(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
                    //                    (TableData.ElementAt(4).First(), appData.ContainsKey(TableData.ElementAt(4).First()) ? (Object)appData.GetNamedNumber(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
                    //                };

                    //                app_dataId = GetIdOfDataSetSQL(appDataParameter, new List<int> { 1, 2, 3 }, TableData.ElementAt(0).First(), db);

                    //                if (app_dataId == 0)
                    //                {
                    //                    app_dataId = InsertIntoTableSQL(appDataParameter, TableData.ElementAt(0).First(), db);
                    //                }

                    //                TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "app_dataDescriptionsRgDescriptionsRel").First();

                    //                List<(String, Object)> appDataDescriptionsRgDescriptionParameter = new List<(String, Object)>
                    //                {
                    //                    (TableData.ElementAt(1).First(), DBNull.Value),
                    //                    (TableData.ElementAt(2).First(), descriptonsId),
                    //                    (TableData.ElementAt(3).First(), rgDescriptonsId),
                    //                    (TableData.ElementAt(4).First(), app_dataId)
                    //                };

                    //                if (GetIdOfDataSetSQL(appDataDescriptionsRgDescriptionParameter, new List<int> { 1, 2 }, TableData.ElementAt(0).First(), db) == 0)
                    //                {
                    //                    InsertIntoTableSQL(appDataDescriptionsRgDescriptionParameter, TableData.ElementAt(0).First(), db);
                    //                }
                    //            }

                    //        }
                    //    }

                    //    if (rgDescription.ContainsKey("actions"))
                    //    {
                    //        JsonArray actions = rgDescription.GetNamedArray("actions");
                    //        for (uint o = 0; o < actions.Count; o++)
                    //        {
                    //            JsonObject action = actions.GetObjectAt(o);

                    //            TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "actions").First();

                    //            List<(String, Object)> actionParameter = new List<(String, Object)>
                    //            {
                    //                (TableData.ElementAt(1).First(), DBNull.Value),
                    //                (TableData.ElementAt(2).First(), action.ContainsKey(TableData.ElementAt(2).First()) ? (Object)action.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
                    //                (TableData.ElementAt(3).First(), action.ContainsKey(TableData.ElementAt(3).First()) ? (Object)action.GetNamedString(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
                    //                (TableData.ElementAt(4).First(), rgDescriptonsId)
                    //            };

                    //            if (GetIdOfDataSetSQL(actionParameter, new List<int> { 1, 2, 3 }, TableData.ElementAt(0).First(), db) == 0)
                    //            {
                    //                InsertIntoTableSQL(actionParameter, TableData.ElementAt(0).First(), db);
                    //            }
                    //        }
                    //    }

                    //    if (rgDescription.ContainsKey("market_actions"))
                    //    {
                    //        JsonArray marketActions = rgDescription.GetNamedArray("market_actions");
                    //        for (uint o = 0; o < marketActions.Count; o++)
                    //        {
                    //            JsonObject marketAction = marketActions.GetObjectAt(o);

                    //            TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "market_actions").First();

                    //            List<(String, Object)> marketActionParameter = new List<(String, Object)>
                    //            {
                    //                (TableData.ElementAt(1).First(), DBNull.Value),
                    //                (TableData.ElementAt(2).First(), marketAction.ContainsKey(TableData.ElementAt(2).First()) ? (Object)marketAction.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
                    //                (TableData.ElementAt(3).First(), marketAction.ContainsKey(TableData.ElementAt(3).First()) ? (Object)marketAction.GetNamedString(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
                    //                (TableData.ElementAt(4).First(), rgDescriptonsId)
                    //            };

                    //            if (GetIdOfDataSetSQL(marketActionParameter, new List<int> { 1, 2, 3 }, "market_actions", db) == 0)
                    //            {
                    //                InsertIntoTableSQL(marketActionParameter, "market_actions", db);
                    //            }
                    //        }
                    //    }

                    //    if (rgDescription.ContainsKey("tags"))
                    //    {
                    //        JsonArray tags = rgDescription.GetNamedArray("tags");
                    //        for (uint p = 0; p < tags.Count; p++)
                    //        {
                    //            JsonObject tag = tags.GetObjectAt(p);

                    //            TableData = SqlDbModel.TableDataList.Where(tdl => tdl[0][0] == "tags").First();

                    //            List<(String, Object)> tagParameter = new List<(String, Object)>
                    //            {
                    //                (TableData.ElementAt(1).First(), DBNull.Value),
                    //                (TableData.ElementAt(2).First(), tag.ContainsKey(TableData.ElementAt(2).First()) ? (Object)tag.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
                    //                (TableData.ElementAt(3).First(), tag.ContainsKey(TableData.ElementAt(3).First()) ? (Object)tag.GetNamedString(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
                    //                (TableData.ElementAt(4).First(), tag.ContainsKey(TableData.ElementAt(4).First()) ? (Object)tag.GetNamedString(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
                    //                (TableData.ElementAt(5).First(), tag.ContainsKey(TableData.ElementAt(5).First()) ? (Object)tag.GetNamedString(TableData.ElementAt(5).First()) : (Object)DBNull.Value),
                    //                (TableData.ElementAt(6).First(), tag.ContainsKey(TableData.ElementAt(6).First()) ? (Object)tag.GetNamedString(TableData.ElementAt(6).First()) : (Object)DBNull.Value),
                    //                (TableData.ElementAt(7).First(), rgDescriptonsId)
                    //            };

                    //            if (GetIdOfDataSetSQL(tagParameter, new List<int> { 1, 2, 3 }, "tags", db) == 0)
                    //            {
                    //                InsertIntoTableSQL(tagParameter, "tags", db);
                    //            }
                    //        }
                    //    }
                    //}
                    //JsonArray rgCurrency = csgoInventory.GetNamedArray("rgCurrency");

                    //db.Close();

                    #endregion
                }
            }
        }
    }
}