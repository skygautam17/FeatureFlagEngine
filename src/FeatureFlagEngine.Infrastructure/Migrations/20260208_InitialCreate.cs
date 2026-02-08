
using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "FeatureFlags",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Key = table.Column<string>(nullable: false),
                Description = table.Column<string>(nullable: true),
                Enabled = table.Column<bool>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FeatureFlags", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "FeatureFlags");
    }
}
