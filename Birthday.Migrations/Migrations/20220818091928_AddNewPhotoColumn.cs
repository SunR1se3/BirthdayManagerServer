﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthday.Migrations.Migrations
{
    public partial class AddNewPhotoColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "User",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "User");
        }
    }
}
