using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DbModel
{
    public static class DbModelStrings
    {
        public static string LinqDbConnectionString
        {
            //get { return "Filename=steamInventory.db"; }
            get { return "Data Source=steamInventoryLinqTestStd.db"; }
        }

        public static string SqlDbConnectionString
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
                        new List<String>{ "steamInventoryItemId",  "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
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
                        new List<String>{ "FOREIGN KEY", "(steamInventoryId)", "REFERENCES", "steamInventory(steamInventoryItemId)" }
                    },

                    new List<List<String>>
                    {
                        new List<String>{ "rgInventory" },
                        new List<String>{ "rgInventoryItemId", "INTEGER", "NOT NULL", "PRIMARY KEY", "AUTOINCREMENT" },
                        new List<String>{ "id", "TEXT", "NOT NULL" },
                        new List<String>{ "classid", "TEXT", "NOT NULL" },
                        new List<String>{ "instanceid", "TEXT", " NOT NULL" },
                        new List<String>{ "amount", "TEXT" },
                        new List<String>{ "pos", "INTEGER" },
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

    public class InventoryDbContext : DbContext
    {
        public DbSet<csgoInventoryItem> csgoInventory { get; set; }
        public DbSet<rgInventoryItem> rgInventory { get; set; }
        public DbSet<rgCurrencyItem> rgCurrency { get; set; }
        public DbSet<rgDescriptionsItem> rgDescriptions { get; set; }
        public DbSet<descriptionsItem> descriptions { get; set; }
        public DbSet<app_dataItem> app_data { get; set; }
        public DbSet<actionsItem> actions { get; set; }
        public DbSet<market_actionsItem> market_actions { get; set; }
        public DbSet<tagsItem> tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(DataAccess.DbConnectionString);
            optionsBuilder.UseSqlite(DbModelStrings.LinqDbConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<csgoInventoryItem>().HasKey(x => x.csgoInventoryItemId);
            //modelBuilder.Entity<csgoInventoryItem>().HasMany(x => x.rgInventory).WithOne(x => x.csgoInventoryItem).HasForeignKey(x => x.rgInventoryItemId);
            //modelBuilder.Entity<csgoInventoryItem>().HasMany(x => x.rgDescriptions).WithOne(x => x.csgoInventoryItem).HasForeignKey(x => x.rgDescriptionsItemId);
            //modelBuilder.Entity<csgoInventoryItem>().HasMany(x => x.rgCurrency).WithOne(x => x.csgoInventoryItem).HasForeignKey(x => x.rgCurrencyItemId);
            //modelBuilder.Entity<csgoInventoryItem>().HasMany(x => x.rgInventory).WithOne(x => x.csgoInventoryItem).HasForeignKey(x => x.rgInventoryItemId);


            modelBuilder.Entity<rgInventoryItem>().HasKey(x => x.rgInventoryItemId);
            modelBuilder.Entity<rgInventoryItem>().HasOne(x => x.csgoInventoryItem).WithMany(x => x.rgInventory).HasForeignKey(x => x.csgoInventoryItemId);

            modelBuilder.Entity<rgCurrencyItem>().HasKey(x => x.rgCurrencyItemId);
            modelBuilder.Entity<rgCurrencyItem>().HasOne(x => x.csgoInventoryItem).WithMany(x => x.rgCurrency).HasForeignKey(x => x.csgoInventoryItemId);

            modelBuilder.Entity<rgDescriptionsItem>().HasKey(x => x.rgDescriptionsItemId);
            modelBuilder.Entity<rgDescriptionsItem>().HasOne(x => x.csgoInventoryItem).WithMany(x => x.rgDescriptions).HasForeignKey(x => x.csgoInventoryItemId);

            modelBuilder.Entity<descriptionsItem>().HasKey(x => x.descriptionsItemId);
            modelBuilder.Entity<descriptionsItem>().HasOne(x => x.rgDescriptionsItem).WithMany(x => x.descriptions);

            modelBuilder.Entity<app_dataItem>().HasKey(x => x.app_dataItemId);
            modelBuilder.Entity<app_dataItem>().HasMany(x => x.descriptions).WithOne(x => x.app_data);

            modelBuilder.Entity<actionsItem>().HasKey(x => x.actionsItemId);
            //modelBuilder.Entity<actionsItem>().Property(x => x.actionsItemId).ValueGeneratedOnAdd();
            modelBuilder.Entity<actionsItem>().HasOne(x => x.rgDescriptionsItem).WithMany(x => x.actions).HasForeignKey(x => x.rgDescriptionsItemId);

            modelBuilder.Entity<market_actionsItem>().HasKey(x => x.market_actionsItemId);
            modelBuilder.Entity<market_actionsItem>().HasOne(x => x.rgDescriptionsItem).WithMany(x => x.market_actions).HasForeignKey(x => x.rgDescriptionsItemId);

            modelBuilder.Entity<tagsItem>().HasKey(x => x.tagsItemId);
            modelBuilder.Entity<tagsItem>().HasOne(x => x.rgDescriptionsItem).WithMany(x => x.tags).HasForeignKey(x => x.rgDescriptionsItemId);
        }
    }

    public class csgoInventoryItem
    {
        public csgoInventoryItem()
        {
            this.rgInventory = new HashSet<rgInventoryItem>();
            this.rgCurrency = new HashSet<rgCurrencyItem>();
            this.rgDescriptions = new HashSet<rgDescriptionsItem>();
        }

        public int csgoInventoryItemId { get; set; }
        public string gameId { get; set; }
        public bool? success { get; set; }
        public virtual ICollection<rgInventoryItem> rgInventory { get; set; }
        public virtual ICollection<rgCurrencyItem> rgCurrency { get; set; }
        public virtual ICollection<rgDescriptionsItem> rgDescriptions { get; set; }
        public bool more { get; set; }
        public bool more_start { get; set; }
    }

    public class rgInventoryItem
    {
        public int rgInventoryItemId { get; set; }
        public string id { get; set; }
        public string classid { get; set; }
        public string instanceid { get; set; }
        public string amount { get; set; }
        public int pos { get; set; }

        //[ForeignKey("csgoInventoryItemId")]
        public virtual int csgoInventoryItemId { get; set; }
        public virtual csgoInventoryItem csgoInventoryItem { get; set; }
    }

    public class rgCurrencyItem
    {
        public int rgCurrencyItemId { get; set; }

        //[ForeignKey("csgoInventoryItemId")]
        public virtual int csgoInventoryItemId { get; set; }
        public virtual csgoInventoryItem csgoInventoryItem { get; set; }
    }

    public class rgDescriptionsItem
    {
        public rgDescriptionsItem()
        {
            this.descriptions = new HashSet<descriptionsItem>();
            this.actions = new HashSet<actionsItem>();
            this.market_actions = new HashSet<market_actionsItem>();
            this.tags = new HashSet<tagsItem>();
        }

        public int rgDescriptionsItemId { get; set; }
        public string appid { get; set; }
        public string classid { get; set; }
        public string instanceid { get; set; }
        public string icon_url { get; set; }
        public string icon_url_large { get; set; }
        public string icon_drag_url { get; set; }
        public string name { get; set; }
        public string market_hast_name { get; set; }
        public string market_name { get; set; }
        public string name_color { get; set; }
        public string background_color { get; set; }
        public string type { get; set; }
        public int tradable { get; set; }
        public int marketable { get; set; }
        public int commodity { get; set; }
        public string market_tradable_restriction { get; set; }

        public virtual ICollection<descriptionsItem> descriptions { get; set; }
        public virtual ICollection<actionsItem> actions { get; set; }
        public virtual ICollection<market_actionsItem> market_actions { get; set; }
        public virtual ICollection<tagsItem> tags { get; set; }

        //[ForeignKey("csgoInventoryItemId")]
        public int csgoInventoryItemId { get; set; }
        public virtual csgoInventoryItem csgoInventoryItem { get; set; }

    }

    public class descriptionsItem
    {
        public descriptionsItem()
        {
        //    this.rgDescriptions = new HashSet<rgDescriptionsItem>();
        }


        public int descriptionsItemId { get; set; }
        public string type { get; set; }
        public string value { get; set; }
        public string color { get; set; }

        public virtual app_dataItem app_data { get; set; }

        //public virtual ICollection<rgDescriptionsItem> rgDescriptions { get; set; }

        //[ForeignKey("rgDescriptionsId")]
        public virtual int rgDescriptionsId { get; set; }
        public virtual rgDescriptionsItem rgDescriptionsItem { get; set; }
    }

    public class app_dataItem
    {
        public int app_dataItemId { get; set; }
        public string def_index { get; set; }
        public int is_itemset_name { get; set; }
        public long limited { get; set; }

        public virtual ICollection<descriptionsItem> descriptions { get; set; }

        //[ForeignKey("descriptionsItemId")]
        //public virtual int descriptionsItemId { get; set; }
        //public virtual descriptionsItem descriptionsItem { get; set; }
    }

    public class actionsItem
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int actionsItemId { get; set; }
        public string name { get; set; }
        public string link { get; set; }

        //[ForeignKey("rgDescriptionsItemId")]
        public virtual int rgDescriptionsItemId { get; set; }
        public virtual rgDescriptionsItem rgDescriptionsItem { get; set; }
    }

    public class market_actionsItem
    {
        public int market_actionsItemId { get; set; }
        public string name { get; set; }
        public string link { get; set; }

        //[ForeignKey("rgDescriptionsItemId")]
        public int rgDescriptionsItemId { get; set; }
        public rgDescriptionsItem rgDescriptionsItem { get; set; }
    }

    public class tagsItem
    {
        public int tagsItemId { get; set; }
        public string internal_name { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string color { get; set; }
        public string category_name { get; set; }

        //[ForeignKey("rgDescriptionsItemId")]
        public int rgDescriptionsItemId { get; set; }
        public rgDescriptionsItem rgDescriptionsItem { get; set; }
    }
}

