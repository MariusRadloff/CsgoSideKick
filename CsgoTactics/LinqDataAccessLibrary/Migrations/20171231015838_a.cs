using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LinqDataAccessLibrary.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "csgoInventory",
                columns: table => new
                {
                    csgoInventoryItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    gameId = table.Column<string>(nullable: true),
                    more = table.Column<bool>(nullable: false),
                    more_start = table.Column<bool>(nullable: false),
                    success = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_csgoInventory", x => x.csgoInventoryItemId);
                });

            migrationBuilder.CreateTable(
                name: "rgCurrency",
                columns: table => new
                {
                    rgCurrencyItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    csgoInventoryItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rgCurrency", x => x.rgCurrencyItemId);
                    table.ForeignKey(
                        name: "FK_rgCurrency_csgoInventory_csgoInventoryItemId",
                        column: x => x.csgoInventoryItemId,
                        principalTable: "csgoInventory",
                        principalColumn: "csgoInventoryItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rgDescriptions",
                columns: table => new
                {
                    rgDescriptionsItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    appid = table.Column<string>(nullable: true),
                    background_color = table.Column<string>(nullable: true),
                    classid = table.Column<string>(nullable: true),
                    commodity = table.Column<int>(nullable: false),
                    csgoInventoryItemId = table.Column<int>(nullable: false),
                    icon_drag_url = table.Column<string>(nullable: true),
                    icon_url = table.Column<string>(nullable: true),
                    icon_url_large = table.Column<string>(nullable: true),
                    instanceid = table.Column<string>(nullable: true),
                    market_hast_name = table.Column<string>(nullable: true),
                    market_name = table.Column<string>(nullable: true),
                    market_tradable_restriction = table.Column<string>(nullable: true),
                    marketable = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    name_color = table.Column<string>(nullable: true),
                    tradable = table.Column<int>(nullable: false),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rgDescriptions", x => x.rgDescriptionsItemId);
                    table.ForeignKey(
                        name: "FK_rgDescriptions_csgoInventory_csgoInventoryItemId",
                        column: x => x.csgoInventoryItemId,
                        principalTable: "csgoInventory",
                        principalColumn: "csgoInventoryItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rgInventory",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    amount = table.Column<string>(nullable: true),
                    classid = table.Column<string>(nullable: true),
                    csgoInventoryItemId = table.Column<int>(nullable: false),
                    instanceid = table.Column<string>(nullable: true),
                    pos = table.Column<int>(nullable: false),
                    rgInventoryItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rgInventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_rgInventory_csgoInventory_csgoInventoryItemId",
                        column: x => x.csgoInventoryItemId,
                        principalTable: "csgoInventory",
                        principalColumn: "csgoInventoryItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "actions",
                columns: table => new
                {
                    actionsItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    link = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    rgDescriptionsItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actions", x => x.actionsItemId);
                    table.ForeignKey(
                        name: "FK_actions_rgDescriptions_rgDescriptionsItemId",
                        column: x => x.rgDescriptionsItemId,
                        principalTable: "rgDescriptions",
                        principalColumn: "rgDescriptionsItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "descriptions",
                columns: table => new
                {
                    descriptionsItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    color = table.Column<string>(nullable: true),
                    rgDescriptionsId = table.Column<int>(nullable: false),
                    rgDescriptionsItemId = table.Column<int>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_descriptions", x => x.descriptionsItemId);
                    table.ForeignKey(
                        name: "FK_descriptions_rgDescriptions_rgDescriptionsItemId",
                        column: x => x.rgDescriptionsItemId,
                        principalTable: "rgDescriptions",
                        principalColumn: "rgDescriptionsItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "market_actions",
                columns: table => new
                {
                    market_actionsItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    link = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    rgDescriptionsItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_market_actions", x => x.market_actionsItemId);
                    table.ForeignKey(
                        name: "FK_market_actions_rgDescriptions_rgDescriptionsItemId",
                        column: x => x.rgDescriptionsItemId,
                        principalTable: "rgDescriptions",
                        principalColumn: "rgDescriptionsItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    tagsItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(nullable: true),
                    category_name = table.Column<string>(nullable: true),
                    color = table.Column<string>(nullable: true),
                    internal_name = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    rgDescriptionsItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.tagsItemId);
                    table.ForeignKey(
                        name: "FK_tags_rgDescriptions_rgDescriptionsItemId",
                        column: x => x.rgDescriptionsItemId,
                        principalTable: "rgDescriptions",
                        principalColumn: "rgDescriptionsItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "app_data",
                columns: table => new
                {
                    app_dataItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    def_index = table.Column<string>(nullable: true),
                    descriptionsItemId = table.Column<int>(nullable: false),
                    is_itemset_name = table.Column<string>(nullable: true),
                    limited = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_data", x => x.app_dataItemId);
                    table.ForeignKey(
                        name: "FK_app_data_descriptions_descriptionsItemId",
                        column: x => x.descriptionsItemId,
                        principalTable: "descriptions",
                        principalColumn: "descriptionsItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actions_rgDescriptionsItemId",
                table: "actions",
                column: "rgDescriptionsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_app_data_descriptionsItemId",
                table: "app_data",
                column: "descriptionsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_descriptions_rgDescriptionsItemId",
                table: "descriptions",
                column: "rgDescriptionsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_market_actions_rgDescriptionsItemId",
                table: "market_actions",
                column: "rgDescriptionsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_rgCurrency_csgoInventoryItemId",
                table: "rgCurrency",
                column: "csgoInventoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_rgDescriptions_csgoInventoryItemId",
                table: "rgDescriptions",
                column: "csgoInventoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_rgInventory_csgoInventoryItemId",
                table: "rgInventory",
                column: "csgoInventoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tags_rgDescriptionsItemId",
                table: "tags",
                column: "rgDescriptionsItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actions");

            migrationBuilder.DropTable(
                name: "app_data");

            migrationBuilder.DropTable(
                name: "market_actions");

            migrationBuilder.DropTable(
                name: "rgCurrency");

            migrationBuilder.DropTable(
                name: "rgInventory");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "descriptions");

            migrationBuilder.DropTable(
                name: "rgDescriptions");

            migrationBuilder.DropTable(
                name: "csgoInventory");
        }
    }
}
