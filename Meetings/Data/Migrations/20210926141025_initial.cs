using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meetings.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meeting_Types",
                columns: table => new
                {
                    Meeting_Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting_Types", x => x.Meeting_Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Meeting_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meeting_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meeting_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Minutes = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Meeting_Id);
                });

            migrationBuilder.CreateTable(
                name: "Meeting_Items",
                columns: table => new
                {
                    Item_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Due_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person_Responsible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meeting_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting_Items", x => x.Item_Id);
                    table.ForeignKey(
                        name: "FK_Meeting_Items_Meetings_Meeting_Id",
                        column: x => x.Meeting_Id,
                        principalTable: "Meetings",
                        principalColumn: "Meeting_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Items_Meeting_Id",
                table: "Meeting_Items",
                column: "Meeting_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meeting_Items");

            migrationBuilder.DropTable(
                name: "Meeting_Types");

            migrationBuilder.DropTable(
                name: "Meetings");
        }
    }
}
