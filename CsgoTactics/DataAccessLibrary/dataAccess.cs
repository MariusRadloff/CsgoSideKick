﻿using System;
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

        private static List<List<List<String>>> tableDataList;

        public static List<List<List<String>>> TableDataList
        {
            get {
                return new List<List<List<String>>>
                {
                    new List<List<String>>
                    {
                        new List<String>{ "steamInventory" },
                        new List<String>{ "steamInventoryId",  "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "userId", "TEXT", "NOT NULL" },
                        new List<String>{ "username", "TEXT", "NOT NULL" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "csgoInventory" },
                        new List<String>{ "csgoInventoryId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "gameId", "TEXT", " NOT NULL" },
                        new List<String>{ "success", "TEXT" },
                        new List<String>{ "more", "TEXT" },
                        new List<String>{ "more_start", "TEXT" },
                        new List<String>{ "steamInventoryId", "INTEGER" },
                        new List<String>{ "FOREIGN KEY", "(steamInventoryId)", "REFERENCES", "steamInventory(steamInventoryId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "rgInventory" },
                        new List<String>{ "rgInventoryId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "id", "INTEGER", "NOT NULL" },
                        new List<String>{ "classid", "INTEGER", "NOT NULL" },
                        new List<String>{ "instanceid", "TEXT", " NOT NULL" },
                        new List<String>{ "amount", "TEXT" },
                        new List<String>{ "pos", "TEXT" },
                        new List<String>{ "csgoInventoryId", "INTEGER" },
                        new List<String>{ "FOREIGN KEY", "(csgoInventoryId)", "REFERENCES", "csgoInventory(csgoInventoryId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "rgCurrency" },
                        new List<String>{ "rgCurrencyId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "csgoInventoryId", "INTEGER", " NOT NULL" },
                        new List<String>{ "FOREIGN KEY", "(csgoInventoryId)", "REFERENCES", "csgoInventory(csgoInventoryId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "rgDescriptions" },
                        new List<String>{ "rgDescriptionsId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "appId", "TEXT" },
                        new List<String>{ "classid", "TEXT" },
                        new List<String>{ "instanceid", "TEXT" },
                        new List<String>{ "icon_url", "TEXT" },
                        new List<String>{ "icon_url_large", "TEXT" },
                        new List<String>{ "icon_drag_url", "TEXT" },
                        new List<String>{ "name", "TEXT" },
                        new List<String>{ "market_hash_name", "TEXT" },
                        new List<String>{ "market_name", "TEXT" },
                        new List<String>{ "name_color", "TEXT" },
                        new List<String>{ "background_color", "TEXT" },
                        new List<String>{ "type", "TEXT" },
                        new List<String>{ "tradable", "NUMBER" },
                        new List<String>{ "marketable", "NUMBER" },
                        new List<String>{ "commodity", "NUMBER" },
                        new List<String>{ "market_tradable_restriction", "TEXT" },
                        new List<String>{ "csgoInventoryId", "INTEGER", " NOT NULL" },
                        new List<String>{ "FOREIGN KEY", "(csgoInventoryId)", "REFERENCES", "csgoInventory(csgoInventoryId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "descriptions" },
                        new List<String>{ "descriptionsId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "type", "TEXT" },
                        new List<String>{ "value", "TEXT" },
                        new List<String>{ "color", "TEXT" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "app_data" },
                        new List<String>{ "app_dataId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "def_index", "TEXT" },
                        new List<String>{ "is_itemset_name", "REAL" },
                        new List<String>{ "limited", "INTEGER" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "actions" },
                        new List<String>{ "actionsId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "name", "TEXT" },
                        new List<String>{ "link", "TEXT" },
                        new List<String>{ "rgDescriptionsId", "INTEGER" },
                        new List<String>{ "FOREIGN KEY", "(rgDescriptionsId)", "REFERENCES", "rgDescription(rgDescriptionsId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "market_actions" },
                        new List<String>{ "market_actionsId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "name", "TEXT" },
                        new List<String>{ "link", "TEXT" },
                        new List<String>{ "rgDescriptionsId", "INTEGER" },
                        new List<String>{ "FOREIGN KEY", "(rgDescriptionsId)", "REFERENCES", "rgDescription(rgDescriptionsId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "tags" },
                        new List<String>{ "tagsId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "internal_name", "TEXT" },
                        new List<String>{ "name", "TEXT" },
                        new List<String>{ "category", "TEXT" },
                        new List<String>{ "color", "TEXT" },
                        new List<String>{ "category_name", "TEXT" },
                        new List<String>{ "rgDescriptionsId", "INTEGER" },
                        new List<String>{ "FOREIGN KEY", "(rgDescriptionsId)", "REFERENCES", "rgDescription(rgDescriptionsId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "priceData" },
                        new List<String>{ "priceDataId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "purchaseDate", "TEXT" },
                        new List<String>{ "purchasePrice", "TEXT" },
                        new List<String>{ "rgDescriptionsId", "INTEGER" },
                        new List<String>{ "FOREIGN KEY", "(rgDescriptionsId)", "REFERENCES", "rgDescription(rgDescriptionsId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "priceCollection" },
                        new List<String>{ "priceCollectionId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "date", "TEXT" },
                        new List<String>{ "price", "TEXT" },
                        new List<String>{ "priceDataId", "INTEGER" },
                        new List<String>{ "FOREIGN KEY", "(priceDataId)", "REFERENCES", "priceData(priceDataId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "app_dataDescriptionsRgDescriptionsRel" },
                        new List<String>{ "app_dataDescriptionsRgDescriptionsRelId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "descriptionsId", "INTEGER" },
                        new List<String>{ "rgDescriptionsId", "INTEGER" },
                        new List<String>{ "app_dataId", "INTEGER" },
                        new List<String>{ "UNIQUE", "( descriptionsId, rgDescriptionsId )" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "descriptionsRgDescriptionsRel" },
                        new List<String>{ "descriptionsRgDescriptionsRelId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "descriptionsId", "INTEGER" },
                        new List<String>{ "rgDescriptionsId", "INTEGER", "NOT NULL" },
                        new List<String>{ "pos", "INTEGER", "NOT NULL" },
                        new List<String>{ "UNIQUE", "( descriptionsId, rgDescriptionsId )" }
                    }
                };
            }
        }

        public static void CreateTables()
        {
            using (SqliteConnection db = new SqliteConnection(DbConnectionString))
            {
                db.Open();
                string createTableCommandString;

                foreach (List<List<String>> tableData in TableDataList)
                {
                    int stringNumber = 0;
                    createTableCommandString = "CREATE TABLE IF NOT EXISTS " + tableData[0][0] + " ( ";
                    foreach (List<String> tableDataStrings in tableData)
                    {
                        foreach (String tableDataString in tableDataStrings)
                        {
                            if (stringNumber != 0)
                            {
                                createTableCommandString += tableDataString + " ";
                            }
                        }
                        if (stringNumber != 0)
                        {
                            createTableCommandString += ", ";
                        }
                        stringNumber++;
                    }
                    createTableCommandString = createTableCommandString.Remove(createTableCommandString.Length - 2);
                    createTableCommandString += ");";

                    SqliteCommand createTableCommand = new SqliteCommand(createTableCommandString, db);
                    createTableCommand.ExecuteReader();
                }
                db.Close();
            }
        }


        public static void CreateTablesOld()
        {
            using (SqliteConnection db = new SqliteConnection(DbConnectionString))
            {
                #region TableCommands
                String steamInventoryTableCommand = "CREATE TABLE IF NOT EXISTS steamInventory (" +
                    "steamInventoryId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "userId	TEXT NOT NULL," +
                    "username	TEXT NOT NULL" +
                    ");";

                String csgoInventoryTableCommand = "CREATE TABLE IF NOT EXISTS csgoInventory (" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "gameId	TEXT NOT NULL," +
                    "success    TEXT," +
                    "more	TEXT," +
                    "more_start	TEXT," +
                    "steamInventoryId	INTEGER," +
                    "FOREIGN KEY(steamInventoryId) REFERENCES steamInventory(id)" +
                    ");";

                String rgInventoryTableCommand = "CREATE TABLE IF NOT EXISTS rgInventory (" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "rgInventoryId	TEXT NOT NULL," +
                    "classid	TEXT," +
                    "instanceid	TEXT," +
                    "amount	TEXT," +
                    "pos	TEXT," +
                    "csgoInventoryId	INTEGER," +
                    "FOREIGN KEY(csgoInventoryId) REFERENCES csgoInventory(id)" +
                    ");";

                String rgCurrencyTableCommand = "CREATE TABLE IF NOT EXISTS rgCurrency (" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "rgCurrencyId	TEXT NOT NULL," +
                    "csgoInventoryId	INTEGER," +
                    "FOREIGN KEY(csgoInventoryId) REFERENCES csgoInventory(id)" +
                    ");";

                String rgDescriptionTableCommand = "CREATE TABLE IF NOT EXISTS rgDescription (" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "appid_instanceid	TEXT NOT NULL," +
                    "appid	TEXT," +
                    "classid TEXT," +
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
                    "csgoInventoryId	INTEGER," +
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
                    "rgDescriptionId	INTEGER," +
                    "FOREIGN KEY(rgDescriptionId) REFERENCES rgDescription(id)" +
                    ");";

                String market_actionsTableCommand = "CREATE TABLE IF NOT EXISTS market_actions (" +
                    "id	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "name	TEXT," +
                    "link	TEXT," +
                    "rgDescriptionId	INTEGER," +
                    "FOREIGN KEY(rgDescriptionId) REFERENCES rgDescription(id)" +
                    ");";

                String tagsTableCommand = "CREATE TABLE IF NOT EXISTS tags (" +
                    "id	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "internal_name	TEXT," +
                    "name	TEXT," +
                    "category	TEXT," +
                    "color	TEXT," +
                    "category_name	TEXT," +
                    "rgDescriptionId	INTEGER," +
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
                    "priceDataId INTEGER," +
                    "FOREIGN KEY(priceDataId) REFERENCES priceData(id)" +
                    ");";

                String app_dataDescriptionsRgDescriptionRelTableCommand = "CREATE TABLE IF NOT EXISTS app_dataDescriptionsRgDescriptionRel(" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "descriptionsId INTEGER NOT NULL," +
                    "rgDescriptionId INTEGER NOT NULL," +
                    "app_dataId INTEGER NOT NULL," +
                    "UNIQUE ( descriptionsId, rgDescriptionId )" +
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
                SqliteCommand createApp_dataDescriptionsRelTable = new SqliteCommand(app_dataDescriptionsRgDescriptionRelTableCommand, db);
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

        public static void DeleteTables()
        {
            using (SqliteConnection db = new SqliteConnection(DbConnectionString))
            {
                db.Open();
                foreach (List<List<String>> tableData in TableDataList)
                {
                    string deleteTableCommandString = "DELETE FROM " + tableData[0][0];
                    SqliteCommand deleteTableCommand = new SqliteCommand(deleteTableCommandString, db);
                    deleteTableCommand.ExecuteReader();
                }
                db.Close();
            }
        }

        public static void DropTables()
        {
            using (SqliteConnection db = new SqliteConnection(DbConnectionString))
            {
                db.Open();
                foreach (List<List<String>> tableData in TableDataList)
                {
                    string deleteTableCommandString = "DROP TABLE " + tableData[0][0];
                    SqliteCommand deleteTableCommand = new SqliteCommand(deleteTableCommandString, db);
                    deleteTableCommand.ExecuteReader();
                }
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

        public static void AddGameInventory(string inventoryString, string Steam64Id, string csgoInventoryId)
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

                List<List<String>> TableData = TableDataList.Where(tdl => tdl[0][0] == "csgoInventory").First();

                List <(String, Object)> csgoInventoryParameter = new List<(String, Object)>
                {
                    (TableData.ElementAt(1).First(), DBNull.Value),
                    (TableData.ElementAt(2).First(), csgoInventoryId),
                    (TableData.ElementAt(3).First(), csgoInventory.ContainsKey(TableData.ElementAt(3).First()) ? (Object)csgoInventory.GetNamedBoolean(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
                    (TableData.ElementAt(4).First(), csgoInventory.ContainsKey(TableData.ElementAt(4).First()) ? (Object)csgoInventory.GetNamedBoolean(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
                    (TableData.ElementAt(5).First(), csgoInventory.ContainsKey(TableData.ElementAt(5).First()) ? (Object)csgoInventory.GetNamedBoolean(TableData.ElementAt(5).First()) : (Object)DBNull.Value),
                    (TableData.ElementAt(6).First(), Steam64Id)
                };

                if (GetIdOfDataSet(csgoInventoryParameter, new List<int> {0, 1, 2, 3, 4 }, TableData.ElementAt(0).First(), db) == 0)
                {
                    InsertIntoTable(csgoInventoryParameter, TableData.ElementAt(0).First(), db);
                }

                JsonObject rgInventory = csgoInventory.GetNamedObject("rgInventory");

                for (int i = 0; i < rgInventory.Count; i++)
                {
                    JsonObject rgInventoryElement = rgInventory.GetNamedObject(rgInventory.ElementAt(i).Key);

                    TableData = TableDataList.Where(tdl => tdl[0][0] == "rgInventory").First();

                    List<(String, Object)> rgInventoryParameter = new List<(String, Object)>
                    {
                        (TableData.ElementAt(1).First(), DBNull.Value),
                        (TableData.ElementAt(2).First(), rgInventoryElement.ContainsKey(TableData.ElementAt(2).First()) ? (Object)rgInventoryElement.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(3).First(), rgInventoryElement.ContainsKey(TableData.ElementAt(3).First()) ? (Object)rgInventoryElement.GetNamedString(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(4).First(), rgInventoryElement.ContainsKey(TableData.ElementAt(4).First()) ? (Object)rgInventoryElement.GetNamedString(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(5).First(), rgInventoryElement.ContainsKey(TableData.ElementAt(5).First()) ? (Object)rgInventoryElement.GetNamedString(TableData.ElementAt(5).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(6).First(), rgInventoryElement.ContainsKey(TableData.ElementAt(6).First()) ? (Object)rgInventoryElement.GetNamedNumber(TableData.ElementAt(6).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(7).First(), csgoInventoryId)
                    };

                    if (GetIdOfDataSet(rgInventoryParameter, new List<int> { 1, 2, 3, 4, 5 }, TableData.ElementAt(0).First(), db) == 0)
                    {
                        InsertIntoTable(rgInventoryParameter, TableData.ElementAt(0).First(), db);
                    }
                }

                JsonObject rgDescriptions = csgoInventory.GetNamedObject("rgDescriptions");

                for (int n = 0; n < rgDescriptions.Count; n++)
                {
                    JsonObject rgDescription = rgDescriptions.GetNamedObject(rgDescriptions.ElementAt(n).Key);
                    long rgDescriptonsId = 0;

                    TableData = TableDataList.Where(tdl => tdl[0][0] == "rgDescriptions").First();

                    List<(String, Object)> rgDescriptionParameter = new List<(String, Object)>
                    {
                        (TableData.ElementAt(1).First(), DBNull.Value),
                        (TableData.ElementAt(2).First(), rgDescription.ContainsKey(TableData.ElementAt(2).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(3).First(), rgDescription.ContainsKey(TableData.ElementAt(3).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(4).First(), rgDescription.ContainsKey(TableData.ElementAt(4).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(5).First(), rgDescription.ContainsKey(TableData.ElementAt(5).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(5).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(6).First(), rgDescription.ContainsKey(TableData.ElementAt(6).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(6).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(7).First(), rgDescription.ContainsKey(TableData.ElementAt(7).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(7).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(8).First(), rgDescription.ContainsKey(TableData.ElementAt(8).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(8).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(9).First(), rgDescription.ContainsKey(TableData.ElementAt(9).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(9).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(10).First(), rgDescription.ContainsKey(TableData.ElementAt(10).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(10).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(11).First(), rgDescription.ContainsKey(TableData.ElementAt(11).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(11).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(12).First(), rgDescription.ContainsKey(TableData.ElementAt(12).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(12).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(13).First(), rgDescription.ContainsKey(TableData.ElementAt(13).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(13).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(14).First(), rgDescription.ContainsKey(TableData.ElementAt(14).First()) ? (Object)rgDescription.GetNamedNumber(TableData.ElementAt(14).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(15).First(), rgDescription.ContainsKey(TableData.ElementAt(15).First()) ? (Object)rgDescription.GetNamedNumber(TableData.ElementAt(15).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(16).First(), rgDescription.ContainsKey(TableData.ElementAt(16).First()) ? (Object)rgDescription.GetNamedNumber(TableData.ElementAt(16).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(17).First(), rgDescription.ContainsKey(TableData.ElementAt(17).First()) ? (Object)rgDescription.GetNamedString(TableData.ElementAt(17).First()) : (Object)DBNull.Value),
                        (TableData.ElementAt(18).First(), csgoInventoryId)
                    };

                    rgDescriptonsId = GetIdOfDataSet(rgDescriptionParameter, new List<int> { 1, 2 }, TableData.ElementAt(0).First(), db);

                    if (rgDescriptonsId == 0)
                    {
                        rgDescriptonsId = InsertIntoTable(rgDescriptionParameter, TableData.ElementAt(0).First(), db);
                    }

                    if (rgDescription.ContainsKey("descriptions"))
                    {
                        JsonArray descriptions = rgDescription.GetNamedArray("descriptions");

                        for (uint m = 0; m < descriptions.Count; m++)
                        {
                            JsonObject description = descriptions.GetObjectAt(m);
                            long descriptonsId = 0;

                            TableData = TableDataList.Where(tdl => tdl[0][0] == "descriptions").First();

                            List<(String, Object)> descriptionParameter = new List<(String, Object)>
                            {
                                (TableData.ElementAt(1).First(), DBNull.Value),
                                (TableData.ElementAt(2).First(), description.ContainsKey(TableData.ElementAt(2).First()) ? (Object)description.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
                                (TableData.ElementAt(3).First(), description.ContainsKey(TableData.ElementAt(3).First()) ? (Object)description.GetNamedString(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
                                (TableData.ElementAt(4).First(), description.ContainsKey(TableData.ElementAt(4).First()) ? (Object)description.GetNamedString(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
                            };

                            descriptonsId = GetIdOfDataSet(descriptionParameter, new List<int> { 1, 2, 3 }, TableData.ElementAt(0).First(), db);

                            if (descriptonsId == 0)
                            {
                                descriptonsId = InsertIntoTable(descriptionParameter, TableData.ElementAt(0).First(), db);
                            }

                            TableData = TableDataList.Where(tdl => tdl[0][0] == "descriptionsRgDescriptionsRel").First();

                            List<(String, Object)> descriptionsRgDescriptionsParameter = new List<(string, object)>
                            {
                                (TableData.ElementAt(1).First(), DBNull.Value),
                                (TableData.ElementAt(2).First(), descriptonsId),
                                (TableData.ElementAt(3).First(), rgDescriptonsId),
                                (TableData.ElementAt(4).First(), m)
                            };

                            if (GetIdOfDataSet(descriptionsRgDescriptionsParameter, new List<int> { 0, 1, 2 }, TableData.ElementAt(0).First(), db) == 0)
                            {
                                InsertIntoTable(descriptionsRgDescriptionsParameter, TableData.ElementAt(0).First(), db);
                            }

                            if (description.ContainsKey("app_data"))
                            {
                                JsonObject appData = description.GetNamedObject("app_data");
                                long app_dataId = 0;

                                TableData = TableDataList.Where(tdl => tdl[0][0] == "app_data").First();

                                List<(String, Object)> appDataParameter = new List<(String, Object)>
                                {
                                    (TableData.ElementAt(1).First(), DBNull.Value),
                                    (TableData.ElementAt(2).First(), appData.ContainsKey(TableData.ElementAt(2).First()) ? (Object)appData.GetNamedString(TableData.ElementAt(2).First()) : (Object)DBNull.Value),
                                    (TableData.ElementAt(3).First(), appData.ContainsKey(TableData.ElementAt(3).First()) ? (Object)appData.GetNamedNumber(TableData.ElementAt(3).First()) : (Object)DBNull.Value),
                                    (TableData.ElementAt(4).First(), appData.ContainsKey(TableData.ElementAt(4).First()) ? (Object)appData.GetNamedNumber(TableData.ElementAt(4).First()) : (Object)DBNull.Value),
                                };

                                app_dataId = GetIdOfDataSet(appDataParameter, new List<int> { 1, 2, 3 }, TableData.ElementAt(0).First(), db);

                                if (app_dataId == 0)
                                {
                                    app_dataId = InsertIntoTable(appDataParameter, TableData.ElementAt(0).First(), db);
                                }

                                List<(String, Object)> appDataDescriptionsRgDescriptionParameter = new List<(String, Object)>
                                {
                                    ("id", DBNull.Value),
                                    ("descriptionsId",descriptonsId),
                                    ("rgDescriptionsId", rgDescriptonsId),
                                    ("app_dataId", app_dataId)
                                };

                                if (GetIdOfDataSet(appDataDescriptionsRgDescriptionParameter, new List<int> { 1, 2 }, "app_dataDescriptionsRgDescriptionsRel", db) == 0)
                                {
                                    InsertIntoTable(appDataDescriptionsRgDescriptionParameter, "app_dataDescriptionsRgDescriptionsRel", db);
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
                                ("rgDescriptionsId", rgDescriptonsId)
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
                                ("rgDescriptionsId", rgDescriptonsId)
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
                                ("rgDescriptionsId", rgDescriptonsId)
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
                insertCommandString += ");";
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
