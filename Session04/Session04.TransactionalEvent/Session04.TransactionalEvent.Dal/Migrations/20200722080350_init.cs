using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Session04.TransactionalEvent.Dal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OutBoxEvents",
                columns: table => new
                {
                    OutBoxEventId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreamName = table.Column<string>(nullable: true),
                    StreamId = table.Column<string>(nullable: true),
                    EventType = table.Column<string>(nullable: true),
                    EventData = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutBoxEvents", x => x.OutBoxEventId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    IsMale = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutBoxEvents");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
