using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Sistema.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "Email",
            //    table: "Usuario",
            //    maxLength: 256,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 100,
            //    oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "Email",
            //    table: "Usuario",
            //    maxLength: 100,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 256,
            //    oldNullable: true);
        }
    }
}
