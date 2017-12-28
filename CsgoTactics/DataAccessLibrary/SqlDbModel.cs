using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccessLibrary
{
    public static class SqlDbModel
    {
        public static string DbConnectionString
        {
            //get { return "Filename=steamInventory.db"; }
            get { return "Filename=steamInventoryLinqTest.db"; }
        }

        public static List<List<List<String>>> TableDataList
        {
            get
            {
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
                        new List<String>{ "csgoInventoryItemId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
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
                        new List<String>{ "rgInventoryItemId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "id", "INTEGER", "NOT NULL" },
                        new List<String>{ "classid", "INTEGER", "NOT NULL" },
                        new List<String>{ "instanceid", "TEXT", " NOT NULL" },
                        new List<String>{ "amount", "TEXT" },
                        new List<String>{ "pos", "TEXT" },
                        new List<String>{ "csgoInventoryItemId", "INTEGER" },
                        new List<String>{ "FOREIGN KEY", "(csgoInventoryItemId)", "REFERENCES", "csgoInventory(csgoInventoryItemId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "rgCurrency" },
                        new List<String>{ "rgCurrencyItemId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "csgoInventoryItemId", "INTEGER", " NOT NULL" },
                        new List<String>{ "FOREIGN KEY", "(csgoInventoryItemId)", "REFERENCES", "csgoInventory(csgoInventoryItemId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "rgDescriptions" },
                        new List<String>{ "rgDescriptionsItemId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "appid", "TEXT" },
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
                        new List<String>{ "csgoInventoryItemId", "INTEGER", " NOT NULL" },
                        new List<String>{ "FOREIGN KEY", "(csgoInventoryItemId)", "REFERENCES", "csgoInventory(csgoInventoryItemId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "descriptions" },
                        new List<String>{ "descriptionsItemId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "type", "TEXT" },
                        new List<String>{ "value", "TEXT" },
                        new List<String>{ "color", "TEXT" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "app_data" },
                        new List<String>{ "app_dataItemId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "def_index", "TEXT" },
                        new List<String>{ "is_itemset_name", "REAL" },
                        new List<String>{ "limited", "INTEGER" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "actions" },
                        new List<String>{ "actionsItemId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "name", "TEXT" },
                        new List<String>{ "link", "TEXT" },
                        new List<String>{ "rgDescriptionsItemId", "INTEGER" },
                        new List<String>{ "FOREIGN KEY", "(rgDescriptionsItemId)", "REFERENCES", "rgDescriptions(rgDescriptionsItemId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "market_actions" },
                        new List<String>{ "market_actionsItemId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "name", "TEXT" },
                        new List<String>{ "link", "TEXT" },
                        new List<String>{ "rgDescriptionsItemId", "INTEGER" },
                        new List<String>{ "FOREIGN KEY", "(rgDescriptionsItemId)", "REFERENCES", "rgDescriptions(rgDescriptionsItemId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "tags" },
                        new List<String>{ "tagsItemId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "internal_name", "TEXT" },
                        new List<String>{ "name", "TEXT" },
                        new List<String>{ "category", "TEXT" },
                        new List<String>{ "color", "TEXT" },
                        new List<String>{ "category_name", "TEXT" },
                        new List<String>{ "rgDescriptionsItemId", "INTEGER" },
                        new List<String>{ "FOREIGN KEY", "(rgDescriptionsItemId)", "REFERENCES", "rgDescriptions(rgDescriptionsItemId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "priceData" },
                        new List<String>{ "priceDataItemId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "purchaseDate", "TEXT" },
                        new List<String>{ "purchasePrice", "TEXT" },
                        new List<String>{ "rgDescriptionsItemId", "INTEGER" },
                        new List<String>{ "FOREIGN KEY", "(rgDescriptionsItemId)", "REFERENCES", "rgDescriptions(rgDescriptionsItemId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "priceCollection" },
                        new List<String>{ "priceCollectionItemId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "date", "TEXT" },
                        new List<String>{ "price", "TEXT" },
                        new List<String>{ "priceDataItemId", "INTEGER" },
                        new List<String>{ "FOREIGN KEY", "(priceDataItemId)", "REFERENCES", "priceData(priceDataItemId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "app_dataDescriptionsRgDescriptionsRel" },
                        new List<String>{ "app_dataDescriptionsRgDescriptionsRelId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "descriptionsItemId", "INTEGER" },
                        new List<String>{ "rgDescriptionsItemId", "INTEGER" },
                        new List<String>{ "app_dataItemId", "INTEGER" },
                        new List<String>{ "UNIQUE", "( descriptionsItemId, rgDescriptionsItemId, app_dataItemId )" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "descriptionsRgDescriptionsRel" },
                        new List<String>{ "descriptionsRgDescriptionsRelId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "descriptionsItemId", "INTEGER" },
                        new List<String>{ "rgDescriptionsItemId", "INTEGER", "NOT NULL" },
                        new List<String>{ "pos", "INTEGER", "NOT NULL" },
                        new List<String>{ "UNIQUE", "( descriptionsItemId, rgDescriptionsItemId, pos )" }
                    }
                };
            }
        }
    }
}

