﻿// <auto-generated />
using DbModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace DbModel.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    partial class InventoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("DbModel.actionsItem", b =>
                {
                    b.Property<int>("actionsItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("link");

                    b.Property<string>("name");

                    b.Property<int>("rgDescriptionsItemId");

                    b.HasKey("actionsItemId");

                    b.HasIndex("rgDescriptionsItemId");

                    b.ToTable("actions");
                });

            modelBuilder.Entity("DbModel.app_dataItem", b =>
                {
                    b.Property<int>("app_dataItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("def_index");

                    b.Property<int>("is_itemset_name");

                    b.Property<long>("limited");

                    b.HasKey("app_dataItemId");

                    b.ToTable("app_data");
                });

            modelBuilder.Entity("DbModel.csgoInventoryItem", b =>
                {
                    b.Property<int>("csgoInventoryItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("gameId");

                    b.Property<bool>("more");

                    b.Property<bool>("more_start");

                    b.Property<bool?>("success");

                    b.HasKey("csgoInventoryItemId");

                    b.ToTable("csgoInventory");
                });

            modelBuilder.Entity("DbModel.descriptionsItem", b =>
                {
                    b.Property<int>("descriptionsItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("app_dataItemId");

                    b.Property<string>("color");

                    b.Property<string>("type");

                    b.Property<string>("value");

                    b.HasKey("descriptionsItemId");

                    b.HasIndex("app_dataItemId");

                    b.ToTable("descriptions");
                });

            modelBuilder.Entity("DbModel.descriptionsRgDescriptionsItem", b =>
                {
                    b.Property<int>("descriptionsRgDescriptionsId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("descriptionsItemId");

                    b.Property<int>("pos");

                    b.Property<int>("rgDescriptionsItemId");

                    b.HasKey("descriptionsRgDescriptionsId");

                    b.HasIndex("descriptionsItemId");

                    b.HasIndex("rgDescriptionsItemId");

                    b.ToTable("descriptionsRgDescriptionsItem");
                });

            modelBuilder.Entity("DbModel.market_actionsItem", b =>
                {
                    b.Property<int>("market_actionsItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("link");

                    b.Property<string>("name");

                    b.Property<int>("rgDescriptionsItemId");

                    b.HasKey("market_actionsItemId");

                    b.HasIndex("rgDescriptionsItemId");

                    b.ToTable("market_actions");
                });

            modelBuilder.Entity("DbModel.rgCurrencyItem", b =>
                {
                    b.Property<int>("rgCurrencyItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("csgoInventoryItemId");

                    b.HasKey("rgCurrencyItemId");

                    b.HasIndex("csgoInventoryItemId");

                    b.ToTable("rgCurrency");
                });

            modelBuilder.Entity("DbModel.rgDescriptionsItem", b =>
                {
                    b.Property<int>("rgDescriptionsItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("appid");

                    b.Property<string>("background_color");

                    b.Property<string>("classid");

                    b.Property<int>("commodity");

                    b.Property<int>("csgoInventoryItemId");

                    b.Property<string>("icon_drag_url");

                    b.Property<string>("icon_url");

                    b.Property<string>("icon_url_large");

                    b.Property<string>("instanceid");

                    b.Property<string>("market_hast_name");

                    b.Property<string>("market_name");

                    b.Property<string>("market_tradable_restriction");

                    b.Property<int>("marketable");

                    b.Property<string>("name");

                    b.Property<string>("name_color");

                    b.Property<int>("tradable");

                    b.Property<string>("type");

                    b.HasKey("rgDescriptionsItemId");

                    b.HasIndex("csgoInventoryItemId");

                    b.ToTable("rgDescriptions");
                });

            modelBuilder.Entity("DbModel.rgInventoryItem", b =>
                {
                    b.Property<int>("rgInventoryItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("amount");

                    b.Property<string>("classid");

                    b.Property<int>("csgoInventoryItemId");

                    b.Property<string>("id");

                    b.Property<string>("instanceid");

                    b.Property<int>("pos");

                    b.HasKey("rgInventoryItemId");

                    b.HasIndex("csgoInventoryItemId");

                    b.ToTable("rgInventory");
                });

            modelBuilder.Entity("DbModel.tagsItem", b =>
                {
                    b.Property<int>("tagsItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("category");

                    b.Property<string>("category_name");

                    b.Property<string>("color");

                    b.Property<string>("internal_name");

                    b.Property<string>("name");

                    b.Property<int>("rgDescriptionsItemId");

                    b.HasKey("tagsItemId");

                    b.HasIndex("rgDescriptionsItemId");

                    b.ToTable("tags");
                });

            modelBuilder.Entity("DbModel.actionsItem", b =>
                {
                    b.HasOne("DbModel.rgDescriptionsItem", "rgDescriptionsItem")
                        .WithMany("actions")
                        .HasForeignKey("rgDescriptionsItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DbModel.descriptionsItem", b =>
                {
                    b.HasOne("DbModel.app_dataItem", "app_dataItem")
                        .WithMany("descriptions")
                        .HasForeignKey("app_dataItemId");
                });

            modelBuilder.Entity("DbModel.descriptionsRgDescriptionsItem", b =>
                {
                    b.HasOne("DbModel.descriptionsItem", "descriptionsItem")
                        .WithMany("descriptionsRgDescriptions")
                        .HasForeignKey("descriptionsItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DbModel.rgDescriptionsItem", "rgDescriptionsItem")
                        .WithMany("descriptionsRgDescriptions")
                        .HasForeignKey("rgDescriptionsItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DbModel.market_actionsItem", b =>
                {
                    b.HasOne("DbModel.rgDescriptionsItem", "rgDescriptionsItem")
                        .WithMany("market_actions")
                        .HasForeignKey("rgDescriptionsItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DbModel.rgCurrencyItem", b =>
                {
                    b.HasOne("DbModel.csgoInventoryItem", "csgoInventoryItem")
                        .WithMany("rgCurrency")
                        .HasForeignKey("csgoInventoryItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DbModel.rgDescriptionsItem", b =>
                {
                    b.HasOne("DbModel.csgoInventoryItem", "csgoInventoryItem")
                        .WithMany("rgDescriptions")
                        .HasForeignKey("csgoInventoryItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DbModel.rgInventoryItem", b =>
                {
                    b.HasOne("DbModel.csgoInventoryItem", "csgoInventoryItem")
                        .WithMany("rgInventory")
                        .HasForeignKey("csgoInventoryItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DbModel.tagsItem", b =>
                {
                    b.HasOne("DbModel.rgDescriptionsItem", "rgDescriptionsItem")
                        .WithMany("tags")
                        .HasForeignKey("rgDescriptionsItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
