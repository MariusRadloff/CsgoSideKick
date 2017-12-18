using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Windows.Data.Json;
using Windows.Storage;

namespace DataAccessLibrary
{
    public static class DataAccess
    {
        private static string dbConnectionString;

        public static string DbConnectionString
        {
            get { return "Filename=steamInventory.db"; }
        }

        public static void InitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection(DbConnectionString))
            {
                #region TableCommands
                String steamInventoryTableCommand = "CREATE TABLE IF NOT EXISTS steamInventory (" +
                "id	TEXT NOT NULL PRIMARY KEY," +
                "username	TEXT NOT NULL" +
                ");";

                String csgoInventoryTableCommand = "CREATE TABLE IF NOT EXISTS csgoInventory (" +
                    "id	TEXT NOT NULL PRIMARY KEY," +
                    "success	TEXT," +
                    "more	TEXT," +
                    "more_start	TEXT," +
                    "steamInventoryId	TEXT," +
                    "FOREIGN KEY(steamInventoryId) REFERENCES steamInventory(id)" +
                    ");";

                String rgInventoryTableCommand = "CREATE TABLE IF NOT EXISTS rgInventory (" +
                    "id	TEXT NOT NULL PRIMARY KEY," +
                    "classid	TEXT," +
                    "instanceid	TEXT," +
                    "amount	TEXT," +
                    "pos	TEXT," +
                    "csgoInventoryId	TEXT," +
                    "FOREIGN KEY(csgoInventoryId) REFERENCES csgoInventory(id)" +
                    ");";

                String rgCurrencyTableCommand = "CREATE TABLE IF NOT EXISTS rgCurrency (" +
                    "id	TEXT NOT NULL PRIMARY KEY," +
                    "csgoInventoryId	TEXT," +
                    "FOREIGN KEY(csgoInventoryId) REFERENCES csgoInventory(id)" +
                    ");";

                String rgDescriptionTableCommand = "CREATE TABLE IF NOT EXISTS rgDescription (" +
                    "id	TEXT NOT NULL PRIMARY KEY," +
                    "appid	TEXT," +
                    "instanceid	TEXT," +
                    "icon_url	TEXT," +
                    "icon_url_large	TEXT," +
                    "icon_drag_url	TEXT," +
                    "name	TEXT," +
                    "market_hash_name	TEXT," +
                    "market_name TEXT," +
                    "name_color	TEXT," +
                    "background_color TEXT," +
                    "type	TEXT," +
                    "tradable	TEXT," +
                    "marketable	TEXT," +
                    "commodity	TEXT," +
                    "market_tradable_restriction	TEXT," +
                    "csgoInventoryId	TEXT," +
                    "FOREIGN KEY(csgoInventoryId) REFERENCES csgoInventory(id)" +
                    ");";

                String descriptionsTableCommand = "CREATE TABLE IF NOT EXISTS descriptions (" +
                    "id	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "type	TEXT," +
                    "value	TEXT," +
                    "color	TEXT," +
                    "rgDescriptionId	TEXT," +
                    "FOREIGN KEY(rgDescriptionId) REFERENCES rgDescription(id)" +
                    ");";

                String app_dataTableCommand = "CREATE TABLE IF NOT EXISTS app_data (" +
                    "id	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "def_index	TEXT," +
                    "is_itemset_name	REAL," +
                    "limited INTEGER," +
                    "descriptionsId	INTEGER," +
                    "FOREIGN KEY(descriptionsId) REFERENCES descriptions(id)" +
                    ");";

                String actionsTableCommand = "CREATE TABLE IF NOT EXISTS actions (" +
                    "id	INTEGER NOT NULL PRIMARY KEY," +
                    "name	TEXT," +
                    "link	TEXT," +
                    "rgDescriptionId	TEXT," +
                    "FOREIGN KEY(rgDescriptionId) REFERENCES rgDescription(id)" +
                    ");";

                String market_actionsTableCommand = "CREATE TABLE IF NOT EXISTS market_actions (" +
                    "id	INTEGER NOT NULL PRIMARY KEY," +
                    "name	TEXT," +
                    "link	TEXT," +
                    "rgDescriptionId	TEXT," +
                    "FOREIGN KEY(rgDescriptionId) REFERENCES rgDescription(id)" +
                    ");";

                String tagsTableCommand = "CREATE TABLE IF NOT EXISTS tags (" +
                    "id	INTEGER NOT NULL PRIMARY KEY," +
                    "internal_name	TEXT," +
                    "name	TEXT," +
                    "category	TEXT," +
                    "color	TEXT," +
                    "category_name	TEXT," +
                    "rgDescriptionId	TEXT," +
                    "FOREIGN KEY(rgDescriptionId) REFERENCES rgDescription(id)" +
                    ");";

                String priceDataTableCommand = "CREATE TABLE IF NOT EXISTS priceData(" +
                    "id INTEGER NOT NULL PRIMARY KEY," +
                    "purchaseDate TEXT," +
                    "purchasePrice TEXT," +
                    "rgDescriptionId INTEGER," +
                    "FOREIGN KEY(rgDescriptionId) REFERENCES rgDescription(id)" +
                    ");";

                String priceCollectionTableCommand = "CREATE TABLE IF NOT EXISTS priceCollection (" +
                    "id INTEGER NOT NULL PRIMARY KEY," +
                    "date TEXT," +
                    "price TEXT," +
                    "priceDataId TEXT," +
                    "FOREIGN KEY(priceDataId) REFERENCES priceData(id)" +
                    ");";

                String app_dataDescriptionsRelTableCommand = "CREATE TABLE IF NOT EXISTS app_dataDescriptionsRel(" +
                    "descriptionsId INTEGER NOT NULL," +
                    "app_dataId INTEGER NOT NULL," +
                    "PRIMARY KEY ( descriptionsId, app_dataId )" +
                    ");";

                String descriptionsRgDescriptionRelTableCommand = "CREATE TABLE IF NOT EXISTS descriptionsRgDescriptionRel(" +
                    "descriptionsId INTEGER NOT NULL," +
                    "rgDescriptionId INTEGER NOT NULL," +
                     "PRIMARY KEY ( descriptionsId, rgDescriptionId )" +
                    ");";

                #endregion

                db.Open();

                SqliteCommand createSteamInventoryTable = new SqliteCommand(steamInventoryTableCommand, db);
                SqliteCommand createCsgoInventoryTable = new SqliteCommand(csgoInventoryTableCommand, db);
                SqliteCommand createRgInventoryTable = new SqliteCommand(rgInventoryTableCommand, db);
                SqliteCommand createRgCurrencyTable = new SqliteCommand(rgCurrencyTableCommand, db);
                SqliteCommand createRgDescriptionTable = new SqliteCommand(rgDescriptionTableCommand, db);
                SqliteCommand createDescriptionsTable = new SqliteCommand(descriptionsTableCommand, db);
                SqliteCommand createApp_dataTable = new SqliteCommand(app_dataTableCommand, db);
                SqliteCommand createActionsTable = new SqliteCommand(actionsTableCommand, db);
                SqliteCommand createMarket_actionsTable = new SqliteCommand(market_actionsTableCommand, db);
                SqliteCommand createTagsTable = new SqliteCommand(tagsTableCommand, db);
                SqliteCommand createPriceDataTable = new SqliteCommand(priceDataTableCommand, db);
                SqliteCommand createPriceCollectionTable = new SqliteCommand(priceCollectionTableCommand, db);
                SqliteCommand createApp_dataRgDescriptionRelTable = new SqliteCommand(app_dataDescriptionsRelTableCommand, db);
                SqliteCommand createDescriptionsRgDescriptionRelTable = new SqliteCommand(descriptionsRgDescriptionRelTableCommand, db);

                createSteamInventoryTable.ExecuteReader();
                createCsgoInventoryTable.ExecuteReader();
                createRgInventoryTable.ExecuteReader();
                createRgCurrencyTable.ExecuteReader();
                createRgDescriptionTable.ExecuteReader();
                createDescriptionsTable.ExecuteReader();
                createApp_dataTable.ExecuteReader();
                createActionsTable.ExecuteReader();
                createMarket_actionsTable.ExecuteReader();
                createTagsTable.ExecuteReader();
                createPriceDataTable.ExecuteReader();
                createPriceCollectionTable.ExecuteReader();
                createApp_dataRgDescriptionRelTable.ExecuteReader();
                createDescriptionsRgDescriptionRelTable.ExecuteReader();
            }
        }

        public static void ResetDatabase()
        {
            using (SqliteConnection db = new SqliteConnection(DbConnectionString))
            {
                #region TableCommands
                String deleteSteamInventoryTableCommand = "DELETE FROM steamInventory";

                String deleteCsgoInventoryTableCommand = "DELETE FROM csgoInventory";

                String deleteRgInventoryTableCommand = "DELETE FROM rgInventory";

                String deleteRgCurrencyTableCommand = "DELETE FROM rgCurrency";

                String deleteRgDescriptionTableCommand = "DELETE FROM rgDescription";

                String deleteDescriptionsTableCommand = "DELETE FROM descriptions";

                String deleteApp_dataTableCommand = "DELETE FROM app_data";

                String deleteActionsTableCommand = "DELETE FROM actions";

                String deleteMarket_actionsTableCommand = "DELETE FROM market_actions";

                String deleteTagsTableCommand = "DELETE FROM tags";
                #endregion

                SqliteCommand deleteSteamInventoryTable = new SqliteCommand(deleteSteamInventoryTableCommand, db);
                SqliteCommand deleteCsgoInventoryTable = new SqliteCommand(deleteCsgoInventoryTableCommand, db);
                SqliteCommand deleteRgInventoryTable = new SqliteCommand(deleteRgInventoryTableCommand, db);
                SqliteCommand deleteRgCurrencyTable = new SqliteCommand(deleteRgCurrencyTableCommand, db);
                SqliteCommand deleteRgDescriptionTable = new SqliteCommand(deleteRgDescriptionTableCommand, db);
                SqliteCommand deleteDescriptionsTable = new SqliteCommand(deleteDescriptionsTableCommand, db);
                SqliteCommand deleteApp_dataTable = new SqliteCommand(deleteApp_dataTableCommand, db);
                SqliteCommand deleteActionsTable = new SqliteCommand(deleteActionsTableCommand, db);
                SqliteCommand deleteMarket_actionsTable = new SqliteCommand(deleteMarket_actionsTableCommand, db);
                SqliteCommand deleteTagsTable = new SqliteCommand(deleteTagsTableCommand, db);

                db.Open();

                deleteSteamInventoryTable.ExecuteReader();
                deleteCsgoInventoryTable.ExecuteReader();
                deleteRgInventoryTable.ExecuteReader();
                deleteRgCurrencyTable.ExecuteReader();
                deleteRgDescriptionTable.ExecuteReader();
                deleteDescriptionsTable.ExecuteReader();
                deleteApp_dataTable.ExecuteReader();
                deleteActionsTable.ExecuteReader();
                deleteMarket_actionsTable.ExecuteReader();
                deleteTagsTable.ExecuteReader();

                db.Close();
            }
        }

        public static void AddData(string inputText)
        {
            using (SqliteConnection db = new SqliteConnection(DbConnectionString))
            {
                db.Open();

                using (SqliteCommand insertCommand = new SqliteCommand("INSERT INTO MyTable VALUES (NULL, @Entry);", db))
                {
                    insertCommand.Parameters.AddWithValue("@Entry", inputText);
                    insertCommand.ExecuteReader();
                }

                db.Close();
            }

        }

        public  static void AddSteamInventory(string Steam64Id, string Username)
        {
            using (SqliteConnection db = new SqliteConnection(DbConnectionString))
            {
                db.Open();

                using (SqliteCommand steamInventoryExistsCommand = new SqliteCommand("SELECT id FROM steamInventory WHERE EXISTS(SELECT id FROM steamInventory WHERE id = @id)", db))
                {
                    steamInventoryExistsCommand.Parameters.AddWithValue("@id", Steam64Id);

                    if (!steamInventoryExistsCommand.ExecuteReader().HasRows)
                    {
                        using (SqliteCommand steamInventoryInsertCommand = new SqliteCommand("INSERT INTO steamInventory VALUES (@id, @username);", db))
                        {
                            steamInventoryInsertCommand.Parameters.AddWithValue("@id", Steam64Id);
                            steamInventoryInsertCommand.Parameters.AddWithValue("@username", Username);
                            steamInventoryInsertCommand.ExecuteReader();
                        }


                    }
                }
                db.Close();
            }

        }

        public static void AddCsgoInventory(string inventoryString, string Steam64Id, string csgoInventoryId)
        {
            using (SqliteConnection db = new SqliteConnection(DbConnectionString))
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

                db.Open();

                List<(String, Object)> csgoInventoryParameter = new List<(String, Object)>
                {
                    ("id", csgoInventoryId),
                    ("success", csgoInventory.ContainsKey("success") ? (Object)csgoInventory.GetNamedBoolean("success") : (Object)DBNull.Value),
                    ("more", csgoInventory.ContainsKey("more") ? (Object)csgoInventory.GetNamedBoolean("more") : (Object)DBNull.Value),
                    ("more_start", csgoInventory.ContainsKey("more_start") ? (Object)csgoInventory.GetNamedBoolean("more_start") : (Object)DBNull.Value),
                    ("steamInventoryId", Steam64Id)
                };

                if (!DataSetExists(csgoInventoryParameter, new List<int> {0, 1, 2, 3, 4 }, "csgoInventory", db))
                {
                    InsertIntoTable(csgoInventoryParameter, csgoInventoryParameter.First().Item2, "csgoInventory", db);
                }

                JsonObject rgInventory = csgoInventory.GetNamedObject("rgInventory");

                for (int i = 0; i < rgInventory.Count; i++)
                {
                    JsonObject rgInventoryElement = rgInventory.GetNamedObject(rgInventory.ElementAt(i).Key);

                    List<(String, Object)> rgInventoryParameter = new List<(String, Object)>
                    {
                        ("id", csgoInventoryId),
                        ("classid", rgInventoryElement.ContainsKey("classid") ? (Object)rgInventoryElement.GetNamedString("classid") : (Object)DBNull.Value),
                        ("instanceid", rgInventoryElement.ContainsKey("instanceid") ? (Object)rgInventoryElement.GetNamedString("instanceid") : (Object)DBNull.Value),
                        ("amount", rgInventoryElement.ContainsKey("amount") ? (Object)rgInventoryElement.GetNamedString("amount") : (Object)DBNull.Value),
                        ("pos", rgInventoryElement.ContainsKey("pos") ? (Object)rgInventoryElement.GetNamedNumber("pos") : (Object)DBNull.Value),
                        ("csgoInventoryId", csgoInventoryId)
                    };

                    if (!DataSetExists(rgInventoryParameter, new List<int> { 1, 2, 3, 4, 5 }, "rgInventory", db))
                    {
                        InsertIntoTable(rgInventoryParameter, rgInventoryParameter.First().Item2, "rgInventory", db);
                    }
                }

                JsonObject rgDescriptions = csgoInventory.GetNamedObject("rgDescriptions");

                for (int n = 0; n < rgDescriptions.Count; n++)
                {
                    JsonObject rgDescription = rgDescriptions.GetNamedObject(rgDescriptions.ElementAt(n).Key);

                    List<(String, Object)> rgDescriptionParameter = new List<(String, Object)>
                    {
                        ("id", rgDescriptions.ElementAt(n).Key),
                        ("appid", csgoInventory.ContainsKey("appid") ? (Object)csgoInventory.GetNamedBoolean("appid") : (Object)DBNull.Value),
                        ("instanceid", csgoInventory.ContainsKey("instanceid") ? (Object)csgoInventory.GetNamedBoolean("instanceid") : (Object)DBNull.Value),
                        ("icon_url", csgoInventory.ContainsKey("icon_url") ? (Object)csgoInventory.GetNamedBoolean("icon_url") : (Object)DBNull.Value),
                        ("icon_url_large", csgoInventory.ContainsKey("icon_url_large") ? (Object)csgoInventory.GetNamedBoolean("icon_url_large") : (Object)DBNull.Value),
                        ("icon_drag_url", csgoInventory.ContainsKey("icon_drag_url") ? (Object)csgoInventory.GetNamedBoolean("icon_drag_url") : (Object)DBNull.Value),
                        ("name", csgoInventory.ContainsKey("name") ? (Object)csgoInventory.GetNamedBoolean("name") : (Object)DBNull.Value),
                        ("market_hash_name", csgoInventory.ContainsKey("market_hash_name") ? (Object)csgoInventory.GetNamedBoolean("market_hash_name") : (Object)DBNull.Value),
                        ("market_name", csgoInventory.ContainsKey("market_name") ? (Object)csgoInventory.GetNamedBoolean("market_name") : (Object)DBNull.Value),
                        ("name_color", csgoInventory.ContainsKey("name_color") ? (Object)csgoInventory.GetNamedBoolean("name_color") : (Object)DBNull.Value),
                        ("background_color", csgoInventory.ContainsKey("background_color") ? (Object)csgoInventory.GetNamedBoolean("background_color") : (Object)DBNull.Value),
                        ("type", csgoInventory.ContainsKey("type") ? (Object)csgoInventory.GetNamedBoolean("type") : (Object)DBNull.Value),
                        ("tradable", csgoInventory.ContainsKey("tradable") ? (Object)csgoInventory.GetNamedBoolean("tradable") : (Object)DBNull.Value),
                        ("marketable", csgoInventory.ContainsKey("marketable") ? (Object)csgoInventory.GetNamedBoolean("marketable") : (Object)DBNull.Value),
                        ("commodity", csgoInventory.ContainsKey("commodity") ? (Object)csgoInventory.GetNamedBoolean("commodity") : (Object)DBNull.Value),
                        ("market_tradable_restriction", csgoInventory.ContainsKey("market_tradable_restriction") ? (Object)csgoInventory.GetNamedBoolean("market_tradable_restriction") : (Object)DBNull.Value),
                        ("csgoInventoryId", csgoInventoryId)
                    };

                    if (!DataSetExists(rgDescriptionParameter, new List<int> { 1, 2, 3, 4, 5 }, "rgDescription", db))
                    {
                        InsertIntoTable(rgDescriptionParameter, rgDescriptionParameter.First().Item2, "rgDescription", db);
                    }

                    if (rgDescription.ContainsKey("descriptions"))
                    {
                        JsonArray descriptions = rgDescription.GetNamedArray("descriptions");

                        for (uint m = 0; m < descriptions.Count; m++)
                        {
                            JsonObject description = descriptions.GetObjectAt(m);

                            List<(String, Object)> descriptionParameter = new List<(String, Object)>
                            {
                                ("id", DBNull.Value),
                                ("type", description.ContainsKey("type") ? (Object)description.GetNamedString("type") : (Object)DBNull.Value),
                                ("value", description.ContainsKey("value") ? (Object)description.GetNamedString("value") : (Object)DBNull.Value),
                                ("color", description.ContainsKey("color") ? (Object)description.GetNamedString("color") : (Object)DBNull.Value),
                                ("rgDescriptionId", rgDescriptions.ElementAt(n).Key)
                            };

                            if (!DataSetExists(descriptionParameter, new List<int> { 1, 2, 3 }, "descriptions", db))
                            {
                                InsertIntoTable(descriptionParameter, descriptionParameter.First().Item2, "descriptions", db);
                            }

                            if (description.ContainsKey("app_data"))
                            {
                                JsonObject appData = description.GetNamedObject("app_data");

                                List<(String, Object)> appDataParameter = new List<(String, Object)>
                                {
                                    ("id", DBNull.Value),
                                    ("def_index", appData.ContainsKey("def_index") ? (Object)appData.GetNamedString("def_index") : (Object)DBNull.Value),
                                    ("is_itemset_name", appData.ContainsKey("is_itemset_name") ? (Object)appData.GetNamedNumber("is_itemset_name") : (Object)DBNull.Value),
                                    ("limited", appData.ContainsKey("limited") ? (Object)appData.GetNamedNumber("limited") : (Object)DBNull.Value),
                                    ("descriptionsId", rgDescriptions.ElementAt(n).Key)
                                };

                                if (!DataSetExists(appDataParameter, new List<int> { 1, 2, 3, 4 }, "app_data", db))
                                {
                                    InsertIntoTable(appDataParameter, appDataParameter.First().Item2, "app_data", db);
                                }
                            }

                        }
                    }

                    if (rgDescription.ContainsKey("actions"))
                    {
                        JsonArray actions = rgDescription.GetNamedArray("actions");
                        for (uint o = 0; o < actions.Count; o++)
                        {
                            JsonObject action = actions.GetObjectAt(o);

                            List<(String, Object)> actionParameter = new List<(String, Object)>
                            {
                                ("id", DBNull.Value),
                                ("name", action.ContainsKey("name") ? (Object)action.GetNamedString("name") : (Object)DBNull.Value),
                                ("link", action.ContainsKey("link") ? (Object)action.GetNamedString("link") : (Object)DBNull.Value),
                                ("rgDescriptionId", rgDescriptions.ElementAt(n).Key)
                            };

                            if (!DataSetExists(actionParameter, new List<int> { 1, 2, 3 }, "actions", db))
                            {
                                InsertIntoTable(actionParameter, actionParameter.First().Item2, "actions", db);
                            }
                        }
                    }

                    if (rgDescription.ContainsKey("market_actions"))
                    {
                        JsonArray marketActions = rgDescription.GetNamedArray("market_actions");
                        for (uint o = 0; o < marketActions.Count; o++)
                        {
                            JsonObject marketAction = marketActions.GetObjectAt(o);

                            List<(String, Object)> marketActionParameter = new List<(String, Object)>
                            {
                                ("id", DBNull.Value),
                                ("name", marketAction.ContainsKey("name") ? (Object)marketAction.GetNamedString("name") : (Object)DBNull.Value),
                                ("link", marketAction.ContainsKey("link") ? (Object)marketAction.GetNamedString("link") : (Object)DBNull.Value),
                                ("rgDescriptionId", rgDescriptions.ElementAt(n).Key)
                            };

                            if (!DataSetExists(marketActionParameter, new List<int> { 1, 2, 3 }, "market_actions", db))
                            {
                                InsertIntoTable(marketActionParameter, marketActionParameter.First().Item2, "market_actions", db);
                            }
                        }
                    }

                    if (rgDescription.ContainsKey("tags"))
                    {
                        JsonArray tags = rgDescription.GetNamedArray("tags");
                        for (uint p = 0; p < tags.Count; p++)
                        {
                            JsonObject tag = tags.GetObjectAt(p);

                            List<(String, Object)> tagParameter = new List<(String, Object)>
                            {
                                ("id", DBNull.Value),
                                ("internal_name", tag.ContainsKey("internal_name") ? (Object)tag.GetNamedString("internal_name") : (Object)DBNull.Value),
                                ("name", tag.ContainsKey("name") ? (Object)tag.GetNamedString("name") : (Object)DBNull.Value),
                                ("category", tag.ContainsKey("category") ? (Object)tag.GetNamedString("category") : (Object)DBNull.Value),
                                ("color", tag.ContainsKey("color") ? (Object)tag.GetNamedString("color") : (Object)DBNull.Value),
                                ("category_name", tag.ContainsKey("category_name") ? (Object)tag.GetNamedString("category_name") : (Object)DBNull.Value),
                                ("rgDescriptionId", rgDescriptions.ElementAt(n).Key)
                            };

                            if (!DataSetExists(tagParameter, new List<int> { 1, 2, 3 }, "tags", db))
                            {
                                InsertIntoTable(tagParameter, tagParameter.First().Item2, "tags", db);
                            }
                        }
                    }
                }
                JsonArray rgCurrency = csgoInventory.GetNamedArray("rgCurrency");

                db.Close();
            }
        }

        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            using (SqliteConnection db = new SqliteConnection(DbConnectionString))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT * from rgInventory", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                db.Close();
            }
            return entries;
        }

        private static Object GetIdOfLastInsertRow(SqliteConnection db)
        {
            SqliteCommand lastInsertSelectCommand = new SqliteCommand("SELECT last_insert_rowid()", db);

            SqliteDataReader query = lastInsertSelectCommand.ExecuteReader();

            query.Read();

            return query.GetValue(0);
            //while (query.Read())
            //{
            //    string dataType = query.GetDataTypeName(0);
            //    entries.Add(query.GetDataTypeName(0));
            //    //query.GetFieldValue < query.GetFieldType(0) > (0);
            //}
        }

        private static void AddItemToTable(SqliteConnection db, string tableName, IJsonValue jValue)
        {
            string commandString = "INSERT OR IGNORE INTO " + tableName + " VALUES (";
            int parameterNumber = 0;
            string parameterName = "";

            Type typeInput = jValue.GetType();

            if (typeInput == typeof(JsonObject))
            {
                JsonObject jObj = (JsonObject)jValue;

                using (SqliteCommand command = new SqliteCommand())
                {
                    foreach (var element in jObj)
                    {
                        switch (element.Value.ValueType)
                        {
                            case JsonValueType.Null:
                                break;
                            case JsonValueType.Boolean:
                                parameterNumber++;
                                parameterName = "@param" + parameterNumber;
                                commandString = commandString + parameterName + ", ";
                                command.Parameters.AddWithValue(parameterName, element.Value.GetBoolean());
                                break;
                            case JsonValueType.Number:
                                parameterNumber++;
                                parameterName = "@param" + parameterNumber;
                                commandString = commandString + parameterName + ", ";
                                command.Parameters.AddWithValue(parameterName, element.Value.GetNumber());
                                break;
                            case JsonValueType.String:
                                parameterNumber++;
                                parameterName = "@param" + parameterNumber;
                                commandString = commandString + parameterName + ", ";
                                command.Parameters.AddWithValue(parameterName, element.Value.GetString());
                                break;
                            case JsonValueType.Array:
                                break;
                            case JsonValueType.Object:
                                break;
                            default:
                                break;
                        }
                    }
                    commandString = commandString.Remove(commandString.Length - 2);
                    commandString = commandString + ");";
                    command.CommandText = commandString;
                    command.Connection = db;
                    command.ExecuteReader();
                }
            }
        }

        private static void InsertIntoTable(List<(String, Object)> parameters, object id, string tableName, SqliteConnection connection)
        {
            string insertCommandString = "INSERT OR IGNORE INTO " + tableName + " VALUES (";

            using (SqliteCommand command = new SqliteCommand())
            {
                command.Connection = connection;

                foreach ((String, Object) parameter in parameters)
                {
                    string name = "@" + parameter.Item1;

                    insertCommandString = insertCommandString + name + ", ";
                    command.Parameters.AddWithValue(name, parameter.Item2);

                    //insertCommandString = insertCommandString + parameter.Item1 + ", ";
                    //command.Parameters.AddWithValue(parameter.Item1, parameter.Item2);
                }
                insertCommandString = insertCommandString.Remove(insertCommandString.Length - 2);
                insertCommandString = insertCommandString + ");";
                command.CommandText = insertCommandString;
                command.ExecuteReader();
            }
        }

        private static void InsertIntoRelTable(List<Object> parameters, object id, string tableName, SqliteConnection connection)
        {

        }

        private static bool DataSetExists(List<(String, Object)> parameter, List<int> parameterNumbers, string tableName, SqliteConnection connection)
        {
            string selectCommandText = "SELECT * FROM " + tableName;
            int index = 0;

            foreach (var num in parameterNumbers)
            {
                if (parameter[num].Item2.GetType() == typeof(String))
                {

                    var b = parameter[num].Item2;
                    if (index == 0)
                    {
                        selectCommandText = selectCommandText + " WHERE " + parameter[num].Item1 + " = " + "\"" + parameter[num].Item2 + "\"";
                    }
                    else
                    {
                        selectCommandText = selectCommandText + " AND " + parameter[num].Item1 + " = " + "\"" + parameter[num].Item2 + "\"";
                    }
                }
                else if (parameter[num].Item2.GetType() == typeof(Double))
                {
                    if (index == 0)
                    {
                        selectCommandText = selectCommandText + " WHERE " + parameter[num].Item1 + " = " + parameter[num].Item2;
                    }
                    else
                    {
                        selectCommandText = selectCommandText + " AND " + parameter[num].Item1 + " = " + parameter[num].Item2;
                    }
                }
                else if (parameter[num].Item2.GetType() == typeof(Boolean))
                {
                    if (index == 0)
                    {
                        if ((Boolean)parameter[num].Item2)
                        {
                            selectCommandText = selectCommandText + " WHERE " + parameter[num].Item1 + " = 1";
                        }
                        else
                        {
                            selectCommandText = selectCommandText + " WHERE " + parameter[num].Item1 + " = 0";
                        }
                    }
                    else
                    {
                        if ((Boolean)parameter[num].Item2)
                        {
                            selectCommandText = selectCommandText + " ANd " + parameter[num].Item1 + " = 1";
                        }
                        else
                        {
                            selectCommandText = selectCommandText + " ANd " + parameter[num].Item1 + " = 0";
                        }
                    }
                }
                else if (parameter[num].Item2.GetType() == typeof(DBNull))
                {
                    if (index == 0)
                    {
                        selectCommandText = selectCommandText + " WHERE " + parameter[num].Item1 + " IS NULL";
                    }
                    else
                    {
                        selectCommandText = selectCommandText + " AND " + parameter[num].Item1 + " IS NULL";
                    }
                }
                index ++;
            }

            selectCommandText += ";";

            SqliteCommand selectCommand = new SqliteCommand(selectCommandText, connection);

            SqliteDataReader query = selectCommand.ExecuteReader();

            if (query.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
