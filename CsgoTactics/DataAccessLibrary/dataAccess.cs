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
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "userId	TEXT NOT NULL," +
                    "username	TEXT NOT NULL" +
                    ");";

                String csgoInventoryTableCommand = "CREATE TABLE IF NOT EXISTS csgoInventory (" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "gameId	TEXT NOT NULL," +
                    "success    TEXT," +
                    "more	TEXT," +
                    "more_start	TEXT," +
                    "steamInventoryId	TEXT," +
                    "FOREIGN KEY(steamInventoryId) REFERENCES steamInventory(id)" +
                    ");";

                String rgInventoryTableCommand = "CREATE TABLE IF NOT EXISTS rgInventory (" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "rgInventoryId	TEXT NOT NULL," +
                    "classid	TEXT," +
                    "instanceid	TEXT," +
                    "amount	TEXT," +
                    "pos	TEXT," +
                    "csgoInventoryId	TEXT," +
                    "FOREIGN KEY(csgoInventoryId) REFERENCES csgoInventory(id)" +
                    ");";

                String rgCurrencyTableCommand = "CREATE TABLE IF NOT EXISTS rgCurrency (" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "rgCurrencyId	TEXT NOT NULL," +
                    "csgoInventoryId	TEXT," +
                    "FOREIGN KEY(csgoInventoryId) REFERENCES csgoInventory(id)" +
                    ");";

                String rgDescriptionTableCommand = "CREATE TABLE IF NOT EXISTS rgDescription (" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "appid_instanceid	TEXT NOT NULL," +
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
                    "tradable	NUMBER," +
                    "marketable	NUMBER," +
                    "commodity	NUMBER," +
                    "market_tradable_restriction	TEXT," +
                    "csgoInventoryId	TEXT," +
                    "FOREIGN KEY(csgoInventoryId) REFERENCES csgoInventory(id)" +
                    ");";

                String descriptionsTableCommand = "CREATE TABLE IF NOT EXISTS descriptions (" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "type	TEXT," +
                    "value	TEXT," +
                    "color	TEXT" +
                    ");";

                String app_dataTableCommand = "CREATE TABLE IF NOT EXISTS app_data (" +
                    "id	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "def_index	TEXT," +
                    "is_itemset_name	REAL," +
                    "limited INTEGER" +
                    ");";

                String actionsTableCommand = "CREATE TABLE IF NOT EXISTS actions (" +
                    "id	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "name	TEXT," +
                    "link	TEXT," +
                    "rgDescriptionId	TEXT," +
                    "FOREIGN KEY(rgDescriptionId) REFERENCES rgDescription(id)" +
                    ");";

                String market_actionsTableCommand = "CREATE TABLE IF NOT EXISTS market_actions (" +
                    "id	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "name	TEXT," +
                    "link	TEXT," +
                    "rgDescriptionId	TEXT," +
                    "FOREIGN KEY(rgDescriptionId) REFERENCES rgDescription(id)" +
                    ");";

                String tagsTableCommand = "CREATE TABLE IF NOT EXISTS tags (" +
                    "id	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "internal_name	TEXT," +
                    "name	TEXT," +
                    "category	TEXT," +
                    "color	TEXT," +
                    "category_name	TEXT," +
                    "rgDescriptionId	TEXT," +
                    "FOREIGN KEY(rgDescriptionId) REFERENCES rgDescription(id)" +
                    ");";

                String priceDataTableCommand = "CREATE TABLE IF NOT EXISTS priceData(" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "purchaseDate TEXT," +
                    "purchasePrice TEXT," +
                    "rgDescriptionId INTEGER," +
                    "FOREIGN KEY(rgDescriptionId) REFERENCES rgDescription(id)" +
                    ");";

                String priceCollectionTableCommand = "CREATE TABLE IF NOT EXISTS priceCollection (" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "date TEXT," +
                    "price TEXT," +
                    "priceDataId TEXT," +
                    "FOREIGN KEY(priceDataId) REFERENCES priceData(id)" +
                    ");";

                String app_dataDescriptionsRelTableCommand = "CREATE TABLE IF NOT EXISTS app_dataDescriptionsRel(" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "descriptionsId INTEGER NOT NULL," +
                    "app_dataId INTEGER NOT NULL," +
                    "UNIQUE ( descriptionsId, app_dataId )" +
                    ");";

                String descriptionsRgDescriptionRelTableCommand = "CREATE TABLE IF NOT EXISTS descriptionsRgDescriptionRel(" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "descriptionsId INTEGER NOT NULL," +
                    "rgDescriptionId INTEGER NOT NULL," +
                    "pos INTEGER NOT NULL," +
                     "UNIQUE ( descriptionsId, rgDescriptionId )" +
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
                SqliteCommand createApp_dataDescriptionsRelTable = new SqliteCommand(app_dataDescriptionsRelTableCommand, db);
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
                createApp_dataDescriptionsRelTable.ExecuteReader();
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
                String deletePriceDataTableCommand = "DELETE FROM priceData";
                String deletePriceCollectionTableCommand = "DELETE FROM priceCollection";
                String deleteApp_dataRgDescriptionRelTableCommand = "DELETE FROM app_dataDescriptionsRel";
                String deleteDescriptionsRgDescriptionRelTableCommand = "DELETE FROM descriptionsRgDescriptionRel";
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
                SqliteCommand deletePriceDataTable = new SqliteCommand(deletePriceDataTableCommand, db);
                SqliteCommand deletePriceCollectionTable = new SqliteCommand(deletePriceCollectionTableCommand, db);
                SqliteCommand deleteApp_dataRgDescriptionRelTable = new SqliteCommand(deleteApp_dataRgDescriptionRelTableCommand, db);
                SqliteCommand deleteDescriptionsRgDescriptionRelTable = new SqliteCommand(deleteDescriptionsRgDescriptionRelTableCommand, db);

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
                deletePriceDataTable.ExecuteReader();
                deletePriceCollectionTable.ExecuteReader();
                deleteApp_dataRgDescriptionRelTable.ExecuteReader();
                deleteDescriptionsRgDescriptionRelTable.ExecuteReader();

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
                    ("id", DBNull.Value),
                    ("gameId", csgoInventoryId),
                    ("success", csgoInventory.ContainsKey("success") ? (Object)csgoInventory.GetNamedBoolean("success") : (Object)DBNull.Value),
                    ("more", csgoInventory.ContainsKey("more") ? (Object)csgoInventory.GetNamedBoolean("more") : (Object)DBNull.Value),
                    ("more_start", csgoInventory.ContainsKey("more_start") ? (Object)csgoInventory.GetNamedBoolean("more_start") : (Object)DBNull.Value),
                    ("steamInventoryId", Steam64Id)
                };

                if (GetIdOfDataSet(csgoInventoryParameter, new List<int> {0, 1, 2, 3, 4 }, "csgoInventory", db) == 0)
                {
                    InsertIntoTable(csgoInventoryParameter, "csgoInventory", db);
                }

                JsonObject rgInventory = csgoInventory.GetNamedObject("rgInventory");

                for (int i = 0; i < rgInventory.Count; i++)
                {
                    JsonObject rgInventoryElement = rgInventory.GetNamedObject(rgInventory.ElementAt(i).Key);

                    List<(String, Object)> rgInventoryParameter = new List<(String, Object)>
                    {
                        ("id", DBNull.Value),
                        ("rgInventoryId", rgInventoryElement.ContainsKey("id") ? (Object)rgInventoryElement.GetNamedString("id") : (Object)DBNull.Value),
                        ("classid", rgInventoryElement.ContainsKey("classid") ? (Object)rgInventoryElement.GetNamedString("classid") : (Object)DBNull.Value),
                        ("instanceid", rgInventoryElement.ContainsKey("instanceid") ? (Object)rgInventoryElement.GetNamedString("instanceid") : (Object)DBNull.Value),
                        ("amount", rgInventoryElement.ContainsKey("amount") ? (Object)rgInventoryElement.GetNamedString("amount") : (Object)DBNull.Value),
                        ("pos", rgInventoryElement.ContainsKey("pos") ? (Object)rgInventoryElement.GetNamedNumber("pos") : (Object)DBNull.Value),
                        ("csgoInventoryId", csgoInventoryId)
                    };

                    if (GetIdOfDataSet(rgInventoryParameter, new List<int> { 1, 2, 3, 4, 5 }, "rgInventory", db) == 0)
                    {
                        InsertIntoTable(rgInventoryParameter, "rgInventory", db);
                    }
                }

                JsonObject rgDescriptions = csgoInventory.GetNamedObject("rgDescriptions");

                for (int n = 0; n < rgDescriptions.Count; n++)
                {
                    JsonObject rgDescription = rgDescriptions.GetNamedObject(rgDescriptions.ElementAt(n).Key);
                    long rgDescriptonId = 0;

                    List<(String, Object)> rgDescriptionParameter = new List<(String, Object)>
                    {
                        ("id", DBNull.Value),
                        ("appid_instanceid", rgDescriptions.ElementAt(n).Key),
                        ("appid", rgDescription.ContainsKey("appid") ? (Object)rgDescription.GetNamedString("appid") : (Object)DBNull.Value),
                        ("instanceid", rgDescription.ContainsKey("instanceid") ? (Object)rgDescription.GetNamedString("instanceid") : (Object)DBNull.Value),
                        ("icon_url", rgDescription.ContainsKey("icon_url") ? (Object)rgDescription.GetNamedString("icon_url") : (Object)DBNull.Value),
                        ("icon_url_large", rgDescription.ContainsKey("icon_url_large") ? (Object)rgDescription.GetNamedString("icon_url_large") : (Object)DBNull.Value),
                        ("icon_drag_url", rgDescription.ContainsKey("icon_drag_url") ? (Object)rgDescription.GetNamedString("icon_drag_url") : (Object)DBNull.Value),
                        ("name", rgDescription.ContainsKey("name") ? (Object)rgDescription.GetNamedString("name") : (Object)DBNull.Value),
                        ("market_hash_name", rgDescription.ContainsKey("market_hash_name") ? (Object)rgDescription.GetNamedString("market_hash_name") : (Object)DBNull.Value),
                        ("market_name", rgDescription.ContainsKey("market_name") ? (Object)rgDescription.GetNamedString("market_name") : (Object)DBNull.Value),
                        ("name_color", rgDescription.ContainsKey("name_color") ? (Object)rgDescription.GetNamedString("name_color") : (Object)DBNull.Value),
                        ("background_color", rgDescription.ContainsKey("background_color") ? (Object)rgDescription.GetNamedString("background_color") : (Object)DBNull.Value),
                        ("type", rgDescription.ContainsKey("type") ? (Object)rgDescription.GetNamedString("type") : (Object)DBNull.Value),
                        ("tradable", rgDescription.ContainsKey("tradable") ? (Object)rgDescription.GetNamedNumber("tradable") : (Object)DBNull.Value),
                        ("marketable", rgDescription.ContainsKey("marketable") ? (Object)rgDescription.GetNamedNumber("marketable") : (Object)DBNull.Value),
                        ("commodity", rgDescription.ContainsKey("commodity") ? (Object)rgDescription.GetNamedNumber("commodity") : (Object)DBNull.Value),
                        ("market_tradable_restriction", rgDescription.ContainsKey("market_tradable_restriction") ? (Object)rgDescription.GetNamedString("market_tradable_restriction") : (Object)DBNull.Value),
                        ("csgoInventoryId", csgoInventoryId)
                    };

                    rgDescriptonId = GetIdOfDataSet(rgDescriptionParameter, new List<int> { 1, 2 }, "rgDescription", db);

                    if (rgDescriptonId == 0)
                    {
                        rgDescriptonId = InsertIntoTable(rgDescriptionParameter, "rgDescription", db);
                    }

                    if (rgDescription.ContainsKey("descriptions"))
                    {
                        JsonArray descriptions = rgDescription.GetNamedArray("descriptions");

                        for (uint m = 0; m < descriptions.Count; m++)
                        {
                            JsonObject description = descriptions.GetObjectAt(m);
                            long descriptonsId = 0;

                            List<(String, Object)> descriptionParameter = new List<(String, Object)>
                            {
                                ("id", DBNull.Value),
                                ("type", description.ContainsKey("type") ? (Object)description.GetNamedString("type") : (Object)DBNull.Value),
                                ("value", description.ContainsKey("value") ? (Object)description.GetNamedString("value") : (Object)DBNull.Value),
                                ("color", description.ContainsKey("color") ? (Object)description.GetNamedString("color") : (Object)DBNull.Value),
                            };

                            descriptonsId = GetIdOfDataSet(descriptionParameter, new List<int> { 1, 2, 3 }, "descriptions", db);

                            if (descriptonsId == 0)
                            {
                                descriptonsId = InsertIntoTable(descriptionParameter, "descriptions", db);
                            }

                            List<(String, Object)> descriptionsRgDescriptionsParameter = new List<(string, object)>
                            {
                                ("id", DBNull.Value),
                                ("descriptionsId", descriptonsId),
                                ("rgDescriptionId", rgDescriptonId),
                                ("pos", m)
                            };

                            if (GetIdOfDataSet(descriptionsRgDescriptionsParameter, new List<int> { 0, 1, 2 }, "descriptionsRgDescriptionRel", db) == 0)
                            {
                                InsertIntoTable(descriptionsRgDescriptionsParameter, "descriptionsRgDescriptionRel", db);
                            }

                            if (description.ContainsKey("app_data"))
                            {
                                JsonObject appData = description.GetNamedObject("app_data");
                                long app_dataId = 0;

                                List<(String, Object)> appDataParameter = new List<(String, Object)>
                                {
                                    ("id", DBNull.Value),
                                    ("def_index", appData.ContainsKey("def_index") ? (Object)appData.GetNamedString("def_index") : (Object)DBNull.Value),
                                    ("is_itemset_name", appData.ContainsKey("is_itemset_name") ? (Object)appData.GetNamedNumber("is_itemset_name") : (Object)DBNull.Value),
                                    ("limited", appData.ContainsKey("limited") ? (Object)appData.GetNamedNumber("limited") : (Object)DBNull.Value),
                                };

                                app_dataId = GetIdOfDataSet(appDataParameter, new List<int> { 1, 2, 3 }, "app_data", db);

                                if (app_dataId == 0)
                                {
                                    app_dataId = InsertIntoTable(appDataParameter, "app_data", db);
                                }

                                List<(String, Object)> appDataDescriptionsParameter = new List<(String, Object)>
                                {
                                    ("id", DBNull.Value),
                                    ("descriptionsId",descriptonsId),
                                    ("app_dataId", app_dataId)
                                };

                                if (GetIdOfDataSet(appDataDescriptionsParameter, new List<int> { 1, 2 }, "app_dataDescriptionsRel", db) == 0)
                                {
                                    InsertIntoTable(appDataDescriptionsParameter, "app_dataDescriptionsRel", db);
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
                                ("rgDescriptionId", rgDescriptonId)
                            };

                            if (GetIdOfDataSet(actionParameter, new List<int> { 1, 2, 3 }, "actions", db) == 0)
                            {
                                InsertIntoTable(actionParameter, "actions", db);
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
                                ("rgDescriptionId", rgDescriptonId)
                            };

                            if (GetIdOfDataSet(marketActionParameter, new List<int> { 1, 2, 3 }, "market_actions", db) == 0)
                            {
                                InsertIntoTable(marketActionParameter, "market_actions", db);
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
                                ("rgDescriptionId", rgDescriptonId)
                            };

                            if (GetIdOfDataSet(tagParameter, new List<int> { 1, 2, 3 }, "tags", db) == 0)
                            {
                                InsertIntoTable(tagParameter, "tags", db);
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

        private static long GetIdOfLastInsertRow(SqliteConnection db)
        {
            SqliteCommand lastInsertSelectCommand = new SqliteCommand("SELECT last_insert_rowid()", db);

            SqliteDataReader query = lastInsertSelectCommand.ExecuteReader();

            query.Read();

            return (long)query.GetValue(0);
        }

        private static void AddJsonItemToTable(SqliteConnection db, string tableName, IJsonValue jValue)
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

        private static long InsertIntoTable(List<(String, Object)> parameters, string tableName, SqliteConnection connection)
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
            return GetIdOfLastInsertRow(connection);
        }

        private static long GetIdOfDataSet(List<(String, Object)> parameter, List<int> parameterNumbers, string tableName, SqliteConnection connection)
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
                else if (parameter[num].Item2.GetType() == typeof(Double) || parameter[num].Item2.GetType() == typeof(Int64) || parameter[num].Item2.GetType() == typeof(UInt32))
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
                else
                {
                    //todo error Type nicht unterstützt
                }
                index ++;
            }

            selectCommandText += ";";

            SqliteCommand selectCommand = new SqliteCommand(selectCommandText, connection);

            SqliteDataReader query = selectCommand.ExecuteReader();

            if (query.HasRows)
            {
                query.Read();

                return (long)query.GetValue(0);
            }
            else
            {
                return 0;
            }
        }
    }
}
