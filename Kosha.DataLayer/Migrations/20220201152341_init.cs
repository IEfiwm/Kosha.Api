using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kosha.DataLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AuthenticationCode",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(maxLength: 450, nullable: false),
            //        Code = table.Column<string>(maxLength: 256, nullable: false),
            //        CreateDate = table.Column<DateTime>(nullable: true),
            //        ExpireDate = table.Column<DateTime>(nullable: true),
            //        IsUsed = table.Column<bool>(nullable: false),
            //        IsDeleted = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AuthenticationCode", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LoginLog",
            //    columns: table => new
            //    {
            //        UserName = table.Column<string>(maxLength: 50, nullable: true),
            //        Login_At = table.Column<string>(maxLength: 50, nullable: true),
            //        Mac_Address = table.Column<string>(maxLength: 1000, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PortalSetting",
            //    columns: table => new
            //    {
            //        PortalSettingId = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PhoneNumberSupport = table.Column<string>(maxLength: 20, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PortalSetting", x => x.PortalSettingId);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AuthenticationCode");

            //migrationBuilder.DropTable(
            //    name: "LoginLog");

            //migrationBuilder.DropTable(
            //    name: "PortalSetting");
        }
    }
}
