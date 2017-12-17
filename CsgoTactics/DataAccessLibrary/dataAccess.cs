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
                    "insatnceid	TEXT," +
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
                    "id	INTEGER NOT NULL PRIMARY KEY," +
                    "type	TEXT," +
                    "value	TEXT," +
                    "color	TEXT," +
                    "rgDescriptionId	TEXT," +
                    "FOREIGN KEY(rgDescriptionId) REFERENCES rgDescription(id)" +
                    ");";

                String app_dataTableCommand = "CREATE TABLE IF NOT EXISTS app_data (" +
                    "id	INTEGER NOT NULL PRIMARY KEY," +
                    "def_index	TEXT," +
                    "is_itemset_name	TEXT," +
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
                JsonObject CsgoInventoryJsonObject = new JsonObject();
                try
                {
                    CsgoInventoryJsonObject = JsonObject.Parse(inventoryString);
                }
                catch (Exception)
                {
                    //CsgoInventoryJsonObject = JsonObject.Parse(inventoryString);
                    System.Diagnostics.Debug.Print("inventoryString ungültig");
                    return;
                }

                db.Open();

                List<Object> parameters = new List<Object>
                {
                    csgoInventoryId,
                    CsgoInventoryJsonObject.GetNamedBoolean("success"),
                    CsgoInventoryJsonObject.GetNamedBoolean("more"),
                    CsgoInventoryJsonObject.GetNamedBoolean("more_start"),
                    Steam64Id
                };

                InsertIntoTable(parameters, "csgoInventory", db);


                JsonObject rgInventory = CsgoInventoryJsonObject.GetNamedObject("rgInventory");

                for (int i = 0; i < rgInventory.Count; i++)
                {
                    JsonObject element = rgInventory.GetNamedObject(rgInventory.ElementAt(i).Key);

                    parameters = new List<Object>{
                        element.GetNamedString("id"),
                        element.GetNamedString("classid"),
                        element.GetNamedString("instanceid"),
                        element.GetNamedString("amount"),
                        element.GetNamedNumber("pos"),
                        csgoInventoryId

                        //skin.PriceCol = new ObservableCollection<SteamItem.SteamPrice>();
                        //skin.PriceCol.Add(new SteamItem.SteamPrice());
                        //skin.BuyPrice = new SteamItem.PurchaseData();
                    };

                    InsertIntoTable(parameters, "rgInventory", db);
                }

                JsonObject rgDescriptions = CsgoInventoryJsonObject.GetNamedObject("rgDescriptions");

                for (int n = 0; n < rgDescriptions.Count; n++)
                {
                    JsonObject rgDescription = rgDescriptions.GetNamedObject(rgDescriptions.ElementAt(n).Key);

                    parameters = new List<Object>
                    {
                        rgDescriptions.ElementAt(n).Key,
                        rgDescription.ContainsKey("appid") ? (Object)rgDescription.GetNamedString("appid") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("instanceid") ? (Object)rgDescription.GetNamedString("instanceid") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("icon_url") ? (Object)rgDescription.GetNamedString("icon_url") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("icon_url_large") ? (Object)rgDescription.GetNamedString("icon_url_large") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("icon_drag_url") ? (Object)rgDescription.GetNamedString("icon_drag_url") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("name") ? (Object)rgDescription.GetNamedString("name") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("market_hash_name") ? (Object)rgDescription.GetNamedString("market_hash_name") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("market_name") ? (Object)rgDescription.GetNamedString("market_name") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("name_color") ? (Object)rgDescription.GetNamedString("name_color") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("background_color") ? (Object)rgDescription.GetNamedString("background_color") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("type") ? (Object)rgDescription.GetNamedString("type") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("tradable") ? (Object)rgDescription.GetNamedNumber("tradable") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("marketable") ? (Object)rgDescription.GetNamedNumber("marketable") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("commodity") ? (Object)rgDescription.GetNamedNumber("commodity") : (Object)DBNull.Value,
                        rgDescription.ContainsKey("market_tradable_restriction") ? (Object)rgDescription.GetNamedString("market_tradable_restriction") : (Object)DBNull.Value,
                        csgoInventoryId
                    };

                    InsertIntoTable(parameters, "rgDescription", db);


                    if (rgDescription.ContainsKey("descriptions"))
                    {
                        JsonArray descriptions = rgDescription.GetNamedArray("descriptions");
                        for (uint m = 0; m < descriptions.Count; m++)
                        {
                            JsonObject description = descriptions.GetObjectAt(m);

                            parameters = new List<Object>
                            {
                                description.GetHashCode(),
                                description.ContainsKey("type"),
                                description.ContainsKey("value"),
                                description.ContainsKey("color"),
                                rgDescriptions.ElementAt(n).Key
                            };

                            InsertIntoTable(parameters, "descriptions", db);

                            if (description.ContainsKey("app_data"))
                            {
                                JsonObject appData = description.GetNamedObject("app_data");

                                parameters = new List<Object>
                                {
                                    appData.GetHashCode(),
                                    appData.ContainsKey("def_index") ? (Object)appData.GetNamedString("def_index") : (Object)DBNull.Value,
                                    appData.ContainsKey("is_itemset_name") ? (Object)appData.GetNamedNumber("is_itemset_name") : (Object)DBNull.Value,
                                    description.GetHashCode()
                                };

                                InsertIntoTable(parameters, "app_data", db);
                            }
                        }
                    }

                    if (rgDescription.ContainsKey("actions"))
                    {
                        JsonArray actions = rgDescription.GetNamedArray("actions");
                        for (uint o = 0; o < actions.Count; o++)
                        {
                            JsonObject action = actions.GetObjectAt(o);

                            using (SqliteCommand actionsInsertCommand = new SqliteCommand("INSERT INTO actions VALUES (@id, @name, @link, @rgDescriptionID);", db))
                            {
                                actionsInsertCommand.Parameters.AddWithValue("@id", DBNull.Value);
                                if (action.ContainsKey("name")) { actionsInsertCommand.Parameters.AddWithValue("@name", action.GetNamedString("name")); } else { actionsInsertCommand.Parameters.AddWithValue("@name", DBNull.Value); }
                                if (action.ContainsKey("link")) { actionsInsertCommand.Parameters.AddWithValue("@link", action.GetNamedString("link")); } else { actionsInsertCommand.Parameters.AddWithValue("@link", DBNull.Value); }
                                actionsInsertCommand.Parameters.AddWithValue("@rgDescriptionID", rgDescriptions.ElementAt(n).Key);
                                actionsInsertCommand.ExecuteReader();
                            }
                        }
                    }

                    if (rgDescription.ContainsKey("market_actions"))
                    {
                        JsonArray marketActions = rgDescription.GetNamedArray("market_actions");
                        for (uint o = 0; o < marketActions.Count; o++)
                        {
                            JsonObject marketAction = marketActions.GetObjectAt(o);

                            using (SqliteCommand actionsInsertCommand = new SqliteCommand("INSERT INTO market_actions VALUES (@id, @name, @link, @rgDescriptionID);", db))
                            {
                                actionsInsertCommand.Parameters.AddWithValue("@id", DBNull.Value);
                                if (marketAction.ContainsKey("name")) { actionsInsertCommand.Parameters.AddWithValue("@name", marketAction.GetNamedString("name")); } else { actionsInsertCommand.Parameters.AddWithValue("@name", DBNull.Value); }
                                if (marketAction.ContainsKey("link")) { actionsInsertCommand.Parameters.AddWithValue("@link", marketAction.GetNamedString("link")); } else { actionsInsertCommand.Parameters.AddWithValue("@link", DBNull.Value); }
                                actionsInsertCommand.Parameters.AddWithValue("@rgDescriptionID", rgDescriptions.ElementAt(n).Key);
                                actionsInsertCommand.ExecuteReader();
                            }
                        }
                    }

                    if (rgDescription.ContainsKey("tags"))
                    {
                        JsonArray tags = rgDescription.GetNamedArray("tags");
                        for (uint p = 0; p < tags.Count; p++)
                        {
                            JsonObject tag = tags.GetObjectAt(p);

                            using (SqliteCommand tagsInsertCommand = new SqliteCommand("INSERT INTO tags VALUES (@id, @internal_name, @name, @category, @color, @category_name, @rgDescriptionID);", db))
                            {
                                tagsInsertCommand.Parameters.AddWithValue("@id", DBNull.Value);
                                if (tag.ContainsKey("internal_name")) { tagsInsertCommand.Parameters.AddWithValue("@internal_name", tag.GetNamedString("internal_name")); } else { tagsInsertCommand.Parameters.AddWithValue("@internal_name", DBNull.Value); }
                                if (tag.ContainsKey("name")) { tagsInsertCommand.Parameters.AddWithValue("@name", tag.GetNamedString("name")); } else { tagsInsertCommand.Parameters.AddWithValue("@name", DBNull.Value); }
                                if (tag.ContainsKey("category")) { tagsInsertCommand.Parameters.AddWithValue("@category", tag.GetNamedString("category")); } else { tagsInsertCommand.Parameters.AddWithValue("@category", DBNull.Value); }
                                if (tag.ContainsKey("color")) { tagsInsertCommand.Parameters.AddWithValue("@color", tag.GetNamedString("color")); } else { tagsInsertCommand.Parameters.AddWithValue("@color", DBNull.Value); }
                                if (tag.ContainsKey("category_name")) { tagsInsertCommand.Parameters.AddWithValue("@category_name", tag.GetNamedString("category_name")); } else { tagsInsertCommand.Parameters.AddWithValue("@category_name", DBNull.Value); }
                                tagsInsertCommand.Parameters.AddWithValue("@rgDescriptionID", rgDescriptions.ElementAt(n).Key);
                                tagsInsertCommand.ExecuteReader();
                            }
                        }
                    }
                }
                JsonArray rgCurrency = CsgoInventoryJsonObject.GetNamedArray("rgCurrency");

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

        private static void InsertIntoTable(List<Object> parameters, string tableName, SqliteConnection connection)
        {
            string commandString = "INSERT OR IGNORE INTO " + tableName + " VALUES (";
            int parameterNumber = 0;
            string parameterName = "";

            using (SqliteCommand command = new SqliteCommand())
            {
                foreach (Object parameter in parameters)
                {
                    parameterNumber++;
                    parameterName = "@param" + parameterNumber;
                    commandString = commandString + parameterName + ", ";
                    command.Parameters.AddWithValue(parameterName, parameter);
                }
                commandString = commandString.Remove(commandString.Length - 2);
                commandString = commandString + ");";
                command.CommandText = commandString;
                command.Connection = connection;
                command.ExecuteReader();
            }
        }
    } 
}
