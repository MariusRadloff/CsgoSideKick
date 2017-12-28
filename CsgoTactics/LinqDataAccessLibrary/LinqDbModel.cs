using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDataAccessLibrary
{
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
            optionsBuilder.UseSqlite("Data Source=steamInventoryLinqTest.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<csgoInventoryItem>().HasKey(x => x.csgoInventoryItemId);
            //modelBuilder.Entity<csgoInventoryItem>().HasMany(x => x.rgInventory).WithOne(x => x.csgoInventoryItem).HasForeignKey(x => x.rgInventoryItemId);
            //modelBuilder.Entity<csgoInventoryItem>().HasMany(x => x.rgDescriptions).WithOne(x => x.csgoInventoryItem).HasForeignKey(x => x.rgDescriptionsItemId);
            //modelBuilder.Entity<csgoInventoryItem>().HasMany(x => x.rgCurrency).WithOne(x => x.csgoInventoryItem).HasForeignKey(x => x.rgCurrencyItemId);
            //modelBuilder.Entity<csgoInventoryItem>().HasMany(x => x.rgInventory).WithOne(x => x.csgoInventoryItem).HasForeignKey(x => x.rgInventoryItemId);


            //modelBuilder.Entity<rgInventoryItem>().HasKey(x => x.rgInventoryItemId);
            //modelBuilder.Entity<rgInventoryItem>().HasOne(x => x.csgoInventoryItem).WithMany(x => x.rgInventory).HasForeignKey(x => x.csgoInventoryItemId);

            //modelBuilder.Entity<rgCurrencyItem>().HasKey(x => x.rgCurrencyItemId);

            //modelBuilder.Entity<rgDescriptionsItem>().HasKey(x => x.rgDescriptionsItemId);
            modelBuilder.Entity<rgDescriptionsItem>().HasMany(x => x.descriptions).WithOne(x => x.rgDescriptionsItem).HasForeignKey(x => x.descriptionsItemId);
            //modelBuilder.Entity<rgDescriptionsItem>().HasMany(x => x.actions).WithOne(x => x.rgDescriptionsItem).HasForeignKey(x => x.actionsItemId);
            //modelBuilder.Entity<rgDescriptionsItem>().HasMany(x => x.market_actions).WithOne(x => x.rgDescriptionsItem).HasForeignKey(x => x.market_actionsItemId);
            //modelBuilder.Entity<rgDescriptionsItem>().HasMany(x => x.tags).WithOne(x => x.rgDescriptionsItem).HasForeignKey(x => x.tagsItemId);


            //modelBuilder.Entity<descriptionsItem>().HasKey(x => x.descriptionsItemId);
            //modelBuilder.Entity<descriptionsItem>().HasOne(x => x.app_data).WithOne(x => x.descriptionsItem);

            //modelBuilder.Entity<actionsItem>().HasKey(x => x.actionsItemId);
            //modelBuilder.Entity<actionsItem>().Property(x => x.actionsItemId).ValueGeneratedOnAdd();
            //modelBuilder.Entity<market_actionsItem>().HasKey(x => x.market_actionsItemId);
            //modelBuilder.Entity<tagsItem>().HasKey(x => x.tagsItemId);
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
        public bool success { get; set; }
        public virtual ICollection<rgInventoryItem> rgInventory { get; set; }
        public virtual ICollection<rgCurrencyItem> rgCurrency { get; set; }
        public virtual ICollection<rgDescriptionsItem> rgDescriptions { get; set; }
        public bool more { get; set; }
        public bool more_start { get; set; }
    }

    public class rgInventoryItem
    {
        public int rgInventoryItemId { get; set; }
        public int id { get; set; }
        public int classid { get; set; }
        public string instanceid { get; set; }
        public string amount { get; set; }
        public string pos { get; set; }

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
        public string background_coloor { get; set; }
        public string type { get; set; }
        public bool tradable { get; set; }
        public bool marketable { get; set; }
        public bool commodity { get; set; }
        public string market_tradable_restriction { get; set; }

        public virtual ICollection<descriptionsItem> descriptions { get; set; }
        public virtual ICollection<actionsItem> actions { get; set; }
        public virtual ICollection<market_actionsItem> market_actions { get; set; }
        public virtual ICollection<tagsItem> tags { get; set; }

        //[ForeignKey("csgoInventoryItemId")]
        //public int csgoInventoryItemId { get; set; }
        public virtual csgoInventoryItem csgoInventoryItem { get; set; }

    }

    public class descriptionsItem
    {
        public descriptionsItem()
        {
            this.rgDescriptions = new HashSet<rgDescriptionsItem>();
        }


        public int descriptionsItemId { get; set; }
        public string type { get; set; }
        public string value { get; set; }
        public string color { get; set; }

        public virtual app_dataItem app_data { get; set; }

        public virtual ICollection<rgDescriptionsItem> rgDescriptions { get; set; }

        //[ForeignKey("rgDescriptionsId")]
        public virtual int rgDescriptionsId { get; set; }
        public virtual rgDescriptionsItem rgDescriptionsItem { get; set; }
    }

    public class app_dataItem
    {
        public int app_dataItemId { get; set; }
        public string def_index { get; set; }
        public string is_itemset_name { get; set; }
        public long limited { get; set; }

        //[ForeignKey("descriptionsItemId")]
        //public virtual int descriptionsItemId { get; set; }
        public virtual descriptionsItem descriptionsItem { get; set; }
    }

    public class actionsItem
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int actionsItemId { get; set; }
        public string name { get; set; }
        public string link { get; set; }

        //[ForeignKey("rgDescriptionsItemId")]
        //public virtual int rgDescriptionsItemId { get; set; }
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

