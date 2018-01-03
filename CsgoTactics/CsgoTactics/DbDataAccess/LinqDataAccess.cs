using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using DbModel;

namespace CsgoTactics.DbDataAccess
{
    public static class LinqDataAccess
    {
        public static void InsertLINQ()
        {
            using (var db = new InventoryDbContext())
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

                csgoInventoryItem currentCsgoInventoryItem = InsertCsgoInventoryItem(db, csgoInventory, csgoInventoryId);

                db.SaveChanges();

                int currentCsgoInventoryItemId = db.csgoInventory.Where(x => x.gameId == currentCsgoInventoryItem.gameId).FirstOrDefault().csgoInventoryItemId;


                JsonObject rgInventory = csgoInventory.GetNamedObject("rgInventory");

                for (int i = 0; i < rgInventory.Count; i++)
                {
                    JsonObject rgInventoryElement = rgInventory.GetNamedObject(rgInventory.ElementAt(i).Key);

                    InsertRgInventoryItem(db, rgInventoryElement, currentCsgoInventoryItemId);
                }

                JsonObject rgDescriptions = csgoInventory.GetNamedObject("rgDescriptions");

                for (int n = 0; n < rgDescriptions.Count; n++)
                {
                    JsonObject rgDescriptionsElement = rgDescriptions.GetNamedObject(rgDescriptions.ElementAt(n).Key);

                    rgDescriptionsItem currentRgDescriptionsItem = InsertRgDescriptionsItem(db, rgDescriptionsElement, currentCsgoInventoryItemId);
                }
                //JsonArray rgCurrency = csgoInventory.GetNamedArray("rgCurrency");

                db.SaveChanges();
            }
        }

        private static List<actionsItem> GetActionsList(InventoryDbContext db, JsonObject rgDescription)
        {
            List<actionsItem> actionsList = new List<actionsItem>();

            if (rgDescription.ContainsKey("actions"))
            {
                JsonArray actions = rgDescription.GetNamedArray("actions");

                for (uint o = 0; o < actions.Count; o++)
                {
                    JsonObject action = actions.GetObjectAt(o);

                    List<List<String>> TableData = DbModelStrings.TableDataList.Where(tdl => tdl[0][0] == "actions").First();

                    actionsItem currentActionsItem = new actionsItem
                    {
                        name = action.ContainsKey(TableData.ElementAt(2).First()) ? action.GetNamedString(TableData.ElementAt(2).First()) : "",
                        link = action.ContainsKey(TableData.ElementAt(3).First()) ? action.GetNamedString(TableData.ElementAt(3).First()) : "",
                        //rgDescriptionsItemId = currentRgDescriptionsItemId
                    };

                    if (db.actions.Any(x => x.name == currentActionsItem.name && x.link == currentActionsItem.link))
                    {
                        actionsList.Add(db.actions.Where<actionsItem>(x => x.name == currentActionsItem.name && x.link == currentActionsItem.link).First());
                    }
                    else if (db.actions.Local.Any(x => x.name == currentActionsItem.name && x.link == currentActionsItem.link))
                    {
                        actionsList.Add(db.actions.Local.Where<actionsItem>(x => x.name == currentActionsItem.name && x.link == currentActionsItem.link).First());
                    }
                    else
                    {
                        actionsList.Add(currentActionsItem);
                    }
                }
            }
            return actionsList;
        }

        private static List<market_actionsItem> GetMarket_actionsList(InventoryDbContext db, JsonObject rgDescription)
        {
            List<market_actionsItem> market_actionsList = new List<market_actionsItem>();

            if (rgDescription.ContainsKey("market_actions"))
            {
                JsonArray marketActions = rgDescription.GetNamedArray("market_actions");

                for (uint o = 0; o < marketActions.Count; o++)
                {
                    JsonObject marketAction = marketActions.GetObjectAt(o);

                    List<List<String>> TableData = DbModelStrings.TableDataList.Where(tdl => tdl[0][0] == "market_actions").First();

                    market_actionsItem currentMarket_ActionsItem = new market_actionsItem
                    {
                        name = marketAction.ContainsKey(TableData.ElementAt(2).First()) ? marketAction.GetNamedString(TableData.ElementAt(2).First()) : "",
                        link = marketAction.ContainsKey(TableData.ElementAt(3).First()) ? marketAction.GetNamedString(TableData.ElementAt(3).First()) : "",
                    };
                    market_actionsList.Add(currentMarket_ActionsItem);

                    if (db.market_actions.Any(x => x.name == currentMarket_ActionsItem.name && x.link == currentMarket_ActionsItem.link))
                    {
                        market_actionsList.Add(db.market_actions.Where<market_actionsItem>(x => x.name == currentMarket_ActionsItem.name && x.link == currentMarket_ActionsItem.link).First());
                    }
                    else if (db.market_actions.Local.Any(x => x.name == currentMarket_ActionsItem.name && x.link == currentMarket_ActionsItem.link))
                    {
                        market_actionsList.Add(db.market_actions.Local.Where<market_actionsItem>(x => x.name == currentMarket_ActionsItem.name && x.link == currentMarket_ActionsItem.link).First());
                    }
                    else
                    {
                        db.market_actions.Add(currentMarket_ActionsItem);
                    }
                }
            }
            return market_actionsList;
        }

        private static List<tagsItem> GetTagsList(InventoryDbContext db, JsonObject rgDescription)
        {
            List<tagsItem> TagsList = new List<tagsItem>();

            if (rgDescription.ContainsKey("tags"))
            {
                JsonArray tags = rgDescription.GetNamedArray("tags");

                for (uint p = 0; p < tags.Count; p++)
                {
                    JsonObject tag = tags.GetObjectAt(p);

                    List<List<String>> TableData = DbModelStrings.TableDataList.Where(tdl => tdl[0][0] == "tags").First();

                    tagsItem currentTagsItem = new tagsItem
                    {
                        internal_name = tag.ContainsKey(TableData.ElementAt(2).First()) ? tag.GetNamedString(TableData.ElementAt(2).First()) : "",
                        name = tag.ContainsKey(TableData.ElementAt(3).First()) ? tag.GetNamedString(TableData.ElementAt(3).First()) : "",
                        category = tag.ContainsKey(TableData.ElementAt(4).First()) ? tag.GetNamedString(TableData.ElementAt(4).First()) : "",
                        color = tag.ContainsKey(TableData.ElementAt(5).First()) ? tag.GetNamedString(TableData.ElementAt(5).First()) : "",
                        category_name = tag.ContainsKey(TableData.ElementAt(6).First()) ? tag.GetNamedString(TableData.ElementAt(6).First()) : "",
                    };

                    if (db.tags.Any(x => x.internal_name == currentTagsItem.internal_name && x.name == currentTagsItem.name && x.category == currentTagsItem.category && x.color == currentTagsItem.color && x.category_name == currentTagsItem.category_name && x.rgDescriptionsItemId == currentTagsItem.rgDescriptionsItemId))
                    {
                        TagsList.Add(db.tags.Where<tagsItem>(x => x.internal_name == currentTagsItem.internal_name && x.name == currentTagsItem.name && x.category == currentTagsItem.category && x.color == currentTagsItem.color && x.category_name == currentTagsItem.category_name && x.rgDescriptionsItemId == currentTagsItem.rgDescriptionsItemId).First());
                    }
                    else if (db.tags.Local.Any(x => x.internal_name == currentTagsItem.internal_name && x.name == currentTagsItem.name && x.category == currentTagsItem.category && x.color == currentTagsItem.color && x.category_name == currentTagsItem.category_name && x.rgDescriptionsItemId == currentTagsItem.rgDescriptionsItemId))

                    {
                        TagsList.Add(db.tags.Local.Where<tagsItem>(x => x.internal_name == currentTagsItem.internal_name && x.name == currentTagsItem.name && x.category == currentTagsItem.category && x.color == currentTagsItem.color && x.category_name == currentTagsItem.category_name && x.rgDescriptionsItemId == currentTagsItem.rgDescriptionsItemId).First());
                    }
                    else
                    {
                        TagsList.Add(currentTagsItem);
                    }

                }
            }
            return TagsList;
        }

        private static List<descriptionsRgDescriptionsItem> GetDescriptionsRgDescriptionsList(InventoryDbContext db, JsonObject rgDescription, rgDescriptionsItem currentRgDescriptionsItem)
        {
            List<descriptionsRgDescriptionsItem> descriptionsRgDescriptionsList = new List<descriptionsRgDescriptionsItem>();

            if (rgDescription.ContainsKey("descriptions"))
            {
                JsonArray descriptions = rgDescription.GetNamedArray("descriptions");

                for (uint descriptionPosition = 0; descriptionPosition < descriptions.Count; descriptionPosition++)
                {
                    JsonObject description = descriptions.GetObjectAt(descriptionPosition);

                    List<List<String>> TableData = DbModelStrings.TableDataList.Where(tdl => tdl[0][0] == "descriptions").First();

                    descriptionsRgDescriptionsItem currentDescriptionsRgDescriptionsItem = new descriptionsRgDescriptionsItem
                    {
                        pos = (int)descriptionPosition,
                    };

                    descriptionsItem currentDescriptionsItem = new descriptionsItem
                    {
                        type = description.ContainsKey(TableData.ElementAt(2).First()) ? description.GetNamedString(TableData.ElementAt(2).First()) : "",
                        value = description.ContainsKey(TableData.ElementAt(3).First()) ? description.GetNamedString(TableData.ElementAt(3).First()) : "",
                        color = description.ContainsKey(TableData.ElementAt(4).First()) ? description.GetNamedString(TableData.ElementAt(4).First()) : ""
                    };

                    if (db.descriptions.Any(x => x.type == currentDescriptionsItem.type && x.value == currentDescriptionsItem.value && x.color == currentDescriptionsItem.color))
                    {
                        currentDescriptionsRgDescriptionsItem.descriptionsItem = db.descriptions.Where<descriptionsItem>(x => x.type == currentDescriptionsItem.type && x.value == currentDescriptionsItem.value && x.color == currentDescriptionsItem.color).First();
                        descriptionsRgDescriptionsList.Add(currentDescriptionsRgDescriptionsItem);
                    }
                    else if (db.descriptions.Local.Any(x => x.type == currentDescriptionsItem.type && x.value == currentDescriptionsItem.value && x.color == currentDescriptionsItem.color))
                    {
                        currentDescriptionsRgDescriptionsItem.descriptionsItem = db.descriptions.Local.Where<descriptionsItem>(x => x.type == currentDescriptionsItem.type && x.value == currentDescriptionsItem.value && x.color == currentDescriptionsItem.color).First();
                        descriptionsRgDescriptionsList.Add(currentDescriptionsRgDescriptionsItem);
                    }
                    else
                    {
                        currentDescriptionsRgDescriptionsItem.descriptionsItem = currentDescriptionsItem;
                        descriptionsRgDescriptionsList.Add(currentDescriptionsRgDescriptionsItem);
                    }

                    if (description.ContainsKey("app_data"))
                    {
                        JsonObject appData = description.GetNamedObject("app_data");

                        TableData = DbModelStrings.TableDataList.Where(tdl => tdl[0][0] == "app_data").First();

                        app_dataItem currentApp_DataItem = new app_dataItem
                        {
                            def_index = appData.ContainsKey(TableData.ElementAt(2).First()) ? appData.GetNamedString(TableData.ElementAt(2).First()) : "",
                            is_itemset_name = appData.ContainsKey(TableData.ElementAt(3).First()) ? (int)appData.GetNamedNumber(TableData.ElementAt(3).First()) : 0,
                            limited = appData.ContainsKey(TableData.ElementAt(4).First()) ? (int)appData.GetNamedNumber(TableData.ElementAt(4).First()) : 0
                        };

                        if (db.app_data.Any(x => x.def_index == currentApp_DataItem.def_index && x.is_itemset_name == currentApp_DataItem.is_itemset_name && x.limited == currentApp_DataItem.limited))
                        {
                            currentDescriptionsRgDescriptionsItem.descriptionsItem.app_dataItem = db.app_data.Where<app_dataItem>(x => x.def_index == currentApp_DataItem.def_index && x.is_itemset_name == currentApp_DataItem.is_itemset_name && x.limited == currentApp_DataItem.limited).First();
                        }
                        else if (db.app_data.Local.Any(x => x.def_index == currentApp_DataItem.def_index && x.is_itemset_name == currentApp_DataItem.is_itemset_name && x.limited == currentApp_DataItem.limited))
                        {
                            currentDescriptionsRgDescriptionsItem.descriptionsItem.app_dataItem = db.app_data.Local.Where<app_dataItem>(x => x.def_index == currentApp_DataItem.def_index && x.is_itemset_name == currentApp_DataItem.is_itemset_name && x.limited == currentApp_DataItem.limited).First();
                        }
                        else
                        {
                            currentDescriptionsRgDescriptionsItem.descriptionsItem.app_dataItem = currentApp_DataItem;
                        }
                    }
                }
            }
            return descriptionsRgDescriptionsList;
        }

        public static csgoInventoryItem InsertCsgoInventoryItem(InventoryDbContext db, JsonObject csgoInventory, string csgoInventoryId)
        {
            List<List<String>> TableData = DbModelStrings.TableDataList.Where(tdl => tdl[0][0] == "csgoInventory").First();

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
            }
            return currentCsgoInventoryItem;
        }

        private static rgInventoryItem InsertRgInventoryItem(InventoryDbContext db, JsonObject rgInventoryElement, int currentCsgoInventoryItemId)
        {
            List<List<String>> TableData = DbModelStrings.TableDataList.Where(tdl => tdl[0][0] == "rgInventory").First();

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
            return currentRgInventoryItem;
        }

        private static rgDescriptionsItem InsertRgDescriptionsItem(InventoryDbContext db, JsonObject rgDescriptionsElement, int currentCsgoInventoryItemId)
        {
            List<List<String>> TableData = DbModelStrings.TableDataList.Where(tdl => tdl[0][0] == "rgDescriptions").First();

            rgDescriptionsItem currentRgDescriptionsItem = new rgDescriptionsItem
            {
                appid = rgDescriptionsElement.ContainsKey(TableData.ElementAt(2).First()) ? rgDescriptionsElement.GetNamedString(TableData.ElementAt(2).First()) : "",
                classid = rgDescriptionsElement.ContainsKey(TableData.ElementAt(3).First()) ? rgDescriptionsElement.GetNamedString(TableData.ElementAt(3).First()) : "",
                instanceid = rgDescriptionsElement.ContainsKey(TableData.ElementAt(4).First()) ? rgDescriptionsElement.GetNamedString(TableData.ElementAt(4).First()) : "",
                icon_url = rgDescriptionsElement.ContainsKey(TableData.ElementAt(5).First()) ? rgDescriptionsElement.GetNamedString(TableData.ElementAt(5).First()) : "",
                icon_url_large = rgDescriptionsElement.ContainsKey(TableData.ElementAt(6).First()) ? rgDescriptionsElement.GetNamedString(TableData.ElementAt(6).First()) : "",
                icon_drag_url = rgDescriptionsElement.ContainsKey(TableData.ElementAt(7).First()) ? rgDescriptionsElement.GetNamedString(TableData.ElementAt(7).First()) : "",
                name = rgDescriptionsElement.ContainsKey(TableData.ElementAt(8).First()) ? rgDescriptionsElement.GetNamedString(TableData.ElementAt(8).First()) : "",
                market_hast_name = rgDescriptionsElement.ContainsKey(TableData.ElementAt(9).First()) ? rgDescriptionsElement.GetNamedString(TableData.ElementAt(9).First()) : "",
                market_name = rgDescriptionsElement.ContainsKey(TableData.ElementAt(10).First()) ? rgDescriptionsElement.GetNamedString(TableData.ElementAt(10).First()) : "",
                name_color = rgDescriptionsElement.ContainsKey(TableData.ElementAt(11).First()) ? rgDescriptionsElement.GetNamedString(TableData.ElementAt(11).First()) : "",
                background_color = rgDescriptionsElement.ContainsKey(TableData.ElementAt(12).First()) ? rgDescriptionsElement.GetNamedString(TableData.ElementAt(12).First()) : "",
                type = rgDescriptionsElement.ContainsKey(TableData.ElementAt(13).First()) ? rgDescriptionsElement.GetNamedString(TableData.ElementAt(13).First()) : "",
                tradable = rgDescriptionsElement.ContainsKey(TableData.ElementAt(14).First()) ? (int)rgDescriptionsElement.GetNamedNumber(TableData.ElementAt(14).First()) : 0,
                marketable = rgDescriptionsElement.ContainsKey(TableData.ElementAt(15).First()) ? (int)rgDescriptionsElement.GetNamedNumber(TableData.ElementAt(15).First()) : 0,
                commodity = rgDescriptionsElement.ContainsKey(TableData.ElementAt(16).First()) ? (int)rgDescriptionsElement.GetNamedNumber(TableData.ElementAt(16).First()) : 0,
                market_tradable_restriction = rgDescriptionsElement.ContainsKey(TableData.ElementAt(17).First()) ? rgDescriptionsElement.GetNamedString(TableData.ElementAt(17).First()) : "",
                csgoInventoryItemId = currentCsgoInventoryItemId,
                actions = GetActionsList(db, rgDescriptionsElement),
                market_actions = GetMarket_actionsList(db, rgDescriptionsElement),
                tags = GetTagsList(db, rgDescriptionsElement)
            };

            currentRgDescriptionsItem.descriptionsRgDescriptions = GetDescriptionsRgDescriptionsList(db, rgDescriptionsElement, currentRgDescriptionsItem);

            if (!db.rgDescriptions.Any(x => x.classid == currentRgDescriptionsItem.classid && x.instanceid == currentRgDescriptionsItem.instanceid))
            {
                db.rgDescriptions.Add(currentRgDescriptionsItem);
            }
            return currentRgDescriptionsItem;
        }

        internal static void DeleteDb()
        {
            using (InventoryDbContext db = new InventoryDbContext())
            {
                var rgD = db.rgDescriptions.ToList();
                var rgI = db.rgInventory.ToList();
                var rgC = db.rgCurrency.ToList();
                var csgoInv = db.csgoInventory.ToList();
                var des = db.descriptions.ToList();
                var ad = db.app_data.ToList();

                db.rgDescriptions.RemoveRange(rgD);
                db.rgInventory.RemoveRange(rgI);
                db.rgCurrency.RemoveRange(rgC);
                db.csgoInventory.RemoveRange(csgoInv);
                db.descriptions.RemoveRange(des);
                db.app_data.RemoveRange(ad);

                db.SaveChanges();
            }
        }
    }
}